using DAL_DatabaseHelper; // Chứa DatabaseHelper
using DAL.Interface;      // Chứa IDAL_Dichvu
using DAL;                // Chứa DAL_DichVu
using BLL.Interface;      // Chứa IBLL_DichVu
using BLL;                // Chứa BLL_DichVu
using shared;

var builder = WebApplication.CreateBuilder(args);

string connectionString = @"Data Source=LAURENT\NHATDEPZAI;Initial Catalog=DA_TRAVEL;Integrated Security=True;Trust Server Certificate=True";
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


// Đăng ký Dependency Injection
builder.Services.AddSingleton<IDatabaseHelper, DatabaseHelper>();

builder.Services.AddScoped<IDAL_DichVu, DAL_DichVu>();
builder.Services.AddScoped<IDAL_TaiKhoan, DAL_TaiKhoan>();
builder.Services.AddScoped<IBLL_DichVu, BLL_DichVu>();

builder.Services.AddControllers();
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();
app.UseMiddleware<RestricAcessMiddleware>();
app.MapControllers();

app.Run();
