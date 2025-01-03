﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Onion.Application.Interfaces.RedisCache;

namespace Onion.Application.Features.Products.Queries.GetAllProducts
{
    public class GetAllProductsQueryRequest : IRequest<IList<GetAllProductQueryResponse>>, ICachableQuery
    {
        public string CacheKey => "GetAllProducts";

        public double CacheTime => 60;
    }
}
