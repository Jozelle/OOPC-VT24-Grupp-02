using CarService.Entities;
using DataLayer;

namespace CarService.BusinessLayer
{
    public class EmployeeController
    {
        public EmployeeController() { }
        public bool VerifyUser(int id, string password)
        {
            using (UnitOfWork uow = new UnitOfWork())
            {
                return uow.Employees.VerifyEmployee(id, password);
            }
        }
        public Employee GetEmployee(int id)
        {
            using (UnitOfWork uow = new UnitOfWork())
            {
                return uow.Employees.Get(id);
            }
        }
        public bool IsReceptionist(int id)
        {
            using (UnitOfWork uow = new UnitOfWork())
            {
                return uow.Employees.IsReceptionist(id);
            }
        }
    }
}
