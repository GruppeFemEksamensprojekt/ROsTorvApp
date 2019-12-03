using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ROsTorvApp.Model.Users;
using ROsTorvApp.ViewModel.Collections;

namespace ROsTorvApp.Helpers
{
    class UserHandler
    {
        public ObservableCollection<UserAccount> UserList { get; set; }
        private CustomerCollectionVM CustomerCollectionVM = new CustomerCollectionVM();
        private AdminCollectionVM AdminCollectionVM = new AdminCollectionVM();
        public string CurrentUsersFirstName { get; set; }
        public string CurrentUsersLastName { get; set; }

        public string CurrentUsersFullName
        {
            get { return $"{CurrentUsersFirstName} {CurrentUsersLastName}"; }
        }
        public UserHandler()
        {
            UserList = new ObservableCollection<UserAccount>();
            //LoadPersonsAsync();
            UpdateUserList();
        }
        
        public void UpdateUserList()
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

        public async void SaveUsersAsync()
        {
            PersistenceFacade.SaveUserToJson(UserList);
        }

        public async void LoadUsersAsync()
        {
            ObservableCollection<UserAccount> users = await PersistenceFacade.LoadUserFromJson();
            UserList.Clear();
            foreach (var user in users)
            {
                UserList.Add(user);
            }
        }
    }
}
