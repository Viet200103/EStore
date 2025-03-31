using AutoMapper;
using EStore.Business.DTOs;
using EStore.Data.Models;

namespace EStore.Business.Mapper;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<CreateMemberDTO, Member>().ForMember(dest => dest.MemberId, opt => opt.Ignore());
    }
}