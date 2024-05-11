using CarService.BusinessLayer;
using CarService.Entities;
using CarService.PresentationLayer.WPF.MVVM.Commands;
using CarService.PresentationLayer.WPF.MVVM.Stores;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace CarService.PresentationLayer.WPF.MVVM.ViewModels
{
    public class JournalViewModel : ViewModelBase
    {
        //Properties
        private VehicleController vehicleController;

        private Vehicle journalVehicle = null!;
        public Vehicle JournalVehicle
        {
            get { return journalVehicle; }
            set { journalVehicle = value;
                OnPropertyChanged();
            }
        }

        private List<string> journalRows = null!;
        public List<string> JournalRows 
        {
            get { return journalRows; } 
            set { journalRows = value;
                OnPropertyChanged();
            } 
        }

        private string searchString;
        public string SearchString
        {
            get { return searchString; }
            set { searchString = value; }
        }

        //Constructor
        //public JournalViewModel(NavigationStore navigationStore)
        public JournalViewModel()
        {          
            vehicleController = new VehicleController();
        }

        //Commands
        private ICommand exitCommand = null!;
        public ICommand ExitCommand => exitCommand ??= exitCommand = new RelayCommand(() => App.Current.Shutdown());

        private ICommand sendCommand = null!;
        public ICommand SendCommand => sendCommand ??= sendCommand = new RelayCommand(() => MessageBox.Show("Not ready yet!"));

        private ICommand searchVehicleCommand = null!;
        public ICommand SearchVehicleCommand => searchVehicleCommand ??= searchVehicleCommand = new RelayCommand(() =>
        {
            JournalVehicle = vehicleController.GetVehicle(SearchString);

            List<string> newList = new List<string>();
            List<Appointment> appointmentsInJournal = vehicleController.GetJournal(journalVehicle.RegistrationNumber);

            foreach (Appointment appointment in appointmentsInJournal)
            {
                newList.Add(appointment.SubmissionDate.ToShortDateString() + " - " + appointment.Purpose);
                foreach (UsedItem ui in appointment.UsedItems)
                {
                    newList.Add($"Item: {ui.Item.Description}\t{ui.Quantity} pcs");
                }
                foreach (Comment comment in appointment.Comments)
                {
                    newList.Add($"Added by: {comment.Author.FirstName}\t{comment.Message}");
                }
            }

            JournalRows = newList;
        });
    }
}
