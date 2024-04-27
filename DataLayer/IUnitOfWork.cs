using CarService.DataLayer.Repositories.Interfaces;

namespace CarService.DataLayer
{
    public interface IUnitOfWork : IDisposable
    {
        IAppointmentRepository Appointments { get; }
        ICustomerRepository Customers { get; }
        IVehicleRepository Vehicles { get; }
        IItemRepository Items { get; }
        IUsedItemRepository UsedItems { get; }
        IEmployeeRepository Employees { get; }
        ICommentRepository Comments { get; }

        int Complete();
    }
}
