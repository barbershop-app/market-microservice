using AutoMapper;
using microservice.Infrastructure.Entities.DB;
using microservice.Infrastructure.Entities.DTOs;

namespace microservice.Web.API.Internal
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            // CartItem
            CreateMap<CartItemDTOs.Create, CartItem>();
            CreateMap<CartItemDTOs.Update, CartItem>();

            // Category
            CreateMap<CategoryDTOs.Create, Category>();
            CreateMap<CategoryDTOs.Update, Category>();

            // Product
            CreateMap<ProductDTOs.Create, Product>();
            CreateMap<ProductDTOs.Update, Product>();
        }
    }
}
