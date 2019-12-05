using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.ServiceModel.Channels;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.ApplicationModel.UserDataTasks;
using Windows.System;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using ROsTorvApp.Annotations;
using ROsTorvApp.Helpers;
using ROsTorvApp.Model.Users;
using ROsTorvApp.View;
using ROsTorvApp.ViewModel.Collections;

namespace ROsTorvApp.ViewModel
{
    public class Login
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        private bool IsAdmin { get; set; }
        public ICommand LoginCommand { get; set; }

        public Login()
        {
            LoginCommand = new RelayCommand(LoginAction, null);
            if (Singleton.Instance.UserList == null)
            {
                AdminCollectionVM AdminCollectionVM = new AdminCollectionVM();
            }
        }
        
        public void LoginAction()
        {
            if (CheckLoginCredentials)
            {
                if (IsAdmin)
                {
                    ((Frame)Window.Current.Content).Navigate(typeof(More));
                }
                else
                {
                    ((Frame)Window.Current.Content).Navigate(typeof(MainPage));
                }
            }
            else
            {
                var messageDialog = new MessageDialog("Failed login");
                messageDialog.ShowAsync();
            }
        }

        private bool CheckLoginCredentials
        {
            get
            {
                foreach (var User in Singleton.Instance.UserList)
                {
                    if (User.UserName == UserName && User.Password == Password)
                    {
                        IsAdmin = User.Admin;
                        UserHandler.CurrentUserAdmin = User.Admin;
                        UserHandler.CurrentUsersUserName = User.UserName;
                        UserHandler.CurrentUsersFirstName = User.FirstName;
                        UserHandler.CurrentUsersLastName = User.LastName;
                        return true;
                    }
                }
                return false;
            }
        }

    }
}
