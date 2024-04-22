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

            
        }
    }
}
