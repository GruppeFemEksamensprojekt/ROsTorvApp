using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using ROsTorvApp.Model.Center;

namespace ROsTorvApp.ViewModel.Collections
{
   class StoreCollectionVM : INotifyPropertyChanged
   {
        #region Instance Fields
        private Store _selectedStore;
        private ObservableCollection<Store> _storeCollection;
        #endregion

        #region Constructor
        public StoreCollectionVM()
        {
            _storeCollection = new ObservableCollection<Store>();
            // Test Data
            StoreCollection.Add(new Store(1, "Matas", "08:00 - 15:00", "Matas description!!!", 1, 2, "Assets\\Images\\Matas.png", "Beauty"));
            StoreCollection.Add(new Store(2, "Tøj Eksperten", "08:00 - 15:00", "Tøj Eksperten description!!!", 1, 3, "TestImage", "Tøj"));
            StoreCollection.Add(new Store(3, "Gamestop+", "08:00 - 15:00", "Gamestop+ description!!!", 1, 4, "TestImage", "Gaming"));
            StoreCollection.Add(new Store(4, "Føtex", "08:00 - 15:00", "Føtex description!!!", 1, 5, "TestImage", "Dagligvarer"));
        }

        #endregion

        #region Properties
        public ObservableCollection<Store> StoreCollection
        {
            get { return _storeCollection; }
            set { _storeCollection = value; }
        }

        public Store SelctedStore
        {
            get { return _selectedStore; }
            set
            {
                _selectedStore = value;
                OnPropertyChanged();
            }
        }
        #endregion

        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion
    }
}
