using System.Collections;
using AutoMapper;
using System.Collections.Generic;
using System.Linq;
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
            var dto = _mapper.Map<Order, OrderDTO>(msg);
            dto.Goods = msg.Goods.Select(_mapper.Map<Good, GoodDTO>).ToList();
            return dto;
        }

        public Order FromOrderDto(OrderDTO msg)
        {
            var o = _mapper.Map<OrderDTO, Order>(msg);
            o.Goods = msg.Goods.Select(_mapper.Map<GoodDTO, Good>).ToList();
            return o;
        }
    }
}