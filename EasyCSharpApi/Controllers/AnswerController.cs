using System;
using EasyCSharpApi.DTOs;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using EasyCSharpApi.Services.Abstractions;

namespace EasyCSharpApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AnswerController : ControllerBase
    {
        private IAnswerService _answerService;
        private IValidationService _validationService;
        private IProgressService _progressService;
        public AnswerController(IAnswerService answerService, IValidationService validationService, IProgressService progressService)
        {
            _answerService = answerService;
            _validationService = validationService;
            _progressService = progressService;
        }

        [HttpGet]
        [Route("get-by-task-id")]
        public ActionResult<List<AnswerDTO>> GetById(int taskId, int take, int skip)
        {
            var result = _answerService.GetAnswerByTaskId(taskId, take, skip);

            return result;
        }

        [HttpGet]
        [Route("get-last/{userId}")]
        public ActionResult<List<AnswerDTO>> GetLastAnswer(int userId)
        {
            var result = _answerService.GetLastAnswer(userId);

            return result;
        }
        [HttpGet]
        [Route("get-statistics/{userId}")]
        public ActionResult<List<StatisticDTO>> GetStatistic(int userId)
        {
            var result = _answerService.GetStatistic(userId);

            return result;
        }


        [HttpPost]
        [Route("create-answers")]
        public ActionResult<List<AnswerDTO>> CreateAnswers(List<AnswerDTO> answersDTO)
        {
            try
            {
                var result = _answerService.CreateAnswer(answersDTO);

                return result;
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("validate-last/{userId}")]
        public ActionResult<List<AnswerDTO>> ValidateLastAnswer(int userId)
        {
            var result = _answerService.GetLastAnswer(userId);
            var resultList = new List<AnswerDTO>();
            foreach(var answer in result)
            {
                _progressService.DeleteProgress(userId, answer.TaskId.Value);
                resultList.Add(_validationService.ValidateAnswer(answer.Id));
            }

            return resultList;
        }

    }
}
