using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ubys_app.Services;

namespace ubys_app.Commands
{
    public class NavigateCommand : CommandBase
    {
        private readonly INavigationService _navigationService;

        public NavigateCommand(INavigationService navigationService)
        {
            _navigationService = navigationService;
        }

        public override bool CanExecute(object parameter)
        {
            return true; // veya istenilen koşul
        }

        public override void Execute(object parameter)
        {
            _navigationService.Navigate();
        }
    }

}
