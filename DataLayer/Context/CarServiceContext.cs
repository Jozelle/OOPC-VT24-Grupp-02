using CarService.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace CarService.DataLayer.Context
{
    public class CarServiceContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<UsedItem> UsedItems { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<Comment> Comments { get; set; }

        public CarServiceContext() { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(AppContext.BaseDirectory)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: false)
                .Build();

            optionsBuilder.UseSqlServer(config.GetConnectionString("CarService"));
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Comment>()
                .HasOne(b => b.Author)
                .WithMany(a => a.Comments)
                .IsRequired()
                .OnDelete(DeleteBehavior.ClientNoAction);

            modelBuilder.Entity<UsedItem>()
                .HasOne(b => b.AddedBy)
                .WithMany(a => a.UsedItems)
                .IsRequired()
                .OnDelete(DeleteBehavior.ClientNoAction);

            modelBuilder.Entity<Invoice>()
                .HasOne(b => b.Appointment)
                .WithOne(a => a.Invoice)
                .IsRequired()
                .OnDelete(DeleteBehavior.ClientNoAction);
        }
    }
}
