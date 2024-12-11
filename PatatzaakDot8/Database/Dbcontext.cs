using Microsoft.EntityFrameworkCore;
using PatatzaakDot8.Models;

namespace PatatzaakDot8.Database
{
    public class Dbcontext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Owner> Owners { get; set; }
        public DbSet<Employee> Employees { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connection = @"Data Source=.;Initial Catalog=Patatzaak;Integrated Security=true;TrustServerCertificate=True;";
            optionsBuilder.UseSqlServer(connection);

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            Customer customer1 = new Customer()
            {
                Id = 1,
                Name = "Sara",
                Address = "Slakkenstraat 53",
                PhoneNumber = "0612345678",
                MailAdress = "Sara.slak@live.nl"

            };

            Product product1 = new Product()
            {
                Id = 11,
                Name = "Medium Friet",
                Description = "Frietje zonder saus",
                Price = 2.50,
                Inventory = 300,
            };
            Product product2 = new Product()
            {
                Id = 12,
                Name = "Kleine friet",
                Description = "Frietje zonder saus",
                Price = 2.00,
                Inventory = 300,
            };
            Product product3 = new Product()
            {
                Id = 13,
                Name = "Grote friet",
                Price = 3.50,
                Description = "Frietje zonder saus",
                Inventory = 300,
            };
            Owner Admin = new Owner()
            {
                Id = 100,
                Name = "Admin",
                MailAdress = "Admin@live.nl"
            };
            Employee employee = new Employee()
            {
                Id = 101,
                Name = "Piet",
                MailAdress = "Piet.werk@live.nl",
                // Test comment

            };
                

            

            modelBuilder.Entity<Customer>()
                .HasData(customer1);
            modelBuilder.Entity<Product>()
                .HasData(product1, product2, product3);
            modelBuilder.Entity<Owner>()
                .HasData(Admin);
            modelBuilder.Entity<Employee>()
                .HasData(employee);

        }
    }

}
