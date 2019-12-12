using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;
using ROsTorvApp.Model.Center;
using ROsTorvApp.Model.Users;
using ROsTorvApp.ViewModel.Collections;

namespace ROsTorvApp.Helpers
{
    class UserHandler
    {
        public static bool CurrentUserAdmin { get; set; }
        public static string CurrentUsersUserName { get; set; }
        public static string CurrentUsersFirstName { get; set; }
        public static string CurrentUsersLastName { get; set; }

        public static string CurrentUsersFullName
        {
            get { return $"{CurrentUsersFirstName} {CurrentUsersLastName}"; }
        }

        public UserHandler()
        {
            
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

        //Gets PersistenceFacade to save SingletonUsers.Instance.UserList to the Json file.
        public static void SaveUsersAsync()
        {
            PersistenceFacade.SaveUserToJson(SingletonUsers.Instance.UserList);
        }


        //Den checker først om filen findes og så tilføjer den alle brugerne til SingletonUsers.Instance.UserList,
        //men hvis filen ikke findes så opretter den det og forsætter eller hvis filen er tom så kalder den AdminCollectionVM.AddDefaultAdmin()
        //og det bliver bliver så tilføjet til SingletonUsers.Instance.UserList og til filen.
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

        //Bruges til at vise fejl meddelser osv.
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
    }
}
