using Microsoft.EntityFrameworkCore;
using NetNLayerApp.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace NetNLayerApp.Data.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly DbContext _context; //miras alinan yerde kullanildigi icin protected
        private readonly DbSet<TEntity> _dbSet; //bu sinifta kullanildigi icin private

        public Repository(AppDbContext context)
        {
            _context = context; //_context ile veritabanina erisim saglanir. 
            _dbSet = context.Set<TEntity>(); //_dbSet'i gelen TEntity'deki dbset'e gore ayarla. _dbSet ile tablolara erisim saglanir. TEntity product veya category olabilir. 
        }

        public async Task AddAsync(TEntity entity)
        {
            await _dbSet.AddAsync(entity);
        }

        public async Task AddRangeAsync(IEnumerable<TEntity> entities)
        {
            await _dbSet.AddRangeAsync(entities);
        }
        //product.where(x=>x.name="kalem")
        public async Task<IEnumerable<TEntity>> Where(Expression<Func<TEntity, bool>> predicate)
        {
            return await _dbSet.Where(predicate).ToListAsync();
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<TEntity> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public void Remove(TEntity entity)
        {
            _dbSet.Remove(entity);
        }

        public void RemoveRange(IEnumerable<TEntity> entities)
        {
            _dbSet.RemoveRange(entities);
        }

        public async Task<TEntity> SingleOrDefaultAsync(Expression<Func<TEntity, bool>> predicate) //predicate delegesi; bir entity alan, geriye de bool donen method ver  
        {
            return await _dbSet.SingleOrDefaultAsync(predicate); //ilk gelen kaydi getir yoksa default olani getir. 
        }

        public TEntity Update(TEntity entity)
        {
            _context.Entry(entity).State = EntityState.Modified; //tek bir alan degisse dahi tek bir alani degistirecek sorgu yerine butun alanlari degistiren sorguyu database'e gonderir

            return entity;
        }
    }
}
