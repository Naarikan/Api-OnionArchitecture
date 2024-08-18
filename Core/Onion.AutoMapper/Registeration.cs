using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Onion.Application.Interfaces.AutoMapper;
using Onion.AutoMapper.AutoMapper;

namespace Onion.AutoMapper
{
    public static class Registeration
    {
        public static void AddCustomMapper(this IServiceCollection services)
        {
            services.AddSingleton<IMapper, Mapper>();

        }
    }
}
