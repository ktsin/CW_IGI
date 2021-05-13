using System;
using AutoMapper;
using BLL.DTO;
using DAL.Entities;
using DAL.Repository.Interfaces;

namespace BLL.Services
{
    public class GoodsService
    {
        private readonly IGoodRepository _goodRepository = null;
        private readonly IMapper _mapper = null;

        public GoodsService(IGoodRepository goodRepository,
            IMapper mapper)
        {
            _goodRepository = goodRepository;
            _mapper = mapper;
        }

        public bool AddGood(GoodDTO good)
        {
            return _goodRepository.Add(FromGoodDto(good));
        }

        public bool DeleteGood(int id)
        {
            return _goodRepository.Remove(id);
        }

        public GoodDTO GetById(int id)
        {
            return ToGoodDto(_goodRepository.GetById(id));
        } 
        
        public GoodDTO ToGoodDto(Good good)
        {
            return _mapper.Map<Good, GoodDTO>(good);
        }

        public Good FromGoodDto(GoodDTO good)
        {
            return _mapper.Map<GoodDTO, Good>(good);
        }
    }
}