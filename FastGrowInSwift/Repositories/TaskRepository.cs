using EasyCSharpApi.DAL;
using EasyCSharpApi.Repositories.Abstractions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EasyCSharpApi.Repositories
{
    public class TaskRepository : BaseRepository<Task>, ITaskRepository
    {
        public TaskRepository(EasyCSharpDBContext context) : base(context)
        {
        }

        public int CreateTitle(Title title)
        {
            var found = _context.Titles.Find(title.Id);
            if (found == null)
            {
                var newTitle = _context.Titles.Add(title);
                title.Id = newTitle.Entity.Id;
            }
            else throw new ArgumentException("This value already in the database");

            return title.Id;
        }

        public int CreateType(DAL.Type type)
        {
            var found = _context.Types.Find(type.Id);
            if (found == null)
            {
                var newType = _context.Types.Add(type);
                type.Id = newType.Entity.Id;
            }
            else throw new ArgumentException("This value already in the database");

            return type.Id;
        }

        public List<Title> GetAllTitles()
        {
            return _context.Titles.ToList();
        }

        public List<DAL.Type> GetAllTypes()
        {
            return _context.Types.ToList();
        }

        public List<Task> GetTaskByTitleId(int titleId, int take, int skip)
        {
            var tasks = _context.Tasks.Where(x => x.TitleId == titleId).OrderBy(x => x.DificultyCoef).Skip(skip).Take(take).Include(x=>x.AnswerOptionEtalons);

            return tasks.ToList();
        }
        public new Task GetById(int id)
        {
            return _context.Tasks.Where(x=>x.Id==id).Include(x => x.AnswerOptionEtalons).FirstOrDefault();
        }
    }
}
