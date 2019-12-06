using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ROsTorvApp.Model.Center;
using ROsTorvApp.Model.Users;

namespace ROsTorvApp.Helpers
{
    public sealed class SingletonStores
    {
        private static SingletonStores instance = null;
        public ObservableCollection<Store> StoreList { get; }

        private SingletonStores()
        {
            StoreList = new ObservableCollection<Store>();
            StoreHandler.LoadStoresAsync();
        }

        public static SingletonStores Instance
        {
            get { return instance ?? (instance = new SingletonStores()); }
        }
    }
}
