using AutoMapper;
using EStore.Business.DTOs;
using EStore.Business.Service.IService;

using EStore.Data.Repositories;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EStore.Business.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly ILogger<CategoryService> _logger;
        private readonly IMapper _mapper;
        public CategoryService(ICategoryRepository categoryRepository, ILogger<CategoryService> logger, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _logger = logger;
            _mapper = mapper;
        }
        public Task<bool> AddCategoryAsync(AddCategoryDTO categoryDTO)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteCategoryAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<AddCategoryDTO>> GetAllCategoryAsync()
        {
           try
            {
                return _mapper.Map<List<AddCategoryDTO>>(await _categoryRepository.GetAllCategoryAsync());
            }
            catch (Exception ex)
            {
                _logger.LogError("Error in business layer when get all category", ex);
                throw;
            }
        }

        public Task<AddCategoryDTO> GetCategoryByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateCategoryAsync(AddCategoryDTO categoryDTO)
        {
            throw new NotImplementedException();
        }
    }
}
