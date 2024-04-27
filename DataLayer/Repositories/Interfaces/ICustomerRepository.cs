using CarService.DataLayer.Repositories.Base;
using CarService.Entities;

namespace CarService.DataLayer.Repositories.Interfaces
{
    public interface ICustomerRepository : IRepository<Customer>
    {
        //Unika metoder för kunder

        Customer GetByFullName(string firstName, string lastName);

        Customer GetBySocialSecurityNo(string socialSecurityNo);

        Customer GetByPhoneNo(string phoneNo);




    }
}
