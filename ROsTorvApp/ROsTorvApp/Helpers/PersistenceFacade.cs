using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ROsTorvApp.Model.Users;
using ROsTorvApp.ViewModel.Collections;
using Newtonsoft.Json;

namespace ROsTorvApp.Helpers
{
    class PersistenceFacade
    {
        private static string jsonFileName = "UsersAsJson.dat";


        public ObservableCollection<UserAccount> Userlist { get; set; }

        public PersistenceFacade()
        {
            Userlist = new ObservableCollection<UserAccount>();
        }

        public void UpdateUserList()
        {
            foreach (var admin in AdminCollectionVM.AdminCollection)
            {
                Userlist.Add(admin);
            }

            foreach (var customer in CustomerCollectionVM.CustomerCollection)
            {
                Userlist.Add(customer);
            }
        }

        public void UserlistFromSaved()
        {

        }

        public void SaveUserToJson()
        {

        }

        public void LoadUserFromJson()
        {

        }

        public void SerializeUsersFileAsync()
        {

        }

        public void DeSerializeUsersFileAsync()
        {

        }
    }
}
