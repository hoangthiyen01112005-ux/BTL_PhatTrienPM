using Microsoft.EntityFrameworkCore; 
using BTL_PhatTrienPM.Models;        

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<DaTravelContext>(options =>
    options.UseSqlServer("Server=.;Database=BanMayTinh;Trusted_Connection=True;TrustServerCertificate=True;Server=PC01\\SQLEXPRESS;Database=DA_TRAVEL;Trusted_Connection=True;TrustServerCertificate=True;"));
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();