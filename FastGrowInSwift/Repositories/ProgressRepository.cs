using EasyCSharpApi.DAL;
using EasyCSharpApi.Repositories.Abstractions;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace EasyCSharpApi.Repositories
{
    public class ProgressRepository : BaseRepository<Progress>, IProgressRepository
    {
        public ProgressRepository(EasyCSharpDBContext context) : base (context)
        {
        }

        public override IQueryable<Progress> GetAll()
        {
            return base.GetAll().Include(p => p.ProgresItems);
        }

        public IQueryable<Progress> GetAllByUserId(int userId)
        {
            var userProgresses = GetAll().Where(p => p.UserId == userId);
            return userProgresses;
        }
    }
}
