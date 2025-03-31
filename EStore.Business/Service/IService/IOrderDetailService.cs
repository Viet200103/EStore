

using EStore.Business.DTOs.OrderDetailDTO;
using EStore.Data.Models;

namespace EStore.Business.Service.IService
{
    public interface IOrderDetailService
    {
        Task<IEnumerable<OrderDetailDTO>> GetAllOrderDetailByOrderAsync(int orderId);
        Task<OrderDetailDTO> GetOrderDetailByIdAsync(int orderDetailId);
        Task<bool> DeleteOrderDetailAsync(int orderDetailId);
    }
}
