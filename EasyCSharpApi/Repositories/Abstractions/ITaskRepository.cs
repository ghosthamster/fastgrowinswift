using EasyCSharpApi.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using Type = EasyCSharpApi.DAL.Type;

namespace EasyCSharpApi.Repositories.Abstractions
{
    public interface ITaskRepository : IRepository<Task>
    {
        List<Task> GetTaskByTitleId(int titleId, int take, int skip);
        List<Title> GetAllTitles();
        List<Type> GetAllTypes();
        int CreateTitle(Title title);
        int CreateType(Type type);
    }
}
