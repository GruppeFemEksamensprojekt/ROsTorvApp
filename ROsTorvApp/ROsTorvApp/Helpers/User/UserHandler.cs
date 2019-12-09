using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        
        public static bool UsernameAvailability(string Username)
        {
            if (SingletonUsers.Instance.UserList.Any(p => p.UserName == Username))
            {
                return true;
            }

            return false;
        }

        public static void SaveUsersAsync()
        {
            PersistenceFacade.SaveUserToJson(SingletonUsers.Instance.UserList);
        }
        
        public static async void LoadUsersAsync()
        {
            PersistenceFacade.FileCreationUser();
            ObservableCollection<UserAccount> users = await PersistenceFacade.LoadUserFromJson();
            SingletonUsers.Instance.UserList.Clear();
            if (users == null)
            {
                AdminCollectionVM AdminCollectionVM = new AdminCollectionVM();
            }
            else
            {
                foreach (var user in users)
                {
                    SingletonUsers.Instance.UserList.Add(user);
                }
            }
        }
    }
}
