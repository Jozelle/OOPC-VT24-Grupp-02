using CarService.DataLayer.Context;
using CarService.DataLayer.Repositories.Base;
using CarService.DataLayer.Repositories.Interfaces;
using CarService.Entities;
using DataLayer;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.X509Certificates;

namespace CarService.DataLayer.Repositories
{
    public class CustomerRepository : Repository<Customer>, ICustomerRepository
    {
        public CustomerRepository(CarServiceContext context) : base(context)
        {
        }

        public Customer ? GetByFullName(string firstName, string lastName)
        {
            try
            {
                return Context.Set<Customer>().Single(x => x.FirstName == firstName && x.LastName == lastName);
            }

            catch { return null; }
        }

        public Customer? GetBySocialSecurityNo(string socialSecurityNo)
        {
            try
            {
                return Context.Set<Customer>().Single(x => x.SocialSecurityNumber == socialSecurityNo);
            }
            catch { return null; }
        }
        public Customer ? GetByPhoneNo(string phoneNo)
        {
            try
            {
                return Context.Set<Customer>().Single(x => x.PhoneNumber == phoneNo);
            }
            catch { return null; }
        }

        

    }


}