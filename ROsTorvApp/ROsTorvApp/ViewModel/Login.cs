using ROsTorvApp.Helpers;
using ROsTorvApp.View;
using ROsTorvApp.ViewModel.Collections;
using System.Windows.Input;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace ROsTorvApp.ViewModel
{
    public class Login
    {
        public Login()
        {
            LoginCommand = new RelayCommand(LoginAction, null);
            OpretBrugerCommand = new RelayCommand(OpretBruger, null);

            if (SingletonUsers.Instance.UserList == null)
            {
                AdminCollectionVM.AddDefaultAdmin();
            }
        }

        public string UserName { get; set; }
        public string Password { private get; set; }
        public ICommand LoginCommand { get; set; }
        public ICommand OpretBrugerCommand { get; set; }

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

        public void OpretBruger()
        {
            ((Frame)Window.Current.Content).Navigate(typeof(OpretBruger));
        }

        public void LoginAction()
        {
            if (UserName != null && Password != null) // Checks if UserName and Password is not null, if true, run the If statement
            {
                if (CheckLoginCredentials) // Checks if credentials exist in the UserList
                {
                    ((Frame)Window.Current.Content).Navigate(typeof(MainPage)); //  redirects to mainpage (Logs in) if the user exists
                }
                else
                {
                    LoginPage.PasswordBox.Password = ""; // Clears the password box if login credentials is wrong
                    UserHandler.contentDialog("Forkert brugernavn eller password", "Failed login"); // Error MessageBox
                }
            }
            else
            {
                UserHandler.contentDialog("Ingen input", "Failed login"); // Error MessageBox
            }
        }
    }
}