using CarService.DataLayer.Context;
using CarService.DataLayer.Repositories.Base;
using CarService.DataLayer.Repositories.Interfaces;
using CarService.Entities;
using CarService.Entities.Enums;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace CarService.DataLayer.Repositories
{
    public class VehicleRepository : Repository<Vehicle>, IVehicleRepository
    {
        CarServiceContext _context;
        
        public VehicleRepository(CarServiceContext context) : base(context)
        {
            _context = context;
        }

        public Vehicle? GetByRegistrationNo(string reg)
        {
            return Table.Find(reg);
        }

        public List<Appointment> GetJournal(string regNo)
        {
            List<Appointment> repairs =
                Context.Set<Appointment>()
                .Where(c => c.Vehicle.RegistrationNumber == regNo)
                .Include(c => c.UsedItems)
                .ThenInclude(c => c.Item)
                .Include(c => c.Comments)
                .ThenInclude(c => c.Author)
                .ToList();

            return repairs;
        }
        public List<Vehicle> GetRange(List<string> regNumbers)
        {
            List<Vehicle> vehicles = Table
                .Where(v => regNumbers.Contains(v.RegistrationNumber)).ToList();
            return vehicles;
        }
    }
}
