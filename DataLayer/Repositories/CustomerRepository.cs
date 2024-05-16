using CarService.DataLayer.Context;
using CarService.DataLayer.Repositories.Base;
using CarService.DataLayer.Repositories.Interfaces;
using CarService.Entities;
using Microsoft.EntityFrameworkCore;

namespace CarService.DataLayer.Repositories
{
    public class CustomerRepository : Repository<Customer>, ICustomerRepository
    {
        private CarServiceContext _context;
        public CustomerRepository(CarServiceContext context) : base(context)
        {
            _context = context;
        }

        public Customer? GetByFullName(string firstName, string lastName)
        {
            try
            {
                return Table.Single(x => x.FirstName == firstName && x.LastName == lastName);
            }

            catch { return null; }
        }

        public Customer? GetBySocialSecurityNo(string socialSecurityNo)
        {
            try
            {
                return Table.Single(x => x.SocialSecurityNumber == socialSecurityNo);
            }
            catch { return null; }
        }
        public Customer? GetByPhoneNo(string phoneNo)
        {
            try
            {
                return Table.Single(x => x.PhoneNumber == phoneNo);
            }
            catch { return null; }
        }

        public List<string> GetVehicleByCustomer(Customer customer)
        {
            List<string> vehicleStrings = Table
                .Join(
                    _context.Appointments,
                    c => c.CustomerID,
                    a => a.CustomerId,
                    (c, a) => new { c, a }
                    )
                .Where(combinedTable => combinedTable.a.CustomerId == customer.CustomerID)
                //.GroupBy(combinedTable => combinedTable.a.VehicleRegistrationNumber)
                .Select(combinedTable => combinedTable.a.VehicleRegistrationNumber).Distinct()
                .ToList();

            return vehicleStrings;

        }
    }
}