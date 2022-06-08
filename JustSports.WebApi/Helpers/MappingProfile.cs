using AutoMapper;
using JustSports.Core.Entities;
using JustSports.WebApi.Models;

namespace JustSports.WebApi.Helpers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //### Model to Resource mapping
            CreateMap<Category, CategoryData>();
            CreateMap<Category, SaveCategoryData>();

            CreateMap<Product, ProductData>();

            CreateMap<Customer, CustomerData>();
            CreateMap<Customer, AccountSignupResponse>();
            CreateMap<Customer, AuthenticateAccount>();

            //### Resource to Model mapping
            CreateMap<CategoryData, Category>();
            CreateMap<SaveCategoryData, Category>();

            CreateMap<CustomerData, Customer>();
            CreateMap<AccountSignup, Customer>();
            CreateMap<AuthenticateAccount, Customer>();


        }
    }
}
