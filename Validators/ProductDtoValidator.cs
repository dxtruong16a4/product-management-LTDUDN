using FluentValidation;
using ProductManagement.DTOs;

namespace ProductManagement.Validators;

public class ProductDtoValidator : AbstractValidator<ProductDto>
{
    public ProductDtoValidator()
    {
        RuleFor(x => x.Id)
            .GreaterThan(0).WithMessage("Id phải lớn hơn 0");

        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Tên sản phẩm là bắt buộc")
            .MinimumLength(3).WithMessage("Tên sản phẩm phải có ít nhất 3 ký tự");

        RuleFor(x => x.Price)
            .GreaterThan(0).WithMessage("Giá phải lớn hơn 0");

        RuleFor(x => x.Stock)
            .GreaterThanOrEqualTo(0).WithMessage("Tồn kho không thể âm");

        RuleFor(x => x.Description)
            .MaximumLength(1000).WithMessage("Mô tả không được vượt quá 1000 ký tự");
    }
}
