using EasyCSharpApi.DAL;
using EasyCSharpApi.Repositories.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EasyCSharpApi.Repositories
{
    public class AccountRepository : BaseRepository<User>, IAccountRepository
    {
        public AccountRepository(EasyCSharpDBContext context) : base(context)
        {
        }

        public int? Authenticate(User user)
        {
            var result = _context.Users.Where(us => us.Login == user.Login && us.Password == user.Password).FirstOrDefault();

            return result?.Id;
        }
    }
}
