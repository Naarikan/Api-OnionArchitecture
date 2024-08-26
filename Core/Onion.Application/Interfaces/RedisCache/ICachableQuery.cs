using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Onion.Application.Interfaces.RedisCache
{
    public interface ICachableQuery
    {
        string CacheKey { get; }
        double CacheTime { get; }
    }
}
