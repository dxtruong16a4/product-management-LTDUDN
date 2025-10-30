using System.ComponentModel.DataAnnotations;

namespace ProductManagement.Models;

public class Product
{
    public int Id { get; set; }

    [Required, MinLength(3)]
    public string Name { get; set; } = string.Empty;

    [Range(0.01, double.MaxValue)]
    public decimal Price { get; set; }

    [Range(0, int.MaxValue)]
    public int Stock { get; set; }

    public string? Description { get; set; }
}
