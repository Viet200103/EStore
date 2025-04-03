

using EStore.Business.DTOs;
using EStore.Data.Models;

namespace EStore.Business.Services.IServices
{
    public interface IOrderDetailService
    {
        Task<IEnumerable<OrderDetailDTO>> GetAllOrderDetailByOrderAsync(int orderId);
        Task<OrderDetailDTO> GetOrderDetailByIdAsync(int orderDetailId);
        Task<bool> DeleteOrderDetailAsync(int orderDetailId);
    }
}
