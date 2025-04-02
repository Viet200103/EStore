using AutoMapper;
using EStore.Business.DTOs;
using EStore.Business.Service.IService;
using EStore.Data.Models;
using EStore.Data.Repositories;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EStore.Business.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly ILogger<ProductService> _logger;
        private readonly IMapper _mapper;
        public ProductService(IProductRepository productRepository, ILogger<ProductService> logger, IMapper mapper)
        {
            _productRepository = productRepository;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<bool> AddProductAsync(CreateProductDTO product)
        {
           try
            {
                var newProduct = _mapper.Map<Product>(product);
                if (newProduct == null)
                {
                    _logger.LogWarning("Product is null");
                    throw new ArgumentNullException("Product is null!!!");
                }
                return await _productRepository.AddProductAsync(newProduct);
            }
            catch (Exception ex)
            {
                _logger.LogError("Error in business layer when adding product", ex);
                throw;
            }
        }

        public async Task<bool> DeleteProductAsync(int id)
        {
           try
            {
                if (id <= 0)
                {
                    _logger.LogWarning("Product id is not valid");
                    throw new ArgumentNullException("Product id is not valid!!!");
                }

                return await _productRepository.DeleteProductAsync(id);
            }
            catch (Exception ex)
            {
                _logger.LogError("Error in business layer when adding product", ex);
                throw;
            }
        }

        public async Task<List<ProductDTO>> GetAllProductAsync()
        {
            try
            {
                List<Product> list = await _productRepository.GetAllProductAsync();
                if (list == null)
                {
                    _logger.LogWarning("Product list is null");
                    throw new ArgumentNullException("Product list is null!!!");
                }
                return _mapper.Map<List<ProductDTO>>(list);
                
            }
            catch (Exception ex)
            {
                _logger.LogError("Error in business layer when adding product", ex);
                throw;
            }
        }

        public async Task<List<ProductDTO>> GetPageProductsAsync(int pageIndex, int pageSize)
        {
            try
            {
                var list = await _productRepository.GetPageProductsAsync(pageIndex, pageSize);
                if (list == null)
                {
                    _logger.LogWarning("Product list is null");
                    throw new ArgumentNullException("Product list is null!!!");
                }
                return _mapper.Map<List<ProductDTO>>(list);
            }
            catch (Exception ex)
            {
                _logger.LogError("Error in business layer when adding product", ex);
                throw;
            }
        }

        public async Task<ProductDTO> GetProductByIdAsync(int id)
        {
           try
            {
                if (id <= 0)
                {
                    _logger.LogWarning("Product id is not valid");
                    throw new ArgumentNullException("Product id is not valid!!!");
                }
                return _mapper.Map<ProductDTO>( await _productRepository.GetProductByIdAsync(id));
            }
            catch (Exception ex)
            {
                _logger.LogError("Error in business layer when adding product", ex);
                throw;
            }
        }

        public async Task<int> GetTotalProductsAsync()
        {
            return await _productRepository.GetTotalProductsAsync();
        }

        public async Task<bool> UpdateProductAsync(ProductDTO productDTO)
        {
            try
            {
                return await _productRepository.UpdateProductAsync(_mapper.Map<Product>(productDTO));

            }
            catch (Exception ex)
            {
                _logger.LogError("Error in business layer when adding product", ex);
                throw;
            }
        }

    }
}
