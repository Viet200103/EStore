using EStore.Business.DTOs.OrderDetailDTO;

namespace EStore.Business.Services.IServices
{
    public interface IOrderDetailService
    {
        Task<IEnumerable<OrderDetailDTO>> GetAllOrderDetailByOrderAsync(int orderId);
        Task<OrderDetailDTO> GetOrderDetailByIdAsync(int orderDetailId);
        Task<bool> DeleteOrderDetailAsync(int orderDetailId);
    }
}
