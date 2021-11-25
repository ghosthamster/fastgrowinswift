using EasyCSharpApi.DTOs;
using System.Collections.Generic;

namespace EasyCSharpApi.Services.Abstractions
{
    public interface IProgressService
    {
        int CreateProgress(ProgressDTO progress);
        ProgressDTO UpdateProgress(ProgressDTO progress);
        void DeleteProgress(int userId, int taskId);
        ProgressDTO GetProgressByTaskIdAndUserId(int taskId, int userId);
        List<ProgressDTO> GetAllUserProgresses(int userId);
    }
}
