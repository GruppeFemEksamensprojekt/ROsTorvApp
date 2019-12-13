using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ROsTorvApp.Model.Center;
using ROsTorvApp.ViewModel.Collections;

namespace ROsTorvApp.Helpers
{
    class StoreHandler
    {
        public StoreHandler()
        {

        }

        //Får PersistenceFacade til at gemme SingletonStores.Instance.StoreList til Json filen som ligger lokalt.
        public static void SaveStoresAsync()
        {
            PersistenceFacade.SaveStoreToJson(SingletonStores.Instance.StoreList);
        }

        //Den checker først om filen findes og så tilføjer den alle butikkerne til SingletonStores.Instance.StoreList,
        //men hvis filen ikke findes så opretter den det og forsætter eller hvis filen er tom så kalder den StoreCollectionVM.AddStoreDummyData()
        //og det bliver bliver så tilføjet til SingletonStores.Instance.StoreList og til filen.
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
    }
}
