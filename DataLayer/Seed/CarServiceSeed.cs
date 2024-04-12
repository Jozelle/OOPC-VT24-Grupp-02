using CarService.DataLayer.Context;
using CarService.Entities;
using CarService.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarService.DataLayer.Seed
{
    public class CarServiceSeed
    {
        public static void Populate(CarServiceContext context)
        {
            //Skapar kunder
            Customer kund1 = new Customer()
            {
                FirstName = "Anders",
                LastName = "Andersson",
                PhoneNumber = "0701234567",
                SocialSecurityNumber = "9876543210",
                Address = "Andersgata 9",
                Email = "andersandersson@mail.com"
            };

            context.Customers.Add(kund1);

            Customer kund2 = new Customer()
            {
                FirstName = "Bertil",
                LastName = "Bertillson",
                PhoneNumber = "0712345678", 
                SocialSecurityNumber = "1122334455",
                Address = "Bertilsgata 5",
                Email = "bertilbertillson@mail.com"
            };
            context.Customers.Add(kund2);

            //Skapar anställda
            Mechanic mek1 = new Mechanic()
            {
                FirstName = "Pamela",
                LastName = "Andersson",
                Specialization = Specialization.Breaks,
                Password = "ILoveCalifornia"
            };
            context.Mechanics.Add(mek1);

            Receptionist rep1 = new Receptionist()
            {
                FirstName = "Mulle",
                LastName = "Meck",
                Password = "Prylar",
            };
            context.Receptionists.Add(rep1);

            //Skapar items
            Item item1 = new Item(){Description = "Broms", Price = 1000};
            Item item2 = new Item() { Description = "Koppling", Price = 2000 };
            Item item3 = new Item() { Description = "Mutter", Price = 10 };
            Item item4 = new Item() { Description = "Backspegel", Price = 1500 };
            Item item5 = new Item() { Description = "Framruta", Price = 1000 };
            Item item6 = new Item() { Description = "Vinterdäck", Price = 2000 };
            Item item7 = new Item() { Description = "Avgasrör", Price = 700 };
            Item item8 = new Item() { Description = "Oljefilter", Price = 300 };
            Item item9 = new Item() { Description = "Kylare", Price = 3500 };
            Item item10 = new Item() { Description = "Tändkablar", Price = 300 };
            Item item11 = new Item() { Description = "Glödlampa", Price = 150 };
            Item item12 = new Item() { Description = "Stötdämpare", Price = 5000 };
            Item item13 = new Item() { Description = "Tändstift", Price = 75 };
            Item item14 = new Item() { Description = "Växellåda", Price = 10000 };

            context.Items.Add(item1);
            context.Items.Add(item2);
            context.Items.Add(item3);
            context.Items.Add(item4);
            context.Items.Add(item5);
            context.Items.Add(item6);
            context.Items.Add(item7);
            context.Items.Add(item8);
            context.Items.Add(item9);
            context.Items.Add(item10);
            context.Items.Add(item11);
            context.Items.Add(item12);
            context.Items.Add(item13);
            context.Items.Add(item14);

            //Skapar Fordon
            Vehicle bil1 = new Vehicle()
            {
                RegistrationNumber = "MOM987",
                Make = "Mercedes",
                Model = "C63 Sedan",
                Year = "2015"

             };
            context.Vehicles.Add(bil1);

            Vehicle bil2 = new Vehicle()
            {
                RegistrationNumber = "DAD567",
                Make = "Audi",
                Model = "rs6",
                Year = "2018"

            };

            //SKapar besök
            Appointment app1 = new Appointment()
            {
                SubmissionDate = DateTime.Now,
                DeliveryDate = DateTime.Now + TimeSpan.FromHours(2),
                Purpose = "Däckbyte",
                Customer = kund1,
                Vehicle = bil1,
                CreatedBy = rep1
            };
            context.Appointments.Add(app1);

            context.Appointments.Add(new Appointment()
            {
                SubmissionDate = new DateTime(2024, 5, 1, 10, 00, 00),
                DeliveryDate = new DateTime(2024, 5, 1, 12, 00, 00),
                Purpose = "Gnälliga bromsar",
                Customer = kund2,
                Vehicle = bil2,
                CreatedBy = rep1
            });

            Repair repair1 = new Repair()
            {
                Description = "Felsökt bromsar, bytt båda bromsskivorna bak.",
                Appointment = app1,
                RepairedBy = mek1
            };
            context.Repairs.Add(repair1);

            context.RepairItems.Add(new RepairItem()
            {
                Item = item1,
                Repair = repair1,
                Quantity = 2,
            });

            context.RepairItems.Add(new RepairItem()
            {
                Item = item12,
                Repair = repair1,
                Quantity = 1,
            });

            context.SaveChanges();

        }



    }
}
