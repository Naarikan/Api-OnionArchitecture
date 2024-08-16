using Microsoft.EntityFrameworkCore;
using Onion.Application.Interfaces.Repositories;
using Onion.Domain.Common;
using Onion.Persistence.Context;

namespace Onion.Persistence.Repositories
{
    public class WriteRepository<T> : IWriteRepository<T> where T : class, IEntityBase, new()
    {
        private readonly AppDbContext _db;

        public WriteRepository(AppDbContext db)
        {
            _db = db;
        }
        private DbSet<T> Table { get => _db.Set<T>(); }

        public async Task AddAsync(T item)
        {
            await Table.AddAsync(item);
        }

        public async Task AddRangeASync(IList<T> items)
        {
           await Table.AddRangeAsync(items);
        }

     
        public async Task DestroyAsync(T item)
        {

            await Task.Run(() => Table.Remove(item));
        }

        public async Task<T> UpdateAsync(T item)
        {
            await Task.Run(() => Table.Update(item));
            return item;
        }
    }
}
