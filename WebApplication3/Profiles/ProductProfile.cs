using AutoMapper;
using Domain.Dtos;
using Domain.Entities;
namespace WebApplication3.Profiles
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<Product, ProductDto>();
            CreateMap<ProductDto, Product>();
        }
    }
}