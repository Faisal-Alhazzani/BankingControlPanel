using BankingControlPanel.Core.Interfaces.Services;
using BankingControlPanel.Persistence.Contexts;
using BankingControlPanel.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// configure EF with SQL Server
builder.Services.AddDbContext<BankingControlPanelContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("AppDBConnectionString"));
});

// configure Identity 
builder.Services.AddIdentity<IdentityUser, IdentityRole>(options =>
{
    options.Password.RequireDigit = true;
    options.Password.RequireUppercase = true;
    options.Password.RequiredLength = 5;
    options.Password.RequiredUniqueChars = 1;
}).AddEntityFrameworkStores<BankingControlPanelContext>()
  .AddDefaultTokenProviders();

// configure auth
builder.Services.AddAuthentication(auth =>
{
    auth.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    auth.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidAudience = "https://github.com/Faisal-Alhazzani",
        ValidIssuer = "https://github.com/Faisal-Alhazzani",
        RequireExpirationTime = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("This is the key for encryption")),
        ValidateIssuerSigningKey = true
    };
});

builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(s =>
{
    s.EnableAnnotations();
});

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
