using AutoMapper;
using EStore.Business.DTOs;
using EStore.Data.Models;

namespace MentorLink.Business.Mapper;

public class CommonMapperProfile : Profile
{
    public CommonMapperProfile()
    {
        CreateMap<Product , ProductDTO>().ReverseMap();
        CreateMap<Order, OrderDTO>().ReverseMap();
        CreateMap<OrderDetail , OrderDetailDTO>().ReverseMap();
        CreateMap<Member, MemberDTO>().ReverseMap();
        CreateMap<Category, CategoryDTO>().ReverseMap();
    }
}