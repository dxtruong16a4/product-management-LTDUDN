using ProductManagement.DTOs;

namespace ProductManagement.Services.Interfaces;

public interface IProductService
{
    Task<IEnumerable<ProductDto>> GetAllAsync();
    Task<ProductDto?> GetByIdAsync(int id);
    Task CreateAsync(ProductDto productDto);
    Task UpdateAsync(ProductDto productDto);
    Task DeleteAsync(int id);
    Task<IEnumerable<ProductDto>> SearchByNameAsync(string searchTerm);
    Task<PagedResult<ProductDto>> GetPagedAsync(int pageNumber, int pageSize, string? searchTerm = null);
}
