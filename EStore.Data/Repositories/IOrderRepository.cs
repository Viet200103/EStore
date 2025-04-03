using EStore.Data.Models;

namespace EStore.Data.Repositories;

public interface IOrderRepository
{
    Task CreateOrderAsync(Order order);
    Task<Order?> GetOrderByIdAsync(int id);
    Task<IList<Order>> GetOrdersByMemberIdAsync(int memberId);
    Task<IList<Order>> GetAllOrdersAsync();
    Task UpdateOrderAsync(Order order);
    Task DeleteOrderAsync(Order order);
}