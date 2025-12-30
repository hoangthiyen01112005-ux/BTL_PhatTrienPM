using BTL_PhatTrienPM.Models;
using BTL_PhatTrienPM.Services.Implements;
using BTL_PhatTrienPM.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// ==============================================
// 1. CẤU HÌNH KẾT NỐI DATABASE (Lấy từ appsettings.json)
// ==============================================
// Thay vì viết cứng, ta đọc từ file cấu hình cho chuyên nghiệp
var connectionString = builder.Configuration.GetConnectionString("DaTravelDb");
builder.Services.AddDbContext<DaTravelContext>(options =>
    options.UseSqlServer(connectionString));

// ==============================================
// 2. ĐĂNG KÝ SERVICES (DEPENDENCY INJECTION) - QUAN TRỌNG
// ==============================================
// Tại đây bạn phải liệt kê tất cả các cặp Interface - Service mà nhóm bạn làm
// Ví dụ (Bỏ comment khi bạn đã tạo file):
builder.Services.AddScoped<IVeService, VeService>();
// builder.Services.AddScoped<IGioHangService, GioHangService>();
// builder.Services.AddScoped<IDichVuService, DichVuService>();

// ==============================================
// 3. CẤU HÌNH API
// ==============================================
builder.Services.AddControllers(); // Chuẩn API (Không dùng Views)

// Cấu hình CORS (Cho phép Frontend gọi vào API)
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.AllowAnyOrigin()  // Cho phép mọi nơi gọi vào
              .AllowAnyMethod()  // Cho phép GET, POST, PUT, DELETE...
              .AllowAnyHeader();
    });
});

// Swagger (Tài liệu API)
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// ==============================================
// 4. CẤU HÌNH PIPELINE (Luồng chạy)
// ==============================================
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(); // Kích hoạt CORS

app.UseAuthorization();

app.MapControllers();

app.Run();