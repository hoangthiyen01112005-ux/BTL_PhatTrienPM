using DAL_DatabaseHelper;
using DAL.Interface;
using DAL;
using BLL.Interface;
using BLL;
using shared;

var builder = WebApplication.CreateBuilder(args);

// --- CÁC DỊCH VỤ MẶC ĐỊNH ---
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// --- ĐĂNG KÝ CÁC DỊCH VỤ CỦA BẠN (DI PHẢI NẰM Ở ĐÂY) ---

// 1. Đăng ký DatabaseHelper
builder.Services.AddSingleton<IDatabaseHelper, DatabaseHelper>();

// 2. Đăng ký tầng DAL
builder.Services.AddScoped<IDAL_DichVu, DAL_DichVu>();
builder.Services.AddScoped<IDAL_TaiKhoan, DAL_TaiKhoan>();

// 3. Đăng ký tầng BLL
builder.Services.AddScoped<IBLL_DichVu, BLL_DichVu>();

// --- SAU KHI ĐĂNG KÝ HẾT MỚI GỌI BUILD ---
var app = builder.Build();

// --- CẤU HÌNH MIDDLEWARE (Sử dụng đối tượng 'app') ---
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();

// Đảm bảo Class này đã được đăng ký hoặc viết đúng
app.UseMiddleware<RestricAcessMiddleware>();

app.MapControllers();

app.Run();