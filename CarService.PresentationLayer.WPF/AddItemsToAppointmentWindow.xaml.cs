using BusinessLayer;
using CarService.Entities;
using CarService.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace CarService.PresentationLayer.WPF
{
    /// <summary>
    /// Interaction logic for AddItemsToAppointmentWindow.xaml
    /// </summary>

    public partial class AddItemsToAppointmentWindow : Window
    {
        CarServiceController controller = new CarServiceController();
        internal IList<Appointment> _appointments = new ObservableCollection<Appointment>();
        internal Appointment? currentAppointment;
        internal Vehicle? currentVehicle;
        internal Item? currentItem;

        public AddItemsToAppointmentWindow()
        {
            InitializeComponent();
            _appointments = controller.getCurrentAppointments();

            if (_appointments.Count > 0 && _appointments != null)
            {
                addItemLB.ItemsSource = _appointments;
            }

        }

        private void searchVehicleButton_Click(object sender, RoutedEventArgs e)
        {
            if (searchVehicleTB.Text.Count() == 6)
            {
                _appointments.Clear();
                List<Appointment> nyLista = controller.getAppointments(searchVehicleTB.Text);
                addItemLB.ItemsSource = nyLista;
            }
            else
            {
                MessageBox.Show("No appointments where found related to that registration number, " +
                    "or the registration number where entered incorrectly. Please try again!", "Oops, something went wrong!");
            }

        }

        private void searchVehicleTB_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void chosenAppButton_Click(object sender, RoutedEventArgs e)
        {
            currentAppointment = (Appointment)addItemLB.SelectedItem;
            currentVehicle = controller.GetVehicle(currentAppointment.Vehicle.RegistrationNumber);


            RegTB.Text = currentAppointment.Vehicle.RegistrationNumber;
            MakeTB.Text = currentAppointment.Vehicle.Make;
            ModelTB.Text = currentAppointment.Vehicle.Model;

            addItem2LB.ItemsSource = currentAppointment.UsedItems;

        }

        private void SearchItemButton_Click(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(ItemTB.Text, out int id))
            {
                currentItem = controller.GetItem(id);

                if (currentItem == null)
                {
                    MessageBox.Show("No item was found!");
                }
                else
                {
                    DescriptionTB.Text = currentItem.Description;
                }
            }
            else
            {
                MessageBox.Show("Item ID was not entered correctly, please try again!");
            }

        }

        private void AddItemButton_Click(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(QuantityTB.Text, out int amount))
            {
                controller.EnterItem(currentAppointment, currentItem, amount);
                MessageBox.Show($"{amount} piece(s) of the item {currentItem.Description} was added!");
            }
            
        }
    }
}
