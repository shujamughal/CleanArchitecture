using Application.Features.Customer.Queries.GetAllCustomers;
using Application.Features.Customer.Queries.GetCustomerDetails;
using AutoMapper;

public class CustomerProfile : Profile
{
    public CustomerProfile()
    {
        CreateMap<CustomerDTO, Customer>().ReverseMap();
        CreateMap<CustomerDetailsDTO, Customer>().ReverseMap();
    }
}
