using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using ROsTorvApp.Annotations;
using ROsTorvApp.Model.Users;

namespace ROsTorvApp.ViewModel.Collections
{
    public class AdminCollectionVM
    {
        public Admin Admin1;
        private ObservableCollection<Admin> _adminCollection;

        public static ObservableCollection<Admin> AdminCollection { get; set; }

        public AdminCollectionVM()
        {
            AddAdmin(Admin1 = new Admin("Admin", "E-Mail@Email.com", "password", "40404040"));
        }
        
        public void AddAdmin(Admin admin)
        {
            AdminCollection.Add(admin);
            
        }

    }
}
