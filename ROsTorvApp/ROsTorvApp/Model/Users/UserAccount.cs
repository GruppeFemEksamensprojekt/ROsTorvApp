using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ROsTorvApp.ViewModel.Collections;

namespace ROsTorvApp.Model.Users
{
    public abstract class UserAccount
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string PhoneNo { get; set; }
        public bool IsAdmin { get; set; }


        protected UserAccount(string userName, string email, string password, string phoneNo, bool isAdmin)
        {
            UserName = userName;
            Email = email;
            Password = password;
            PhoneNo = phoneNo;
            IsAdmin = isAdmin;
        }

        protected UserAccount()
        {

        }
    }
}
