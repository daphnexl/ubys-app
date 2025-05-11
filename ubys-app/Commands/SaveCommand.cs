using System;
using System.Windows.Input;

namespace ubys_app.Commands
{
    public class SaveCommand : ICommand
    {
        private readonly Action<object> _execute;

        public SaveCommand(Action<object> execute)
        {
            _execute = execute ?? throw new ArgumentNullException(nameof(execute));
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            // Burada, Save komutunun aktif olup olmadığını belirleyebilirsiniz.
            return true; // Örneğin, her zaman aktif
        }

        public void Execute(object parameter)
        {
            _execute(parameter);
        }
    }
}
