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
using ROsTorvApp.Model.Center.Offers;

namespace ROsTorvApp.ViewModel.Collections
{
    public class StoreCollectionVM : INotifyPropertyChanged
    {

        #region Instance Fields
        private static Store _selectedStore;
        private bool _showStoreDetailsOnSelection;
        private bool _hideStoreListViewOnSelection;
        private bool _showAdminButton;
        private ObservableCollection<Store> _storeCollection;
        #endregion

        #region Constructors
        public StoreCollectionVM()
        {
            _storeCollection = new ObservableCollection<Store>();

            _showStoreDetailsOnSelection = false;
            _hideStoreListViewOnSelection = false;
            //_selectedOpeningHours = OpeningAndClosingTime[0];
            //_selectedClosingHours = OpeningAndClosingTime[15];
            //_selectedStoreCategories = StoreCategories[0];

            AddCommand = new RelayCommand(AddStore, null);
            DeleteCommand = new RelayCommand(DeleteStore, StoreIsSelected);
            BrowseCommand = new RelayCommand(BrowseStores, null);
            RedirectToAddStorePage = new RelayCommand(RedirectToAddStorePageMethod, null);
            RedirectToAdminPanelCommand = new RelayCommand(RedirectToAdminpanel, StoreIsSelected);
            BackToStoreListViewCommand = new RelayCommand(BackToStoreListView, null);
            SaveStoreCommand = new RelayCommand(SaveStoreMethod, StoreIsSelected);
        }

        #endregion

        #region Properties

        #region StoreDetails
        public int StoreIdVM { get; set; }
        public string StoreNameVM { get; set; }
        public string DescriptionVM { get; set; }
        public int LocationFloorVM { get; set; }
        public int LocationNoVM { get; set; }
        public string PhoneNoVM { get; set; }
        public string ImageStoreVM { get; set; }
        public string StoreCategoryVM { get; set; }
        public string OpeningAndClosingHoursVM { get; }      
        public static List<string> OpeningAndClosingTime 
        { 
            get 
            { 
                return new List<string> 
                {
                    "10:00", "10:30", "11:00", "11:30", "12:00", "12:30", "13:00", "13:30",
                "14:00", "14:30", "15:00", "15:30", "16:00", "16:30", "17:00", "17:30", "18:00", "18:30", "19:00", "19:30", "20:00"
                };
            } 
        }
        public static List<string> StoreCategories
        {
            get
            {
                return new List<string>
                {
                    "Bolig & livsstil", "Børn & fritid", "Dagligvarer & specialiteter", "Damemode", "Herremode", "Elektronik", 
                    "Erhverv, kontorer & service", "Modetilbehør", "Sko", "Skønhed & sundhed", "Restauranter", "Underholdning", "Sport"
                };
            }
        }
        public string ImageFileName { get; set; }
        #endregion

        public StorageFile ImageFile { get; set; }
        public string UsersFullName { get { return UserHandler.CurrentUsersFullName; } }

        #region ICommand
        public ICommand RedirectToAddStorePage { get; set; }
        public ICommand AddCommand { get; set; }
        public ICommand DeleteCommand { get; set; }
        public ICommand BrowseCommand { get; set; }
        public ICommand BackToStoreListViewCommand { get; set; }
        public ICommand SaveStoreCommand { get; set; }
        public ICommand RedirectToAdminPanelCommand { get; set; }
        #endregion

        public ObservableCollection<Store> StoreCollection
        {
            get { return SingletonStores.Instance.StoreList; }
            set { _storeCollection = value; }
        }
        public static Store TransferSelectedStore{ get { return _selectedStore; } }
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

        public static string Time
        {
            get
            {
                DateTime timeNow = DateTime.Now;
                if (timeNow.Hour >= 5 && timeNow.Hour < 9)
                {
                    return "God morgen,";
                }

                if (timeNow.Hour >= 9 && timeNow.Hour < 12)
                {
                    return "God formiddag,";
                }

                if (timeNow.Hour >= 12 && timeNow.Hour < 13)
                {
                    return "God middag,";
                }

                if (timeNow.Hour >= 13 && timeNow.Hour < 18)
                {
                    return "God eftermiddag,";
                }

                if (timeNow.Hour >= 18)
                {
                    return "God aften,";
                }

                return timeNow.ToShortTimeString();
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
            try
            {
                Shops.StoreListViewElement.SelectedIndex = -1;
            }
            catch (Exception)
            {

                return;
            }
            finally
            {
                ShowStoreDetailsOnSelection = false;
                HideStoreListViewOnSelection = false;
            }
            ShowStoreDetailsOnSelection = false;
            HideStoreListViewOnSelection = false;

        }

        //This method Adds a new store, bound in XAML page.
        public void AddStore()
        {
            AddStoreToList(new Store(StoreIdVM, StoreNameVM, OpeningAndClosingHoursVM, OpeningAndClosingHoursVM, DescriptionVM,
                LocationFloorVM, LocationNoVM, ImageStoreVM, StoreCategoryVM, PhoneNoVM));
        }
        public void SaveStoreMethod()
        {
            Shops.StoreListViewElement.SelectedIndex = -1;
            ((Frame)Window.Current.Content).GoBack();
            StoreHandler.SaveStoresAsync();
        }
        // This method deletes a selected store, if one is selected.
        public void DeleteStore()
        {
            if (SelectedStore != null)
            {
                SingletonStores.Instance.StoreList.Remove(SelectedStore);
                StoreHandler.SaveStoresAsync();
            }
            ((Frame)Window.Current.Content).Navigate(typeof(Shops));
            //BackToStoreListView();
        }

        public void RedirectToAddStorePageMethod()
        {
            try
            {
                Shops.StoreListViewElement.SelectedIndex = -1;
            }
            catch (Exception)
            {
                return;
            }

            ((Frame)Window.Current.Content).Navigate(typeof(AddStore));
        }
        public void RedirectToAdminpanel()
        {
            ((Frame)Window.Current.Content).Navigate(typeof(AdminPanel), _selectedStore);
        }

        public async void BrowseStores()
        {
            FileOpenPicker f = new FileOpenPicker();
            f.SuggestedStartLocation = PickerLocationId.PicturesLibrary;
            f.ViewMode = PickerViewMode.List;
            f.FileTypeFilter.Add(".jpeg");
            f.FileTypeFilter.Add(".jpg");
            f.FileTypeFilter.Add(".png");
            ImageFile = await f.PickSingleFileAsync();
            ImageStoreVM = "/Assets/Images/" + ImageFile.Name;
            ImageFileName = ImageFile.Name;
            try
            {
                SelectedStore.ImageStore = ImageStoreVM;
            }
            catch (Exception)
            {
                OnPropertyChanged();
                OnPropertyChanged(nameof(ImageFileName));
                return;
            }
            OnPropertyChanged();
            OnPropertyChanged(nameof(ImageFileName));
        }

        //Adds dummy data to the StoreCollection list, and saves them in Json (Localstorage)
        public static void AddStoreDummyData()
        {
            // Fill with dummy data
            SingletonStores.Instance.StoreList.Add(new Store(1, "Matas", OpeningAndClosingTime[0], OpeningAndClosingTime[14], "Matas description!!!", 1, 2, "/Assets/Images/Matas.png", StoreCategories[9], "40404040"));
            SingletonStores.Instance.StoreList.Add(new Store(2, "Tøj Eksperten", OpeningAndClosingTime[0], OpeningAndClosingTime[14], "Tøj Eksperten description!!!", 1, 3, "/Assets/Images/TøjEksperten.jpg", StoreCategories[4], "10101010"));
            SingletonStores.Instance.StoreList.Add(new Store(3, "Gamestop+", OpeningAndClosingTime[1], OpeningAndClosingTime[16], "Gamestop+ description!!!", 1, 4, "/Assets/Images/Gamestop.png", StoreCategories[5], "32125341"));
            SingletonStores.Instance.StoreList.Add(new Store(4, "Føtex", OpeningAndClosingTime[2], OpeningAndClosingTime[18], "Føtex description!!!", 1, 5, "/Assets/Images/Føtex.jpg", StoreCategories[2], "95756214"));
            SingletonStores.Instance.StoreList.Add(new Store(4, "Burger King", OpeningAndClosingTime[2], OpeningAndClosingTime[18], "Burger King description!!!", 1, 6, "/Assets/Images/Billede1.jpg", StoreCategories[10], "98273461"));
            StoreHandler.SaveStoresAsync();
        }
        //A method which adds a new Store to the list of stores, and saves them in Json in localstorage
        public void AddStoreToList(Store store)
        {
            SingletonStores.Instance.StoreList.Add(store);
            OnPropertyChanged(nameof(SingletonStores.Instance.StoreList));
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
