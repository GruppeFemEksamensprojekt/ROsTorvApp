using ROsTorvApp.ViewModel.Collections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ROsTorvApp.Model.Center
{
    public class Store
    {
        public static int StoreId { get; set; }
        public static string StoreName { get; set; }
        public static string OpeningHours { get; set; }
        public static string Description { get; set; }
        public static int LocationFloor { get; set; }
        public static int LocationNo { get; set; }
        public static string PhoneNo { get; set; }
        public static string ImageStore { get; set; }
        public static string StoreCategory { get; set; }

        public Store(int storeId, string storeName, string openingHours, string description, int locationFloor, int locationNo, string imageStore, string storeCategory, string phoneNo)
        {
            //StoreCollectionVM StoreCollection = new StoreCollectionVM();
            //StoreCollection.StoreCollection.Add(new Store(storeId, storeName, openingHours, description, locationFloor, locationNo, imageStore, storeCategory));

            PhoneNo = phoneNo;
            StoreId = storeId;
            StoreName = storeName;
            OpeningHours = openingHours;
            Description = description;
            LocationFloor = locationFloor;
            LocationNo = locationNo;
            ImageStore= imageStore;
            StoreCategory = storeCategory;    
        }

        public Store()
        {

        }

    }
}
