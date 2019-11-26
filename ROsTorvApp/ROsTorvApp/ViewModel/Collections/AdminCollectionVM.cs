using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ROsTorvApp.Model.Users;

namespace ROsTorvApp.ViewModel.Collections
{
    class AdminCollectionVM
    {
        public ObservableCollection<Admin> AdminCollection { get; set; }
    }
}
