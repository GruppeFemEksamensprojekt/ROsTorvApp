using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using ROsTorvApp.Helpers;
using ROsTorvApp.Model.Center;
using ROsTorvApp.ViewModel.Collections;

namespace ROsTorvApp.Model.Users
{
    public class Admin : UserAccount
    {
        public ICommand AddCommand { get; set; }
        public ICommand DeleteCommand { get; set; }

        public Admin(string userName, string email, string password, string phoneNo)
            : base(userName,email,password,phoneNo,true)
        {
            AddCommand = new RelayCommand(AddStore, null);
            DeleteCommand = new RelayCommand(DeleteStore, StoreCollectionVM.StoreIsSelected);
        }

        //public void AddStoreToList()
        //{
        //    //StoreCollectionVM.AddStoreToList();
        //}


        public void AddStore()
        {
            StoreCollectionVM.AddStoreToList(new Store(Store.StoreId, Store.StoreName, Store.OpeningHours, Store.Description, Store.LocationFloor, Store.LocationNo, Store.ImageStore, Store.StoreCategory, Store.PhoneNo));
        }

        public void DeleteStore()
        {
            StoreCollectionVM.StoreCollection.Remove(StoreCollectionVM.SelectedStore);
        }
    }
}
