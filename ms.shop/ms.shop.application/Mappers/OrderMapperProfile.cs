﻿using AutoMapper;
using ms.communications.rabbitmq.Events;
using ms.shop.application.Commands;
using ms.shop.application.DTOs;
using ms.shop.domain.Entities;

namespace ms.shop.application.Mappers
{
    public class OrderMapperProfile : Profile
    {
        public OrderMapperProfile()
        {
            CreateMap<Order, OrderDto>().ReverseMap();
            CreateMap<Order, OrderCreateDto>().ReverseMap();
            CreateMap<OrderCreateDto, OrderCreatedEvent>().ReverseMap();
        }
    }
}
