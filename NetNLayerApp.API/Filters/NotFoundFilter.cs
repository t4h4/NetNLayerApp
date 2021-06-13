using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using NetNLayerApp.API.DTOs;
using NetNLayerApp.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetNLayerApp.API.Filters
{
    public class NotFoundFilter : ActionFilterAttribute
    {
        private readonly IProductService _productService;

        public NotFoundFilter(IProductService productService)
        {
            _productService = productService;
        }

        public async override Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            int id = (int)context.ActionArguments.Values.FirstOrDefault(); //public async Task<IActionResult> GetById or Remove(int id) parametre olarak gonderilen id degerini aliyor. FirstOrDefault() ise value degeri bir tane olmasi durumundandir. value yerine key kullansaydik, parametre olarak gonderilen ismi alirdik, degeri degil. 

            var product = await _productService.GetByIdAsync(id);

            if (product != null)
            {
                await next();
            }
            else
            {
                ErrorDto errorDto = new ErrorDto();

                errorDto.Status = 404; //not found

                errorDto.Errors.Add($"Id degeri {id} olan ürün veritabanında bulunamadı.");

                context.Result = new NotFoundObjectResult(errorDto);
            }
        }
    }
}
