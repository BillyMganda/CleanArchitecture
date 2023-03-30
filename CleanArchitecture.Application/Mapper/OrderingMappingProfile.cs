using AutoMapper;
using CleanArchitecture.Application.Commands;
using CleanArchitecture.Application.Commands.Brands;
using CleanArchitecture.Application.Commands.Categories;
using CleanArchitecture.Application.Commands.Stores;
using CleanArchitecture.Application.Response;
using CleanArchitecture.Domain.DTOs.Users;
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

            // Category Mapping
            CreateMap<Category, CategoryResponse>().ReverseMap();
            CreateMap<Category, CreateCategoryCommand>().ReverseMap();
            CreateMap<Category, EditCategoryCommand>().ReverseMap();

            // Store Mapping
            CreateMap<Store, StoreResponse>().ReverseMap();
            CreateMap<Store, CreateStoreCommand>().ReverseMap();
            CreateMap<Store, EditStoreCommand>().ReverseMap();

            // Store Mapping
            //CreateMap<User, GetUserDto>().ReverseMap();
            //CreateMap<User, CreateUserCommand>().ReverseMap();
            //CreateMap<User, EditUserCommand>().ReverseMap();
        }
    }
}
