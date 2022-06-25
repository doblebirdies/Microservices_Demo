using AutoMapper;
using ms.communcations.rabbitmq.Events;
using ms.storage.application.DTOs;
using ms.storage.application.Notifications;
using ms.storage.domain.Entities;

namespace ms.storage.application.Mappers
{
    public class ProductMapperProfile : Profile
    {
        public ProductMapperProfile()
        {
            CreateMap<Product, ProductDto>().ReverseMap();
            CreateMap<Product, ProductCreateDto>().ReverseMap();
            CreateMap<PreparedProductNotification, PreparedProductEvent>().ReverseMap();
        }
    }
}
