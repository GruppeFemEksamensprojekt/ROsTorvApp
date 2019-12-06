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
using ROsTorvApp.Model.Center;

namespace ROsTorvApp.Helpers
{
    class PersistenceFacade
    {
        #region UserList
        private static string jsonFileName = "UsersAsJson.dat";

        public static async void FileCreationUser()
        {
            var item = await ApplicationData.Current.LocalFolder.TryGetItemAsync(jsonFileName);
            if (item == null)
            {
                StorageFile localFile = await ApplicationData.Current.LocalFolder.CreateFileAsync(jsonFileName);
            }

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
        #endregion
        #region Stores
        private static string jsonFileName2 = "StoresAsJson.dat";

        public static async void FileCreationStore()
        {
            var item = await ApplicationData.Current.LocalFolder.TryGetItemAsync(jsonFileName2);
            if (item == null)
            {
                StorageFile localFile = await ApplicationData.Current.LocalFolder.CreateFileAsync(jsonFileName2);
            }

        }

        public static void SaveStoreToJson(ObservableCollection<Store> stores)
        {
            string storesJsonString = JsonConvert.SerializeObject(stores);
            SerializeUsersFileAsync(storesJsonString, jsonFileName2);
        }

        public static async Task<ObservableCollection<UserAccount>> LoadStoreFromJson()
        {
            string storesJsonString = await DeSerializeStoresFileAsync(jsonFileName2);
            return (ObservableCollection<UserAccount>)JsonConvert.DeserializeObject(storesJsonString, typeof(ObservableCollection<UserAccount>));
        }

        public static async void SerializeStoresFileAsync(string storesString, string fileName)
        {
            StorageFile localFile = await ApplicationData.Current.LocalFolder.CreateFileAsync(fileName, CreationCollisionOption.ReplaceExisting);
            await FileIO.WriteTextAsync(localFile, storesString);
        }

        public static async Task<string> DeSerializeStoresFileAsync(String fileName)
        {
            StorageFile localFile = await ApplicationData.Current.LocalFolder.GetFileAsync(fileName);
            return await FileIO.ReadTextAsync(localFile);
        } 
        #endregion
    }
}
