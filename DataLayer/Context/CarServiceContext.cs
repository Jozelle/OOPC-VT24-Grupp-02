using CarService.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarService.DataLayer.Context
{
    public class CarServiceContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=CarService;Integrated Security=True");

            //optionsBuilder.UseSqlServer(@"Server=ROGER\SQLEXPRESS;Database=test2;Trusted_Connection=true;TrustServerCertificate=true");
            base.OnConfiguring(optionsBuilder);
        }

        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<Customer> Customers { get; set; }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<UsedItem> UsedItems { get; set; }

        public DbSet<Payment> Payments { get; set; }    
        public DbSet<Comment> Comments { get; set; }

        public CarServiceContext() { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Comment>()
                .HasOne(b => b.Author)
                .WithMany(a => a.Comments)
                .IsRequired()
                .OnDelete(DeleteBehavior.ClientNoAction);
        }

    }
}
