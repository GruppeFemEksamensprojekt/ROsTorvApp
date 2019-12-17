using ROsTorvApp.Model.Center;
using System.Collections.ObjectModel;

namespace ROsTorvApp.Helpers
{
    public sealed class SingletonStores
    {
        #region Instance Fields

        private static SingletonStores instance = null;
        public ObservableCollection<Store> StoreList { get; }

        #endregion Instance Fields

        #region Constructors

        //StoreList gets created as ObservableCollection<Store>,
        //and then gets all stores from the Json file get added to StoreList
        //by calling StoreHandler.LoadStoresAsync().
        private SingletonStores()
        {
            StoreList = new ObservableCollection<Store>();
            StoreHandler.LoadStoresAsync();
        }

        #endregion Constructors

        #region Properties

        //Checks if instance is null and if it is then it gets created
        //and makes sure that it only can get created one time.
        public static SingletonStores Instance
        {
            get { return instance ?? (instance = new SingletonStores()); }
        }

        #endregion Properties
    }
}