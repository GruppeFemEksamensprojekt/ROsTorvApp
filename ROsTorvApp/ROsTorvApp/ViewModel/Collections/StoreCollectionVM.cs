using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.Devices.Lights.Effects;
using Windows.Storage;
using Windows.Storage.Pickers;
using Windows.System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using ROsTorvApp.Helpers;
using ROsTorvApp.Model.Center;
using ROsTorvApp.View;
using Microsoft.Win32;

namespace ROsTorvApp.ViewModel.Collections
{
   public class StoreCollectionVM : INotifyPropertyChanged
   {
        #region Instance Fields

        private string _selectedOpeningHours;
        private string _selectedOpeningMinutes;
        private string _selectedClosingHours;
        private string _selectedClosingMinutes;

        public int StoreIdVM { get; set; }
        public string StoreNameVM { get; set; }

        public string ClosingHoursVM
        {
            get { return $"{SelectedClosingHours}:{SelectedClosingMinutes}"; }
        }

        public string OpeningHoursVM
        {
            get { return $"{SelectedOpeningHours}:{SelectedOpeningMinutes}"; }
        }
        public string DescriptionVM { get; set; }
        public int LocationFloorVM { get; set; }
        public int LocationNoVM { get; set; }
        public string PhoneNoVM { get; set; }
        public string ImageStoreVM { get; set; }
        public string StoreCategoryVM { get; set; }
        public StorageFile Test { get; set; }
        public string UsersFullName { get { return UserHandler.CurrentUsersFullName; } }
        public List<string> Timer { get; set; }
        public List<string> Minutter { get; set; }

        public string SelectedOpeningHours
        {
            get { return _selectedOpeningHours; }
            set { _selectedOpeningHours = value; }
        }
        public string SelectedOpeningMinutes
        {
            get { return _selectedOpeningMinutes; }
            set { _selectedOpeningMinutes = value; }
        }

        public string SelectedClosingHours
        {
            get { return _selectedClosingHours;}
            set { _selectedClosingHours = value; }
        }

        public string SelectedClosingMinutes
        {
            get { return _selectedClosingMinutes; }
            set { _selectedClosingMinutes = value; }
        }
        public ICommand RedirectToAddStorePage { get; set; }
        public ICommand AddCommand { get; set; }
        public ICommand DeleteCommand { get; set; }
        public ICommand BrowseCommand { get; set; }

        private static Store _selectedStore;
        private bool _showStoreDetails;
        #endregion

        #region Constructor
        public StoreCollectionVM()
        {
            StoreCollection = new ObservableCollection<Store>();
            // Test Data
            StoreCollection.Add(new Store(1, "Matas", "10:00-", "10:00", "Matas description!!!", 1, 2, "/Assets/Images/Matas.png", "Beauty","40404040"));
            StoreCollection.Add(new Store(2, "Tøj Eksperten", "10:00-", "19:00", "Tøj Eksperten description!!!", 1, 3, "/Assets/Images/TøjEksperten.jpg", "Tøj","10101010"));
            StoreCollection.Add(new Store(3, "Gamestop+", "10:30-", "13:00", "Gamestop+ description!!!", 1, 4, "/Assets/Images/Gamestop.png", "Gaming","32125341"));
            StoreCollection.Add(new Store(4, "Føtex", "11:00-", "20:00", "Føtex description!!!", 1, 5, "/Assets/Images/Føtex.jpg", "Dagligvarer","95756214"));
            StoreCollection.Add(new Store(4, "Føtex", "11:00-", "20:00", "Føtex description!!!", 1, 5, "/Assets/Images/Billede1.jpg", "Dagligvarer", "95756214"));

            Timer = new List<string> {"10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20"};
            Minutter = new List<string> {"00", "15", "30", "45"};


            _selectedStore = StoreCollection[0];
            _showStoreDetails = false;
            _selectedOpeningHours = Timer[0];
            _selectedOpeningMinutes = Minutter[0];

            AddCommand = new RelayCommand(AddStore, null);
            DeleteCommand = new RelayCommand(DeleteStore, StoreCollectionVM.StoreIsSelected);
            BrowseCommand = new RelayCommand(BrowseStores, null);
            RedirectToAddStorePage = new RelayCommand(RedirectToAddStorePageMethod, null);

            UserHandler.LoadStoresAsync();
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

        #region XAML-Bindings
        //This method Adds a new store, bound in XAML page.

        public void AddStore()
        {
            AddStoreToList(new Store(StoreIdVM, StoreNameVM, OpeningHoursVM, ClosingHoursVM, DescriptionVM, 
                LocationFloorVM, LocationNoVM, ImageStoreVM,StoreCategoryVM,PhoneNoVM));
        }
        // This method deletes a selected store, if one is selected.
        public void DeleteStore()
        {
            if (SelectedStore != null)
            {
                StoreCollection.Remove(SelectedStore);
                UserHandler.SaveStoresAsync();
            }
        }
        public void RedirectToAddStorePageMethod()
        {
            ((Frame)Window.Current.Content).Navigate(typeof(AddStore));

        }
        public async void BrowseStores()
        {
            FileOpenPicker f = new FileOpenPicker();
            f.SuggestedStartLocation = PickerLocationId.PicturesLibrary;
            f.ViewMode = PickerViewMode.List;
            f.FileTypeFilter.Add(".jpeg");
            f.FileTypeFilter.Add(".jpg");
            f.FileTypeFilter.Add(".png");
            Test = await f.PickSingleFileAsync();
            ImageStoreVM = "/Assets/Images/" + Test.Name;
            
            OnPropertyChanged();
            OnPropertyChanged(nameof(Test));
        }

        #endregion

        //A method which adds a new Store to the list of stores.
        public void AddStoreToList(Store store)
        {
            StoreCollection.Add(store);
            OnPropertyChanged(nameof(StoreCollection));
            ((Frame)Window.Current.Content).Navigate(typeof(Shops));
            UserHandler.SaveStoresAsync();
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
