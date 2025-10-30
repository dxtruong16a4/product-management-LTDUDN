using ProductManagement.DTOs;
using ProductManagement.Models;

namespace ProductManagement.Mappers;

public static class ProductMapper
{
    public static ProductDto ToDto(Product product)
    {
        return new ProductDto
        {
            Id = product.Id,
            Name = product.Name,
            Price = product.Price,
            Stock = product.Stock,
            Description = product.Description
        };
    }

    public static Product ToEntity(ProductDto dto)
    {
        return new Product
        {
            Id = dto.Id,
            Name = dto.Name,
            Price = dto.Price,
            Stock = dto.Stock,
            Description = dto.Description
        };
    }

    public static IEnumerable<ProductDto> ToDtoList(IEnumerable<Product> products)
    {
        return products.Select(ToDto);
    }
}
