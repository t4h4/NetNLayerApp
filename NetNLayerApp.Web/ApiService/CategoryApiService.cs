using NetNLayerApp.Web.DTOs;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace NetNLayerApp.Web.ApiService
{
    public class CategoryApiService
    {
        private readonly HttpClient _httpClient;

        public CategoryApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<CategoryDto>> GetAllAsync()
        {
            IEnumerable<CategoryDto> categoryDtos;

            var response = await _httpClient.GetAsync("categories"); //https://localhost:44303/api/categories

            if (response.IsSuccessStatusCode) //200
            {
                categoryDtos = JsonConvert.DeserializeObject<IEnumerable<CategoryDto>>(await response.Content.ReadAsStringAsync());
            }
            else
            {
                categoryDtos = null;
            }

            return categoryDtos;
        }

        public async Task<CategoryDto> AddAsync(CategoryDto categoryDto)
        {
            var stringContent = new StringContent(JsonConvert.SerializeObject(categoryDto), Encoding.UTF8, "application/json"); //nesneyi json'a donusturme

            var response = await _httpClient.PostAsync("categories", stringContent); //https://localhost:44303/api/categories

            if (response.IsSuccessStatusCode)
            {
                categoryDto = JsonConvert.DeserializeObject<CategoryDto>(await response.Content.ReadAsStringAsync()); //json datayi class'a donusturme

                return categoryDto;
            }
            else
            {
                //logging
                return null;
            }
        }
    }
}
