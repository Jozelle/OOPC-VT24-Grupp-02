using CarService.DataLayer.Context;
using CarService.DataLayer.Repositories.Base;
using CarService.DataLayer.Repositories.Interfaces;
using CarService.Entities;

namespace CarService.DataLayer.Repositories
{
    public class EmployeeRepository : Repository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(CarServiceContext context) : base(context)
        {
        }

        public ICollection<Mechanic> GetMechanics()
        {
            return Table.OfType<Mechanic>().ToList();
        }
        public ICollection<Receptionist> GetReceptionist()
        {
            return Table.OfType<Receptionist>().ToList();
        }
        public bool IsReceptionist(int id)
        {
            var employee = Table.Find(id);
            if (employee is Receptionist)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public Mechanic? GetMechanic(int id)
        {
            var employee = Table.Find(id);
            if (employee is Mechanic)
            {
                return (Mechanic)employee;
            }
            else { return null; }
        }
        public Receptionist? GetReceptionist(int id)
        {
            var employee = Table.Find(id);
            if (employee is Receptionist)
            {
                return (Receptionist)employee;
            }
            else { return null; }
        }
        public bool VerifyEmployee(int id, string password)
        {
            return Table
                .Any(x => x.EmployeeId == id && x.Password.Equals(password));
        }
    }
}
