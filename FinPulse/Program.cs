using System.Text;
using FinPulse.BL;
using FinPulse.DAL;
using FinPulse.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

#region Default Services

builder.Services.AddControllers();

#endregion

#region Database

builder.Services.AddDbContext<FinPulseContext>(options =>
{
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection"));
});

#endregion

#region Repos

builder.Services.AddScoped<IStockRepo, StockRepo>();
builder.Services.AddScoped<ICommentRepo, CommentRepo>();

#endregion

#region Managers

builder.Services.AddScoped<IStockManager, StockManager>();
builder.Services.AddScoped<ICommentManager, CommentManager>();

#endregion

#region Token Service

builder.Services.AddScoped<ITokenService, TokenService>();

#endregion

#region Identity

builder.Services.AddIdentity<AppUser, IdentityRole>(options =>
    {
        options.Password.RequireDigit = true;
        options.Password.RequireLowercase = true;
        options.Password.RequireUppercase = true;
        options.Password.RequireNonAlphanumeric = true;
        options.Password.RequiredLength = 12;
    })
    .AddEntityFrameworkStores<FinPulseContext>();

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme =
        options.DefaultChallengeScheme =
            options.DefaultForbidScheme =
                options.DefaultScheme =
                    options.DefaultSignInScheme =
                        options.DefaultSignOutScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = false,
        ValidateAudience = false,
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(
            System.Text.Encoding.UTF8.GetBytes(builder.Configuration["SigningKey"])
        )
    };
});

#endregion

var app = builder.Build();

// Configure the HTTP request pipeline.

#region Middlewares

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

#endregion

app.Run();