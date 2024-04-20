using CarService.DataLayer;
using CarService.DataLayer.Context;
using CarService.DataLayer.Repositories;
using CarService.DataLayer.Repositories.Interfaces;
using CarService.Entities;

namespace DataLayer
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly CarServiceContext _context = new CarServiceContext();

        //public UnitOfWork(CarServiceContext context)
        //{
        //    _context = context;
        //    Appointments = new AppointmentRepository(_context);
        //    Customers = new CustomerRepository(_context);
        //    Vehicles = new VehicleRepository(_context);
        //    Items = new ItemRepository(_context);
        //    UsedItems = new UsedItemRepository(_context);
        //}

        public UnitOfWork()
        {
            Appointments = new AppointmentRepository(_context);
            Customers = new CustomerRepository(_context);
            Vehicles = new VehicleRepository(_context);
            Items = new ItemRepository(_context);
            UsedItems = new UsedItemRepository(_context);
        }

        public IAppointmentRepository Appointments { get; private set; }
        public ICustomerRepository Customers { get; private set; }
        public IVehicleRepository Vehicles { get; private set; }
        public IItemRepository Items { get; private set; }
        public IUsedItemRepository UsedItems { get; private set; }
        public IMechanicCommentRepository MechanicComments { get; private set; }

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
