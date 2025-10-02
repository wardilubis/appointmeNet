using restAPI.DTOs;
using restAPI.models;

namespace restAPI.services;

public interface IProductService
{
    Task<IEnumerable<ProductDto>> GetAllProductsAsync();
    Task<ProductDto?> GetProductByIdAsync(int id);
    Task<ProductDto?> CreateProductByIdAsync(CreateProductDto createProductDto);
    Task<ProductDto?> UpdateProductByIdAsync(int id, UpdateProductDto updateProductDto);
    Task<bool> DeleteProductAsync(int id);
}