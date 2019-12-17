using ROsTorvApp.Helpers;
using ROsTorvApp.Model.Users;
using System.Collections.ObjectModel;

namespace ROsTorvApp.ViewModel.Collections
{
    public class AdminCollectionVM
    {
        public Admin Admin1;
        private ObservableCollection<Admin> _adminCollection;

        public ObservableCollection<Admin> AdminCollection
        {
            get { return _adminCollection; }
        }

        public AdminCollectionVM()
        {
            _adminCollection = new ObservableCollection<Admin>();
        }

        //A method which adds the default admin.
        public static void AddDefaultAdmin()
        {
            SingletonUsers.Instance.UserList.Add(new Admin("Super", "User", 69, "Admin", "E-Mail@Email.com", "password", "40404040"));
            UserHandler.SaveUsersAsync();
        }
    }
}