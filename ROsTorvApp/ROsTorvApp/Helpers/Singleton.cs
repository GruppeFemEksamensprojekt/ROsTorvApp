using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ROsTorvApp.Model.Users;

namespace ROsTorvApp.Helpers
{
    public sealed class Singleton
    {
        private static Singleton instance = null;
        public ObservableCollection<UserAccount> UserList { get; }

        private Singleton()
        {
            UserList = new ObservableCollection<UserAccount>();
            UserHandler.LoadUsersAsync();
        }

        public static Singleton Instance
        {
            get { return instance ?? (instance = new Singleton());}
        }
    }
}
