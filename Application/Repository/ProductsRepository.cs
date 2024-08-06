using Database;
using Database.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Repository
{
    public class ProductsRepository
    {
        private readonly ApplicationContext _dbContext;

        public ProductsRepository(ApplicationContext dbContext) { 
         
            _dbContext = dbContext;
        
        }

        public async Task AddAsync(Product product)
        {
            await _dbContext.Products.AddAsync(product);
            await _dbContext.SaveChangesAsync();
        }
        public async Task UpdateAsync(Product product)
        {
             _dbContext.Entry(product).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }
        public async Task DeleteAsync(Product product)
        {
            _dbContext.Set<Product>().Remove(product);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<Product>> GetAllAsync() 
        { 
            return await _dbContext.Set<Product>().ToListAsync();
        }

        public async Task<Product> GetByIdAsync(int id)
        {
            return await _dbContext.Set<Product>().FindAsync(id);
        }

    }
}
