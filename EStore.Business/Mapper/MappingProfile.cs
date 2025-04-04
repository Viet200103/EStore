﻿using AutoMapper;
using EStore.Business.DTOs;
using EStore.Data.Models;

namespace EStore.Business.Mapper;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Order, OrderDTO>()
            .ForMember(dest => dest.MemberEmail, opt => opt.MapFrom(src => src.Member.Email))
            .ReverseMap();

        CreateMap<Product, CreateProductOrderDTO>().ReverseMap();

        CreateMap<CreateMemberDTO, Member>().ForMember(dest => dest.MemberId, opt => opt.Ignore());
            
        CreateMap<Product, ProductDTO>().ReverseMap();
        CreateMap<Product, CreateProductDTO>().ReverseMap();
        CreateMap<Category, AddCategoryDTO>().ReverseMap();
    }
}
