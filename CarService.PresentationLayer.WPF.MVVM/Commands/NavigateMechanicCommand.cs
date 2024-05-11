using CarService.PresentationLayer.WPF.MVVM.Stores;
using CarService.PresentationLayer.WPF.MVVM.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarService.PresentationLayer.WPF.MVVM.Commands
{
    public class NavigateMechanicCommand : CommandBase
    {
        private readonly NavigationStore _navigationStore;
        public NavigateMechanicCommand(NavigationStore navigationStore)
        {
            _navigationStore = navigationStore;
        }
        public override void Execute(object parameter)
        {
            _navigationStore.CurrentViewModel = new MechanicViewModel();
            //_navigationStore.CurrentViewModel = new MechanicViewModel(_navigationStore);
        }
    }
}
