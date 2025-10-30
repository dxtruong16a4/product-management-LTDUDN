using ProductManagement.Models;

namespace ProductManagement.Data;

public static class DbSeeder
{
    public static async Task SeedAsync(AppDbContext context)
    {
        // Kiểm tra xem database đã được seed hay chưa  
        if (context.Products.Any()) return; // Database đã được seed

        var products = new List<Product>();
        var random = new Random();

        for (int i = 1; i <= 100; i++)
        {
            products.Add(new Product
            {
                Name = $"Product {i}",
                Price = Math.Round((decimal)(random.NextDouble() * 1000 + 10), 2),
                Stock = random.Next(0, 500),
                Description = $"Đây là mô tả cho Sản phẩm {i}. " +
                             $"Loại: {GetRandomCategory(i)}. " +
                             $"Số lượng: {GetRandomQuality(i)}."
            });
        }

        context.Products.AddRange(products);
        await context.SaveChangesAsync();
    }

    private static string GetRandomCategory(int seed)
    {
        var categories = new[] {"Đồ điện tử", "Quần áo", "Thực phẩm", "Sách", "Đồ chơi", "Nội thất", "Thể thao", "Làm đẹp"};
        return categories[seed % categories.Length];
    }

    private static string GetRandomQuality(int seed)
    {
        var qualities = new[] {"Cao cấp", "Tiêu chuẩn", "Tiết kiệm", "Sang trọng", "Cơ bản"};
        return qualities[seed % qualities.Length];
    }
}
