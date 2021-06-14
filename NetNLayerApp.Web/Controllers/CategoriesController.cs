using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NetNLayerApp.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetNLayerApp.Web.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;

        public CategoriesController(ICategoryService categoryService, IMapper mapper)
        {
            _categoryService = categoryService;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
