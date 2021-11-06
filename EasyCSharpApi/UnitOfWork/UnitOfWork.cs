using EasyCSharpApi.DAL;
using EasyCSharpApi.Repositories;
using EasyCSharpApi.Repositories.Abstractions;
using EasyCSharpApi.UnitOfWork.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EasyCSharpApi.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private IAccountRepository _accountRepository;
        private ITaskRepository _taskRepository;
        private IAnswerRepository _answerRepository;
        private IProgressRepository _progressRepository;
        private EasyCSharpDBContext _context;

        public UnitOfWork(EasyCSharpDBContext context)
        {
            _context = context;

        }

        public IAccountRepository AccountRepository
        {
            get
            {
                return _accountRepository ??= new AccountRepository(_context);
            }
        }
        public ITaskRepository TaskRepository
        {
            get
            {
                return _taskRepository ??= new TaskRepository(_context);
            }
        }
        public IAnswerRepository AnswerRepository
        {
            get
            {
                return _answerRepository ??= new AnswerRepository(_context);
            }
        }

        public IProgressRepository ProgressRepository
        {
            get
            {
                return _progressRepository ??= new ProgressRepository(_context);
            }
        }

        public void Dispose()
        {
            if (_context != null)
            {
                _context.Dispose();
                _context = null;
            }
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }

}
