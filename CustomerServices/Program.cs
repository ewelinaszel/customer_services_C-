using CustomerServices.DataAccessLayer;
using CustomerServices.DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using MediatR;
using AutoMapper;
using CustomerServices;

var builder = WebApplication.CreateBuilder(args);
var config = new MapperConfiguration(cfg => cfg.CreateMap<Customer, ListCustomersResult>());

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());
builder.Services.AddMediatR(Assembly.GetExecutingAssembly());
builder.Services.AddDbContext<IContext, Context>(options => options.UseSqlite("Filename=Database"));

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
