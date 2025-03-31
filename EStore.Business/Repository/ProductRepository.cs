using EStore.Data.Database;
using EStore.Data.Models;
using EStore.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EStore.Business.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly EStoreContext _dbContext;
        private ILogger<ProductRepository> _logger;
        public ProductRepository(EStoreContext dbContext, ILogger<ProductRepository> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }
        public async Task<bool> AddProductAsync(Product product)
        {
            try
            {
                await _dbContext.Products.AddAsync(product);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError("Error when adding product", ex);
                throw;
            }
        }

        public async Task<bool> DeleteProductAsync(int id)
        {
            try
            {
                var product = await _dbContext.Products.FindAsync(id);
                if (product == null)
                {
                    _logger.LogWarning($"Product with id {id} is not found.");
                    return false;
                }
                _dbContext.Products.Remove(product);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError("Error when deleting product", ex);
                throw;
            }
        }

        public async Task<List<Product>> GetAllProductAsync()
        {
            try
            {
                return await _dbContext.Products.Include(p => p.Category).ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.InnerException.Message);
            }

        }

        public async Task<Product> GetProductByIdAsync(int id)
        {
            try
            {
                return await _dbContext.Products.Include(p => p.Category).FirstOrDefaultAsync(x => x.ProductId == id);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error when retrieving product with {id}");
                throw;
            }
        }

        public async Task<Product> GetProductForUpdateAsync(int id)
        {
            return await _dbContext.Products.AsNoTracking().Include(p => p.Category).FirstOrDefaultAsync(x => x.ProductId == id);

        }

        public async Task<bool> UpdateProductAsync(Product product)
        {
            try
            {
                _dbContext.ChangeTracker.Clear();
                var existingProduct =  await _dbContext.Products.FirstOrDefaultAsync(x => x.ProductId == product.ProductId);
                if (existingProduct == null)
                {
                    _logger.LogWarning($"Product with id {product.ProductId} is not found.");
                    return false;
                }
                existingProduct.ProductName = product.ProductName;
                existingProduct.CategoryId = product.CategoryId;
                existingProduct.Weight = product.Weight;
                existingProduct.UnitPrice = product.UnitPrice;
                existingProduct.UnitslnStock = product.UnitslnStock;
                existingProduct.Category = product.Category;
                await _dbContext.SaveChangesAsync();
                return true; ;
            }
            catch (Exception ex)
            {
                _logger.LogError("Error when updating the produtc", ex);
                throw;
            }
        }

        
    }
}
