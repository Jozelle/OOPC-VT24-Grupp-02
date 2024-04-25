using CarService.DataLayer.Context;
using CarService.DataLayer.Seed;
using CarService.Entities;
using DataLayer;
namespace OOPC_VT24_Grupp_02
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Tjena, Johanna!");
            Console.WriteLine("Hejhej, Carro!");
            Console.WriteLine("Testar GitHub Desktop!");
            Console.WriteLine("Hej Jojo, har ändrat en massor, ska vi kika på det ihop?");

            CarServiceContext carServiceContext = new CarServiceContext();
            carServiceContext.Database.EnsureDeleted();
            carServiceContext.Database.EnsureCreated();

            CarServiceSeed.Populate(carServiceContext);


            Console.WriteLine("Jag tog bort och la till databasen lokalt!");

            
            //        $"\nFordon: {appointment.Vehicle.RegistrationNumber} ({appointment.Vehicle.Make} {appointment.Vehicle.Model})" +
            //        $"\nInlämning: {appointment.SubmissionDate.ToString()}" +
            //        $"\nFelbeskrivning: {appointment.Purpose}" +
            //        $"\nStatus: {appointment.Status}");
            //}

            //Testar UnitOfWork
            using (var unitOfWork = new UnitOfWork(carServiceContext))
            {
                Appointment appointment = unitOfWork.Appointments.Get(2);

                Console.WriteLine($"\nBesöksID: {appointment.AppointmentId}" +
                    $"\nKund: {appointment.Customer.FirstName} {appointment.Customer.LastName}" +
                    $"\nFordon: {appointment.Vehicle.RegistrationNumber} ({appointment.Vehicle.Make} {appointment.Vehicle.Model})" +
                    $"\nInlämning: {appointment.SubmissionDate.ToString()}" +
                    $"\nFelbeskrivning: {appointment.Purpose}" +
                    $"\nStatus: {appointment.Status}");

                Vehicle bil = unitOfWork.Vehicles.GetByRegistrationNo("MOM987");

                Console.WriteLine($"{bil.Make}");

                Customer kund = unitOfWork.Customers.Get(1);
                Console.WriteLine(kund.FirstName + " " + kund.LastName);

                var besök = unitOfWork.Vehicles.GetJournal(bil);

                foreach (var rep in besök)
                {
                    Console.WriteLine($"Felbeskrivning: {rep.Appointment.Purpose}" +
                        $"\nKommentar: {rep.Description}" +
                        $"\nMekaniker: {rep.RepairedBy.FirstName}");

                    foreach (var item in rep.RepairItems)
                    {
                        Console.WriteLine($"Artikel: {item.Item.Description}, {item.Quantity} st á {item.Item.Price} kr");
                    }
                }

                Console.WriteLine("-- Alla dagens besök --");

                var appointments = unitOfWork.Appointments.GetTodaysAppointments();
                foreach(var a in appointments)
                {
                    Console.WriteLine($"\nBesöksID: {a.AppointmentId}" +
                        $"\nKund: {a.Customer.FirstName} {a.Customer.LastName}" +
                        $"\nFordon: {a.Vehicle.RegistrationNumber} ({a.Vehicle.Make} {a.Vehicle.Model})" +
                        $"\nInlämning: {a.SubmissionDate.ToString()}" +
                        $"\nFelbeskrivning: {a.Purpose}" +
                        $"\nStatus: {a.Status}");
                }

            }
        }
    }
}
