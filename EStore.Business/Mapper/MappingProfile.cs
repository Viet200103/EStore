using AutoMapper;
using EStore.Business.DTOs;
using EStore.Data.Models;

namespace MentorLink.Business.Mapper;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Product, ProductDTO>().ReverseMap();
        CreateMap<Product, CreateProductDTO>().ReverseMap();
        CreateMap<Category, AddCategoryDTO>().ReverseMap();
    }
}