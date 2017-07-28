using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FolderExplorer
{
    public class RelayCommand : ICommand
    {
        private Action _action;

        public event EventHandler CanExecuteChanged = (sender, e) => { };

        public RelayCommand(Action action)
        {
            _action = action;                
        }

        public bool CanExecute(object parameter)
            => _action != null;

        public void Execute(object parameter)
        {
            _action?.Invoke();
        }
    }
}
