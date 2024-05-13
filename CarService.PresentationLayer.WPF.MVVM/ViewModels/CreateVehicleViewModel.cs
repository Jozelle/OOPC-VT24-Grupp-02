using CarService.BusinessLayer;
using CarService.Entities;
using CarService.PresentationLayer.WPF.MVVM.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CarService.PresentationLayer.WPF.MVVM.ViewModels
{
    public class CreateVehicleViewModel : ViewModelBase
    {
        //Controllers
        private CustomerController customerController = null!;
        private VehicleController vehicleController = null!;

        private string registrationNumber = "Registration number";


        //Properties
        private Customer customer = null!;
        public Customer Customer
        {
            get { return customer; }
            set
            {
                customer = value;
                OnPropertyChanged();
            }
        }

        private Vehicle vehicle = null!;
        public Vehicle Vehicle
        {
            get { return vehicle; }
            set
            {
                vehicle = value;
                OnPropertyChanged();
            }
        }

        public string RegistrationNumber
        {
            get { return registrationNumber; }
            set { registrationNumber = value; }
        }


        //Commands

        private ICommand addCustomerCommand = null!;
        public ICommand AddCustomerCommand => addCustomerCommand ??= addCustomerCommand = new RelayCommand(() =>
        {

        });

        private ICommand addVehicleCommand = null!;
        public ICommand AddVehicleCommand => addVehicleCommand ??= addVehicleCommand = new RelayCommand(() =>
        {

        });

    }
}
