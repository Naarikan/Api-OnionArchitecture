using Onion.Domain.Common;

namespace Onion.Domain.Entities
{
    public  class Category:EntityBase,IEntityBase
    {
        public Category()
        {
            
        }
        public Category(Guid parentId,string name,int priorty)
        {
            ParentId = parentId;
            Name = name;
            Priorty = priorty;
        }

        public Guid? ParentId { get; set; }=Guid.Empty;
        public string Name { get; set; }
        public  int Priorty { get; set; }

        //Relations 
        public ICollection<Detail> Details { get; set; }
        public ICollection<ProductCategory> ProductCategories { get; set; }
    }
}
