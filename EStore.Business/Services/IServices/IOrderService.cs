using EStore.Business.DTOs;
using EStore.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EStore.Business.Services.IServices
{
    public interface IOrderService
    {
        Task CreateOrderAsync(OrderDTO orderDTO);
        Task DeleteOrderAsync(int orderId);
        Task<IList<OrderDTO>> GetAllOrdersAsync();
        Task<OrderDTO?> GetOrderByIdAsync(int id);
        Task<IList<OrderDTO>> GetOrdersByMemberIdAsync(int memberId);
        Task UpdateOrderAsync(OrderDTO orderDTO);
    }
}
