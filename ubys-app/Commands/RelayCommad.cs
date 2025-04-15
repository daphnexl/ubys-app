using System;
using System.Windows.Input;

public class RelayCommand : ICommand
{
    private readonly Action<object> _execute;
    private readonly Func<object, bool> _canExecute;

    // Constructor
    public RelayCommand(Action<object> execute) : this(execute, null) { }

    public RelayCommand(Action<object> execute, Func<object, bool> canExecute)
    {
        _execute = execute ?? throw new ArgumentNullException(nameof(execute));
        _canExecute = canExecute;
    }

    // CanExecuteChanged event
    public event EventHandler CanExecuteChanged
    {
        add => CommandManager.RequerySuggested += value;
        remove => CommandManager.RequerySuggested -= value;
    }

    // CanExecute method to determine whether the command can execute
    public bool CanExecute(object parameter)
    {
        return _canExecute == null || _canExecute(parameter);
    }

    // Execute method to perform the command
    public void Execute(object parameter)
    {
        _execute(parameter);
    }
}
