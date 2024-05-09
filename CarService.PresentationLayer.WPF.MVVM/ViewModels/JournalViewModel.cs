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
    public class JournalViewModel
    {
        private VehicleController vehicleController;
        string regNo = "abc123";

        private Vehicle vehicle = null!;

        public Vehicle JournalVehicle
        {
            get { return JournalVehicle; }
            set
            {
                JournalVehicle = value;

                Vehicle vehicle = vehicleController.GetVehicle(regNo);

                string registrationNo = vehicle.RegistrationNumber;
                string make = vehicle.Make;
                string model = vehicle.Model;
                string year = vehicle.Year;



            }


        }

        private ICommand refreshCommand = null!;
        public ICommand RefreshCommand => refreshCommand ??= refreshCommand = new RelayCommand(() =>
        {
            JournalVehicle = (vehicleController.GetVehicle(regNo));
        });

    }
}
