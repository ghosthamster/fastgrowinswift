using EasyCSharpApi.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EasyCSharpApi.Services.Abstractions
{
    public interface IAnswerService
    {
        List<AnswerDTO> CreateAnswer(List<AnswerDTO> answer);
        List<AnswerDTO> GetAnswerByTaskId(int taskId, int take, int skip);
        List<AnswerDTO> GetLastAnswer(int userId);
        List<StatisticDTO> GetStatistic(int userId);
    }
}
