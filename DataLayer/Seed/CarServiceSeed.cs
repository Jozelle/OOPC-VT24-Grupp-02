using CarService.DataLayer.Context;
using CarService.Entities;
using CarService.Entities.Enums;

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
                PostalCode = "11111",
                City = "Anderstorp",
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
                PostalCode = "22222",
                City = "Bertilsstad",
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
                PostalCode = "33333",
                City = "Curtby",
                Email = "cc@mail.com"
            };
            context.Customers.Add(kund3);

            Customer kund4 = new Customer()
            {
                FirstName = "David",
                LastName = "Davidsson",
                PhoneNumber = "0707070707",
                SocialSecurityNumber = "9801010101",
                Address = "Davidsgatan 4D",
                PostalCode = "44444",
                City = "Davidstorp",
                Email = "davido@mail.com"
            };
            context.Customers.Add(kund4);

            Customer kund5 = new Customer()
            {
                FirstName = "Erika",
                LastName = "Eriksdotter",
                PhoneNumber = "0705555555",
                SocialSecurityNumber = "9505050505",
                Address = "Eriksgatan 5",
                PostalCode = "55555",
                City = "Eriksort",
                Email = "erikas@mail.com"
            };
            context.Customers.Add(kund5);

            Customer kund6 = new Customer()
            {
                FirstName = "Frida",
                LastName = "Fridsson",
                PhoneNumber = "0706666666",
                SocialSecurityNumber = "8606060606",
                Address = "Fridhem 6",
                PostalCode = "66666",
                City = "Fridby",
                Email = "fridas@mail.com"
            };
            context.Customers.Add(kund6);

            Customer kund7 = new Customer()
            {
                FirstName = "Greta",
                LastName = "Hansson",
                PhoneNumber = "0707123456",
                SocialSecurityNumber = "8707070707",
                Address = "Häxvägen 7",
                PostalCode = "77777",
                City = "Smultorp",
                Email = "hansgreta@mail.com"
            };
            context.Customers.Add(kund7);

            Customer kund8 = new Customer()
            {
                FirstName = "Hanna",
                LastName = "Hansson",
                PhoneNumber = "0708080808",
                SocialSecurityNumber = "9808080808",
                Email = "hannas@mail.com"
            };
            context.Customers.Add(kund8);

            Customer kund9 = new Customer()
            {
                FirstName = "David",
                LastName = "Davidsson",
                PhoneNumber = "0704040404",
                SocialSecurityNumber = "9804040404",
            };
            context.Customers.Add(kund9);

            //Skapar anställda
            Mechanic mek1 = new Mechanic()
            {
                FirstName = "Pamela",
                LastName = "Andersson",
                Specialization = Specialization.Breaks,
                Password = "ILoveCalifornia"
            };
            context.Employees.Add(mek1);

            Mechanic mek2 = new Mechanic()
            {
                FirstName = "Cindy",
                LastName = "Crawford",
                Password = "Vogue"
            };
            context.Employees.Add(mek2);

            Mechanic mek3 = new Mechanic()
            {
                FirstName = "Gigi",
                LastName = "Hadid",
                Specialization = Specialization.Tires,
                Password = "Fashion"
            };
            context.Employees.Add(mek3);

            Mechanic mek4 = new Mechanic()
            {
                FirstName = "Bella",
                LastName = "Hadid",
                Specialization = Specialization.Services,
                Password = "Model"
            };
            context.Employees.Add(mek4);

            Receptionist rep1 = new Receptionist()
            {
                FirstName = "Mulle",
                LastName = "Meck",
                Password = "Prylar",
            };
            context.Employees.Add(rep1);

            Receptionist rep2 = new Receptionist()
            {
                FirstName = "Mulle",
                LastName = "Meck",
                Password = "Prylar",
            };
            context.Employees.Add(rep2);

            Receptionist rep3 = new Receptionist()
            {
                FirstName = "Mulle",
                LastName = "Meck",
                Password = "Prylar",
            };
            context.Employees.Add(rep3);

            Receptionist rep4 = new Receptionist()
            {
                FirstName = "Mulle",
                LastName = "Meck",
                Password = "Prylar",
            };
            context.Employees.Add(rep4);

            //Skapar items
            context.Items.Add(new Item() { Description = "Broms", Price = 1000 });
            context.Items.Add(new Item() { Description = "Koppling", Price = 2000 });
            context.Items.Add(new Item() { Description = "Mutter", Price = 10 });
            context.Items.Add(new Item() { Description = "Backspegel", Price = 1500 });
            context.Items.Add(new Item() { Description = "Framruta", Price = 1000 });
            context.Items.Add(new Item() { Description = "Vinterdäck", Price = 2000 });
            context.Items.Add(new Item() { Description = "Avgasrör", Price = 700 });
            context.Items.Add(new Item() { Description = "Oljefilter", Price = 300 });
            context.Items.Add(new Item() { Description = "Kylare", Price = 3500 });
            context.Items.Add(new Item() { Description = "Tändkablar", Price = 300 });
            context.Items.Add(new Item() { Description = "Glödlampa", Price = 150 });
            context.Items.Add(new Item() { Description = "Stötdämpare", Price = 5000 });
            context.Items.Add(new Item() { Description = "Tändstift", Price = 75 });
            context.Items.Add(new Item() { Description = "Tändstift", Price = 75 });
            context.Items.Add(new Item() { Description = "Sommardäck", Price = 950 });
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
                CustomerId = 8,
                Vehicle = bil3,
                CreatedBy = rep1,
                Status = AppointmentStatus.Booked
            };
            context.Appointments.Add(app3);

            Appointment app4 = new Appointment()
            {
                SubmissionDate = new DateTime(2024, 4, 30, 8, 30, 00),
                DeliveryDate = new DateTime(2024, 4, 30, 9, 30, 00),
                Purpose = "Rekond",
                CustomerId = 1,
                VehicleRegistrationNumber = "DAD567",
                CreatedBy = rep1,
                Status = AppointmentStatus.Booked
            };
            context.Appointments.Add(app4);

            context.SaveChanges();

            context.Comments.Add(new Comment()
            {
                Appointment = app2,
                Author = mek2,
                Message = "Bytt bromsskivor bak",
                Time = DateTime.Now
            });

            context.Comments.Add(new Comment()
            {
                Appointment = app11,
                Author = mek2,
                Message = "Självläkt",
                Time = new DateTime(2024, 1, 27, 10, 00, 00),
            });

            context.Comments.Add(new Comment()
            {
                Appointment = app12,
                Author = mek2,
                Message = "Framdäck slitna, informerar kund om att nya däck behövs. Inväntar svar.",
                Time = new DateTime(2023, 4, 11, 10, 15, 00),
            });

            context.Comments.Add(new Comment()
            {
                Appointment = app12,
                Author = mek2,
                Message = "Kund önskar nya däck. Monterat nya däck på fälg, hjulinställning OK.",
                Time = new DateTime(2023, 4, 11, 11, 20, 00),
            });

            context.UsedItems.Add(new UsedItem()
            {
                ItemId = 15,
                Appointment = app3,
                Quantity = 4
            });

            context.UsedItems.Add(new UsedItem()
            {
                ItemId = 1,
                Appointment = app2,
                Quantity = 2,
            });

            context.UsedItems.Add(new UsedItem()
            {
                ItemId = 12,
                Appointment = app2,
                Quantity = 1,
            });

            context.SaveChanges();

        }



    }
}
