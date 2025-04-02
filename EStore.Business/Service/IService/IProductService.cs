using EStore.Business.DTOs;
using EStore.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EStore.Business.Service.IService
{
    public interface IProductService
    {
        Task<List<ProductDTO>> GetAllProductAsync();
        Task<ProductDTO> GetProductByIdAsync(int id);
        Task<bool> AddProductAsync(CreateProductDTO product);
        Task<bool> DeleteProductAsync(int id);
        Task<bool> UpdateProductAsync(ProductDTO product);
        Task<List<ProductDTO>> GetPageProductsAsync(int pageIndex, int pageSize);
        Task<int> GetTotalProductsAsync();

    }
}
