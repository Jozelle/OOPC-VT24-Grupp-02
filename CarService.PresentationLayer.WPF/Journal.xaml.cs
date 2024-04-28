using CarService.BusinessLayer;
using CarService.Entities;
using System.Windows;
using MessageBox = System.Windows.MessageBox;

namespace CarService.PresentationLayer.WPF
{
    /// <summary>
    /// Interaction logic for Journal.xaml
    /// </summary>
    public partial class Journal : Window
    {
        VehicleController vehicleController = new();
        public Journal(string regNo)
        {
            InitializeComponent();

            Vehicle vehicle = vehicleController.GetVehicle(regNo);

            labelRegistrationNo.Content = vehicle.RegistrationNumber;
            labelMake.Content = vehicle.Make;
            labelModel.Content = vehicle.Model;
            labelYear.Content = vehicle.Year;

            List<string> journalRows = new List<string>();
            List<Appointment> appointmentsInJournal = vehicleController.GetJournal(vehicle.RegistrationNumber);

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

            lbxJournal.ItemsSource = journalRows;
        }

        private void btnSend_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("This method is not implemented yet, sorry!");
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
