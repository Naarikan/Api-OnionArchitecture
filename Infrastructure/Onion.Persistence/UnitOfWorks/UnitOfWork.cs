using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Onion.Application.Interfaces.Repositories;
using Onion.Application.Interfaces.UnitOfWorks;
using Onion.Persistence.Context;
using Onion.Persistence.Repositories;

namespace Onion.Persistence.UnitOfWorks
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _appDbContext;

        public UnitOfWork(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async ValueTask DisposeAsync()=> await _appDbContext.DisposeAsync();
      

        public int Save()=> _appDbContext.SaveChanges();
       

        public async Task<int> SaveAsync()=>await _appDbContext.SaveChangesAsync();
       

        IReadRepository<T> IUnitOfWork.GetReadRepository<T>()=>new ReadRepository<T>(_appDbContext);
       
        IWriteRepository<T> IUnitOfWork.GetWriteRepository<T>()=>new WriteRepository<T>(_appDbContext);
       
    }
}
