using EasyCSharpApi.DAL;
using EasyCSharpApi.Repositories.Abstractions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EasyCSharpApi.Repositories
{
    public class AnswerRepository:BaseRepository<Answer>, IAnswerRepository
    {
        public AnswerRepository(EasyCSharpDBContext context) : base(context)
        {
        }

        public List<Answer> GetAnswerByTaskId(int taskId, int take, int skip)
        {
            var result = _context.Answers.Where(x => x.TaskId == taskId).OrderByDescending(x => x.DateOfAnswer).Include(x => x.AnswerItems);

            return result.Skip(skip).Take(take).ToList();
        }

        public new IQueryable<Answer> GetAll()
        {
            return _context.Answers.Include(x=>x.AnswerItems);
        }

        public List<Answer> GetLastAnswer(int userId)
        {
            var seq = GetMaxAttemptSeq(userId);

            var result = _context.Answers.Where(x => x.AttemtpSequence == seq && x.UserId==userId).Include(x=>x.AnswerItems);

            return result.ToList();
        }

        public int GetMaxAttemptSeq(int userId)
        {
            int result;
            if (_context.Answers.Where(x=>x.UserId == userId).Count() > 0)
                result = _context.Answers.Where(x => x.UserId == userId).Select(x => x.AttemtpSequence).Max();
            else
                result = 0;

            return result;
        }
    }
}
