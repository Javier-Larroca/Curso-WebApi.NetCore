using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using MiPrimerWebApi.Api.Routes;
using MiPrimerWebApi.Bussiness;
using MiPrimerWebApi.DataAccess.Contexto;
using MiPrimerWebApi.DataAccess.DbInitializer;
using MiPrimerWebApi.Middlewares;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<BibliotecaDbContext>(
    options => options.UseSqlServer(builder.Configuration.GetConnectionString("BibliotecaConnectionString"))
    );

builder.Services.AddDbContext<TodoDbContext>(
    options => options.UseSqlServer(builder.Configuration.GetConnectionString("TodoConnectionString"))
    );

//builder.Services.AddDbContext<JsonplaceholderContext>(
//    options => options.UseSqlite("")
//    );

builder.Services.AddScoped<IAutoresService, AutoresService>();
builder.Services.AddScoped<ILibrosService, LibrosService>();

builder.Services.AddScoped<LoggerMiddleware>();
builder.Services.AddScoped<LoggerActionFilter>();
builder.Services.AddScoped<GlobalFilter>();

builder.Services.AddControllers(
        options =>
        {
            options.Filters.Add<GlobalFilter>();
        }
    );

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(
    c =>
    {
        c.SwaggerDoc("v1", new OpenApiInfo { Title = "Biblioteca API", Version = "v1" });

        c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
        {
            In = ParameterLocation.Header,
            Description = "Please enter JWT with Bearer into field",
            Name = "Authorization",
            Type = SecuritySchemeType.ApiKey,
            Scheme = "Bearer"
        });

        c.AddSecurityRequirement(new OpenApiSecurityRequirement
{
    {
        new OpenApiSecurityScheme
        {
            Reference = new OpenApiReference
            {
                Type = ReferenceType.SecurityScheme,
                Id = "Bearer"
            }
        },
        new string[] {}
    }
});

    }
    );

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(
    options =>
        {
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = "JavierIssuer",
                ValidAudience = "JavierAudience",
                IssuerSigningKey = new SymmetricSecurityKey(
                    Encoding.UTF8.GetBytes(builder.Configuration["Jwt_Secret"]!))
            };
        }
    );

var app = builder.Build();

app.CreateDbIfNotExist();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<LoggerMiddleware>();

app.Use(async (context, next) =>
{
    Console.WriteLine($"{context.Request.Method}");
    await next(context);
    Console.WriteLine($"{context.Request.Method}");
});

app.UseMiddleware<ConventionMiddleware>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.MapValuesRoutes();

app.MapTodosRoutes();

app.Run();
