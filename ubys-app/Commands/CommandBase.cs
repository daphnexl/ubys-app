using System;
using System.Windows.Input;

public abstract class CommandBase : ICommand
{
    public event EventHandler CanExecuteChanged;

    public abstract bool CanExecute(object parameter);
    public abstract void Execute(object parameter);

    protected void RaiseCanExecuteChanged()
    {
        CanExecuteChanged?.Invoke(this, EventArgs.Empty);
    }
}
