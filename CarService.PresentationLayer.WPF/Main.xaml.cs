using BusinessLayer;
using CarService.Entities;
using System.Collections.ObjectModel;
using System.Windows;

namespace CarService.PresentationLayer.WPF
{
    /// <summary>
    /// Interaction logic for Main.xaml
    /// </summary>
    public partial class Main : Window
    {
        CarServiceController controller = new CarServiceController();
        internal IList<Appointment> _appointments = new ObservableCollection<Appointment>();
        public Main(int id)
        {
            InitializeComponent();

            _appointments = controller.GetCurrentAppointments();
            if (_appointments.Count > 0 && _appointments != null)
            {
                lbxAppointments.ItemsSource = _appointments;
            }
        }

        private void btn_CreateBooking_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btn_SearchAppointment_Click(object sender, RoutedEventArgs e)
        {

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
    }
}
