using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ROsTorvApp.Model.Users
{
    class Admin : UserAccount
    {
        public Admin()
            : base()
        {
            IsAdmin = true;
        }





    }
}
