using MediatR;
using Microsoft.EntityFrameworkCore;
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

builder.Services.AddMediatR(typeof(CreateOrderCommand).Assembly); // .GetExecutingAssembly());
//builder.Services.AddScoped<IMapper, Mapper>();  
builder.Services.AddAutoMapper(typeof(OrderMapperProfile).Assembly);

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
