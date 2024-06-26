using API.DTO;
using AutoMapper;
using Domain.Abstractions.Orders;
using Infrastructure.DataAccess.Entities;

namespace Infrastructure.AutoMapper;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Order, IOrder>()
            .ConstructUsing(source => new Domain.Models.Orders.Order
            {
                OrderId = source.OrderId,
                SenderCity = source.SenderCity,
                SenderAddress = source.SenderAddress,
                ReceiverCity = source.ReceiverCity,
                ReceiverAddress = source.ReceiverAddress,
                Weight = source.Weight,
                PickupDate = source.PickupDate
            }).ReverseMap();
        
        CreateMap<Order, Domain.Models.Orders.Order>()
            .ForMember(dest => dest.OrderId, act => act.MapFrom(src => src.OrderId))
            .ForMember(dest => dest.SenderCity, act => act.MapFrom(src => src.SenderCity))
            .ForMember(dest => dest.SenderAddress, act => act.MapFrom(src => src.SenderAddress))
            .ForMember(dest => dest.ReceiverCity, act => act.MapFrom(src => src.ReceiverCity))
            .ForMember(dest => dest.ReceiverAddress, act => act.MapFrom(src => src.ReceiverAddress))
            .ForMember(dest => dest.Weight, act => act.MapFrom(src => src.Weight))
            .ForMember(dest => dest.PickupDate, act => act.MapFrom(src => src.PickupDate))
            .ReverseMap();

        CreateMap<OrderCreateDto, Domain.Models.Orders.Order>()
            .ForMember(dest => dest.SenderCity, opt => opt.MapFrom(src => src.SenderCity))
            .ForMember(dest => dest.SenderAddress, opt => opt.MapFrom(src => src.SenderAddress))
            .ForMember(dest => dest.ReceiverCity, opt => opt.MapFrom(src => src.ReceiverCity))
            .ForMember(dest => dest.ReceiverAddress, opt => opt.MapFrom(src => src.ReceiverAddress))
            .ForMember(dest => dest.Weight, opt => opt.MapFrom(src => src.Weight))
            .ForMember(dest => dest.PickupDate, opt => opt.MapFrom(src => src.PickupDate));

        CreateMap<Domain.Models.Orders.Order, OrderDto>();
    }
}