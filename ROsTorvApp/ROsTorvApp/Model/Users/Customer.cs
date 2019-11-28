using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ROsTorvApp.Model.Users
{
    class Customer : UserAccount
    {
        public Customer(string userName, string email, string password, string phoneNo, bool isAdmin)
            : base()
        {
            IsAdmin = false;
        }
        
    }
}
