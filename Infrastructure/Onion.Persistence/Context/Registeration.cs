using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Onion.Application.Interfaces.Repositories;
using Onion.Application.Interfaces.UnitOfWorks;
using Onion.Persistence.Repositories;
using Onion.Persistence.UnitOfWorks;

namespace Onion.Persistence.Context
{
    public static class Registeration
    {
        public static void AddPersistence(this IServiceCollection services, IConfiguration _configuration) 
        {
            services.AddDbContext<AppDbContext>(opt => opt.UseSqlServer(_configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped(typeof (IReadRepository<>), typeof (ReadRepository<>));
            services.AddScoped(typeof (IWriteRepository<>), typeof (WriteRepository<>));

            services.AddScoped<IUnitOfWork,UnitOfWork>();
        }
       
    }
}
