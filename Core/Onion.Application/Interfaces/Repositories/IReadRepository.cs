using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Query;
using Onion.Domain.Common;

namespace Onion.Application.Interfaces.Repositories
{
    public interface IReadRepository<T> where T : class,IEntityBase,new() 
    {
        Task<IList<T>> GetAllAsync(Expression<Func<T, bool>>? predicate = null,
          Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null,
          Func<IQueryable<T>, IOrderedQueryable<T>>? orederedBy = null,
          bool enableTracking = false);//-->Read yaparken tracking'in çalışmaması için


        Task<IList<T>> GetAllByPagingAsync(Expression<Func<T, bool>>? predicate = null,
           Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null,
           Func<IQueryable<T>, IOrderedQueryable<T>>? orederedBy = null,
           bool enableTracking = false, int currentPage = 1, int pageSize = 3);//-->Read yaparken tracking'in çalışmaması için

        Task<T> GetAsync(Expression<Func<T, bool>> predicate,
            Func<IQueryable<T>, IIncludableQueryable<T, object>> include,
            bool enableTracking = false);//-->Read yaparken tracking'in çalışmaması için


        IQueryable<T> Find(Expression<Func<T, bool>> predicate,bool enableTracing=false);

        Task<int> CountAsync(Expression<Func<T, bool>>? predicate = null);

    }
}
