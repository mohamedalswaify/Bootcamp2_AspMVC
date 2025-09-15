
using Bootcamp2_AspMVC.Models;
using Microsoft.EntityFrameworkCore;


namespace Bootcamp2_AspMVC.Data
{
    public class ApplicationDbContext : DbContext
    {


        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) :base(options)
        {

        }
      
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Supliers> Supliers { get; set; }
        public virtual DbSet<UserRole> UserRoles { get; set; }

        public virtual DbSet<Permission> Permissions { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<CartItem> CartItems { get; set; }



    }
}
