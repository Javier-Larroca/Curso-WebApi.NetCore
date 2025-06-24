using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MiPrimerWebApi.Api.Routes;
using MiPrimerWebApi.Bussiness;
using MiPrimerWebApi.DataAccess.Contexto;
using MiPrimerWebApi.DataAccess.DbInitializer;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<BibliotecaDbContext>(
    options => options.UseSqlServer(builder.Configuration.GetConnectionString("BibliotecaConnectionString"))
    );

builder.Services.AddDbContext<TodoDbContext>(
    options => options.UseSqlServer(builder.Configuration.GetConnectionString("TodoConnectionString"))
    );

builder.Services.AddScoped<IAutoresService, AutoresService>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.CreateDbIfNotExist();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.MapValuesRoutes();

app.MapTodosRoutes();

app.Run();
