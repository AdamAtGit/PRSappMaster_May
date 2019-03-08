using System;
using System.Diagnostics;
using System.Windows.Input;

namespace PRSapp.UWP.ViewModels.Commands
{
    public class RelayCommand : ICommand
    {

        //The 2Constructors    
        /// <summary>
        /// Adam creates a new command that can always execute.
        /// </summary>
        /// <param name="Execute">Adams execution logic.</param>
        public RelayCommand(Action<object> Execute)
             : this(Execute, null)// the : this(...) is called an initializer.
                                  //Maybe used only in constructors. 
                                  //not sure, but executes the method.
                                  //Can have only 1 per method, someone said.
        {
        }
        /// <summary>
        /// Creates another command.
        /// </summary>
        /// <param name="Execute"></param>
        /// <param name="CanExecute"></param>
        public RelayCommand(Action<object> execute, Predicate<object> canExecute)
        {
            _execute = execute;
            _canExecute = canExecute;
        }

        //Fields
        readonly Action<object> _execute;
        readonly Predicate<object> _canExecute;

        #region ICommand Members
        [DebuggerStepThrough]
        public bool CanExecute(object parameter)
        {
            return _canExecute == null ? true : _canExecute(parameter);
        }
        public void Execute(object parameter)
        {
            _execute(parameter);
        }

        public event EventHandler CanExecuteChanged;

        public void RaiseCanExecuteChanged()
        {
            if (CanExecuteChanged != null)
                CanExecuteChanged(this, EventArgs.Empty);
        }
        //in WinRT apps, Win Phone UWP, etc use above, below is for >NET platform apps like WPF
        //add { CommandManager.RequerySuggested += value; }
        //remove { CommandManager.RequerySuggested -= value; }

        #endregion    
    }
}
