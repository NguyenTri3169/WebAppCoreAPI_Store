using DataAccess.DAO;
using DataAccess.DAOImpl;
using DataAccess.DbContext;
using Microsoft.EntityFrameworkCore;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddTransient<ICategory, CategoryImpl>();
builder.Services.AddScoped<ICategory, CategoryImpl>();
builder.Services.AddDbContext<StoreDbContext>(p => p.UseSqlServer(builder.Configuration.GetConnectionString("Store")));
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
