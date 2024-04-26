using BusinessLayer;
using CarService.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using MessageBox = System.Windows.MessageBox;

namespace CarService.PresentationLayer.WPF
{
    /// <summary>
    /// Interaction logic for Journal.xaml
    /// </summary>
    public partial class Journal : Window
    {
        CarServiceController controller = new();
        public Journal()
        {
            InitializeComponent();

            Vehicle vehicle = controller.GetVehicle("DAD567");

            labelRegistrationNo.Content = vehicle.RegistrationNumber;
            labelMake.Content = vehicle.Make;
            labelModel.Content = vehicle.Model;
            labelYear.Content = vehicle.Year;

            List<string> journalRows = new List<string>();
            List<Appointment> appointmentsInJournal = controller.ShowJournal(vehicle.RegistrationNumber);

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
    }
}
