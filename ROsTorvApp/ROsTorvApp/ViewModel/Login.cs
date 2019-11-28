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
        private string _usernameBox;
        private string _passwordBox;
        
        public ObservableCollection<UserAccount> UserList { get; set; }

        public Login()
        {
            UserList = new ObservableCollection<UserAccount>();
        }




        public bool CheckLoginCredentials(UserAccount user)
        {
            MergeList();
            foreach (var user1 in UserList)
            {
                if (user.UserName == user1.UserName && user.Password == user1.Password)
                {
                    return true;
                    ((Frame) Window.Current.Content).Navigate(typeof(MainPage));
                }
            }
            return false;
        }
            
    


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
