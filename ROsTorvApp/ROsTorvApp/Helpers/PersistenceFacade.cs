using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;
using Windows.System;
using ROsTorvApp.Model.Users;
using ROsTorvApp.ViewModel.Collections;
using Newtonsoft.Json;

namespace ROsTorvApp.Helpers
{
    class PersistenceFacade
    {
        private static string jsonFileName = "UsersAsJson.dat";

        public static async void FileCreation()
        {
            StorageFile localFile = await ApplicationData.Current.LocalFolder.CreateFileAsync(jsonFileName);
        }
        public static void SaveUserToJson(ObservableCollection<UserAccount> users)
        {
            string usersJsonString = JsonConvert.SerializeObject(users);
            SerializeUsersFileAsync(usersJsonString, jsonFileName);
        }

        public static async Task<ObservableCollection<UserAccount>> LoadUserFromJson()
        {
            string usersJsonString = await DeSerializeUsersFileAsync(jsonFileName);
            return (ObservableCollection<UserAccount>)JsonConvert.DeserializeObject(usersJsonString, typeof(ObservableCollection<UserAccount>));
        }

        public static async void SerializeUsersFileAsync(string UsersString, string fileName)
        {
            StorageFile localFile = await ApplicationData.Current.LocalFolder.CreateFileAsync(fileName, CreationCollisionOption.ReplaceExisting);
            await FileIO.WriteTextAsync(localFile, UsersString);
        }

        public static async Task<string> DeSerializeUsersFileAsync(String fileName)
        {
            StorageFile localFile = await ApplicationData.Current.LocalFolder.GetFileAsync(fileName);
            return await FileIO.ReadTextAsync(localFile);
        }
    }
}
