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

        public UserHandler()
        {
            UserList = new ObservableCollection<UserAccount>();
            LoadPersonsAsync();
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

        public async void SavePersonsAsync()
        {
            PersistenceFacade.SaveUserToJson(UserList);
        }

        public async void LoadPersonsAsync()
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
