using System;
using System.Windows.Input;

namespace PRSapp.UWP.ViewModels.Commands
{
    public class ChangeForeGroundColorCommand : ICommand
    {
        public ViewModelBase ViewModel { get; set; }

        public ChangeForeGroundColorCommand(ViewModelBase viewModel)
        {
            ViewModel = viewModel;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            ViewModel.ChangeForeGroundColorMethod();
        }
    }
}
