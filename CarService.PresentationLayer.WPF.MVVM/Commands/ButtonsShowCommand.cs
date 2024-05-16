using CarService.PresentationLayer.WPF.MVVM.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarService.PresentationLayer.WPF.MVVM.Commands
{
    class ButtonsShowCommand : CommandBase
    {



        private readonly ButtonVisibilityStore _buttonVisibilityStore;
        public ButtonsShowCommand(ButtonVisibilityStore buttonVisibilityStore)
        {
            _buttonVisibilityStore = buttonVisibilityStore;
        }
        public override void Execute(object parameter)
        {
            _buttonVisibilityStore.CurrentButtonVisibility = true;
        }

       

      
    }
}
