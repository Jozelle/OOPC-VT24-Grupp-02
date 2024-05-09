using CarService.BusinessLayer;
using CarService.Entities;
using CarService.PresentationLayer.WPF.MVVM.Commands;
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
    public class JournalViewModel
    {
        //Properties
        private VehicleController vehicleController;

        private Vehicle journalVehicle = null!;
        public Vehicle JournalVehicle
        {
            get { return journalVehicle; }
            set { journalVehicle = value; }
        }

        private List<string> journalRows = null!;
        public List<string> JournalRows 
        {
            get { return journalRows; } 
            set { journalRows = value; } 
        }

        //Constructor
        public JournalViewModel(/*string regNo*/)
        {
            string regNo = "ABC123";
            
            vehicleController = new VehicleController();
            JournalVehicle = vehicleController.GetVehicle(regNo);

            journalRows = new List<string>();
            List<Appointment> appointmentsInJournal = vehicleController.GetJournal(journalVehicle.RegistrationNumber);

            foreach (Appointment appointment in appointmentsInJournal)
            {
                journalRows.Add(appointment.SubmissionDate.ToShortDateString() + " - " + appointment.Purpose);
                foreach (UsedItem ui in appointment.UsedItems)
                {
                    journalRows.Add($"Item: {ui.Item.Description}\t{ui.Quantity} pcs");
                }
                foreach (Comment comment in appointment.Comments)
                {
                    journalRows.Add($"Added by: {comment.Author.FirstName}\t{comment.Message}");
                }
            }
        }

        //Commands
        private ICommand exitCommand = null!;
        public ICommand ExitCommand => exitCommand ??= exitCommand = new RelayCommand(() => App.Current.Shutdown());

        private ICommand sendCommand = null!;
        public ICommand SendCommand => sendCommand ??= sendCommand = new RelayCommand(() => MessageBox.Show("Not ready yet!"));
    }
}
