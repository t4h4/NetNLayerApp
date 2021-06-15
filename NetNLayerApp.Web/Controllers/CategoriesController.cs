using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NetNLayerApp.Core.Models;
using NetNLayerApp.Core.Services;
using NetNLayerApp.Web.ApiService;
using NetNLayerApp.Web.DTOs;
using NetNLayerApp.Web.Filters;
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
        private readonly CategoryApiService _categoryApiService;

        public CategoriesController(ICategoryService categoryService, IMapper mapper, CategoryApiService categoryApiService)
        {
            _categoryService = categoryService;
            _mapper = mapper;
            _categoryApiService = categoryApiService;
        }

        public async Task<IActionResult> Index()
        {
            //var categories = await _categoryService.GetAllAsync();
            var categories = await _categoryApiService.GetAllAsync();

            return View(_mapper.Map<IEnumerable<CategoryDto>>(categories));
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CategoryDto categoryDto)
        {
            //await _categoryService.AddAsync(_mapper.Map<Category>(categoryDto));
            await _categoryApiService.AddAsync(categoryDto);

            return RedirectToAction("Index");
        }

        //update/5
        public async Task<IActionResult> Update(int id)
        {
            //var category = await _categoryService.GetByIdAsync(id);
            var category = await _categoryApiService.GetByIdAsync(id);

            return View(_mapper.Map<CategoryDto>(category));
        }

        [HttpPost]
        //public IActionResult Update(CategoryDto categoryDto)
        public async Task<IActionResult> Update(CategoryDto categoryDto)
        {
            //_categoryService.Update(_mapper.Map<Category>(categoryDto));
            await _categoryApiService.Update(categoryDto);

            return RedirectToAction("Index");
        }

        [ServiceFilter(typeof(NotFoundFilter))]
        //public IActionResult Delete(int id)
        public async Task<IActionResult> Delete(int id)
        {
            //var category = _categoryService.GetByIdAsync(id).Result;

            //_categoryService.Remove(category);

            await _categoryApiService.Remove(id);

            return RedirectToAction("Index");
        }
    }
}
