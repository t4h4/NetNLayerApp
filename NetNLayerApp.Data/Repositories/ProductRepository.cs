using Microsoft.EntityFrameworkCore;
using NetNLayerApp.Core.Models;
using NetNLayerApp.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetNLayerApp.Data.Repositories
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        private AppDbContext _appDbContext { get => _context as AppDbContext; } //AppDbContext'e cast edildi.

        public ProductRepository(AppDbContext context) : base(context) // get AppDbContext context send to base context (Repository) --- miras alinan sinifta const. oldugundan const. olmak zorunda.
        {
        }
        public async Task<Product> GetWithCategoryByIdAsync(int productId)
        {
            return await _appDbContext.Products.Include(x => x.Category).SingleOrDefaultAsync(x => x.Id == productId); //Include(x => x.Category) product donerken, ilgili category'ide ekle. --- x.Id'si, productId'ye esit olan ilk kaydi bul.
        }
    }
}
