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
            //SKapar besök
            context.Appointments.Add(new Appointment()
            {
                SubmissionDate = DateTime.Now,
                DeliveryDate = DateTime.Now + TimeSpan.FromHours(2),
                Purpose = "Däckbyte"
            });

            context.Appointments.Add(new Appointment()
            {
                SubmissionDate = new DateTime(2024,5,1,10,00,00),
                DeliveryDate = new DateTime(2024, 5, 1, 12, 00, 00),
                Purpose = "Gnälliga bromsar"
            });

            //Skapar kunder
            context.Customers.Add(new Customer()
            {
                FirstName = "Anders",
                LastName = "Andersson",
                PhoneNumber = "0701234567",
                Address = "Andersgata 9",
                Email = "andersandersson@mail.com"
            });
        
            context.Customers.Add(new Customer()
            {
                FirstName = "Bertil",
                LastName = "Bertillson",
                PhoneNumber = "0712345678", 
                Address = "Bertilsgata 5",
                Email = "bertilbertillson@mail.com"
            });

            //Skapar anställda
            context.Employees.Add(new Employee()
            {
                FirstName = "Pamela",
                LastName = "Andersson",
                Role = Role.Mechanic,
                Specialisation = "Pedaler",
                Password = "ILoveCalifornia"
            });

            //Skapar items
            context.Items.Add(new Item()
            {
                
                Description = "Broms"

            });

            context.Items.Add(new Item()
            {
                
                Description = "Koppling"

            });

            //Skapar Fordon
            context.Vehicles.Add(new Vehicle()
            {
                RegistrationNumber = "MOM987",
                Make = "Mercedes",
                Model = "C63 Sedan",
                Year = "2015"

             });

            context.Vehicles.Add(new Vehicle()
            {
                RegistrationNumber = "DAD567",
                Make = "Audi",
                Model = "rs6",
                Year = "2018"

            });

            context.SaveChanges();

        }



    }
}
