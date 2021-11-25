using AutoMapper;
using EasyCSharpApi.DAL;
using EasyCSharpApi.DTOs;
using EasyCSharpApi.Services.Abstractions;
using EasyCSharpApi.UnitOfWork.Abstraction;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EasyCSharpApi.Services
{
    public class AnswerService:IAnswerService
    {
        private IUnitOfWork _unitOfWork;
        private IMapper _mapper;

        public AnswerService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public List<AnswerDTO> CreateAnswer(List<AnswerDTO> answers)
        {
            var userId = answers.Select(x => x.UserId).FirstOrDefault();
            var seq = _unitOfWork.AnswerRepository.GetMaxAttemptSeq(userId)+1;
            foreach (var answer in answers)
            {
                answer.AttemtpSequence = seq;
                answer.DateOfAnswer = DateTime.Now;
                var mappedAnswer = _mapper.Map<AnswerDTO, Answer>(answer);
                mappedAnswer = _unitOfWork.AnswerRepository.Add(mappedAnswer);
                answer.Id = mappedAnswer.Id;
            }
            _unitOfWork.Save();

            return answers;
        }

        public List<AnswerDTO> GetAnswerByTaskId(int taskId, int take, int skip)
        {
            var list = _unitOfWork.AnswerRepository.GetAnswerByTaskId(taskId, take, skip);
            var result = _mapper.Map<List<Answer>,List< AnswerDTO> > (list);

            return result;
        }

        public List<AnswerDTO> GetLastAnswer(int userId)
        {
            var list = _unitOfWork.AnswerRepository.GetLastAnswer(userId);
            var result = _mapper.Map<List<Answer>, List<AnswerDTO>>(list);

            return result;
        }

        public List<StatisticDTO> GetStatistic(int userId)
        {
            var answers = _unitOfWork.AnswerRepository.GetAll(x => x.UserId == userId).Include(x=>x.Task).ThenInclude(x=>x.Title).ToList();
            var statistics = new List<StatisticDTO>();
            foreach(var answer in answers)
            {
                var item = statistics.Find(x => x.AttemptSequence == answer.AttemtpSequence);
                if (item != null)
                {
                    var statItem = new StatisticItemDTO()
                    {
                        DificultyCoef = (double)answer.Task.DificultyCoef,
                        Mark = (double)answer.CorrectnessPercent,
                        TimeOfExecution = answer.TimeOfExecution,
                        TaskTitle = answer.Task.Content
                    };
                    var index = statistics.IndexOf(item);
                    statistics[index].StatisticItems.Add(statItem);
                }
                else
                {
                    item = new StatisticDTO()
                    {
                        AttemptSequence = answer.AttemtpSequence,
                        Title = answer.Task.Title.TitleName,
                        DateOfAnswer = answer.DateOfAnswer, 
                        StatisticItems = new List<StatisticItemDTO>()
                    };
                    var statItem = new StatisticItemDTO()
                    {
                        DificultyCoef = (double)answer.Task.DificultyCoef,
                        Mark = (double)answer.CorrectnessPercent,
                        TimeOfExecution = answer.TimeOfExecution,
                        TaskTitle = answer.Task.Content
                    };
                    item.StatisticItems.Add(statItem);
                    statistics.Add(item);
                }
            }

            foreach(var stat in statistics)
            {
                var totalCoef = stat.StatisticItems.Sum(x => x.DificultyCoef);
                foreach(var item in stat.StatisticItems)
                {
                    item.MarkInfluence = item.DificultyCoef / totalCoef;
                }
                stat.Mark = stat.StatisticItems.Sum(x => x.Mark * x.MarkInfluence);
            }
            statistics.OrderBy(x => x.DateOfAnswer);
            return statistics;
        }
        
    }
}
