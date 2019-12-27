using DAL.Helpers;
using DAL.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace DAL.Repositories
{
    public class GenericRepository<T> : IRepository<T> where T : class
    {
        protected DbContext context;
        protected DbSet<T> dbSet;

        public GenericRepository(DbContext context)
        {
            this.context = context;
            this.dbSet = this.context.Set<T>();
        }

        public IQueryable<T> All()
        {
            return dbSet.AsQueryable();
        }

        public IQueryable<T> All(string include)
        {
            return this.Include(dbSet.AsQueryable(), include);
        }

        public virtual void Add(T entity)
        {
            dbSet.Add(entity);
        }

        public virtual void AddRange(IEnumerable<T> entities)
        {
            dbSet.AddRange(entities);
        }

        public virtual void Update(T entity)
        {
            dbSet.Attach(entity);
            var entry = context.Entry(entity);
            entry.State = EntityState.Modified;
        }

        public virtual T Get(long id)
        {
            return dbSet.Find(id);
        }

        public virtual void Remove(long id)
        {
            var entity = Get(id);
            if (entity != null)
            {
                Remove(entity);
            }
        }

        public virtual void Remove(T entity)
        {
            dbSet.Remove(entity);
        }

        public virtual void RemoveRange(IEnumerable<T> entities)
        {
            dbSet.RemoveRange(entities);
        }

        public virtual T Get(Expression<Func<T, bool>> where, string includes = null)
        {
            return PrepareQuery(where, null, includes).FirstOrDefault();
        }

        public virtual U Get<U>(Expression<Func<T, bool>> where, Expression<Func<T, U>> selector, string includes = null)
        {
            return PrepareQuery(where, selector, null, includes).FirstOrDefault();
        }

        public virtual IEnumerable<T> Find(Expression<Func<T, bool>> where, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, string includes = null)
        {
            return PrepareQuery(where, orderBy, includes).ToList();
        }

        public virtual IEnumerable<U> Find<U>(Expression<Func<T, bool>> where, Expression<Func<T, U>> selector, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, string includes = null)
        {
            return PrepareQuery(where, selector, orderBy, includes).ToList();
        }

        public virtual int Count(Expression<Func<T, bool>> where, string includes = null)
        {
            return PrepareQuery(where, null, includes).Count();
        }

        public virtual bool Any(Expression<Func<T, bool>> where)
        {
            return dbSet.Any(where);
        }

        protected IQueryable<T> PrepareQuery(Expression<Func<T, bool>> where, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, string includes = null)
        {
            var query = dbSet.Where(where);

            query = Include(query, includes);

            if (orderBy != null)
            {
                return orderBy(query);
            }

            return query;
        }
        #region Helpers
        protected IQueryable<U> PrepareQuery<U>(Expression<Func<T, bool>> where, Expression<Func<T, U>> selector, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, string includes = null)
        {
            var query = PrepareQuery(where, orderBy, includes);

            return query.Select(selector);
        }
        protected virtual IQueryable<T> Include(IQueryable<T> sequence, string includeProperties)
        {
            return QueryHelper.Include(sequence, includeProperties);
        }
        #endregion
    }
}
