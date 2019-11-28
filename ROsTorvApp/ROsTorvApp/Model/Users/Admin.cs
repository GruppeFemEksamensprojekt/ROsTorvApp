using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ROsTorvApp.Model.Users
{
    class Admin : UserAccount
    {
        public Admin(string userName, string email, string password, string phoneNo, bool isAdmin)
            : base()
        {
            IsAdmin = true;
        }





    }
}
