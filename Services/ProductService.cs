using ProductManagement.DTOs;
using ProductManagement.Mappers;
using ProductManagement.Repositories.Interfaces;
using ProductManagement.Services.Interfaces;

namespace ProductManagement.Services;

public class ProductService : IProductService
{
    private readonly IProductRepository _repo;

    public ProductService(IProductRepository repo)
    {
        _repo = repo;
    }

    public async Task<IEnumerable<ProductDto>> GetAllAsync()
    {
        var products = await _repo.GetAllAsync();
        return ProductMapper.ToDtoList(products);
    }

    public async Task<ProductDto?> GetByIdAsync(int id)
    {
        var product = await _repo.GetByIdAsync(id);
        return product != null ? ProductMapper.ToDto(product) : null;
    }

    public async Task<ProductDto> CreateAsync(ProductDto productDto)
    {
        var product = ProductMapper.ToEntity(productDto);
        await _repo.AddAsync(product);
        // After saving, EF will populate product.Id — return created DTO
        return ProductMapper.ToDto(product);
    }

    public async Task UpdateAsync(ProductDto productDto)
    {
        var product = ProductMapper.ToEntity(productDto);
        await _repo.UpdateAsync(product);
    }

    public Task DeleteAsync(int id)
    {
        return _repo.DeleteAsync(id);
    }

    public async Task<IEnumerable<ProductDto>> SearchByNameAsync(string searchTerm)
    {
        var products = await _repo.SearchByNameAsync(searchTerm);
        return ProductMapper.ToDtoList(products);
    }

    public async Task<PagedResult<ProductDto>> GetPagedAsync(int pageNumber, int pageSize, string? searchTerm = null)
    {
        var (products, totalCount) = await _repo.GetPagedAsync(pageNumber, pageSize, searchTerm);
        
        return new PagedResult<ProductDto>
        {
            Items = ProductMapper.ToDtoList(products),
            CurrentPage = pageNumber,
            PageSize = pageSize,
            TotalCount = totalCount
        };
    }
}
