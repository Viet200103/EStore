using EStore.Business.DTOs;
using EStore.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EStore.Business.Service.IService
{
    public interface ICategoryService
    {
        Task<List<AddCategoryDTO>> GetAllCategoryAsync();
        Task<AddCategoryDTO> GetCategoryByIdAsync(int id);
        Task<bool> AddCategoryAsync(AddCategoryDTO categoryDTO);
        Task<bool> DeleteCategoryAsync(int id);
        Task<bool> UpdateCategoryAsync(AddCategoryDTO categoryDTO);
    }

}
