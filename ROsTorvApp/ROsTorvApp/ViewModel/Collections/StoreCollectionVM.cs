﻿using System;
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
        private static string _selectedStoreImageFileName;
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

            LogOutCommand = new RelayCommand(LogOut, null);
            AddCommand = new RelayCommand(AddStore, null);
            DeleteCommand = new RelayCommand(DeleteStore, StoreIsSelected);
            BrowseCommand = new RelayCommand(BrowseStores, null);
            RedirectToAddStorePage = new RelayCommand(RedirectToAddStorePageMethod, null);
            RedirectToAdminPanelCommand = new RelayCommand(RedirectToAdminpanel, StoreIsSelected);
            BackToStoreListViewCommand = new RelayCommand(BackToStoreListView, null);
            SaveStoreCommand = new RelayCommand(SaveStoreMethod, StoreIsSelected);
            RedirectToShopsCommand = new RelayCommand(RedirectToShopsMethod, null);
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
        public string SelectedImageFileName {
            get
            {
                return SelectedStore.ImageStore.Remove(0,15);
            }
            set 
            {
                SelectedStore.ImageStore = value;
                OnPropertyChanged();
            }

        }
        public string UsersFullName { get { return UserHandler.CurrentUsersFullName; } }

        #region ICommand
        public ICommand RedirectToAddStorePage { get; set; }
        public ICommand AddCommand { get; set; }
        public ICommand DeleteCommand { get; set; }
        public ICommand BrowseCommand { get; set; }
        public ICommand BackToStoreListViewCommand { get; set; }
        public ICommand SaveStoreCommand { get; set; }
        public ICommand RedirectToAdminPanelCommand { get; set; }
        public ICommand RedirectToShopsCommand { get; set; }
        public ICommand LogOutCommand { get; set; }

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
                    return "Godmorgen,";
                }

                if (timeNow.Hour >= 9 && timeNow.Hour < 12)
                {
                    return "God formiddag,";
                }

                if (timeNow.Hour >= 12 && timeNow.Hour < 14)
                {
                    return "God middag,";
                }

                if (timeNow.Hour >= 14 && timeNow.Hour < 18)
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

        public void LogOut()
        {
            ((Frame)Window.Current.Content).Navigate(typeof(LoginPage));
        }

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

        public void RedirectToShopsMethod()
        {
            Shops.StoreListViewElement.SelectedIndex = -1;
            ((Frame)Window.Current.Content).GoBack();
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
            try
            {
                ImageStoreVM = "/Assets/Images/" + ImageFile.Name;
                ImageFileName = ImageFile.Name;
                //SelectedStore.ImageStore = ImageStoreVM;
                SelectedImageFileName = ImageFile.Name;
            }       
            catch (Exception)
            {
                OnPropertyChanged();
                OnPropertyChanged(nameof(ImageFileName));
                return;
            }
            OnPropertyChanged();
            OnPropertyChanged(nameof(ImageFile));
        }

        //Adds dummy data to the StoreCollection list, and saves them in Json (Localstorage)
        public static void AddStoreDummyData()
        {
            // Fill with dummy data
            SingletonStores.Instance.StoreList.Add(new Store(1, "Matas", OpeningAndClosingTime[0], OpeningAndClosingTime[18], "Hos Matas er vi eksperter i skønhed. Vi vejleder dig gerne om valg af alle former for skønhedsprodukter samt brugen af dem. Vi fører eksklusive mærker inden for skønhed til både kvinder og mænd, såsom Dior, Chanel, Chloe, Ole Henriksen og mange flere. Vores sortiment inden for makeup, ansigtspleje og kropspleje er stort, og vi får nye varer ind ad døren hver uge.", 1, 2, "/Assets/Images/Matas.jpg", StoreCategories[9], "46 34 10 44"));
            SingletonStores.Instance.StoreList.Add(new Store(2, "Tøj Eksperten", OpeningAndClosingTime[0], OpeningAndClosingTime[18], "Hos Tøjeksperten finder du herretøj fra alle de kendte modebrands såsom Bison, Björn Borg, Lindbergh, Eterna, Junk de Luxe, JBS og mange flere. Vi får ofte nye varer ind af døren, så vores sortiment er opdateret med de nyeste kollektioner. Vi har blandt andet mange flotte klassiske habitter, skjorter, slips, t-shirts, undertrøjer m.m.", 1, 3, "/Assets/Images/TøjEksperten.jpg", StoreCategories[4], "72 34 90 85"));
            SingletonStores.Instance.StoreList.Add(new Store(3, "GameStop+", OpeningAndClosingTime[1], OpeningAndClosingTime[18], "GameStop+ er verdens største forhandler af TV-spil, computerspil og tilbehør. Vores stadig voksende sortiment af spil, garanterer, at der er noget for enhver smag og alder. Vi laver også vores egne produkter i eget navn,, som tilbydes til fordelagtige priser. ", 1, 4, "/Assets/Images/Gamestop.jpg", StoreCategories[5], "35 36 38 16"));
            SingletonStores.Instance.StoreList.Add(new Store(4, "Føtex", OpeningAndClosingTime[2], OpeningAndClosingTime[20], "I Føtex er vi vilde med gode fødevarer, og jo flere vi kan tilbyde, jo bedre. Vi har et tæt samarbejde med nogle af de allerbedste fødevareproducenter – herunder mange økologiske producenter. I vores butik står vores passionerede medarbejdere, herunder faglærte bagere og slagtere, hver dag klar til at tilbyde dig de bedste varer.", 1, 5, "/Assets/Images/Føtex.jpg", StoreCategories[2], "46 33 90 00"));
            SingletonStores.Instance.StoreList.Add(new Store(5, "Burger King", OpeningAndClosingTime[2], OpeningAndClosingTime[20], "Når du besøger Burger King på RO’s Torv i Roskilde kan du være sikker på én ting: Taste is King. Derfor får du kun serveret de bedste, friske råvarer såsom 100% velsmagende oksekød, lækre og sprøde salater, nuggets, onion rings, pommes frites, softice, vafler og den klassiske, flammegrillede Whopper. Vi står altid klar til at byde dig velkommen med et smil.", 1, 6, "/Assets/Images/BurgerKing.jpg", StoreCategories[10], "46 37 30 00"));
            SingletonStores.Instance.StoreList.Add(new Store(6, "Arnold Busck", OpeningAndClosingTime[2], OpeningAndClosingTime[18], "Arnold Busck er Danmarks ældste og største kæde af boghandlere. Den første boghandel åbnede i 1896 i København, og siden da har vi åbnet i alt 30 butikker fordelt over hele Danmark. Selvom de alle er Arnold Busck butikker, har hver butik sit helt eget præg. Det gælder også Arnold Busck på RO’s Torv i Roskilde. Her finder du et stort udvalg af bøger indenfor alle genrer.", 1, 7, "/Assets/Images/ArnoldBusck.jpg", StoreCategories[1], "46 34 12 46"));
            SingletonStores.Instance.StoreList.Add(new Store(6, "BR", OpeningAndClosingTime[2], OpeningAndClosingTime[18], "Hos BR er vores fornemmeste opgave at gøre alle børn glade. Hos os finder du et stort udvalg af legetøj til børn i alle aldre – vi har kreativt legetøj til læring, klassisk legetøj og meget mere. Du finder ligeledes babyudstyr, accessories til børnefødselsdage og ting til indretningen af børneværelset.", 1, 8, "/Assets/Images/br.jpg", StoreCategories[1], "87 78 84 60"));
            SingletonStores.Instance.StoreList.Add(new Store(6, "Deichmann", OpeningAndClosingTime[2], OpeningAndClosingTime[18], "Hos Deichmann på RO’s Torv i Roskilde finder du et stort udvalg af kvalitetssko til alle lejligheder. Vi har alt fra herresko, damesko, børnesko, sandaler og gummistøvler til træningssko, fede sneakers, business-sko, stiletter, støvletter, vintersko og vinterstøvler.", 1, 9, "/Assets/Images/Deichmann.jpg", StoreCategories[8], "88 80 91 64"));
            SingletonStores.Instance.StoreList.Add(new Store(6, "Zhiki Sushi", OpeningAndClosingTime[2], OpeningAndClosingTime[20], "Hos Zhiki Sushi på RO’s Torv træder du ind i en verden af japansk mad og specialiteter. Her kan du nyde både sushi, friske forårsruller af rispapir, sticks, andre varme retter og masser af lækkert tilbehør såsom ris, miso dip, goma dressing og mange flere japanske specialiteter.", 1, 10, "/Assets/Images/ZhikiSushi.jpg", StoreCategories[10], "44 44 55 36"));
            SingletonStores.Instance.StoreList.Add(new Store(6, "SAMS", OpeningAndClosingTime[2], OpeningAndClosingTime[18], "Hos Sams på RO’s Torv i Roskilde har vi et stort udvalg af moderigtigt herretøj til alle lejligheder. Vi har klassisk herretøj til jobbet i form af blazere, skjorter, bluser m.m. Derudover finder du et stort udvalg af cool og casual hverdagstøj såsom t-shirts, jeans, bluser og bukser.", 1, 11, "/Assets/Images/SAMS.jpg", StoreCategories[4], "27 10 77 31"));
            SingletonStores.Instance.StoreList.Add(new Store(6, "Profil Optik", OpeningAndClosingTime[2], OpeningAndClosingTime[18], "Profil Optik er Danmarks førende landsdækkende optikerkæde. I Profil Optik går vi meget højt op i at tilbyde et højt service- og kompetenceniveau. Vi hjælper vores kunder med at finde individuelle løsninger til den enkeltes behov og smag. Hos Profil Optik får du altid en synstest eller synsprøve, som definerer hvilket styrkebehov du har.", 2, 1, "/Assets/Images/ProfilOptik.jpg", StoreCategories[7], "46 36 11 88"));
            SingletonStores.Instance.StoreList.Add(new Store(6, "Sportmaster", OpeningAndClosingTime[2], OpeningAndClosingTime[18], "Hos Sportmaster er vi vilde med sport, og derfor finder du et stort sortiment af sportsudstyr i vores butik. Vi har noget for enhver smag, alder og sportsgren. Vi har udstyr til håndbold, fodbold, gymnastik, fitness, løb, udendørstøj og meget mere. I Sportmaster giver vi god rådgivning omkring de produkter vi sælger, så du får mest muligt ud af produktet.", 2, 2, "/Assets/Images/SportMaster.jpg", StoreCategories[12], "55 40 99 20"));
            SingletonStores.Instance.StoreList.Add(new Store(6, "Kino", OpeningAndClosingTime[2], OpeningAndClosingTime[20], "Hos Kino på RO’s Torv i Roskilde, viser vi altid de nyeste film i både 2D og 3D. Du får et bredt udvalg af film til både voksne og børn, da vi bestræber os på at have noget for enhver smag og alder. Du kan booke dine billetter online eller købe dem i skranken hos os. Kino er en moderne biograf, der siden den åbnede i 2003 er blevet opgraderet flere gange.", 2, 3, "/Assets/Images/Kino.jpg", StoreCategories[11], "46 35 16 66"));
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
