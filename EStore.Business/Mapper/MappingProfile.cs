using AutoMapper;
using EStore.Business.DTOs;
using EStore.Data.Models;

namespace MentorLink.Business.Mapper;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Order, OrderDTO>()
            .ForMember(dest => dest.MemberEmail, opt => opt.MapFrom(src => src.Member.Email))
            .ReverseMap();

        CreateMap<Product, CreateProductOrderDTO>()
            .ReverseMap();
    }
}

