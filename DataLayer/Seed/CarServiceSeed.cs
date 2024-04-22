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

            Customer kund3 = new Customer()
            {
                FirstName = "Curt",
                LastName = "Curtsson",
                PhoneNumber = "0701020304",
                SocialSecurityNumber = "4004040404",
                Address = "Curtvägen 3C",
                Email = "cc@mail.com"
            };
            context.Customers.Add(kund3);

            //Skapar anställda
            Mechanic mek1 = new Mechanic()
            {
                FirstName = "Pamela",
                LastName = "Andersson",
                Specialization = Specialization.Breaks,
                Password = "ILoveCalifornia"
            };
            context.Mechanics.Add(mek1);

            Mechanic mek2 = new Mechanic()
            {
                FirstName = "Cindy",
                LastName = "Crawford",
                Password = "Vogue"
            };
            context.Mechanics.Add(mek2);

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
            Item item15 = new Item() { Description = "Sommardäck", Price = 950 };

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
            context.Items.Add(item15);
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

            Vehicle bil3 = new Vehicle()
            {
                RegistrationNumber = "ABC123",
                Make = "Kia",
                Model = "Ceed",
                Year = "2004"

            };


            //SKapar besök
            Appointment app1 = new Appointment()
            {
                SubmissionDate = DateTime.Now + TimeSpan.FromHours(1),
                DeliveryDate = DateTime.Now + TimeSpan.FromHours(2),
                Purpose = "Däckbyte",
                Customer = kund1,
                Vehicle = bil1,
                CreatedBy = rep1,
                Status = AppointmentStatus.CarReceived
            };
            context.Appointments.Add(app1);

            Appointment app11 = new Appointment()
            {
                SubmissionDate = new DateTime(2024, 2, 1, 10, 00, 00),
                DeliveryDate = new DateTime(2024, 2, 1, 12, 00, 00),
                Purpose = "Trasig framlykta",
                Customer = kund1,
                Vehicle = bil1,
                CreatedBy = rep1,
                Status = AppointmentStatus.Canceled
            };
            context.Appointments.Add(app11);

            Appointment app12 = new Appointment()
            {
                SubmissionDate = new DateTime(2023, 4, 11, 10, 00, 00),
                DeliveryDate = new DateTime(2023, 4, 11, 12, 00, 00),
                Purpose = "Däckbyte",
                Customer = kund1,
                Vehicle = bil1,
                CreatedBy = rep1,
                Status = AppointmentStatus.Completed
            };
            context.Appointments.Add(app12);

            Appointment app2 = new Appointment()
            {
                SubmissionDate = new DateTime(2024, 5, 1, 10, 00, 00),
                DeliveryDate = new DateTime(2024, 5, 1, 12, 00, 00),
                Purpose = "Gnälliga bromsar",
                Customer = kund2,
                Vehicle = bil2,
                CreatedBy = rep1,
                Status = AppointmentStatus.Booked
            };
            context.Appointments.Add(app2);

            Appointment app3 = new Appointment()
            {
                SubmissionDate = new DateTime(2024, 4, 25, 8, 30, 00),
                DeliveryDate = new DateTime(2024, 4, 25, 9, 30, 00),
                Purpose = "Service",
                Customer = kund3,
                Vehicle = bil3,
                CreatedBy = rep1,
                Status = AppointmentStatus.Booked
            };
            context.Appointments.Add(app3);

            context.UsedItems.Add(new UsedItem()
            {
                Item = item1,
                Appointment = app2,
                Quantity = 2,
            });

            context.UsedItems.Add(new UsedItem()
            {
                Item = item12,
                Appointment = app2,
                Quantity = 1,
            });

            context.MechanicComments.Add(new MechanicComment()
            {
                Appointment = app2,
                RepairedBy = mek2,
                Comment = "Bytt bromsskivor bak",
                Time = DateTime.Now
            });

            context.MechanicComments.Add(new MechanicComment()
            {
                Appointment = app11,
                RepairedBy = mek2,
                Comment = "Självläkt",
                Time = new DateTime(2024, 1, 27, 10, 00, 00),
            });

            context.MechanicComments.Add(new MechanicComment()
            {
                Appointment = app12,
                RepairedBy = mek2,
                Comment = "Framdäck slitna, informerar kund om att nya däck behövs. Inväntar svar.",
                Time = new DateTime(2023, 4, 11, 10, 15, 00),
            });

            context.MechanicComments.Add(new MechanicComment()
            {
                Appointment = app12,
                RepairedBy = mek2,
                Comment = "Kund önskar nya däck. Monterat nya däck på fälg, hjulinställning OK.",
                Time = new DateTime(2023, 4, 11, 11, 20, 00),
            });

            context.UsedItems.Add(new UsedItem()
            {
                Item = item15,
                Appointment = app12,
                Quantity = 4,
            });

            context.SaveChanges();

        }



    }
}
