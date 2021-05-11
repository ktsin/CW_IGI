using AutoMapper;
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
    }
}