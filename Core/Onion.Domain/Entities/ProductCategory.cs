using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Onion.Domain.Common;

namespace Onion.Domain.Entities
{
    public class ProductCategory : IEntityBase
    {
        public Guid ProductId { get; set; }
        public Guid CategoryId { get; set; }

        public Product Product { get; set; }
        public Category Category { get; set; }
    }
}
