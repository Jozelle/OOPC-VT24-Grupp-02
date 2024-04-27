using CarService.DataLayer.Repositories.Base;
using CarService.Entities;

namespace CarService.DataLayer.Repositories.Interfaces
{
    public interface IEmployeeRepository : IRepository<Employee>
    {
        ICollection<Mechanic> GetMechanics();
        ICollection<Receptionist> GetReceptionist();

        Mechanic GetMechanic(int id);
        Receptionist GetReceptionist(int id);

        bool VerifyEmployee(int id, string password);
        bool IsReceptionist(int id);
    }
}
