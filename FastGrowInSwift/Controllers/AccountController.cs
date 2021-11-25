using System;
using EasyCSharpApi.DTOs;
using Microsoft.AspNetCore.Mvc;
using EasyCSharpApi.Services.Abstractions;

namespace EasyCSharpApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AccountController : ControllerBase
    {
        private IAccountService _accountService;
        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpGet]
        [Route("get-by-id/{userId}")]
        public ActionResult<UserDTO> GetById(int userId)
        {
            var result = _accountService.GetUserById(userId);
            if (result != null)
                return result;
            else
                return NotFound();
        }

        [HttpPost]
        [Route("register")]
        public ActionResult<int?> Register(UserDTO user)
        {
            try
            {
                var result = _accountService.Register(user);

                return result;
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("login")]
        public ActionResult<int?> Login(UserDTO user)
        {
            var result = _accountService.Login(user);

            if (result != null)
                return result;
            else
                return BadRequest("Wrong login or password");
        }
    }
}
