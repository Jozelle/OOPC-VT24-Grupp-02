using CarService.DataLayer.Context;
using CarService.DataLayer.Repositories.Base;
using CarService.DataLayer.Repositories.Interfaces;
using CarService.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarService.DataLayer.Repositories
{
    public class EmployeeRepository : Repository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(CarServiceContext context) : base(context)
        { 
        }

        public ICollection<Mechanic> GetMechanics()
        {
            return Context.Set<Employee>().OfType<Mechanic>().ToList();
        }
        public ICollection<Receptionist> GetReceptionist()
        {
            return Context.Set<Employee>().OfType<Receptionist>().ToList();
        }

        public Mechanic? GetMechanic(int id)
        {
            var employee = Context.Set<Employee>().Find(id);
            if (employee is Mechanic)
            {
                return (Mechanic)employee;
            }
            else { return null; }
        }
        public Receptionist? GetReceptionist(int id)
        {
            var employee = Context.Set<Employee>().Find(id);
            if (employee is Receptionist)
            {
                return (Receptionist)employee;
            }
            else { return null; }
        }
        public bool VerifyEmployee(int id, string password)
        {
            return Context.Set<Employee>()
                .Any(x => x.EmployeeId == id && x.Password.Equals(password));
        }
    }
}
