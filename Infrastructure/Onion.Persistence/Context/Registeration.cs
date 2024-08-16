using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Onion.Persistence.Context
{
    public static class Registeration
    {
        public static void AddPersistence(this IServiceCollection services, IConfiguration _configuration) 
        {
            services.AddDbContext<AppDbContext>(opt => opt.UseSqlServer(_configuration.GetConnectionString("DefaultConnection")));
        }
       
    }
}
