using System;
using EasyCSharpApi.DTOs;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using EasyCSharpApi.Services.Abstractions;

namespace EasyCSharpApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TaskController : ControllerBase
    {
        private ITaskService _taskService;
        public TaskController(ITaskService taskService)
        {
            _taskService = taskService;
        }

        [HttpGet]
        [Route("get-by-title-id/{titleId}/{take}/{skip}")]
        public ActionResult<List<TaskDTO>> GetById(int titleId, int take, int skip)
        {
            var result = _taskService.GetTaskByTitleId(titleId, take, skip);

            return result;
        }

        [HttpGet]
        [Route("get-all-titles")]
        public ActionResult<List<TitleDTO>> GetAllTitles()
        {
            var result = _taskService.GetAllTitles();

            return result;
        }

        [HttpGet]
        [Route("get-all-types")]
        public ActionResult<List<TypeDTO>> GetAllTypes()
        {
            var result = _taskService.GetAllTypes();

            return result;
        }

        [HttpPost]
        [Route("create-task")]
        public ActionResult<int> CreateTask(TaskDTO taskDTO)
        {
            try
            {
                var result = _taskService.CreateTask(taskDTO);

                return result;
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("create-title")]
        public ActionResult<int> CreateTitle(TitleDTO title)
        {
            try
            {
                var result = _taskService.CreateTitle(title);

                return result;
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("create-type")]
        public ActionResult<int> CreateType(TypeDTO type)
        {
            try
            {
                var result = _taskService.CreateType(type);

                return result;
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
