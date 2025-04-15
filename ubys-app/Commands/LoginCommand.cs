using System;
using System.Windows.Input;

public class LoginCommand : RelayCommand
{
    public LoginCommand(Action<object> execute) : base(execute) { }
}
