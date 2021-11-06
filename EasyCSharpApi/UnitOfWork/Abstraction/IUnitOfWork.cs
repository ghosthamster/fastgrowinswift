using EasyCSharpApi.Repositories.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EasyCSharpApi.UnitOfWork.Abstraction
{
    public interface IUnitOfWork : IDisposable
    {
        public IAccountRepository AccountRepository { get; }
        public ITaskRepository TaskRepository { get; }
        public IAnswerRepository AnswerRepository { get; }
        public IProgressRepository ProgressRepository { get; }
        void Save();
    }

}
