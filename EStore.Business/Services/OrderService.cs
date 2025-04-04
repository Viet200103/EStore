using AutoMapper;
using EStore.Business.DTOs;
using EStore.Business.Security;
using EStore.Business.Services.IServices;
using EStore.Data.Models;
using EStore.Data.Repositories;

namespace EStore.Business.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IOrderDetailRepository _orderDetailRepository;
        private readonly IProductRepository _productRepository;
        private readonly IMemberRepository _memberRepository;
        private readonly IMapper _mapper;

        public OrderService(IOrderRepository orderRepository, IOrderDetailRepository orderDetailRepository, IMapper mapper, IProductRepository productRepository, IMemberRepository memberRepository)
        {
            _orderRepository = orderRepository;
            _orderDetailRepository = orderDetailRepository;
            _productRepository = productRepository;
            _memberRepository = memberRepository;
            _mapper = mapper;
        }

        public async Task CreateOrderAsync(OrderDTO orderDTO)
        {
            var user = await _memberRepository.GetByEmailAsync(orderDTO.MemberEmail);

            if (user == null)
            {
                throw new KeyNotFoundException($"User {orderDTO.MemberEmail} not found.");
            }

            Order order = new()
            {
                Member = user,
                MemberId = user.MemberId,
                OrderDate = DateTime.Now,
                RequireDate = DateTime.Now.AddDays(7),
                Freight = 0
            };
            List<OrderDetail> orderDetails = new();

            foreach (var orderDetail in orderDTO.OrderDetails)
            {
                var existingProduct = await _productRepository.GetProductByIdAsync(orderDetail.ProductId);
                if (existingProduct == null)
                {
                    throw new Exception($"Product ID {orderDetail.ProductId} does not exist.");
                }
                if (orderDetail.Quantity > existingProduct.UnitslnStock)
                {
                    throw new InvalidOperationException($"Not enough stock for existingProduct {existingProduct.ProductName}. Available: {existingProduct.UnitslnStock}, Requested: {orderDetail.Quantity}");
                }

                orderDetails.Add(new()
                {
                    Product=existingProduct,
                    UnitPrice= (decimal)existingProduct.UnitPrice,
                    Quantity= orderDetail.Quantity,
                    Discount = orderDetail.Discount
                });

                order.Freight +=(orderDetail.Quantity * existingProduct.UnitPrice * (1 - ((decimal)orderDetail.Discount / 100)))*(decimal)0.1;
            }

            order.OrderDetails.Clear();
            order.OrderDetails = orderDetails;

            await _orderRepository.CreateOrderAsync(order);
        }

        public async Task<List<CreateProductOrderDTO>> GetAvailableProductsAsync()
        {
            var products = await _productRepository.GetAvailableProductsAsync();
            return _mapper.Map<List<CreateProductOrderDTO>>(products);
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
            if (order == null)
            {
                throw new KeyNotFoundException("Order not found.");
            }

            var result = _mapper.Map<OrderDTO>(order);
            var products = await GetAvailableProductsAsync();

            foreach (var item in result.OrderDetails)
            {
                foreach (var product in products)
                {
                    if (item.ProductId == product.ProductId)
                    {
                        item.ProductName = product.ProductName;
                    }
                }
            }

            return result;
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

        public async Task<List<OrderDTO>> GetOrdersByCurrentMemberAsync(int userId)
        {
            var result = await _orderRepository.GetOrdersByMemberIdAsync(userId);
            return _mapper.Map<List<OrderDTO>>(result);
        }
    }
}
