using AutoMapper;
using GeekShopping.CartAPI.Data.ValueObjects;
using GeekShopping.CartAPI.Model;

namespace GeekShopping.CartAPI.Mappings
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<ProductVO, Product>().ReverseMap();
            CreateMap<CartHeaderVO, CartHeader>().ReverseMap();
            CreateMap<CartDetailVO, CartDetail>().ReverseMap();
            CreateMap<CartVO, Cart>().ReverseMap();
        }
    }
}
