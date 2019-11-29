using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using ROsTorvApp.Model.Center;
using ROsTorvApp.View;

namespace ROsTorvApp.ViewModel.Collections
{
   public class StoreCollectionVM : INotifyPropertyChanged
   {
        #region Instance Fields

        private static Store _selectedStore;
        private bool _showStoreDetails;
        #endregion

        #region Constructor
        public StoreCollectionVM()
        {
            StoreCollection = new ObservableCollection<Store>();
            // Test Data
            StoreCollection.Add(new Store(1, "Matas", "08:00 - 15:00", "Matas description!!!", 1, 2, "/Assets/Images/Matas.png", "Beauty","40404040"));
            StoreCollection.Add(new Store(2, "Tøj Eksperten", "08:00 - 15:00", "Tøj Eksperten description!!!", 1, 3, "/Assets/Images/TøjEksperten.jpg", "Tøj","10101010"));
            StoreCollection.Add(new Store(3, "Gamestop+", "08:00 - 15:00", "Gamestop+ description!!!", 1, 4, "/Assets/Images/Gamestop.png", "Gaming","32125341"));
            StoreCollection.Add(new Store(4, "Føtex", "08:00 - 15:00", "Føtex description!!!", 1, 5, "/Assets/Images/Føtex.jpg", "Dagligvarer","95756214"));

            _selectedStore = StoreCollection[0];
            _showStoreDetails = false;
        }

        #endregion

        #region Properties
        public static ObservableCollection<Store> StoreCollection { get; set; }
        // A property for binding the store you select in the view.
        public static Store SelectedStore
        {
            get { return _selectedStore; }
            set
            {
                _selectedStore = value;
            }
        }

        public static bool StoreIsSelected()
        {
            return SelectedStore != null;
        }

        public bool ShowStoreDetails
        {
            get { return _showStoreDetails; }
            set
            {
                _showStoreDetails = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(StoreDetailsVisibility));
            }
        }

        public Visibility StoreDetailsVisibility
        {
            get { return ShowStoreDetails ? Visibility.Visible : Visibility.Collapsed; }
        }
        #endregion
        //A method which adds a new Store to the list of stores.
        public static void AddStore(Store store)
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
