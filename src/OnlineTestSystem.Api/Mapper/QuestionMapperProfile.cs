using AutoMapper;
using OnlineTestSystem.Api.Models;
using OnlineTestSystem.Api.Models.Dto;
using System.Linq;

namespace OnlineTestSystem.Api.Mapper
{
    public class QuestionMapperProfile : Profile
    {
        public QuestionMapperProfile()
        {
            CreateMap<TestQuestion, QuestionResponse>().
                ForMember(q => q.Options, opts => opts.MapFrom(q => q.Options.Select(o => o.Value)));
        }
    }
}
