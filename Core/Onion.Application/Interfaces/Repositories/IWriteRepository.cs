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
    public interface IWriteRepository<T> where T : class,IEntityBase
    {
        Task AddAsync(T item);
        Task AddRangeASync(IList<T> items);

        Task<T> UpdateAsync(T item);
       
        Task DestroyAsync(T item);

        Task DestroyRangeAsync(IList<T> item);


    }
}
