using NetNLayerApp.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetNLayerApp.Core.Services
{
    interface ICategoryService : IService<Category>
    {
        Task<Category> GetWithProductsByIdAsync(int categoryId);

    }
}
