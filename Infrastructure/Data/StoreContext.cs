
using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class StoreContext : DbContext
    {
        public StoreContext(DbContextOptions<StoreContext> options) : base(options)
        {
        }
        //@ 12 -> 10:13
        //by adding these DbSet, this allows us when we use our context: StoreContext, this will allow us to 
        //access the products and then use some of those methods that are defined inside the DbContext to find
        //an entity with an Id or got a list of all of the products.
        //When we specify our DbSet in this way, then this is what's going to allow us to query those entities.
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductBrand> ProductBrands { get; set; }
        public DbSet<ProductType> ProductTypes { get; set; }
        
        
        
        
        
        
    }
}