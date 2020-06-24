using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Service
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Threading.Tasks;

    namespace Core.Services.Base
    {
        public interface IEntityService<T> where T : class
        {
            Task<IQueryable<T>> All();
            Task<IQueryable<T>> Filter(Expression<Func<T, bool>> predicate);
            Task<IQueryable<T>> Filter<Key>(Expression<Func<T, bool>> filter, int index = 0, int size = 50);
            Task<bool> Contains(Expression<Func<T, bool>> predicate);
            Task<T> Find(params object[] keys);
            Task<T> Find(Expression<Func<T, bool>> predicate);
            Task<T> Create(T t);
            Task<int> Delete(T t);
            Task<int> Delete(Expression<Func<T, bool>> predicate);
            Task<int> Update(T t);
            Task<T> UpdateType(T t);
            Task<IEnumerable<T>> UpdateType(IEnumerable<T> l);
            Task<int> Count { get; }
            Task<Tuple<List<T>, int>> Pager<Key>(Expression<Func<T, bool>> filter, Expression<Func<T, string>> order, int skip = 0, int take = 50, params string[] properties);
            Task<Tuple<List<T>, int>> Pager<Key>(Expression<Func<T, bool>> filter, Expression<Func<T, string>> order, bool descSort, int skip = 0, int take = 50, params string[] properties);
        }
    }

}
