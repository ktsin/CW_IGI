using System.Collections;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using BLL.DTO;
using DAL.Entities;
using DAL.Repository.Interfaces;

namespace BLL.Services
{
    public class OrderService
    {
        private readonly IOrderRepository _orderRepository = null;
        private readonly IMapper _mapper = null;

        public OrderService(IOrderRepository orderRepository, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
        }

        public IEnumerable<OrderDTO> GetAll()
        {
            return _orderRepository.GetAllInclude().Select(ToOrderDto);
        }

        public OrderDTO ToOrderDto(Order msg)
        {
            return _mapper.Map<Order, OrderDTO>(msg);
        }

        public Order FromOrderDto(OrderDTO msg)
        {
            return _mapper.Map<OrderDTO, Order>(msg);
        }
    }
}