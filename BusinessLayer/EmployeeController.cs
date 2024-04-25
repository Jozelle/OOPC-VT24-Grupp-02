using CarService.Entities;
using DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
