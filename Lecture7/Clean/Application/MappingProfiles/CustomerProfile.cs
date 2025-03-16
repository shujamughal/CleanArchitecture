using Application.Features.Customer.Commands.CreateCustomer;
using Application.Features.Customer.Queries.GetAllCustomers;
using Application.Features.Customer.Queries.GetCustomerDetails;
using AutoMapper;
using Domain;

namespace Application.MappingProfiles
{
    public class CustomerProfile : Profile
    {
        public CustomerProfile()
        {
            CreateMap<CustomerDTO, Customer>().ReverseMap();
            CreateMap<CustomerDetailsDTO, Customer>().ReverseMap();
            CreateMap<CreateCustomerCommand, Customer>().ReverseMap();
        }
    }
}
