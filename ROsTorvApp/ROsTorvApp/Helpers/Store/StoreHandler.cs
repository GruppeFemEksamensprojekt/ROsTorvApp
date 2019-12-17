using ROsTorvApp.Model.Center;
using ROsTorvApp.ViewModel.Collections;
using System.Collections.ObjectModel;

namespace ROsTorvApp.Helpers
{
    internal class StoreHandler
    {
        #region Constructors

        public StoreHandler()
        {
        }

        #endregion Constructors

        #region Methods

        //Gets PersistenceFacade to save SingletonStores.Instance.StoreList to the Json file.
        public static void SaveStoresAsync()
        {
            PersistenceFacade.SaveStoreToJson(SingletonStores.Instance.StoreList);
        }

        //Checks if the Json file exists then adds all stores to SingletonStores.Instance.StoreList
        //but if the file don't exists then it creates it and continues else if the file is empty then StoreCollectionVM.AddStoreDummyData() gets called
        //and Store Dummy Data gets added to SingletonStores.Instance.StoreList and get saved to the file.
        public static async void LoadStoresAsync()
        {
            PersistenceFacade.FileCreationStore();
            ObservableCollection<Store> stores = await PersistenceFacade.LoadStoreFromJson();
            SingletonStores.Instance.StoreList.Clear();
            if (stores == null)
            {
                StoreCollectionVM.AddStoreDummyData();
            }
            else
            {
                foreach (var store in stores)
                {
                    SingletonStores.Instance.StoreList.Add(store);
                }
            }
        }

        #endregion Methods
    }
}