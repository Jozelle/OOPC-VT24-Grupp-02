using CarService.Entities;
using Microsoft.EntityFrameworkCore;

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
            //optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=CarService;Integrated Security=True");
            //optionsBuilder.UseSqlServer(@"Server=ROGER\SQLEXPRESS;Database=test3;Trusted_Connection=true;TrustServerCertificate=true");

            optionsBuilder.UseSqlServer(@"Server=sqlutb2-db.hb.se, 56077;Database=oopc2402;User=oopc2402;Password=PZE328;TrustServerCertificate=true");
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Comment>()
                .HasOne(b => b.Author)
                .WithMany(a => a.Comments)
                .IsRequired()
                .OnDelete(DeleteBehavior.ClientNoAction);

            modelBuilder.Entity<Invoice>()
                .HasOne(b => b.Appointment)
                .WithOne(a => a.Invoice)
                .IsRequired()
                .OnDelete(DeleteBehavior.ClientNoAction);
        }
        //sqlutb2-db.hb.se, 56077
        //oopc2402    PZE328
    }
}
