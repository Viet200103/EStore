using EStore.Data.Database;
using EStore.Data.Models;
using EStore.Data.Repositories;
using Microsoft.EntityFrameworkCore;

namespace EStore.Business.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly EStoreDbContext _context;

        public OrderRepository(EStoreDbContext context)
        {
            _context = context;
        }

        public async Task CreateOrderAsync(Order order)
        {
            try
            {
                _context.Orders.Add(order);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex) { 
                throw new Exception(ex.InnerException.Message);
            }
            }

        public async Task DeleteOrderAsync(Order order)
        {
            _context.Orders.Remove(order);
            await _context.SaveChangesAsync();
        }

        public async Task<IList<Order>> GetAllOrdersAsync()
        {
            return await _context.Orders
            .Include(o => o.Member)
            .Include(o => o.OrderDetails)
            .ToListAsync();
        }

        public async Task<Order?> GetOrderByIdAsync(int id)
        {
            return await _context.Orders
            .Include(o => o.Member)
            .Include(o => o.OrderDetails)
            .FirstOrDefaultAsync(o => o.OrderId == id);
        }

        public async Task<IList<Order>> GetOrdersByMemberIdAsync(int memberId)
        {
            return await _context.Orders
                .Include(o => o.Member)
                .Include(o => o.OrderDetails)
                .Where(o => o.MemberId == memberId)
                .ToListAsync();
        }

        public async Task UpdateOrderAsync(Order order)
        {
            _context.Orders.Update(order);
            await _context.SaveChangesAsync();
        }
    }
}
