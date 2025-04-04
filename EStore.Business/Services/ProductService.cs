using AutoMapper;
using EStore.Business.DTOs;
using EStore.Data.Models;
using EStore.Data.Repositories;
using EStore.Business.Services.IServices;

namespace EStore.Business.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        
        public ProductService(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        // public async Task<bool> UpdateProduct(ProductDTO productDTO)
        // {
        //     return await _productRepository.UpdateProductAsync(_mapper.Map<Product>(productDTO));
        // }
        //
        public async Task<(IEnumerable<ProductDTO> productsDTO, int totalPages)> GetProducts(int pageNumber, int pageSize, string? search = null, string? condition = null)
        {
            var (products, totalPages) = await _productRepository.GetProducts(pageNumber, pageSize, search, condition);
            IEnumerable<ProductDTO> productsDTO = _mapper.Map<IEnumerable<ProductDTO>>(products);
            return (productsDTO, totalPages);
        }

        public async Task<ProductDTO?> GetProductById(int id)
        {
            var product = await _productRepository.GetProductById(id);
            ProductDTO productDTO = _mapper.Map<ProductDTO>(product);
            return productDTO;
        }

        public async Task<bool> AddProduct(CreateProductDTO createProductDTO)
        {
            Product product = _mapper.Map<Product>(createProductDTO);
            return await _productRepository.AddProduct(product);
        }

        public async Task<bool> DeleteProduct(int id)
        {
            return await _productRepository.DeleteProductAsync(id);
        }

        public Task<bool> UpdateProduct(ProductDTO product)
        {
            throw new NotImplementedException();
        }
    }
}
