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

        public async Task<IList<SalesReport>> GetSalesReportAsync(DateTime startDate, DateTime endDate)
        {
            try
            {
                var result = await _context.OrderDetails
                    .Where(o => o.Order != null && o.Product != null
                             && o.Order.OrderDate >= startDate
                             && o.Order.OrderDate <= endDate)
                    .Select(o => new SalesReport
                    {
                        OrderDate = o.Order.OrderDate,
                        ProductName = o.Product.ProductName,
                        Quantity = o.Quantity,
                        UnitPrice = o.UnitPrice,
                        Discount = o.Discount
                    })
                    .ToListAsync();

                if (!result.Any())
                {
                    Console.WriteLine("No sales data found for the selected period.");
                }

                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in GetSalesReportAsync: {ex.Message}");
                return new List<SalesReport>();
            }
        }

    }
}
