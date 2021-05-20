using System;
using System.Collections;
using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using BLL.DTO;
using DAL.Entities;
using DAL.Repository.Interfaces;
using OrderState = BLL.DTO.OrderState;
using ShipmentOptions = BLL.DTO.ShipmentOptions;

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

        public IEnumerable<OrderDTO> GetOrderHistory(int userId)
        {
            return _orderRepository
                .GetBySelector(e => e.UserId == userId)
                .Select(ToOrderDto);
        }
        
        public bool PlaceOrder(OrderDTO order)
        {
            order.OrderDate = DateTime.Now;
            order.State = OrderState.Placed;
            order.ShipmentOptions = ShipmentOptions.SelfShipment;
            return _orderRepository.Add(FromOrderDto(order));
        }

        public bool UpdateOrder(OrderDTO order)
        {
            return _orderRepository.Update(FromOrderDto(order));
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