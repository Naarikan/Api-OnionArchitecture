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

        public string Name { get; set; }
        public string Description { get; set; }
        public  decimal Price { get; set; }

        public  decimal Discount { get; set; }
         
        //Relations
        public  Guid BrandId { get; set; } 
        public Brand Brand { get; set; }

        public ICollection<ProductCategory> ProductCategories { get; set; }

    }
}
