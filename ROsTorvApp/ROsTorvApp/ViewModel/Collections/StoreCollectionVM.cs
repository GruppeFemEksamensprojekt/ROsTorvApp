using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ROsTorvApp.Model.Center;

namespace ROsTorvApp.ViewModel.Collections
{
    class StoreCollectionVM
    {
        public ObservableCollection<Store> StoreCollection { get; set; }
    }
}
