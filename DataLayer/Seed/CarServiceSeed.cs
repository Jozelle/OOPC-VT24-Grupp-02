using CarService.DataLayer.Context;
using CarService.Entities;
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
                PhoneNumber = "0701234567"
            });
            context.Customers.Add(new Customer()
            {
                FirstName = "Bertil",
                LastName = "Bertillson",
                PhoneNumber = "0712345678"
            });

            //Skapar anställda
            context.Employees.Add(new Employee()
            {
                FirstName= ,
                LastName= ,
                RoleID= , 
                Specialisation= ,
                Password=
            });
        }



    }
}
