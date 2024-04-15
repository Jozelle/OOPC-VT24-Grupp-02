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

            //Console.WriteLine("-- Alla bokade besök -- ");
            //foreach (Appointment appointment in carServiceContext.Appointments)
            //{
            //    Console.WriteLine($"\nBesöksID: {appointment.AppointmentId}" +
            //        $"\nKund: {appointment.Customer.FirstName} {appointment.Customer.LastName}" +
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

                Customer kund = unitOfWork.Customers.Get(1);
                Console.WriteLine(kund.FirstName + " " + kund.LastName);

                Vehicle bil = unitOfWork.Vehicles.GetByRegistrationNo("DAD567");

                Console.WriteLine($"{bil.Make}");

                foreach (var rep in bil.Appointments)
                {
                    Console.WriteLine($"Felbeskrivning: {rep.Purpose}");

                    if (rep.Comments != null)
                    {
                        foreach(var com in rep.Comments)
                        {
                            Console.WriteLine($"Kommentar: {com.Comment}" +
                                $"\nMekaniker: {com.RepairedBy.FirstName} {com.RepairedBy.LastName}");

                        }
                    }

                    if (rep.UsedItems != null)
                    {
                        foreach (var item in rep.UsedItems)
                        {
                            Console.WriteLine($"Artikel: {item.Item.Description}, {item.Quantity} st á {item.Item.Price} kr");
                        }
                    }

                }

                Console.WriteLine("Vilken artikel vill du lägga till?");
                int.TryParse(Console.ReadLine(), out int itemId);
                Item itemToAdd = unitOfWork.Items.Get(itemId);

                Console.WriteLine("Hur många?");
                int.TryParse(Console.ReadLine(), out int quantity);

                Appointment app1 = unitOfWork.Appointments.GetByRegNo("DAD567");

                UsedItem usedItem = new UsedItem { Item = itemToAdd, Quantity = quantity };
                app1.UsedItems.Add(usedItem);

                unitOfWork.Complete();

                Console.WriteLine("SPARAT!");

                Vehicle bilIgen = unitOfWork.Vehicles.GetByRegistrationNo("DAD567");

                foreach (var rep in bilIgen.Appointments)
                {
                    Console.WriteLine($"Felbeskrivning: {rep.Purpose}");

                    if (rep.Comments != null)
                    {
                        foreach (var com in rep.Comments)
                        {
                            Console.WriteLine($"Kommentar: {com.Comment}" +
                                $"\nMekaniker: {com.RepairedBy.FirstName} {com.RepairedBy.LastName}");

                        }
                    }

                    if (rep.UsedItems != null)
                    {
                        foreach (var item in rep.UsedItems)
                        {
                            Console.WriteLine($"Artikel: {item.Item.Description}, {item.Quantity} st á {item.Item.Price} kr");
                        }
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
