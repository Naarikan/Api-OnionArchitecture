using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Onion.Domain.Common;

namespace Onion.Domain.Entities
{
    public class Detail:EntityBase,IEntityBase
    {
        public Detail() { }
        public Detail(string name,string description,Guid categoryId)
        {
            Name = name;
            Description = description;
            CategoryId = categoryId;
        }

        public string Name { get; set; }
        public  string Description { get; set; }

        //Relations
        public  Guid CategoryId { get; set; }
        public Category Category { get; set; }

    }
}
