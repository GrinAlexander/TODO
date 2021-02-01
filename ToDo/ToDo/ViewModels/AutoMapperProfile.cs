using AutoMapper;
using ToDo.Models;

namespace ToDo.ViewModels
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<ToDoItem, ToDoItemViewModel>().ReverseMap();

            CreateMap<ToDoItem, ToDoItemUpdateModel>();
            CreateMap<ToDoItemUpdateModel, ToDoItem>()
               .ReverseMap();

            CreateMap<ToDoItem, ToDoItemCreateModel>();
            CreateMap<ToDoItemCreateModel, ToDoItem>()
                .ReverseMap();
        }
    }
}
