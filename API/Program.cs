using API.Data;
using API.interfaces;
using API.services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<DataContext>(opt =>
{
    opt.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")); 
}
);
builder.Services.AddCors();

/*If we provide an interface over here we also have to provide the implmentation class 
as well 
The advantage of using an interface is when testing our codes */
builder.Services.AddScoped<ITokenService, TokenServices>();

var app = builder.Build();

app.UseCors(builder => builder.AllowAnyHeader().AllowAnyMethod().WithOrigins("https://localhost:4200"));


app.MapControllers();

app.Run();
