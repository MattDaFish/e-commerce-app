using AutoMapper;
using JustSports.Core.Entities;
using JustSports.Core.Entities.BasketAggregate;
using JustSports.Core.Entities.OrderAggregate;
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

            CreateMap<Basket, BasketData>();
            CreateMap<BasketItem, BasketItemData>();

            CreateMap<Order, OrderData>();
            CreateMap<OrderItem, OrderItemData>();

            //### Resource to Model mapping
            CreateMap<CategoryData, Category>();
            CreateMap<SaveCategoryData, Category>();

            CreateMap<CustomerData, Customer>();
            CreateMap<AccountSignup, Customer>();
            CreateMap<AuthenticateAccount, Customer>();

            CreateMap<BasketData, Basket>();
            CreateMap<BasketItemData, BasketItem>();

            //CreateMap<SaveBasketData, Basket>();
        }
    }
}
