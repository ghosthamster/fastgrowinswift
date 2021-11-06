using EasyCSharpApi.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EasyCSharpApi.Repositories.Abstractions
{
    public interface IAnswerRepository:IRepository<Answer>
    {
        int GetMaxAttemptSeq(int userId);
        List<Answer> GetAnswerByTaskId(int taskId, int take, int skip);
        List<Answer> GetLastAnswer(int userId);
    }
}
