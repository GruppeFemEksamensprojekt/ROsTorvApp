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

        //UserList gets created as ObservableCollection<UserAccount>,
        //and then gets all users from the Json file get added to UserList
        //by calling UserHandler.LoadUsersAsync().
        private SingletonUsers()
        {
            UserList = new ObservableCollection<UserAccount>();
            UserHandler.LoadUsersAsync();
        }

        #endregion

        #region Properties

        //Checks if instance is null and if it is then it gets created 
        //and makes sure that it only can get created one time.
        public static SingletonUsers Instance
        {
            get { return instance ?? (instance = new SingletonUsers());}
        }

        #endregion

    }
}
