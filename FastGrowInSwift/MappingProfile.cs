using AutoMapper;
using EasyCSharpApi.DAL;
using EasyCSharpApi.DTOs;

namespace EasyCSharpApi
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User, UserDTO>().ReverseMap();
            CreateMap<AnswerOptionEtalon, TaskItemDTO>().ReverseMap();
            CreateMap<Task, TaskDTO>()
                .ForMember(x => x.TaskItems, opt => opt.MapFrom(x => x.AnswerOptionEtalons))
                .ForMember(x => x.TitleName, opt => opt.MapFrom(x => x.Title.TitleName))
                .ForMember(x => x.TypeName, opt => opt.MapFrom(x => x.Type.TypeName));
            CreateMap<TaskDTO, Task>()
                .ForMember(x => x.AnswerOptionEtalons, opt => opt.MapFrom(x => x.TaskItems));
            CreateMap<Title, TitleDTO>().ReverseMap();
            CreateMap<Type, TypeDTO>().ReverseMap();
            CreateMap<AnswerItem, AnswerItemDTO>().ReverseMap();
            CreateMap<Answer, AnswerDTO>().ReverseMap();
            CreateMap<ProgressItem, ProgressItemDTO>().ReverseMap();
            CreateMap<Progress, ProgressDTO>().ForMember(x => x.ProgressItems, opt => opt.MapFrom(x => x.ProgresItems));
            CreateMap<ProgressDTO, Progress>().ForMember(x => x.ProgresItems, opt => opt.MapFrom(x => x.ProgressItems));

        }

    }
}
