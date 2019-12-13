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
        #region Instance Fields

        private static SingletonStores instance = null;
        public ObservableCollection<Store> StoreList { get; }

        #endregion

        #region Constructors

        //StoreList bliver oprettet som en ObservableCollection<Store>,
        //og så bliver alle de butikker som er gemt i Json file tilføjet til StoreList
        //ved at kalde StoreHandler.LoadStoresAsync().
        private SingletonStores()
        {
            StoreList = new ObservableCollection<Store>();
            StoreHandler.LoadStoresAsync();
        }

        #endregion

        #region Properties

        //Checker om Instance er null og hvis den er så opretter den en ny,
        //og det gør også at den kun kan blive oprettet en gang.
        public static SingletonStores Instance
        {
            get { return instance ?? (instance = new SingletonStores()); }
        }

        #endregion
    }
}
