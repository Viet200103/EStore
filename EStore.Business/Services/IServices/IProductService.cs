using EStore.Business.DTOs;

namespace EStore.Business.Services.IServices
{
    public interface IProductService
    {
        Task<(IEnumerable<ProductDTO> productsDTO, int totalPages)> GetProducts(int pageNumber, int pageSize, string? search = null, string? condition = null);
        
        Task<ProductDTO?> GetProductById(int id);
        Task<bool> AddProduct(CreateProductDTO createProductDTO);
        Task<bool> DeleteProduct(int id);
        Task<bool> UpdateProduct(ProductDTO product);

    }
}
