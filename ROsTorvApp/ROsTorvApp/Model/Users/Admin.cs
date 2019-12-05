using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using ROsTorvApp.Helpers;
using ROsTorvApp.Model.Center;
using ROsTorvApp.ViewModel.Collections;

namespace ROsTorvApp.Model.Users
{
    public class Admin : UserAccount
    {
        public Admin(string firstName, string lastName, int age, string userName, string email, string password, string phoneNo)
            : base(firstName, lastName, age, userName, email, password, phoneNo, true)
        {
        }
    }
}
