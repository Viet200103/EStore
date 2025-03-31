using AutoMapper;
using EStore.Business.DTOs;
using EStore.Data.Models;

namespace MentorLink.Business.Mapper;

public class CommonMapperProfile : Profile
{
    public CommonMapperProfile()
    {
        CreateMap<Member, MemberDTO>().ReverseMap();
    }
}