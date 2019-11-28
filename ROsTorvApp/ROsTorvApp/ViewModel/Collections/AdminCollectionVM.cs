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
    class AdminCollectionVM
    {
        public Admin Admin1;
        public ObservableCollection<Admin> AdminCollection { get; set; }

        public AdminCollectionVM()
        {
            AddAdmin(Admin);
        }
        
        public void AddAdmin(Admin Admin)
        {
            AdminCollection.Add(Admin);
        }

        Admin Admin = new Admin("Admin","E-Mail@Email.com","password","40404040",true);

        
    }
}
