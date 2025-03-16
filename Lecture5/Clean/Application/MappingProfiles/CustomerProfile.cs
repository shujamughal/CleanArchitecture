using Application.Features.Customer.Queries.GetAllCustomers;
using AutoMapper;

namespace Application.MappingProfiles
{
    public class CustomerProfile : Profile
    {
        public CustomerProfile()
        {
            CreateMap<CustomerDTO, Customer>().ReverseMap();
        }
    }
}
