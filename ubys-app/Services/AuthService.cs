using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ubys_app.MVVM.Model;

namespace ubys_app.Services
{
    public class AuthService
    {
        public void Logout()
        {
            CurrentUser = null;
            Token = null;
            // Session temizliği vs.
        }

        public string Token { get; private set; }
        public User CurrentUser { get; private set; }
    }

}
