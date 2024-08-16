using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Onion.Domain.Common;

namespace Onion.Domain.Entities
{
   public class Product:EntityBase,IEntityBase
    {
        public Product()
        {
        
        }

        public Product()
        {
            
        }

        public required string Name { get; set; }
        public required string Description { get; set; }
        public required decimal Price { get; set; }

        public required decimal Discount { get; set; }
         
        //Relations
        public required Guid BrandId { get; set; } 
        public Brand Brand { get; set; }

        public ICollection<Category> Categories { get; set; }

    }
}
