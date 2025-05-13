using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ubys_app.Services;

namespace ubys_app.MVVM.ViewModel
{
    public class AdminHomeVM : ViewModelBase
    {
        private readonly INavigationService _navigationService;

        public AdminHomeVM(INavigationService navigationService)
        {
            _navigationService = navigationService;
        }

    }
}
