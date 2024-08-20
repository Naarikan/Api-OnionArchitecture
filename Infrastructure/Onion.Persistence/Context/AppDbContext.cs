using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Onion.Domain.Entities;
namespace Onion.Persistence.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(){}
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        //Persistence katmanında design paketine ihtiyaç yoktur,tools indirilmesi yeterlidir.Design Startup'a kurulur.
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Category> Categories{get;set;}
        public DbSet<Detail> Details { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
