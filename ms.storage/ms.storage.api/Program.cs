using MediatR;
using Microsoft.EntityFrameworkCore;
using ms.communcations.rabbitmq.Consumers;
using ms.communcations.rabbitmq.Middlewares;
using ms.communcations.rabbitmq.Producers;
using ms.storage.api.Consumers;
using ms.storage.application.Commands;
using ms.storage.application.Mappers;
using ms.storage.domain.Interfaces;
using ms.storage.infrastructure.Data;
using ms.storage.infrastructure.Repository;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped(typeof(IProducer), typeof(EventProducer));
builder.Services.AddDbContext<ApplicationDbContext>(opt =>
{
    opt.UseSqlServer(builder.Configuration.GetConnectionString("DbConn"));
});
builder.Services.AddAutoMapper(typeof(ProductMapperProfile).Assembly);
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddMediatR(typeof(CreateProductCommand).Assembly);

builder.Services.AddSingleton(typeof(IConsumer), typeof(ProductConsumer));

builder.Services.AddHostedService<UseRabbitConsumer>();


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
