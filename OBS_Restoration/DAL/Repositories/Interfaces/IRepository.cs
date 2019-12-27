using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace DAL.Repositories.Interfaces
{
    public interface IRepository<T> where T : class
    {
        T Get(long id);
        IQueryable<T> All();
        T Get(Expression<Func<T, bool>> where, string include = null);
        U Get<U>(Expression<Func<T, bool>> where, Expression<Func<T, U>> selector, string include = null);

        IEnumerable<T> Find(Expression<Func<T, bool>> where, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, string includes = null);
        IEnumerable<U> Find<U>(Expression<Func<T, bool>> where, Expression<Func<T, U>> selector, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, string includes = null);

        void Add(T entity);
        void Update(T entity);
        void AddRange(IEnumerable<T> entities);
        void Remove(T entity);
        void RemoveRange(IEnumerable<T> entities);
        void Remove(long id);
        int Count(Expression<Func<T, bool>> where, string includes = null);
        bool Any(Expression<Func<T, bool>> where);
    }
}
