using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ubys_app.Services
{
    public class LogoutNavigationService : INavigationService
    {
        private readonly AuthService _authService;
        private readonly INavigationService _loginNavigationService;

        public LogoutNavigationService(AuthService authService, INavigationService loginNavigationService)
        {
            _authService = authService;
            _loginNavigationService = loginNavigationService;
        }

        public void Navigate()
        {
            _authService.Logout(); // örneğin token, kullanıcı verilerini temizle
            _loginNavigationService.Navigate(); // login ekranına geç
        }
    }

}
