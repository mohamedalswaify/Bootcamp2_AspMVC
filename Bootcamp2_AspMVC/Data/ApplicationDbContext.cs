
using Bootcamp2_AspMVC.Models;
using Microsoft.EntityFrameworkCore;


namespace Bootcamp2_AspMVC.Data
{
    public class ApplicationDbContext : DbContext
    {


        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) :base(options)
        {

        }
      
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Employee> Employees { get; set; }



    }
}
