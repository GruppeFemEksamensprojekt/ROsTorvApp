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
        private static SingletonUsers instance = null;
        public ObservableCollection<UserAccount> UserList { get; }

        private SingletonUsers()
        {
            UserList = new ObservableCollection<UserAccount>();
            UserHandler.LoadUsersAsync();
        }

        public static SingletonUsers Instance
        {
            get { return instance ?? (instance = new SingletonUsers());}
        }
    }
}
