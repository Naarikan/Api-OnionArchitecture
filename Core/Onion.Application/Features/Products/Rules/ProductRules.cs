using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Onion.Application.Bases;
using Onion.Application.Features.Products.Exceptions;
using Onion.Domain.Entities;

namespace Onion.Application.Features.Products.Rules
{
    public class ProductRules:BaseRules
    {
        public Task ProductTitleMustNotBeSame(IList<Product> products , string requestName)
        {
            if(products.Any(x=>x.Name == requestName)) 
                throw new ProductTitleMustNotBeSameException();

            return Task.CompletedTask;


        }
    }
}
