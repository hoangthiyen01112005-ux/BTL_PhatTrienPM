using APIGateway.Middleware;
using APIGateway.Middlewares;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
//builder.Services.AddEndpointsApiExplorer();
builder.Configuration.AddJsonFile("Ocelot.json", optional: true, reloadOnChange: true);
builder.Services.AddOcelot();
builder.Services.AddCors(option =>
{
    option.AddPolicy("MyPolicy", builder =>
    {
        builder.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin();
    });
});


var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseCors();
app.UseHttpsRedirection();

app.UseMiddleware<TokenCheck_iddleware>();
app.UseMiddleware<interceptionMiddleware>();
app.UseAuthorization();
app.UseOcelot().Wait();

app.Run();
