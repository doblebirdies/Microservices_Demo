using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ms.communcations.rabbitmq.Producers;
using ms.shop.application.Commands;
using ms.shop.application.Mappers;
using ms.shop.application.Services;
using ms.shop.domain.Interfaces;
using ms.shop.infrastructure.Data;
using ms.shop.infrastructure.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ApplicationDbContext>(opt => {
    opt.UseSqlServer(builder.Configuration.GetConnectionString("DbConn"));
});

builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddScoped<IEmailSender, EmailSender>();
builder.Services.AddScoped<IStorageApi, StorageService>();
builder.Services.AddScoped(typeof(IProducer), typeof(EventProducer));

builder.Services.AddMediatR(typeof(CreateOrderCommand).Assembly); 

var automapperConfig = new MapperConfiguration(mapperConfig =>
{ mapperConfig.AddMaps(typeof(OrderMapperProfile).Assembly); });
IMapper mapper = automapperConfig.CreateMapper();
builder.Services.AddSingleton(mapper);

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
