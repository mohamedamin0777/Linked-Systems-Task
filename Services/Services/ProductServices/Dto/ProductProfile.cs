using AutoMapper;
using Core.Entities;

namespace Services.Services.ProductServices.Dto
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<Product, ProductResultDto>().ReverseMap();
        }
    }
}
