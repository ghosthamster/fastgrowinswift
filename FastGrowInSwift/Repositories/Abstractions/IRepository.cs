using EasyCSharpApi.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace EasyCSharpApi.Repositories.Abstractions
{
    public interface IRepository<TEntity> where TEntity : IEntity<int>
    {
        TEntity GetById(int id);

        IQueryable<TEntity> GetAll();

        IQueryable<TEntity> GetAll(Expression<Func<TEntity, bool>> predicate);

        TEntity Add(TEntity entity);

        void Delete(int id);

        TEntity Edit(TEntity entity);
    }

}
