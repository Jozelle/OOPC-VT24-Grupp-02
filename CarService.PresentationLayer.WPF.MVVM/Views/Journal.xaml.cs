using CarService.BusinessLayer;
using CarService.Entities;
using CarService.PresentationLayer.WPF.MVVM.Services;
using CarService.PresentationLayer.WPF.MVVM.ViewModels;
using System.Windows;
using MessageBox = System.Windows.MessageBox;

namespace CarService.PresentationLayer.WPF.MVVM.Views
{
    /// <summary>
    /// Interaction logic for Journal.xaml
    /// </summary>
    public partial class Journal : Window, ICloseable
    {

        public Journal()
        {
            InitializeComponent();

        }
    }
}
