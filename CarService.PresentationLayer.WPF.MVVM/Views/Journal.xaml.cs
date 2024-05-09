using CarService.BusinessLayer;
using CarService.Entities;
using System.Windows;
using MessageBox = System.Windows.MessageBox;

namespace CarService.PresentationLayer.WPF.MVVM.Views
{
    /// <summary>
    /// Interaction logic for Journal.xaml
    /// </summary>
    public partial class Journal : Window
    {
        VehicleController vehicleController = new();
        public Journal(/*string regNo*/)
        {
            InitializeComponent();
        }
    }
}
