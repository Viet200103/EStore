using EStore.Data.Database;
using EStore.Data.Models;
using EStore.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace EStore.Business.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly EStoreDbContext _dbContext;
        public ProductRepository(EStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        
        public async Task<bool> AddProduct(Product product)
        {
            await _dbContext.Products.AddAsync(product);
            var result = await _dbContext.SaveChangesAsync();
            return result > 0;
        }

        public async Task<bool> DeleteProductAsync(int id)
        {
            var product = await _dbContext.Products.FindAsync(id);
            if (product == null)
            {
                return false;
            }
            _dbContext.Products.Remove(product);
            var result = await _dbContext.SaveChangesAsync();
            return result > 0;
        }
        
        public async Task<(IEnumerable<Product> products, int totalPages)> GetProducts(int pageNumber, int pageSize, string? search = null, string? condition = null)
        {
            if (pageNumber < 1)  pageNumber = 1;

            IQueryable<Product> query = _dbContext
                .Products
                .TagWith("Get Products")
                .AsNoTracking();
            
            if (!string.IsNullOrEmpty(search))
            {
                if (condition == "ProductName")
                {
                    query = query.Where(p => EF.Functions.Like(p.ProductName, $"%{search}%"));
                }
                else if (condition == "UnitPrice" && decimal.TryParse(search, out var price))
                {
                    query = query.Where(p => p.UnitPrice == price);
                }
            }
            
            int count = await query.CountAsync();
            var totalPages = count == 0  ? 1 : (int) Math.Ceiling((double) count / pageSize);

            IEnumerable<Product> products = await query
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return (products, totalPages);
        }

        public async Task<Product?> GetProductById(int id)
        {
            var product = await _dbContext.Products
                .AsNoTracking()
                .Include(p => p.Category)
                .FirstOrDefaultAsync(x => x.ProductId == id);
            return product;
        }

        public async Task<bool> UpdateProductAsync(Product product)
        {
            _dbContext.Products.Attach(product);
            _dbContext.Entry(product).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}
