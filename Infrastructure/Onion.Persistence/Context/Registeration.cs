using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Onion.Application.Interfaces.Repositories;
using Onion.Application.Interfaces.UnitOfWorks;
using Onion.Domain.Entities;
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

            services.AddIdentityCore<User>(opt => {
             
                opt.Password.RequireNonAlphanumeric = false;
                opt.Password.RequiredLength = 2;
                opt.Password.RequireLowercase = false;
                opt.Password.RequireUppercase = false;
                opt.Password.RequireDigit = false;
                opt.SignIn.RequireConfirmedEmail = false;
            
            })
                .AddRoles<Role>()
                .AddEntityFrameworkStores<AppDbContext>();
        }
       
    }
}
