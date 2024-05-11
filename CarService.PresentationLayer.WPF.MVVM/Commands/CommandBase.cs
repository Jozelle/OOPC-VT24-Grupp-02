using System.Windows.Input;

namespace CarService.PresentationLayer.WPF.MVVM.Commands
{
    public abstract class CommandBase : ICommand
    {
        public virtual bool CanExecute(object parameter) => true;

        public abstract void Execute(object parameter);

        public event EventHandler CanExecuteChanged
        {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
        }
    }
}
