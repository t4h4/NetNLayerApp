using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using NetNLayerApp.Web.DTOs;
using NetNLayerApp.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetNLayerApp.Web.Filters
{
    public class NotFoundFilter : ActionFilterAttribute
    {
        private readonly ICategoryService _categoryService;

        public NotFoundFilter(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public async override Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            int id = (int)context.ActionArguments.Values.FirstOrDefault(); //public async Task<IActionResult> GetById or Remove(int id) parametre olarak gonderilen id degerini aliyor. FirstOrDefault() ise value degeri bir tane olmasi durumundandir. value yerine key kullansaydik, parametre olarak gonderilen ismi alirdik, degeri degil. 

            var product = await _categoryService.GetByIdAsync(id);

            if (product != null)
            {
                await next();
            }
            else
            {
                ErrorDto errorDto = new ErrorDto();

                //errorDto.Status = 404; //not found

                errorDto.Errors.Add($"Id degeri {id} olan kategori veritabanında bulunamadı.");

                //context.Result = new NotFoundObjectResult(errorDto);
                context.Result = new RedirectToActionResult("Error", "Home", errorDto); //errorDto hata sayfasina gonderilen dto nesnesi
            }
        }
    }
}
