using CarService.PresentationLayer.WPF.MVVM.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CarService.PresentationLayer.WPF.MVVM.ViewModels
{
    public class MainViewModel
    {
        private ICommand exitCommand = null!;
        public ICommand ExitCommand => exitCommand ??= exitCommand = new RelayCommand(() => App.Current.Shutdown());
    }
}
