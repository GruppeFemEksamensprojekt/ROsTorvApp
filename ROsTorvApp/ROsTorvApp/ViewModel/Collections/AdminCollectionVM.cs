using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using ROsTorvApp.Annotations;
using ROsTorvApp.Helpers;
using ROsTorvApp.Model.Users;

namespace ROsTorvApp.ViewModel.Collections
{
    public class AdminCollectionVM
    {
        public Admin Admin1;
        private ObservableCollection<Admin> _adminCollection;

        public ObservableCollection<Admin> AdminCollection
        {
            get { return _adminCollection; }
        }

        public AdminCollectionVM()
        {
            _adminCollection = new ObservableCollection<Admin>();
            AddAdmin(new Admin("Meme","Lord",69,"Admin", "E-Mail@Email.com", "password", "40404040"));
        }
        //A method which adds a new Admin to the list of admins.
        public void AddAdmin(Admin admin)
        {
            //AdminCollection.Add(admin);
            SingletonUsers.Instance.UserList.Add(admin);
            UserHandler.SaveUsersAsync();
        }





    }
}
