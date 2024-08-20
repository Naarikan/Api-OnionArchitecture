using Microsoft.AspNetCore.Builder;

namespace Onion.Application.Exceptions
{
    public static class ConfigureExeptionMiddleware
    {
        public static void ConfigureExeptionHandlingMiddleware(this IApplicationBuilder app) {

            app.UseMiddleware<ExceptionMiddleware>();
        
        }
    }
}
