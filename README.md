# 🛒 Hệ Thống Quản Lý Sản Phẩm (Product Management System)

Ứng dụng web quản lý sản phẩm được xây dựng bằng **ASP.NET Core MVC** theo kiến trúc phân tầng (Layered Architecture) với các nguyên tắc **SOLID** và **Clean Code**.

## 📋 Mục Lục
- [Tính Năng](#-tính-năng)
- [Công Nghệ Sử Dụng](#-công-nghệ-sử-dụng)
- [Kiến Trúc Dự Án](#-kiến-trúc-dự-án)
- [Cài Đặt](#-cài-đặt)
- [Cấu Hình](#-cấu-hình)
- [Chạy Ứng Dụng](#-chạy-ứng-dụng)
- [Cấu Trúc Thư Mục](#-cấu-trúc-thư-mục)

## ✨ Tính Năng

### CRUD Cơ Bản
- ✅ **Tạo mới** sản phẩm với thông tin đầy đủ
- ✅ **Xem danh sách** tất cả sản phẩm
- ✅ **Xem chi tiết** từng sản phẩm
- ✅ **Chỉnh sửa** thông tin sản phẩm
- ✅ **Xóa** sản phẩm

### Tính Năng Nâng Cao
- 🔍 **Tìm kiếm** theo tên hoặc mô tả sản phẩm
- 📄 **Phân trang** (5 sản phẩm/trang)
- ✅ **Validation** dữ liệu ở client và server
- 🎨 **Giao diện Bootstrap 5** responsive
- 📦 **DTO Pattern** để tách biệt domain model và presentation

### Data Seeding
- 🌱 Tự động seed **100 sản phẩm** mẫu khi khởi động lần đầu
- 🎲 Dữ liệu ngẫu nhiên: giá, số lượng, danh mục, chất lượng

## 🛠 Công Nghệ Sử Dụng

### Backend
- **Framework**: ASP.NET Core 8.0 MVC
- **ORM**: Entity Framework Core 9.0.10
- **Database**: SQL Server
- **Language**: C# (.NET 8)

### Frontend
- **UI Framework**: Bootstrap 5
- **Validation**: jQuery Validation
- **Template Engine**: Razor Views

### Kiến Trúc & Patterns
- **Repository Pattern** - Tầng truy xuất dữ liệu
- **Service Layer Pattern** - Tầng business logic
- **DTO Pattern** - Data Transfer Objects
- **Dependency Injection** - IoC Container
- **Code First Approach** - EF Core Migrations

## 🏗 Kiến Trúc Dự Án

```
┌─────────────────┐
│  Presentation   │  ← Controllers + Views (Razor)
│     Layer       │
└────────┬────────┘
         │
┌────────▼────────┐
│   Service       │  ← Business Logic + DTOs
│     Layer       │
└────────┬────────┘
         │
┌────────▼────────┐
│  Repository     │  ← Data Access Layer
│     Layer       │
└────────┬────────┘
         │
┌────────▼────────┐
│   Database      │  ← SQL Server + EF Core
│     Layer       │
└─────────────────┘
```

### Phân Tầng Chi Tiết

1. **Controllers** - Xử lý HTTP requests và responses
2. **Services** - Business logic và orchestration
3. **Repositories** - Truy xuất dữ liệu từ database
4. **DTOs** - Đối tượng truyền tải dữ liệu
5. **Models** - Domain entities
6. **Mappers** - Chuyển đổi giữa Entity và DTO
7. **Data** - DbContext và Database Seeder

## 📦 Cài Đặt

### Yêu Cầu Hệ Thống
- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- [SQL Server](https://www.microsoft.com/sql-server/sql-server-downloads) (Express hoặc phiên bản cao hơn)
- [Visual Studio 2022](https://visualstudio.microsoft.com/) hoặc [VS Code](https://code.visualstudio.com/)

### Các Bước Cài Đặt

1. **Clone hoặc tải dự án về**
2. **Cài đặt các package NuGet**
```bash
dotnet restore
```

3. **Cấu hình connection string** (xem phần [Cấu Hình](#-cấu-hình))

4. **Chạy migrations để tạo database**
```bash
dotnet ef database update
```

5. **Build project**
```bash
dotnet build
```

## ⚙️ Cấu Hình

### Connection String

Mở file `appsettings.json` và cấu hình connection string phù hợp với SQL Server của bạn:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=TÊN_SERVER;Database=ProductDB;Integrated Security=True;Trust Server Certificate=True;"
  }
}
```

**Ví dụ:**
- SQL Server Local: `Server=localhost;Database=ProductDB;...`
- SQL Server Express: `Server=LAPTOP\\SQLEXPRESS;Database=ProductDB;...`

### Database Seeding

Khi ứng dụng chạy lần đầu, hệ thống sẽ tự động:
- Kiểm tra database có tồn tại chưa
- Tạo các bảng thông qua EF Migrations
- Seed 100 sản phẩm mẫu (nếu database trống)

## 🚀 Chạy Ứng Dụng

### Sử dụng .NET CLI
```bash
dotnet run
```

### Sử dụng Visual Studio
1. Mở solution/project trong Visual Studio
2. Nhấn `F5` hoặc click nút **Run**

### Truy Cập Ứng Dụng
Sau khi chạy, mở trình duyệt và truy cập:
```
http://localhost:5282
http://localhost:5282/Products
```

## 📁 Cấu Trúc Thư Mục

```
ProductManagement/
├── Controllers/
│   ├── HomeController.cs
│   └── ProductsController.cs          # CRUD operations controller
├── Data/
│   ├── AppDbContext.cs                # EF Core DbContext
│   └── DbSeeder.cs                    # Database seeding logic
├── DTOs/
│   ├── ProductDto.cs                  # Product data transfer object
│   └── PagedResult.cs                 # Pagination wrapper
├── Mappers/
│   └── ProductMapper.cs               # Entity ↔ DTO mapping
├── Migrations/
│   └── ...                            # EF Core migrations
├── Models/
│   ├── Product.cs                     # Domain entity
│   └── ErrorViewModel.cs
├── Repositories/
│   ├── Interfaces/
│   │   └── IProductRepository.cs
│   └── ProductRepository.cs           # Data access implementation
├── Services/
│   ├── Interfaces/
│   │   └── IProductService.cs
│   └── ProductService.cs              # Business logic
├── Views/
│   ├── Products/
│   │   ├── Index.cshtml              # Danh sách + tìm kiếm + phân trang
│   │   ├── Create.cshtml             # Form tạo mới
│   │   ├── Edit.cshtml               # Form chỉnh sửa
│   │   ├── Details.cshtml            # Xem chi tiết
│   │   └── Delete.cshtml             # Xác nhận xóa
│   └── Shared/
│       └── _Layout.cshtml             # Master layout
├── wwwroot/                           # Static files (CSS, JS, images)
├── appsettings.json                   # Configuration
├── Program.cs                         # Application entry point
└── ProductManagement.csproj           # Project file
```

## 🎯 Các Tính Năng Chính

### 1. Quản Lý Sản Phẩm (Product CRUD)
- **Model**: `Product` với các thuộc tính: Id, Name, Price, Stock, Description
- **Validation**: Required, MinLength, Range constraints
- **DTO**: `ProductDto` để tách biệt presentation và domain layer

### 2. Tìm Kiếm & Phân Trang
- Tìm kiếm theo tên hoặc mô tả sản phẩm
- Phân trang với 5 sản phẩm/trang
- Điều hướng: Trước, Sau, số trang
- Duy trì từ khóa tìm kiếm khi chuyển trang

### 3. Database Seeding
- Tự động tạo 100 sản phẩm mẫu
- Dữ liệu đa dạng với 8 danh mục và 5 mức chất lượng
- Chỉ chạy 1 lần khi database trống

## 🔧 Entity Framework Migrations

### Tạo migration mới
```bash
dotnet ef migrations add TenMigration
```

### Áp dụng migrations
```bash
dotnet ef database update
```

### Xóa database (cẩn thận!)
```bash
dotnet ef database drop --force
```

## 📊 Database Schema

### Bảng Products
| Cột         | Kiểu Dữ Liệu    | Mô Tả                    |
|-------------|-----------------|--------------------------|
| Id          | int (PK)        | Khóa chính, tự tăng      |
| Name        | nvarchar(max)   | Tên sản phẩm (bắt buộc)  |
| Price       | decimal(18,2)   | Giá sản phẩm             |
| Stock       | int             | Số lượng tồn kho         |
| Description | nvarchar(max)   | Mô tả sản phẩm (nullable)|

## 👨‍💻 Phát Triển

### Thêm Tính Năng Mới
1. Tạo/Cập nhật Entity trong `Models/`
2. Tạo DTO tương ứng trong `DTOs/`
3. Update Mapper trong `Mappers/`
4. Thêm method vào Repository Interface và Implementation
5. Thêm business logic vào Service Layer
6. Tạo Controller action và View

### Best Practices Được Áp Dụng
- ✅ Dependency Injection cho tất cả các dependencies
- ✅ Async/await cho tất cả database operations
- ✅ Repository pattern để abstract data access
- ✅ Service layer để chứa business logic
- ✅ DTO để tách biệt concerns
- ✅ Validation ở cả client và server side

## 📝 License

Dự án mã nguồn mở, tự do sử dụng cho mục đích học tập và nghiên cứu.

---

**Phát triển với ❤️ bởi ASP.NET Core MVC**
