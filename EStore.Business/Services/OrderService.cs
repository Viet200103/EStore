using AutoMapper;
using EStore.Business.DTOs;
using EStore.Business.Services.IServices;
using EStore.Data.Models;
using EStore.Data.Repositories;

namespace EStore.Business.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;

        public OrderService(IOrderRepository orderRepository, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
        }

        public async Task CreateOrderAsync(OrderDTO orderDTO)
        {
            var order = _mapper.Map<Order>(orderDTO);
            await _orderRepository.CreateOrderAsync(order);
        }

        public async Task DeleteOrderAsync(int orderId)
        {
            var order = await _orderRepository.GetOrderByIdAsync(orderId);

            if (order == null)
            {
                throw new KeyNotFoundException("Order not found.");
            }

            await _orderRepository.DeleteOrderAsync(order);
        }

        public async Task<IList<OrderDTO>> GetAllOrdersAsync()
        {
            var orders = await _orderRepository.GetAllOrdersAsync();
            return _mapper.Map<IList<OrderDTO>>(orders);
        }

        public async Task<OrderDTO?> GetOrderByIdAsync(int id)
        {
            var order = await _orderRepository.GetOrderByIdAsync(id);
            return order == null ? null : _mapper.Map<OrderDTO>(order);
        }

        public async Task<IList<OrderDTO>> GetOrdersByMemberIdAsync(int memberId)
        {
            var orders = await _orderRepository.GetOrdersByMemberIdAsync(memberId);
            return _mapper.Map<IList<OrderDTO>>(orders);
        }

        public async Task UpdateOrderAsync(OrderDTO orderDTO)
        {
            var existingOrder = await _orderRepository.GetOrderByIdAsync(orderDTO.OrderId);
            if (existingOrder == null) throw new KeyNotFoundException("Order not found.");

            var order = _mapper.Map(orderDTO, existingOrder);
            await _orderRepository.UpdateOrderAsync(order);
        }
    }
}
