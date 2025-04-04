using AutoMapper;
using EStore.Business.DTOs.OrderDetailDTO;
using EStore.Business.Services.IServices;
using EStore.Data.Models;
using EStore.Data.Repositories;

namespace EStore.Business.Services
{
    public class OrderDetailService : IOrderDetailService
    {
        private readonly IOrderDetailRepository _repository;
        private readonly IMapper _mapper;
        public OrderDetailService(IOrderDetailRepository repository, IMapper mapper)
        {
            _mapper = mapper;
            _repository = repository;
        }
        public async Task<bool> DeleteOrderDetailAsync(int orderDetailId)
        {
            return await _repository.DeleteOrderDetailAsync(orderDetailId);
        }

        public async Task<IEnumerable<OrderDetailDTO>> GetAllOrderDetailByOrderAsync(int orderId)
        {
            IEnumerable<OrderDetail> orderDetailList = await _repository.GetAllOrderDetailByOrderAsync(orderId);
            return _mapper.Map<IEnumerable<OrderDetailDTO>>(orderDetailList);
        }

        public async Task<OrderDetailDTO> GetOrderDetailByIdAsync(int orderDetailId)
        {
            var orderDetail = await _repository.GetOrderDetailByIdAsync(orderDetailId);
            return _mapper.Map<OrderDetailDTO>(orderDetail);
        }

        public async Task<IList<SalesReport>> GetSalesReportAsync(DateTime startDate, DateTime endDate)
        {
            return await _repository.GetSalesReportAsync(startDate, endDate);
        }
    }
}
