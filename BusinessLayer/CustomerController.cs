using CarService.Entities;
using DataLayer;

namespace CarService.BusinessLayer
{
    public class CustomerController
    {
        public CustomerController() { }

        public Customer? GetCustomerBySSN(string ssn)
        {
            using (UnitOfWork uow = new UnitOfWork())
            {
                return uow.Customers.GetBySocialSecurityNo(ssn);
            }
        }

        public Customer? GetCustomerByPhone(string phoneNo)
        {
            using (UnitOfWork uow = new UnitOfWork())
            {
                return uow.Customers.GetByPhoneNo(phoneNo);
            }
        }

        public Customer? GetCustomerByFullName(string firstName, string lastName)
        {
            using (UnitOfWork uow = new UnitOfWork())
            {
                return uow.Customers.GetByFullName(firstName, lastName);
            }
        }
      

        public int SaveCustomer(Customer customer)
        {
            using (UnitOfWork uow = new UnitOfWork())
            {
                Customer customerFromDB = uow.Customers.GetBySocialSecurityNo(customer.SocialSecurityNumber);
                if (customerFromDB == null)
                {
                    uow.Customers.Add(customer);
                    return uow.Complete();
                }
                else
                {
                    //uow.Customers.Update(customerFromDB, customer);
                    //return uow.Complete();
                    return -1;
                }
            }
        }
        public int UpdateCustomer(Customer customer)
        {
            using (UnitOfWork uow = new UnitOfWork())
            {
                Customer customerFromDB = uow.Customers.FirstOrDefault(x => x.CustomerID == customer.CustomerID);
                if (customerFromDB != null)
                {
                    uow.Customers.Update(customerFromDB, customer);
                    return uow.Complete();
                }
                else
                    return 0;
            }
        }
    }
}
