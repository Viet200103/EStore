using AutoMapper;
using EStore.Business.DTOs;
using EStore.Data.Models;

namespace EStore.Business.Mappers
{
    public class CommonMapperProfile : Profile
    {
        public CommonMapperProfile()
        {
            CreateMap<OrderDetail, OrderDetailDTO>()
                .ForMember(dest => dest.ProductName, opt => opt.MapFrom(src => src.Product.ProductName)).ReverseMap();
        }
    }
}
