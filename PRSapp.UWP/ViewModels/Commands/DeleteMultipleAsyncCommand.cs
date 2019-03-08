using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PRSapp.UWP.ViewModels.Commands
{
    public class DeleteMultipleAsyncCommand : ICommand
    {
        public ViewModelBase ViewModel { get; set; }

        public DeleteMultipleAsyncCommand(ViewModelBase viewModel)
        {
            ViewModel = viewModel;
        }
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            if(parameter != null)
            {
                //if(ShowTitlesListView.SelectedItems.Count)
                return false;
                 
            }
            return true;
        }

        public void Execute(object parameter)
        {
            ViewModel.DeleteMultipleAsycnMethod();
        }
    }
}
