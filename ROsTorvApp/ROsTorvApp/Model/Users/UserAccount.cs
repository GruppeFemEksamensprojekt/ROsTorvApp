using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ROsTorvApp.Model.Users
{
    class UserAccount
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string PhoneNo { get; set; }
        public bool IsAdmin { get; set; }


        public UserAccount(string userName, string email, string password, string phoneNo, bool isAdmin)
        {
            UserName = userName;
            Email = email;
            Password = password;
            PhoneNo = phoneNo;
            IsAdmin = isAdmin;
        }

        public UserAccount()
        {

        }


        public void CreateUser()
        {

        }

    }
}
