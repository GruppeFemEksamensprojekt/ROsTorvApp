using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ROsTorvApp.Model.Users;

namespace ROsTorvApp.Helpers
{
    public sealed class SingletonUsers
    {
        #region Instance Fields

        private static SingletonUsers instance = null;
        public ObservableCollection<UserAccount> UserList { get; }

        #endregion

        #region Constructors

        //UserList bliver oprettet som en ObservableCollection<UserAccount>,
        //og så bliver alle de brugere som er gemt i Json file tilføjet til UserList
        //ved at kalde UserHandler.LoadUsersAsync().
        private SingletonUsers()
        {
            UserList = new ObservableCollection<UserAccount>();
            UserHandler.LoadUsersAsync();
        }

        #endregion

        #region Properties

        //Checker om Instance er null og hvis den er så opretter den en ny,
        //og det gør også at den kun kan blive oprettet en gang.
        public static SingletonUsers Instance
        {
            get { return instance ?? (instance = new SingletonUsers());}
        }

        #endregion

    }
}
