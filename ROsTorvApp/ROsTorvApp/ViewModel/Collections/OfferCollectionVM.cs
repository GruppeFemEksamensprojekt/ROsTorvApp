using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ROsTorvApp.Helpers;
using ROsTorvApp.Model.Center.Offers;

namespace ROsTorvApp.ViewModel.Collections
{
    class OfferCollectionVM
    {
        public Offer Offer1;
        public ObservableCollection<Offer> OfferCollection { get; set; }

        public OfferCollectionVM()
        {
            OfferCollection = new ObservableCollection<Offer>();
            AddOffer(new Offer(1, "Matas", "Mandeparfume", 30, 5000, "/Assets/Images/Offers/MatasTilbud1.jpg"));
            AddOffer(new Offer(1, "Matas", "Mandeparfume", 30, 5000, "/Assets/Images/Offers/MatasTilbud1.jpg"));
            AddOffer(new Offer(1, "Matas", "Mandeparfume", 30, 5000, "/Assets/Images/Offers/MatasTilbud1.jpg"));
            AddOffer(new Offer(1, "Matas", "Mandeparfume", 30, 5000, "/Assets/Images/Offers/MatasTilbud1.jpg"));
            AddOffer(new Offer(1, "Matas", "Mandeparfume", 30, 5000, "/Assets/Images/Offers/MatasTilbud1.jpg"));
            AddOffer(new Offer(1, "Matas", "Mandeparfume", 30, 5000, "/Assets/Images/Offers/MatasTilbud1.jpg"));

        }
        //A method which adds a new Offer to the list of offers.
        public void AddOffer(Offer offer)
        {
            OfferCollection.Add(offer);
        }

        public string Time{ get { return StoreCollectionVM.Time; } }
        public string UsersFullName { get { return UserHandler.CurrentUsersFullName; } }
    }
}
