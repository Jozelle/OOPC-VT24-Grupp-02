using CarService.DataLayer;
using CarService.DataLayer.Context;
using CarService.DataLayer.Repositories;
using CarService.DataLayer.Repositories.Interfaces;
using CarService.Entities;

namespace DataLayer
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly CarServiceContext _context;

        public UnitOfWork(CarServiceContext context)
        {
            _context = context;
            Appointments = new AppointmentRepository(_context);
            Customers = new CustomerRepository(_context);
            Vehicles = new VehicleRepository(_context);
        }

        public IAppointmentRepository Appointments { get; private set; }
        public ICustomerRepository Customers { get; private set; }
        public IVehicleRepository Vehicles { get; private set; }

        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }

    }
}
