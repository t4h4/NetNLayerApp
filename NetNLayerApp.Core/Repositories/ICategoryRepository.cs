using NetNLayerApp.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetNLayerApp.Core.Repositories
{
    interface ICategoryRepository : IRepository<Category> //IRepository'ye generic olarak Category veriliyor
    {
        Task<Category> GetWithProductsByIdAsync(int categoryId); //category'e bagli urunlerin donmesi beklenmekte 
    }
}
