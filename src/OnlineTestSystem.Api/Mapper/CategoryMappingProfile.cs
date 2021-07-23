using AutoMapper;
using OnlineTestSystem.Api.Models;
using OnlineTestSystem.Api.Models.Dto;

namespace OnlineTestSystem.Api.Mapper
{
    public class CategoryMappingProfile : Profile
    {
        public CategoryMappingProfile()
        {
            CreateMap<Category, CategoryResponse>();
        }        
    }
}
