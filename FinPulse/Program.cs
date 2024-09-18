using FinPulse.BL;
using FinPulse.DAL;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

#region Default Services

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

#endregion

#region Database

builder.Services.AddDbContext<FinPulseContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

#endregion

#region Repos

builder.Services.AddScoped<IStockRepo, StockRepo>();

#endregion

#region Managers

builder.Services.AddScoped<IStockManager, StockManager>();

#endregion

var app = builder.Build();

// Configure the HTTP request pipeline.

#region Middlewares

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

#endregion

app.Run();