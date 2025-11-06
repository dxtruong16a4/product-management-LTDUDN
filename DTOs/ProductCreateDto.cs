using System.ComponentModel.DataAnnotations;

namespace ProductManagement.DTOs;

public class ProductCreateDto
{
    [Required(ErrorMessage = "Tên sản phẩm là bắt buộc")]
    [MinLength(3, ErrorMessage = "Tên sản phẩm phải có ít nhất 3 ký tự")]
    [Display(Name = "Tên sản phẩm")]
    public string Name { get; set; } = string.Empty;

    [Required(ErrorMessage = "Giá là bắt buộc")]
    [Range(0.01, double.MaxValue, ErrorMessage = "Giá phải lớn hơn 0")]
    [Display(Name = "Giá (VNĐ)")]
    public decimal Price { get; set; }

    [Required(ErrorMessage = "Tồn kho là bắt buộc")]
    [Range(0, int.MaxValue, ErrorMessage = "Tồn kho không thể âm")]
    [Display(Name = "Số lượng hàng tồn kho")]
    public int Stock { get; set; }

    [Display(Name = "Mô tả")]
    public string? Description { get; set; }
}
