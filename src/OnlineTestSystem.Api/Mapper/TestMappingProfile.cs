using AutoMapper;
using OnlineTestSystem.Api.Models;
using OnlineTestSystem.Api.Models.Dto;

namespace OnlineTestSystem.Api.Mapper
{
    public class TestMappingProfile : Profile
    {
        public TestMappingProfile()
        {
            CreateMap<Test, TestResponse>()
                .ForMember(t => t.QuestionCount, opt => opt.MapFrom(src => src.ApplicationUsers.Count))
                .ForMember(t => t.CategoryName, opt => opt.MapFrom(src => src.Category != null ? src.Category.Name : null));
        }        
    }
}
