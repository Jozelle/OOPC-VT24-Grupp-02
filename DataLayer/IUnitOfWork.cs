using CarService.DataLayer.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        IMechanicCommentRepository MechanicComments { get; }

        IReceptionistRepository Receptionists { get; }

        int Complete();
    }
}
