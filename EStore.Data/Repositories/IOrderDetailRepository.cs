using EStore.Data.Models;

namespace EStore.Data.Repositories;

public interface IOrderDetailRepository
{
    Task<IEnumerable<OrderDetail>> GetAllOrderDetailByOrderAsync(int orderId);
    Task<OrderDetail> GetOrderDetailByIdAsync(int orderDetailId);
    Task<OrderDetail> CreateOrderDetailAsync(OrderDetail orderDetail);
    Task<bool> DeleteOrderDetailAsync(int orderDetailId);
}