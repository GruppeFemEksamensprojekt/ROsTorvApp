using ROsTorvApp.Model.Users;
using ROsTorvApp.ViewModel.Collections;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using Windows.UI.Xaml.Controls;

namespace ROsTorvApp.Helpers
{
    internal class UserHandler
    {
        #region Instance Fields

        public static bool CurrentUserAdmin { get; set; }
        public static string CurrentUsersUserName { get; set; }
        public static string CurrentUsersFirstName { get; set; }
        public static string CurrentUsersLastName { get; set; }

        #endregion Instance Fields

        #region Constructors

        public UserHandler()
        {
        }

        #endregion Constructors

        #region Properties

        public static string CurrentUsersFullName
        {
            get { return $"{CurrentUsersFirstName} {CurrentUsersLastName}"; }
        }

        //Checks if the username already exists.
        public static bool UsernameAvailability(string Username)
        {
            if (SingletonUsers.Instance.UserList.Any(p => p.UserName == Username))
            {
                return true;
            }

            return false;
        }

        #endregion Properties

        #region Methods

        //Gets PersistenceFacade to save SingletonUsers.Instance.UserList to the Json file.
        public static void SaveUsersAsync()
        {
            PersistenceFacade.SaveUserToJson(SingletonUsers.Instance.UserList);
        }

        //Checks if the Json file exists then adds all users to SingletonUsers.Instance.UserList
        //but if the file don't exists then it creates it and continues else if the file is empty then AdminCollectionVM.AddDefaultAdmin() gets called
        //and the Default Admin get added to SingletonUsers.Instance.UserList and get saved to the file.
        public static async void LoadUsersAsync()
        {
            PersistenceFacade.FileCreationUser();
            ObservableCollection<UserAccount> users = await PersistenceFacade.LoadUserFromJson();
            SingletonUsers.Instance.UserList.Clear();
            if (users == null)
            {
                AdminCollectionVM.AddDefaultAdmin();
            }
            else
            {
                foreach (var user in users)
                {
                    SingletonUsers.Instance.UserList.Add(user);
                }
            }
        }

        //Used to show error message box.
        public static async void contentDialog(string message, string title)
        {
            ContentDialog contentDialog = new ContentDialog
            {
                Title = title,
                Content = message,
                CloseButtonText = "Ok",
                DefaultButton = ContentDialogButton.Close
            };
            ContentDialogResult result = await contentDialog.ShowAsync();
        }

        #endregion Methods
    }
}