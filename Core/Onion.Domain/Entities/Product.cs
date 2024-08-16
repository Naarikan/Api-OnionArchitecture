using Onion.Domain.Common;

namespace Onion.Domain.Entities
{
    public class Product:EntityBase,IEntityBase
    {
        public Product()
        {
        
        }

        public Product(string name,string desc,decimal price,decimal discount,Guid brandId)
        {
            Name = name;
            Description = desc;
            Price = price;
            Discount = discount;
            BrandId = brandId;
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
