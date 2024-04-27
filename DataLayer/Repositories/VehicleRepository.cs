using CarService.DataLayer.Context;
using CarService.DataLayer.Repositories.Base;
using CarService.DataLayer.Repositories.Interfaces;
using CarService.Entities;
using Microsoft.EntityFrameworkCore;

namespace CarService.DataLayer.Repositories
{
    public class VehicleRepository : Repository<Vehicle>, IVehicleRepository
    {
        public VehicleRepository(CarServiceContext context) : base(context)
        {
        }

        public Vehicle? GetByRegistrationNo(string reg)
        {
            return Context.Set<Vehicle>().Find(reg);
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
    }
}
