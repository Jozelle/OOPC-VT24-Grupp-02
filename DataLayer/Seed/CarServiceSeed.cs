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
            Customer kund1 = new Customer("Anders", "Andersson", "0701234567", "9876543210", "Andersgata 9", "11111", "Anderstorp", "andersandersson@mail.com");
            context.Customers.Add(kund1);

            Customer kund2 = new Customer("Bertil", "Bertillson", "0712345678", "1122334455", "Bertilsgata 5", "22222", "Bertilsstad", "bertilbertillson@mail.com");
            context.Customers.Add(kund2);

            Customer kund3 = new Customer("Curt", "Curtsson", "0701020304", "4004040404", "Curtvägen 3C", "33333", "Curtby", "cc@mail.com");
            context.Customers.Add(kund3);

            Customer kund4 = new Customer("David", "Davidsson", "0707070707", "9801010101", "Davidsgatan 4D", "44444", "Davidstorp", "davido@mail.com");
            context.Customers.Add(kund4);

            Customer kund5 = new Customer("Erika", "Eriksdotter", "0705555555", "9505050505", "Eriksgatan 5", "55555", "Eriksort", "erikas@mail.com");
            context.Customers.Add(kund5);

            Customer kund6 = new Customer("Frida", "Fridsson", "0706666666", "8606060606", "Fridhem 6", "66666", "Fridby", "fridas@mail.com");
            context.Customers.Add(kund6);

            Customer kund7 = new Customer("Greta", "Hansson", "0707123456", "8707070707", "Häxvägen 7", "77777", "Smultorp", "hansgreta@mail.com");
            context.Customers.Add(kund7);

            Customer kund8 = new Customer("Hanna", "Hansson", "0708080808", "9808080808", null, null, null, "hannas@mail.com");
            context.Customers.Add(kund8);

            Customer kund9 = new Customer("David", "Davidsson", "0704040404", "9804040404", null, null, null, null);
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
                Specialization = Specialization.Breaks,
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
                FirstName = "Findus",
                LastName = "Pettson",
                Password = "Hönor",
            };
            context.Employees.Add(rep2);

            Receptionist rep3 = new Receptionist()
            {
                FirstName = "Nalle",
                LastName = "Puh",
                Password = "Honing",
            };
            context.Employees.Add(rep3);

            Receptionist rep4 = new Receptionist()
            {
                FirstName = "Barba",
                LastName = "Pappa",
                Password = "Rosa",
            };
            context.Employees.Add(rep4);

            //Skapar items
            context.Items.Add(new SparePart() { Description = "Broms", Price = 1000, Inventory = 12 });
            context.Items.Add(new SparePart() { Description = "Koppling", Price = 2000, Inventory = 5 });
            context.Items.Add(new SparePart() { Description = "Mutter", Price = 10, Inventory = 134 });
            context.Items.Add(new SparePart() { Description = "Backspegel", Price = 1500, Inventory = 4 });
            context.Items.Add(new SparePart() { Description = "Framruta", Price = 1000, Inventory = 2 });
            context.Items.Add(new SparePart() { Description = "Vinterdäck", Price = 2000, Inventory = 28 });
            context.Items.Add(new SparePart() { Description = "Avgasrör", Price = 700, Inventory = 2 });
            context.Items.Add(new SparePart() { Description = "Oljefilter", Price = 300, Inventory = 31 });
            context.Items.Add(new SparePart() { Description = "Kylare", Price = 3500, Inventory = 3 });
            context.Items.Add(new SparePart() { Description = "Tändkablar", Price = 300, Inventory = 13 });
            context.Items.Add(new SparePart() { Description = "Glödlampa", Price = 150, Inventory = 17 });
            context.Items.Add(new SparePart() { Description = "Stötdämpare", Price = 5000, Inventory = 12 });
            context.Items.Add(new SparePart() { Description = "Tändstift", Price = 75, Inventory = 34 });
            context.Items.Add(new SparePart() { Description = "Sommardäck", Price = 950, Inventory = 16 });
            context.Items.Add(new Service() { Description = "Däckbyte", Price = 700 });
            context.Items.Add(new Service() { Description = "Service", Price = 2400 });
            context.Items.Add(new Service() { Description = "Arbete, per timme", Price = 900 });
            context.Items.Add(new Service() { Description = "Byte av växellåda", Price = 7900 });
            context.Items.Add(new Service() { Description = "Byte av framruta", Price = 700 });
            context.Items.Add(new Service() { Description = "Rekond", Price = 3500 });
            context.Items.Add(new Service() { Description = "Hjulinställning", Price = 500 });
            context.Items.Add(new Service() { Description = "Kamremsbyte", Price = 1500 });
            context.Items.Add(new Service() { Description = "AC-service", Price = 1000 });
            context.Items.Add(new Service() { Description = "Laga stenskott", Price = 450 });
            context.Items.Add(new Service() { Description = "Bromsbelägg fram", Price = 700 });
            context.Items.Add(new Service() { Description = "Bromsbelägg bak", Price = 700 });
            context.Items.Add(new Service() { Description = "Felsökning broms", Price = 1100 });
            context.Items.Add(new Service() { Description = "Montering av dragkrok", Price = 700 });
            context.Items.Add(new Service() { Description = "Montering av nya däck", Price = 700 });
            context.Items.Add(new Service() { Description = "Byte lampa fram", Price = 400 });
            context.Items.Add(new Service() { Description = "Byte lampa bak", Price = 700 });

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
