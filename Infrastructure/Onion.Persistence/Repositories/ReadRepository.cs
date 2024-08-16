using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using Onion.Application.Interfaces.Repositories;
using Onion.Domain.Common;
using Onion.Persistence.Context;

namespace Onion.Persistence.Repositories
{
    public class ReadRepository<T> : IReadRepository<T> where T : class, IEntityBase, new()
    {
        private readonly AppDbContext _db;
        public ReadRepository(AppDbContext db)
        {
            _db = db;
        }
        private DbSet<T> Table { get => _db.Set<T>(); }

        public async Task<IList<T>> GetAllAsync(Expression<Func<T, bool>>? predicate = null, Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null, Func<IQueryable<T>, IOrderedQueryable<T>>? orederedBy = null, bool enableTracking = false)
        {
            IQueryable<T> query = Table;
            if(!enableTracking) query=query.AsNoTracking();
            if (include is not null) query =include(query);
            if (predicate is not null) query = query.Where(predicate);
            if(orederedBy is not null)
                return await orederedBy(query).ToListAsync();

            return await query.ToListAsync();
        }

        public async Task<IList<T>> GetAllByPagingAsync(Expression<Func<T, bool>>? predicate = null, Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null, Func<IQueryable<T>, IOrderedQueryable<T>>? orederedBy = null, bool enableTracking = false, int currentPage = 1, int pageSize = 3)
        {
            IQueryable<T> query = Table;
            if (!enableTracking) query = query.AsNoTracking();
            if (include is not null) query = include(query);
            if (predicate is not null) query = query.Where(predicate);
            if (orederedBy is not null)
                return await orederedBy(query).Skip((currentPage-1)* pageSize).Take(pageSize).ToListAsync();

            return await query.ToListAsync();
        }


        public async Task<T> GetAsync(Expression<Func<T, bool>> predicate, Func<IQueryable<T>, IIncludableQueryable<T, object>> include, bool enableTracking = false)
        {
            IQueryable<T> query = Table;
            if (!enableTracking) query = query.AsNoTracking();
            if (include is not null) query = include(query);

            return await query.FirstOrDefaultAsync(predicate);

         

            
        }

        public async Task<int> CountAsync(Expression<Func<T, bool>>? predicate = null)
        {
            Table.AsNoTracking();
            if (predicate is not null)
            {
                return await Table.Where(predicate).CountAsync();
            }
            return await Table.CountAsync();
        }

        public IQueryable<T> Find(Expression<Func<T, bool>> predicate,bool enableTracking=false)
        {
            if(!enableTracking) Table.AsNoTracking();
            return Table.Where(predicate);
        }

       

       

       
    }
}
