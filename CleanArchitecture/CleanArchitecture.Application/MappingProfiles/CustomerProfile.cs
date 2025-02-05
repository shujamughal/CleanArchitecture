using AutoMapper;
using CleanArchitecture.Domain;

namespace CleanArchitecture.Application.MappingProfiles
{
    public class CustomerProfile : Profile
    {
        public CustomerProfile()
        {
            // Define a two-way mapping between Customer and CustomerDTO.
            CreateMap<Customer, CustomerDTO>().ReverseMap();
        }
    }
}
