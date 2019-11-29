using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel.UserDataTasks;
using Windows.System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using ROsTorvApp.Annotations;
using ROsTorvApp.Model.Users;
using ROsTorvApp.ViewModel.Collections;

namespace ROsTorvApp.ViewModel
{
    public class Login
    {
        public ObservableCollection<UserAccount> UserList { get; set; }

        public Login()
        {
            UserList = new ObservableCollection<UserAccount>();
        }

        //This method checks if the user logging in is an admin or not,
        //if he is an admin, he will be sent to an admin specific page.'
        public bool IsAdmin(UserAccount user)
        {
            if (user.IsAdmin == true)
            {
                ((Frame) Window.Current.Content).Navigate(typeof(MainPage));
            }
            return false;
        }
        //This pseudo login-system, checks if username and password fit together,
        //if it is then it lets the user log in, nothing is encrypted or hashed,
        //so this system is really weak and is only here for proof of concept/testing.
        public bool CheckLoginCredentials(UserAccount user)
        {
            MergeList();
            foreach (var user1 in UserList)
            {
                if (user.UserName == user1.UserName && user.Password == user1.Password)
                {
                    return ((Frame) Window.Current.Content).Navigate(typeof(MainPage));
                }
            }
            return false;
        }
        //This method merge the two lists in AdminCollection and CustomerCollection together,
        //so we only need to check on list when a user log in.
        public void MergeList()
        {
            foreach (var admin in AdminCollectionVM.AdminCollection)
            {
                UserList.Add(admin);
            }
            foreach (var customer in CustomerCollectionVM.CustomerCollection)
            {
                UserList.Add(customer);
            }
        }
    }
}
