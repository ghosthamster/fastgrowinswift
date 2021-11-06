using EasyCSharpApi.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EasyCSharpApi.Repositories.Abstractions
{
    public interface IAccountRepository:IRepository<User>
    {
        int? Authenticate(User user);
    }
}
