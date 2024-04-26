using BusinessLayer;
using CarService.Entities;
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
