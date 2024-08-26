using MediatR;
using Onion.Application.Interfaces.RedisCache;

namespace Onion.Application.Behaviours
{
    public class RedisCacheBehevior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    {
        private readonly IRedisCacheService redisCacheService;

        public RedisCacheBehevior(IRedisCacheService redisCacheService)
        {
            this.redisCacheService = redisCacheService;
        }

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            if (request is ICachableQuery query)
            {
                var cacheKey=query.CacheKey;
                var cacheTime = query.CacheTime;

                var cachedData = await redisCacheService.GetAsync<TResponse>(cacheKey);
                var response = await next();

                if (response is not null)
                    await redisCacheService.SetAsync(cacheKey,response,DateTime.Now.AddMinutes(cacheTime));
                return response;
            }
            return await next();
        }
    }
}
