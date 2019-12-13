﻿using System;
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
        public string Password { private get; set; }
        public ICommand LoginCommand { get; set; }
        public ICommand OpretBrugerCommand { get; set; }

        public Login()
        {
            LoginCommand = new RelayCommand(LoginAction, null);
            OpretBrugerCommand = new RelayCommand(OpretBruger, null);
            if (SingletonUsers.Instance.UserList == null)
            {
                AdminCollectionVM.AddDefaultAdmin();
            }
        }

        public void OpretBruger()
        {
            ((Frame)Window.Current.Content).Navigate(typeof(OpretBruger));
        }
        
        public void LoginAction()
        {
            if (UserName != null  && Password != null)
            {
                if (CheckLoginCredentials)
                {
                    ((Frame)Window.Current.Content).Navigate(typeof(MainPage));
                }
                else
                {
                    LoginPage.PasswordBox.Password = "";
                    UserHandler.contentDialog("Forkert brugernavn eller password", "Failed login");
                }
            }
            else
            {
                UserHandler.contentDialog("Ingen input","Failed login");
            }
        }

        private bool CheckLoginCredentials
        {
            get
            {
                foreach (var User in SingletonUsers.Instance.UserList)
                {
                    if (User.UserName == UserName && User.Password == Password)
                    {
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
