using ROsTorvApp.ViewModel.Collections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ROsTorvApp.Model.Center
{
    class Store
    {
        private string _imageStore;

        public int StoreId { get; set; }
        public string StoreName { get; set; }
        public string OpeningHours { get; set; }
        public string Description { get; set; }
        public int LocationFloor { get; set; }
        public int LocationNo { get; set; }
        public string ImageStore
        {
            get { return _imageStore; }
        }
        public string StoreCategory { get; set; }

        public Store(int storeId, string storeName, string openingHours, string description, int locationFloor, int locationNo, string imageStore, string storeCategory)
        {
            //StoreCollectionVM StoreCollection = new StoreCollectionVM();
            //StoreCollection.StoreCollection.Add(new Store(storeId, storeName, openingHours, description, locationFloor, locationNo, imageStore, storeCategory));
            
            StoreId = storeId;
            StoreName = storeName;
            OpeningHours = openingHours;
            Description = description;
            LocationFloor = locationFloor;
            LocationNo = locationNo;
            _imageStore= imageStore;
            StoreCategory = storeCategory;    
        }
        

    }
}
