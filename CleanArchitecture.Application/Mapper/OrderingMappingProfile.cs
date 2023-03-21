using AutoMapper;
using CleanArchitecture.Application.Commands;
using CleanArchitecture.Application.Commands.Brands;
using CleanArchitecture.Application.Response;
using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Application.Mapper
{
    public class OrderingMappingProfile : Profile
    {
        public OrderingMappingProfile()
        {
            // Customer Mapping
            CreateMap<Customer, CustomerResponse>().ReverseMap();
            CreateMap<Customer, CreateCustomerCommand>().ReverseMap();
            CreateMap<Customer, EditCustomerCommand>().ReverseMap();

            // Brand Mapping
            CreateMap<Brand, BrandResponse>().ReverseMap();
            CreateMap<Brand, CreateBrandCommand>().ReverseMap();
            CreateMap<Brand, EditBrandCommand>().ReverseMap();
        }
    }
}
