
using Microsoft.EntityFrameworkCore;
using MyApp.Models.Models;


namespace webapp.Model.Models;

    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options) 
        { 
      
        }
        public DbSet<Category> categories { get; set; }
        public DbSet<Product> products { get; set; }


}

