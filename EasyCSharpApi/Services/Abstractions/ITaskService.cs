using EasyCSharpApi.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EasyCSharpApi.Services.Abstractions
{
    public interface ITaskService
    {
        List<TaskDTO> GetTaskByTitleId(int titleId, int take, int skip);
        int CreateTask(TaskDTO task);
        List<TitleDTO> GetAllTitles();
        List<TypeDTO> GetAllTypes();
        int CreateTitle(TitleDTO title);
        int CreateType(TypeDTO type);

    }
}
