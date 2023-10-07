using Autofac.Extensions.DependencyInjection;
using AutoMapper;
using Data;
using Data.Contracts;
using Data.Repository;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAutoMapper(typeof(Program));

// Add services to the container.

builder.Services.AddScoped<DapperContext>();
builder.Services.AddScoped<ICompanyRepository, CompanyRepository>();

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

app.UseAuthorization();

app.MapControllers();

app.Run();
