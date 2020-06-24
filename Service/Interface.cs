using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Service
{
    public abstract class AsyncEntityService<T> : DbContext where T : class
    {
        protected DbContext Context;
        protected DbSet<T> Dbset;
        private readonly bool shareContext = false;

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="context">Контекст СУБД</param>
        protected AsyncEntityService(DbContext context)
        {
            Context = context;
            Dbset = Context.Set<T>();
            //shareContext = true;
        }

        protected DbSet<T> DbSet => Context.Set<T>();

        public virtual async Task<int> Update(T t)
        {
            var entry = Context.Entry(t);
            DbSet.Attach(t);
            entry.State = EntityState.Modified;
            if (!shareContext)
                return await Context.SaveChangesAsync();
            return 0;
        }
        public virtual async Task<T> Find(params object[] keys)
        {
            return await DbSet.FindAsync(keys);
        }
        /// <summary>
        /// Удалить запись
        /// </summary>
        /// <param name="t">Типизированный параметр</param>
        /// <returns>Целочисленный результат SaveChangesAsync</returns>
        public virtual async Task<int> Delete(T t)
        {
            DbSet.Remove(t);
            if (!shareContext)
                return await Context.SaveChangesAsync();
            return 0;
        }

    }
}
