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
    public class OrderDetailRepository : IOrderDetailRepository
    {
        private readonly EStoreContext _context;
        public OrderDetailRepository(EStoreContext context)
        {
            _context = context;
        }


        public async Task<OrderDetail> CreateOrderDetailAsync(OrderDetail orderDetail)
        {
            _context.OrderDetails.Add(orderDetail);
            await _context.SaveChangesAsync();
            return orderDetail;
        }

        public async Task<bool> DeleteOrderDetailAsync(int orderDetailId)
        {
            _context.OrderDetails.Remove(_context.OrderDetails.FirstOrDefault(o => o.OrderDetailId == orderDetailId) ?? throw new InvalidOperationException());
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<OrderDetail>> GetAllOrderDetailByOrderAsync(int orderId)
        {
            return await _context.OrderDetails.Include(o => o.Product)
                                              .Where(o => o.OrderId == orderId)  
                                              .ToListAsync(); 
        }

        public async Task<OrderDetail> GetOrderDetailByIdAsync(int orderDetailId)
        {
            return await _context.OrderDetails.Include(o => o.Product).FirstOrDefaultAsync(o => o.OrderDetailId == orderDetailId);
        }
    }
}
