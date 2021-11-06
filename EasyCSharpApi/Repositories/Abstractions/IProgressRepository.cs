using EasyCSharpApi.DAL;
using System.Linq;

namespace EasyCSharpApi.Repositories.Abstractions
{
    public interface IProgressRepository : IRepository<Progress>
    {
        IQueryable<Progress> GetAllByUserId(int userId);
    }
}
