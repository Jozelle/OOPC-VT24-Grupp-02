
using CarService.BusinessLayer;
using CarService.Entities;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using MessageBox = System.Windows.MessageBox;

namespace CarService.PresentationLayer.WPF
{
    /// <summary>
    /// Interaction logic for AddItemsToAppointmentWindow.xaml
    /// </summary>

    public partial class AddItemsToAppointmentWindow : Window
    {

        AppointmentController ac = new();
        ItemController ic = new();
        VehicleController vc = new();
        EmployeeController ec = new();

        internal IList<Appointment> _appointments = new ObservableCollection<Appointment>();
        internal Appointment? currentAppointment;
        internal Vehicle? currentVehicle;
        internal Item? currentItem;
        internal int loggedInId;


        public AddItemsToAppointmentWindow(int id)
        {
            InitializeComponent();

            loggedInId = id;
            _appointments = ac.GetTodaysAppointments();

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
                List<Appointment> nyLista = ac.GetAppointmentsByRegNo(searchVehicleTB.Text);
                addItemLB.ItemsSource = nyLista;
            }
            else
            {
                MessageBox.Show("No appointments where found related to that registration number, " +
                    "or the registration number where entered incorrectly. Please try again!", "Oops, something went wrong!");
            }

        }

        private void chosenAppButton_Click(object sender, RoutedEventArgs e)
        {
            if (addItemLB.SelectedItem != null)
            {
                currentAppointment = (Appointment)addItemLB.SelectedItem;
                currentVehicle = vc.GetVehicle(currentAppointment.Vehicle.RegistrationNumber);


                RegTB.Text = currentAppointment.Vehicle.RegistrationNumber;
                CarDescriptionTB.Text = $"{currentAppointment.Vehicle.Make} {currentAppointment.Vehicle.Model}, {currentAppointment.Vehicle.Year}";
                AppDescriptionTB.Text = currentAppointment.Purpose;

                addItem2LB.ItemsSource = currentAppointment.UsedItems;
                addCommentLB.ItemsSource = currentAppointment.Comments;
            }
            else
            {
                MessageBox.Show("No appointment was selected, please try again!");
            }

        }

        private void SearchItemButton_Click(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(ItemTB.Text, out int id))
            {
                currentItem = ic.GetItem(id);

                if (currentItem == null)
                {
                    MessageBox.Show("No item was found!");
                }
                else
                {
                    ItemDescriptionTB.Text = currentItem.Description;
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
                int affectedRows = ac.EnterItem(currentAppointment, currentItem, amount);
                MessageBox.Show($"{amount} piece(s) of the item {currentItem.Description} was added!" +
                    $"\n{affectedRows} were affected!");
            }

        }

        private void ItemTB_GotKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            ItemTB.Text = "";
        }

        private void QuantityTB_GotKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            QuantityTB.Text = "";
        }

        private void AddCommentButton_Click(object sender, RoutedEventArgs e)
        {
            if (AddCommentTB.Text.Length > 0 && currentAppointment != null)
            {
                Employee loggedInEmployee = ec.GetEmployee(loggedInId);
                int affectedRows = ac.AddCommentToAppointment(currentAppointment, AddCommentTB.Text, loggedInEmployee);
                MessageBox.Show($"The comment was added! {affectedRows} were affected.");
            }
            else
            {
                MessageBox.Show("Please enter a comment!");
            }
        }

        private void searchVehicleTB_IsKeyboardFocusedChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            searchVehicleTB.Text = "";

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (currentVehicle != null)
            {
                Journal journal = new Journal(currentVehicle.RegistrationNumber);
                journal.ShowDialog();
            }

            else MessageBox.Show("Please select an appointment!");
        }

        private void btn_SaveStatus_Click(object sender, RoutedEventArgs e)
        {
            if (currentAppointment != null)
            {
                int selected = ChooseStatusBox.SelectedIndex;
                switch (selected)
                {
                    case 0:
                        currentAppointment.Status = Entities.Enums.AppointmentStatus.CarReceived;
                        break;

                    case 1:
                        currentAppointment.Status = Entities.Enums.AppointmentStatus.Booked;
                        break;

                    case 2:
                        currentAppointment.Status = Entities.Enums.AppointmentStatus.InProgress;
                        break;

                    case 3:
                        currentAppointment.Status = Entities.Enums.AppointmentStatus.WaitingForParts;
                        break;

                    case 4:
                        currentAppointment.Status = Entities.Enums.AppointmentStatus.ReadyForPickup;
                        break;

                    case 5:
                        currentAppointment.Status = Entities.Enums.AppointmentStatus.Canceled;
                        break;

                    case 6:
                        currentAppointment.Status = Entities.Enums.AppointmentStatus.Completed;
                        break;
                }

                int affectedRows = ac.SaveChanges(currentAppointment);
                if (affectedRows > 0)
                {
                    MessageBox.Show("The status was changed!");
                }
            }
            else
            {
                MessageBox.Show("Please select an appointment first!");
            }
        }

        private void btn_Exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
