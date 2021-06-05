using NetNLayerApp.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetNLayerApp.Core.Repositories
{
    interface IProductRepository : IRepository<Product>
    {
        Task<Product> GetWithCategoryByIdAsync(int productId); //producId'ye gore urunun kategorisi. 
    }
}
