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
        private string _selectedClosingHours;
        private Store _selectedStore;
        private bool _showStoreDetailsOnSelection;
        private bool _hideStoreListViewOnSelection;
        private bool _showAdminButton;


        #endregion

        #region Constructoras
        public StoreCollectionVM()
        {
            StoreCollection = new ObservableCollection<Store>();
            //Test Data
            StoreCollection.Add(new Store(1, "Matas", "10:00 - 17:00", "Matas description!!!", 1, 2, "/Assets/Images/Matas.png", "Helse/Beauty", "40404040"));
            StoreCollection.Add(new Store(2, "Tøj Eksperten", "10:00 - 17:00", "Tøj Eksperten description!!!", 1, 3, "/Assets/Images/TøjEksperten.jpg", "Beklædning", "10101010"));
            StoreCollection.Add(new Store(3, "Gamestop+", "10:30 - 18:00", "Gamestop+ description!!!", 1, 4, "/Assets/Images/Gamestop.png", "Gaming/Elektronik", "32125341"));
            StoreCollection.Add(new Store(4, "Føtex", "11:00 - 20:00", "Føtex description!!!", 1, 5, "/Assets/Images/Føtex.jpg", "Dagligvarer", "95756214"));
            StoreCollection.Add(new Store(4, "Føtex", "11:00 - 20:00", "Føtex description!!!", 1, 5, "/Assets/Images/Billede1.jpg", "Dagligvarer", "95756214"));

            OpeningAndClosingTime = new List<string> {"10:00", "10:30", "11:00", "11:30", "12:00", "12:30", "13:00", "13:30", 
                "14:00", "14:30", "15:00", "15:30", "16:00", "16:30", "17:00", "17:30", "18:00", "18:30", "19:00", "19:30", "20:00"};
           //FillStoreList();

           // _selectedStore = StoreCollection[0]; // Not really needed kek
            _showStoreDetailsOnSelection = false;
            _selectedOpeningHours = OpeningAndClosingTime[0];
            _selectedClosingHours = OpeningAndClosingTime[15];

            AddCommand = new RelayCommand(AddStore, null);
            DeleteCommand = new RelayCommand(DeleteStore, StoreIsSelected);
            BrowseCommand = new RelayCommand(BrowseStores, null);
            RedirectToAddStorePage = new RelayCommand(RedirectToAddStorePageMethod, null);
            BackToStoreListViewCommand = new RelayCommand(BackToStoreListView, null);
            //StoreHandler.LoadStoresAsync();
        }

        #endregion

        #region Properties

        public string OpeningAndClosingHoursVM
        {
            get { return $"{SelectedOpeningHours} - {SelectedClosingHours}"; }
        }

        #region StoreDetails
        public int StoreIdVM { get; set; }
        public string StoreNameVM { get; set; }
        public string DescriptionVM { get; set; }
        public int LocationFloorVM { get; set; }
        public int LocationNoVM { get; set; }
        public string PhoneNoVM { get; set; }
        public string ImageStoreVM { get; set; }
        public string StoreCategoryVM { get; set; }
        public StorageFile Test { get; set; }
        public string UsersFullName { get { return UserHandler.CurrentUsersFullName; } }
        public List<string> OpeningAndClosingTime { get; set; }
        public string SelectedOpeningHours
        {
            get { return _selectedOpeningHours; }
            set { _selectedOpeningHours = value; }
        }
        public string SelectedClosingHours
        {
            get { return _selectedClosingHours; }
            set { _selectedClosingHours = value; }
        }
        #endregion

        public ICommand RedirectToAddStorePage { get; set; }
        public ICommand AddCommand { get; set; }
        public ICommand DeleteCommand { get; set; }
        public ICommand BrowseCommand { get; set; }
        public ICommand BackToStoreListViewCommand { get; set; }
        public static ObservableCollection<Store> StoreCollection { get; set; }
        // A property for binding the store you select in the view.
        public Store SelectedStore
        {
            get { return _selectedStore; }
            // This happens when you select a store from the Listview
            set
            {
                _selectedStore = value;
                OnPropertyChanged();
                // Hides the Storelistview (Shops) and shows to store details pane, from the selected item
                HideStoreListViewOnSelection = true;
                ShowStoreDetailsOnSelection = true;
            }
        }

        // if true, then SHOW the Store details screen for the selected store
        public bool ShowStoreDetailsOnSelection
        {
            get 
            { return _showStoreDetailsOnSelection; }
            set
            {
                _showStoreDetailsOnSelection = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(ShowStoreDetailsOnSelectionVisibility));
            }
        }
        public Visibility ShowStoreDetailsOnSelectionVisibility
        {
            get { return ShowStoreDetailsOnSelection ? Visibility.Visible : Visibility.Collapsed; }
        }

        // If true, then HIDE the Store Listview on a any selected store
        public bool HideStoreListViewOnSelection
        {
            get { return _hideStoreListViewOnSelection; }
            set
            {
                _hideStoreListViewOnSelection = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(HideStoreListViewOnSelectionVisibility));
            }
        }
        public Visibility HideStoreListViewOnSelectionVisibility
        {
            get { return HideStoreListViewOnSelection ? Visibility.Collapsed : Visibility.Visible; }
        }

        // Shows the "Indstillinger" button on the Shop.xaml page, if the user is logged in as admin
        public bool ShowAdminButton
        {
            get 
            {
                if (UserHandler.CurrentUserAdmin)
                {
                    return _showAdminButton = true;
                }
                return false;
            }
            set
            {
                _showAdminButton = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(ShowAdminButtonVisibility));
            }
        }
        public Visibility ShowAdminButtonVisibility
        {
            get 
            {
                return ShowAdminButton ? Visibility.Visible : Visibility.Collapsed; }
        }
        #endregion

        #region Methods
        public bool StoreIsSelected()
        {
            return SelectedStore != null;
        }

        // shows the store list and hides to store details pane
        public void BackToStoreListView()
        {
            ShowStoreDetailsOnSelection = false;
            HideStoreListViewOnSelection = false;
        }

        //This method Adds a new store, bound in XAML page.
        public void AddStore()
        {
            AddStoreToList(new Store(StoreIdVM, StoreNameVM, OpeningAndClosingHoursVM, DescriptionVM,
                LocationFloorVM, LocationNoVM, ImageStoreVM, StoreCategoryVM, PhoneNoVM));
        }
        // This method deletes a selected store, if one is selected.
        public void DeleteStore()
        {
            if (SelectedStore != null)
            {
                StoreCollection.Remove(SelectedStore);
                StoreHandler.SaveStoresAsync();
            }
            BackToStoreListView();
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

        // Ongoing - 
        public async void FillStoreList()
        {
            ObservableCollection<Store> stores;
            try
            {
                stores = await PersistenceFacade.LoadStoreFromJson();
                if (stores != null)
                {
                    foreach (var item in stores)
                    {
                        StoreCollection.Add(item);
                    }
                }
            }
            catch (FileNotFoundException)
            {
                
                // Fill with dummy data
                AddStoreToList(new Store(1, "Matas", "10:00 - 17:00", "Matas description!!!", 1, 2, "/Assets/Images/Matas.png", "Helse/Beauty", "40404040"));
                AddStoreToList(new Store(2, "Tøj Eksperten", "10:00 - 17:00", "Tøj Eksperten description!!!", 1, 3, "/Assets/Images/TøjEksperten.jpg", "Beklædning", "10101010"));
                AddStoreToList(new Store(3, "Gamestop+", "10:30 - 18:00", "Gamestop+ description!!!", 1, 4, "/Assets/Images/Gamestop.png", "Gaming/Elektronik", "32125341"));
                AddStoreToList(new Store(4, "Føtex", "11:00 - 20:00", "Føtex description!!!", 1, 5, "/Assets/Images/Føtex.jpg", "Dagligvarer", "95756214"));
                AddStoreToList(new Store(4, "Føtex", "11:00 - 20:00", "Føtex description!!!", 1, 5, "/Assets/Images/Billede1.jpg", "Dagligvarer", "95756214"));
            }
        }
        //A method which adds a new Store to the list of stores.
        public void AddStoreToList(Store store)
        {
            StoreCollection.Add(store);
            OnPropertyChanged(nameof(StoreCollection));
            StoreHandler.SaveStoresAsync();
            ((Frame)Window.Current.Content).Navigate(typeof(Shops));
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
