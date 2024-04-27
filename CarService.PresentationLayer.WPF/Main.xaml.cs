using CarService.BusinessLayer;
using CarService.Entities;
using System.Collections.ObjectModel;
using System.Windows;
using MessageBox = System.Windows.MessageBox;

namespace CarService.PresentationLayer.WPF
{
    /// <summary>
    /// Interaction logic for Main.xaml
    /// </summary>
    public partial class Main : Window
    {
        AppointmentController appointmentController = new AppointmentController();

       internal Appointment currentAppointment;

       internal IList<Appointment> _appointments = new ObservableCollection<Appointment>();
        public Main(int id)
        {
            InitializeComponent();

            _appointments = appointmentController.GetTodaysAppointments();
            if (_appointments.Count > 0 && _appointments != null)
            {
                CurrentAppLB.ItemsSource = _appointments;
            }
        }

        private void btn_CreateBooking_Click(object sender, RoutedEventArgs e)
        {
            CreateAppointmentWindow createAppointmentWindow = new CreateAppointmentWindow();
            createAppointmentWindow.ShowDialog();

        }

        private void btn_OkAppointment_Click(object sender, RoutedEventArgs e)
        {
            if (CurrentAppLB.SelectedItem != null)
            {
                currentAppointment = (Appointment)CurrentAppLB.SelectedItem;
                SelectedAppTB.Text = currentAppointment.AppointmentId.ToString();
            }
            else
            {
                MessageBox.Show("Please select an appointment in the list.");
            }
        }
        private void btn_SearchAppointment_Click(object sender, RoutedEventArgs e)
        {
            if (SelectionBox.SelectedIndex == 0)
            {
                //SSNo.
                CurrentAppLB.ItemsSource = appointmentController.GetAppointmentsBySSNo(SearchAppTB.Text);
                
            }

            else if (SelectionBox.SelectedIndex == 1)
            {
                //PhoneNo.
                CurrentAppLB.ItemsSource = appointmentController.GetAppointmentsByPhoneNo(SearchAppTB.Text);
            }
            
            else if (SelectionBox.SelectedIndex == 2)
            {
                //FullName
                string[] nameStrings = SearchAppTB.Text.Split(",");
                if (nameStrings != null && nameStrings.Length == 2 ) 
                {
                    CurrentAppLB.ItemsSource = appointmentController.GetAppointmentsByFullName(nameStrings[0], nameStrings[1]);
                }
               
            }

            else if(SelectionBox.SelectedIndex == 3)
            {
                //RegNo.
                CurrentAppLB.ItemsSource = appointmentController.GetAppointmentsByRegNo(SearchAppTB.Text);

            }

            else { }

        }

        private void btn_SearchRegNo_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btn_SubmitVehicle_Click(object sender, RoutedEventArgs e)
        {

        }

        private void DatePicker_CalendarOpened(object sender, RoutedEventArgs e)
        {

        }

        private void rbtn_CardPayment_Click(object sender, RoutedEventArgs e)
        {

        }

        private void rbtn_CashPayment_Click(object sender, RoutedEventArgs e)
        {

        }

        private void rbtn_SwishPayment_Click(object sender, RoutedEventArgs e)
        {

        }

        private void rbtn_CardPayment_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void rbtn_CashPayment_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void rbtn_SwishPayment_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void btn_CheckoutPayment_Click(object sender, RoutedEventArgs e)
        {

        }

       

        private void btn_SaveStatus_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btn_AddComment_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btn_GenerateInvoice_Click(object sender, RoutedEventArgs e)
        {

        }

        private void SearchAppTB_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {

        }
    }
}
