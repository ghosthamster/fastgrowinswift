using EasyCSharpApi.DAL;
using EasyCSharpApi.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EasyCSharpApi.Services.Abstractions
{
    public interface IAccountService
    {
        int? Login(UserDTO user);
        int? Register(UserDTO user);
        UserDTO GetUserById(int id);
    }
}
