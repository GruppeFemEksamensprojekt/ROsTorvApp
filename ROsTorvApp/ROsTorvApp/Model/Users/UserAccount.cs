using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ROsTorvApp.ViewModel.Collections;

namespace ROsTorvApp.Model.Users
{
    public class UserAccount
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string PhoneNo { get; set; }
        public bool Admin { get; set; }


        protected UserAccount(string firstName, string lastName, int age, string userName, string email, string password, string phoneNo, bool Admin)
        {
            FirstName = firstName;
            LastName = lastName;
            Age = age;
            UserName = userName;
            Email = email;
            Password = password;
            PhoneNo = phoneNo;
            Admin = Admin;
        }

        protected UserAccount()
        {

        }
    }
}
