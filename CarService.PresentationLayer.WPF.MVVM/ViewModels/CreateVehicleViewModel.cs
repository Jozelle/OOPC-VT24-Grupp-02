using CarService.PresentationLayer.WPF.MVVM.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CarService.PresentationLayer.WPF.MVVM.ViewModels
{
    public class CreateVehicleViewModel : ViewModelBase
    {













        private ICommand addVehicleCommand = null!;
        public ICommand AddVehicleCommand => addVehicleCommand ??= addVehicleCommand = new RelayCommand(() =>
        {

        });

    }
}
