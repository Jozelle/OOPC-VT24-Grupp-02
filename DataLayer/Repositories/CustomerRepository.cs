using CarService.DataLayer.Context;
using CarService.DataLayer.Repositories.Base;
using CarService.DataLayer.Repositories.Interfaces;
using CarService.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarService.DataLayer.Repositories
{
    public class CustomerRepository : Repository<Customer>, ICustomerRepository
    {
        public CustomerRepository(CarServiceContext context) : base(context)
        {
        }

        public  Customer GetByFullName(string firstName, string lastName)
        {
            return Context.Set<Customer>().Single(x => x.FirstName == firstName && x.LastName == lastName);
        }

        public Customer GetBySocialSecurityNo(string socialSecurityNo)
        {
            return Context.Set<Customer>().Find(socialSecurityNo);

            //return Context.Set<Customer>().Find(socialSecurityNo) ?? throw new Exception("Kund med det angivna sociala säkerhetsnumret hittades inte.");
        }

        public CarServiceContext CarServiceContext
        {
            get { return CarServiceContext as CarServiceContext; }
        }

    }

  
}