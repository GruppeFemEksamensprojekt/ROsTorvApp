using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ROsTorvApp.Model.Center;
using ROsTorvApp.ViewModel.Collections;

namespace ROsTorvApp.Model.Users
{
    public class Admin : UserAccount
    {
        public Admin(string userName, string email, string password, string phoneNo)
            : base(userName,email,password,phoneNo,true)
        {
        }

        public void CreateStore()
        {
            StoreCollectionVM.AddStore(new Store());
        }
    }
}
