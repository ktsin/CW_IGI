using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using BLL.DTO;
using DAL.Entities;
using DAL.Repository.Interfaces;

namespace BLL.Services
{
    public class GoodsService
    {
        private readonly IGoodRepository _goodRepository = null;
        private readonly ICategoryRepository _categoryRepository = null;
        private readonly IMapper _mapper = null;

        public GoodsService(IGoodRepository goodRepository,
            ICategoryRepository categoryRepository,
            IMapper mapper)
        {
            _goodRepository = goodRepository;
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public bool AddGood(GoodDTO good)
        {
            return _goodRepository.Add(FromGoodDto(good));
        }

        public bool UpdateGood(GoodDTO good)
        {
            return _goodRepository.Update(FromGoodDto(good));
        }

        public bool DeleteGood(int id)
        {
            return _goodRepository.Remove(id);
        }

        public GoodDTO GetById(int id)
        {
            return ToGoodDto(_goodRepository.GetById(id));
        }

        public IEnumerable<GoodDTO> GetAllGoods()
        {
            return _goodRepository.GetAll().Select(ToGoodDto);
        }

        public bool EditGood(GoodDTO good)
        {
            _goodRepository.Update(FromGoodDto(good));
            return true;
        }

        public IEnumerable<GoodDTO> GetGoodsByCategoryId(int categoryId)
        {
            return _goodRepository
                .GetBySelector(e => e.CategoryId == categoryId)
                .Select(ToGoodDto);
        }

        public IEnumerable<GoodDTO> GetGoodsByStoreId(int storeId)
        {
            return _goodRepository
                .GetBySelector(e => e.StoreId == storeId)
                .Select(ToGoodDto);
        }
        
        public bool AddCategory(CategoryDTO obj)
        {
            return _categoryRepository.Add(FromCategoryDTO(obj));
        }

        public bool DeleteCategory(int id)
        {
            return _categoryRepository.Remove(id);
        }

        public CategoryDTO GetCategoryById(int id)
        {
            return ToCategoryDto(_categoryRepository.GetById(id));
        }

        public IEnumerable<CategoryDTO> GetCategories()
        {
            return _categoryRepository
                .GetAllInclude()
                .Select(ToCategoryDto);
        }

        public bool UpdateCategory(CategoryDTO category)
        {
            return  _categoryRepository.Update(FromCategoryDTO(category));
        }

        public GoodDTO ToGoodDto(Good good)
        {
            return _mapper.Map<Good, GoodDTO>(good);
        }

        public Good FromGoodDto(GoodDTO good)
        {
            return _mapper.Map<GoodDTO, Good>(good);
        }
        
        public CategoryDTO ToCategoryDto(Category obj)
        {
            return _mapper.Map<Category, CategoryDTO>(obj);
        }

        public Category FromCategoryDTO(CategoryDTO obj)
        {
            return _mapper.Map<CategoryDTO, Category>(obj);
        }
    }
}