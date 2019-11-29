using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using ROsTorvApp.Model.Center;
using ROsTorvApp.View;

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
            StoreCollection.Add(new Store(1, "Matas", "08:00 - 15:00", "Matas description!!!", 1, 2, "/Assets/Images/Matas.png", "Beauty","40404040"));
            StoreCollection.Add(new Store(2, "Tøj Eksperten", "08:00 - 15:00", "Tøj Eksperten description!!!", 1, 3, "/Assets/Images/TøjEksperten.jpg", "Tøj","10101010"));
            StoreCollection.Add(new Store(3, "Gamestop+", "08:00 - 15:00", "Gamestop+ description!!!", 1, 4, "/Assets/Images/Gamestop.png", "Gaming","32125341"));
            StoreCollection.Add(new Store(4, "Føtex", "08:00 - 15:00", "Føtex description!!!", 1, 5, "/Assets/Images/Føtex.jpg", "Dagligvarer","95756214"));

            _selectedStore = _storeCollection[0];
        }

        #endregion

        #region Properties

        public ObservableCollection<Store> StoreCollection
        {
            get { return _storeCollection; }
            set { _storeCollection = value; }
        }
        // A property for binding the store you select in the view.
        public Store SelectedStore
        {
            get { return _selectedStore; }
            set
            {
                _selectedStore = value;
                if (_selectedStore != null)
                {
                    ((Frame)Window.Current.Content).Navigate(typeof(StoreDetails));
                }
                OnPropertyChanged(nameof(SelectedStore.StoreName));
            }
        }
        #endregion
        //A method which adds a new Store to the list of stores.
        public void AddStore(Store store)
        {
            StoreCollection.Add(store);
        }



        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion
    }
}
