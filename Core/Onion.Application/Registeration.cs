using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Onion.Application.Bases;
using Onion.Application.Behaviours;
using Onion.Application.Exceptions;
using Onion.Application.Features.Products.Rules;

namespace Onion.Application
{
    public static class Registeration
    {
        public static void AddApplication(this IServiceCollection services)
        {
            var assembly=Assembly.GetExecutingAssembly();

            services.AddTransient<ExceptionMiddleware>();

            services.AddRulesFromAssemblyContaining(assembly , typeof(BaseRules));

            services.AddMediatR(cfg=>cfg.RegisterServicesFromAssemblies(assembly));

            services.AddValidatorsFromAssembly(assembly);

            ValidatorOptions.Global.LanguageManager.Culture = new CultureInfo("tr");

            services.AddTransient(typeof(IPipelineBehavior<,>),typeof(FluentValidationBehaviour<,>));
        }

        private static IServiceCollection AddRulesFromAssemblyContaining(this IServiceCollection services,
            Assembly assembly,
            Type type) 
        { 
          var types = assembly.GetTypes().Where(t=>t.IsSubclassOf(type) && type != t).ToList();
            foreach (var item in types)
                services.AddTransient(item);
            return services;
        }
    }

    
}
