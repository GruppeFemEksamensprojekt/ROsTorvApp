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

        public static void SaveStoresAsync()
        {
            PersistenceFacade.SaveStoreToJson(StoreCollectionVM.StoreCollection);
        }

        public static async void LoadStoresAsync()
        {
            PersistenceFacade.FileCreationStore();
            ObservableCollection<Store> stores = await PersistenceFacade.LoadStoreFromJson();
            StoreCollectionVM.StoreCollection.Clear();
            foreach (var store in stores)
            {
                StoreCollectionVM.StoreCollection.Add(store);
            }
        }
    }
}
