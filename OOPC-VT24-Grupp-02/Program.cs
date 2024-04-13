using CarService.DataLayer.Context;
using CarService.DataLayer.Seed;
using CarService.Entities;
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

            Console.WriteLine( "-- Alla bokade besök -- ");
            foreach (Appointment appointment in carServiceContext.Appointments) 
            {
                Console.WriteLine($"\nBesöksID: {appointment.AppointmentId}" +
                    $"\nKund: {appointment.Customer.FirstName} {appointment.Customer.LastName}" +
                    $"\nFordon: {appointment.Vehicle.RegistrationNumber} ({appointment.Vehicle.Make} {appointment.Vehicle.Model})" +
                    $"\nInlämning: {appointment.SubmissionDate.ToString()}" +
                    $"\nFelbeskrivning: {appointment.Purpose}" +
                    $"\nStatus: {appointment.Status}");
            }
        }
    }
}
