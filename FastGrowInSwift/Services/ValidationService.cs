using AutoMapper;
using EasyCSharpApi.DAL;
using EasyCSharpApi.DTOs;
using EasyCSharpApi.Services.Abstractions;
using EasyCSharpApi.UnitOfWork.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace EasyCSharpApi.Services
{
    public class ValidationService : IValidationService
    {
        private IUnitOfWork _unitOfWork;
        private IMapper _mapper;

        public ValidationService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public AnswerDTO ValidateAnswer(int id)
        {
            const int minuteInMilis = 60000;
            var answer = _unitOfWork.AnswerRepository.GetById(id);
            var task = _unitOfWork.TaskRepository.GetById(answer.TaskId);
            var answerItems = answer.AnswerItems;
            var taskItems = task.AnswerOptionEtalons;
            int countOfRight = 0;
            var isExpended = false;
            foreach(var answerItem in answerItems)
            {
                if (answerItem.AnswerOptionId != null)
                {
                    var option = taskItems.Where(x => x.Id == answerItem.AnswerOptionId).FirstOrDefault();
                    if (option != null && option.Order==answerItem.Order)
                    {
                        answerItem.CorrectnessPercent = 100;
                        countOfRight++;
                    }
                    else
                    {
                        answerItem.CorrectnessPercent = 0;
                    }
                }
                else
                {
                    isExpended = true;
                    answerItem.CorrectnessPercent = 0;
                    foreach (var option in taskItems)
                    {
                        answerItem.Content=Regex.Replace(answerItem.Content, @"\s+", "");
                        option.Content=Regex.Replace(option.Content, @"\s+", "");
                        if (answerItem.Content.Equals(option.Content))
                        {
                            answerItem.CorrectnessPercent = 100;
                            break;
                        }
                        else
                        {
                            int count = 0;
                            for( int i =0; i < answerItem.Content.Length; i++)
                            {
                                if(option.Content.Length>i && option.Content[i]==answerItem.Content[i])
                                {
                                    count++;
                                }
                                else
                                {
                                    break;
                                }
                            }
                            var correctness = (decimal)count / (decimal)option.Content.Length * 100; 
                            if (correctness > answerItem.CorrectnessPercent)
                                answerItem.CorrectnessPercent = correctness;
                        }
                    }
                }
            }
            var timeLimit = task.DificultyCoef * minuteInMilis;
            var extraTime = answer.TimeOfExecution - timeLimit;
            
            if (!isExpended)
            {
                var countOfAnswers = taskItems.Where(x => x.Order != -1).Count();
                answer.CorrectnessPercent = (decimal)countOfRight / (decimal)countOfAnswers * 100;
            }
            else
            {
                answer.CorrectnessPercent = answerItems.First().CorrectnessPercent;
            }
            if (extraTime > 0)
            {
                answer.CorrectnessPercent -= (decimal)extraTime / 10000;
                if(answer.CorrectnessPercent<0)
                {
                    answer.CorrectnessPercent = 0;
                }
            }
            answer.AnswerItems = answerItems;
            _unitOfWork.AnswerRepository.Edit(answer);
            _unitOfWork.Save();

            return _mapper.Map<Answer, AnswerDTO>(answer);
        }

        public AnswerDTO ValidateAnswer(AnswerDTO answerDTO)
        {
            var answer = _mapper.Map<AnswerDTO, Answer>(answerDTO);
            var task = _unitOfWork.TaskRepository.GetById(answer.TaskId);
            var answerItems = answer.AnswerItems;
            var taskItems = task.AnswerOptionEtalons;
            int countOfRight = 0;
            foreach (var answerItem in answerItems)
            {
                if (answerItem.AnswerOptionId != null)
                {
                    var option = taskItems.Where(x => x.Id == answerItem.AnswerOptionId).FirstOrDefault();
                    if (option != null && option.Order == answerItem.Order)
                    {
                        answerItem.CorrectnessPercent = 100;
                        countOfRight++;
                    }
                    else
                    {
                        answerItem.CorrectnessPercent = 0;
                    }
                }
                else
                {
                    foreach (var option in taskItems)
                    {
                        if (answerItem.Content.Equals(option.Content))
                        {
                            answerItem.CorrectnessPercent = 100;
                            countOfRight++;
                            break;
                        }
                    }
                }
            }
            answer.CorrectnessPercent = (decimal)countOfRight / (decimal)answerItems.Count * 100;
            answer.AnswerItems = answerItems;
            if (answer.Id != 0)
                _unitOfWork.AnswerRepository.Edit(answer);
            else
                _unitOfWork.AnswerRepository.Add(answer);
            _unitOfWork.Save();
            return _mapper.Map<Answer, AnswerDTO>(answer);
        }
    }
}
