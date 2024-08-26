using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Onion.Application.Interfaces.RedisCache;

namespace Onion.Application.Features.Brands.Queries.GetAllBrands
{
    public class GetAllBrandsQueryRequest : IRequest<IList<GetAllBrandsQueryResponse>>, ICachableQuery
    {
        public string CacheKey => "GetAllBrands";


        public double CacheTime => 60;
    }
}
