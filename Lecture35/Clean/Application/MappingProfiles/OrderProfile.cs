using Application.Features.Order.Commands.CreateOrder;
using Application.Features.Order.Commands.UpdateOrder;
using Application.Features.Order.Queries.GetAllOrders;
using Application.Features.Order.Queries.GetOrderDetails;
using AutoMapper;
using Domain;

namespace Application.MappingProfiles
{
    public class OrderProfile : Profile
    {
        public OrderProfile()
        {
            CreateMap<OrderDTO, Order>().ReverseMap();
            CreateMap<OrderDetailsDTO, Order>().ReverseMap();
            CreateMap<CreateOrderCommand, Order>().ReverseMap();
            CreateMap<UpdateOrderCommand, Order>().ReverseMap();
        }
    }
}