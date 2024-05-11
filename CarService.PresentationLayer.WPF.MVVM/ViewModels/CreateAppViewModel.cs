using CarService.BusinessLayer;
using CarService.Entities;
using CarService.PresentationLayer.WPF.MVVM.Commands;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace CarService.PresentationLayer.WPF.MVVM.ViewModels
{
    public class CreateAppViewModel : ViewModelBase
    {
        private VehicleController vehicleController = null!;
        private CustomerController customerController = null!;

        private string registrationNumber = "Registration number";
        public string RegistrationNumber
        {
            get { return registrationNumber; }
            set { registrationNumber = value; }
        }

        private Vehicle currentVehicle = null!;
        public Vehicle CurrentVehicle
        {
            get { return currentVehicle; }
            set
            {
                currentVehicle = value;
                OnPropertyChanged();
            }
        }

        private Customer currentCustomer = null!;
        public Customer CurrentCustomer
        {
            get { return currentCustomer; }
            set
            {
                currentCustomer = value;
                OnPropertyChanged();
            }
        }
        private string firstName = "First name";
        public string FirstName
        {
            get { return firstName; }
            set
            {
                firstName = value;
                OnPropertyChanged();
            }
        }
        private string lastName = "Last Name";
        public string LastName
        {
            get { return lastName; }
            set
            {
                lastName = value;
                OnPropertyChanged();
            }
        }
        private string socialSecurityNumber = "Social Security Number";
        public string SocialSecurityNumber
        {
            get { return socialSecurityNumber; }
            set
            {
                socialSecurityNumber = value;
                OnPropertyChanged();
            }
        }
        private string address = "Last Name";
        public string Address
        {
            get { return address; }
            set
            {
                address = value;
                OnPropertyChanged();
            }
        }
        private string postalCode = "Postal Code";
        public string PostalCode
        {
            get { return postalCode; }
            set
            {
                postalCode = value;
                OnPropertyChanged();
            }
        }
        private string city = "City";
        public string City
        {
            get { return city; }
            set
            {
                city = value;
                OnPropertyChanged();
            }
        }
        private string phoneNumber = "Phone Number";
        public string PhoneNumber
        {
            get { return phoneNumber; }
            set
            {
                phoneNumber = value;
                OnPropertyChanged();
            }
        }
        private string email = "Email";
        public string Email
        {
            get { return email; }
            set
            {
                email = value;
                OnPropertyChanged();
            }
        }
        private int searchTypeIndex = 0;
        public int SearchTypeIndex
        {
            get { return searchTypeIndex; }
            set
            {
                searchTypeIndex = value;
                OnPropertyChanged();
            }
        }
        public CreateAppViewModel()
        {
            vehicleController = new VehicleController();
            customerController = new CustomerController();
        }
        private ICommand searchVehicleCommand = null!;
        public ICommand SearchVehicleCommand => searchVehicleCommand ??= searchVehicleCommand = new RelayCommand(() =>
        {
            if(RegistrationNumber  != "Registration number")
            {
                CurrentVehicle = vehicleController.GetVehicle(RegistrationNumber);
                if(CurrentVehicle == null)
                {
                    MessageBox.Show("No vehicle could be found, please try again.");
                }
            }
        });

        private ICommand saveVehicleCommand = null!;
        public ICommand SaveVehicleCommand => saveVehicleCommand ??= saveVehicleCommand = new RelayCommand(() =>
        {
            if(CurrentVehicle == null)
            {
                MessageBox.Show("Please search for a vehicle before you try making changes.");
            }
            else if(CurrentVehicle.RegistrationNumber != RegistrationNumber)
            {
                MessageBox.Show("Something went wrong, please enter vehicle details and try again!");
                CurrentVehicle = null!;
            }
            else
            {
                int rowsChanged = vehicleController.UpdateVehicle(CurrentVehicle);
                if (rowsChanged > 0)
                {
                    MessageBox.Show($"The changes has been saved! {rowsChanged}");
                }
                else if (rowsChanged == -1)
                {
                    MessageBox.Show("Something went wrong, please try again!");
                }
                else
                {
                    MessageBox.Show("No changes was made.");
                }
            }
        });
        private ICommand searchCustomerCommand = null!;
        public ICommand SearchCustomerCommand => searchCustomerCommand ??= searchCustomerCommand = new RelayCommand(() =>
        {
            if (SearchTypeIndex == 0)
            {
                currentCustomer = customerController.GetCustomerBySSN(SocialSecurityNumber);
            }
            else if (SearchTypeIndex == 1)
            {
                currentCustomer = customerController.GetCustomerByPhone(PhoneNumber);
            }
            else if (SearchTypeIndex == 2)
            {
                currentCustomer = customerController.GetCustomerByFullName(FirstName, LastName);
            }
            else if (SearchTypeIndex == -1)
            {
                MessageBox.Show("Please choose what to search by in the drop down menu.");
                return;
            }
        });
    }
}
