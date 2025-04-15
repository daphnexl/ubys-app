using System;
using System.Windows.Input;

public class ForgotPasswordCommand : RelayCommand
{
    public ForgotPasswordCommand(Action<object> execute) : base(execute) { }
}
