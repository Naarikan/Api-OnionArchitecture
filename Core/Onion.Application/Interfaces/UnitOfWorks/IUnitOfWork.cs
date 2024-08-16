using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Onion.Application.Interfaces.Repositories;
using Onion.Domain.Common;

namespace Onion.Application.Interfaces.UnitOfWorks
{
    public interface IUnitOfWork:IAsyncDisposable
    {
        IReadRepository<T> GetReadRepository<T>() where T:class,IEntityBase,new();
        IWriteRepository<T> GetWriteRepository<T>() where T:class,IEntityBase,new();

        int Save();

        Task<int> SaveAsync();  
    }
}
