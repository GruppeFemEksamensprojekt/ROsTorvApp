using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ROsTorvApp.Model.Center;

namespace ROsTorvApp.ViewModel.Collections
{
   class StoreCollectionVM
    {
        private ObservableCollection<Store> _storeCollection;
        public StoreCollectionVM()
        {
            _storeCollection = new ObservableCollection<Store>();
            // Test Data
            StoreCollection.Add(new Store(1, "Matas", "08:00 - 15:00", "Matas description!!!", 1, 2, "TestImage", "Beauty"));
            StoreCollection.Add(new Store(2, "Tøj Eksperten", "08:00 - 15:00", "Tøj Eksperten description!!!", 1, 3, "TestImage", "Tøj"));
            StoreCollection.Add(new Store(3, "Gamestop+", "08:00 - 15:00", "Gamestop+ description!!!", 1, 4, "TestImage", "Gaming"));
            StoreCollection.Add(new Store(4, "Føtex", "08:00 - 15:00", "Føtex description!!!", 1, 5, "TestImage", "Dagligvarer"));
        }
        public ObservableCollection<Store> StoreCollection 
        {
            get { return _storeCollection; }
            set { _storeCollection = value; }
        }
    }
}
