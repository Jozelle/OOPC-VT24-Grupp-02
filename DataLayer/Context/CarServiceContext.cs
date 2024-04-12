using CarService.Entities;
using Microsoft.EntityFrameworkCore;
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

            //optionsBuilder.UseSqlServer(@"Server=ROGER\SQLEXPRESS;Database=test;Trusted_Connection=true;TrustServerCertificate=true");
            base.OnConfiguring(optionsBuilder);
        }

        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Mechanic> Mechanics { get; set; }
        public DbSet<Receptionist> Receptionists { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }

    }
}
