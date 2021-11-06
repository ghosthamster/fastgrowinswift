using System;
using EasyCSharpApi.DTOs;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using EasyCSharpApi.Services.Abstractions;

namespace EasyCSharpApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProgressController : ControllerBase
    {
        private IProgressService _progressService;

        public ProgressController(IProgressService progressService)
        {
            _progressService = progressService;
        }

        [HttpGet]
        [Route("get-by-user-task")]
        public ActionResult<ProgressDTO> GetByUserIdAndTaskId(int taskId, int userId)
        {
            var result = _progressService.GetProgressByTaskIdAndUserId(taskId, userId);

            return result;
        }

        [HttpGet]
        [Route("get-by-user")]
        public ActionResult<List<ProgressDTO>> GetByUserId(int userId)
        {
            var result = _progressService.GetAllUserProgresses(userId);

            return result;
        }

        [HttpPost]
        [Route("add-progress")]
        public ActionResult<int> AddProgress(ProgressDTO progressDTO)
        {
            try
            {
                var result = _progressService.CreateProgress(progressDTO);

                return result;
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Route("update-progress")]
        public ActionResult<ProgressDTO> UpdateProgress(ProgressDTO progressDTO)
        {
            try
            {
                var result = _progressService.UpdateProgress(progressDTO);

                return result;
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Route("delete-progress/{userId}/{taskId}")]
        public ActionResult<int> DeleteProgress(int userId, int taskId)
        {
            try
            {
                _progressService.DeleteProgress(userId, taskId);

                return Ok();
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
