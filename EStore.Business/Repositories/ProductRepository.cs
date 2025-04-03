using EStore.Business.DTOs;
using EStore.Data.Database;
using EStore.Data.Models;
using EStore.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EStore.Business.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly EStoreDbContext _context;

        public ProductRepository(EStoreDbContext context)
        {
            _context = context;
        }

        public async Task<IList<Product>> GetAvailableProductsAsync()
        {
            return await _context.Products
        .Where(p => p.UnitslnStock > 0)
        .ToListAsync();
        }

        public async Task<Product?> GetProductByIdAsync(int id)
        {
            return await _context.Products.FindAsync(id);
        }
    }
}
