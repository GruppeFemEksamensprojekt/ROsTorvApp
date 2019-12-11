using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ROsTorvApp.Model.Center.Offers;

namespace ROsTorvApp.ViewModel.Collections
{
    class OfferCollectionVM
    {
        public Offer Offer1;
        public ObservableCollection<Offer> OfferCollection { get; set; }

        public OfferCollectionVM()
        {
            AddOffer(Offer1 = new Offer(1, "Tilbud In Matas",30,5000,"Føtex", new DateTime(2019,12,16), new DateTime(2019,12,24), ""));
            AddOffer(Offer1 = new Offer(2, "Tilbud In Føtex",30,5000,"Føtex", new DateTime(2019,12,16), new DateTime(2019,12,24), ""));
            AddOffer(Offer1 = new Offer(3, "Tilbud In Føtex",30,5000,"Føtex", new DateTime(2019,12,16), new DateTime(2019,12,24), ""));
            AddOffer(Offer1 = new Offer(4, "Tilbud In Føtex",30,5000,"Føtex", new DateTime(2019,12,16), new DateTime(2019,12,24), ""));
            AddOffer(Offer1 = new Offer(5, "Tilbud In Føtex",30,5000,"Føtex", new DateTime(2019,12,16), new DateTime(2019,12,24), ""));
            AddOffer(Offer1 = new Offer(6, "Tilbud In Føtex",30,5000,"Føtex", new DateTime(2019,12,16), new DateTime(2019,12,24), ""));
            AddOffer(Offer1 = new Offer(7, "Tilbud In Føtex",30,5000,"Føtex", new DateTime(2019,12,16), new DateTime(2019,12,24), ""));
            AddOffer(Offer1 = new Offer(8, "Tilbud In Føtex",30,5000,"Føtex", new DateTime(2019,12,16), new DateTime(2019,12,24), ""));
            AddOffer(Offer1 = new Offer(9, "Tilbud In Føtex",30,5000,"Føtex", new DateTime(2019,12,16), new DateTime(2019,12,24), ""));
            AddOffer(Offer1 = new Offer(10, "Tilbud In Føtex",30,5000,"Føtex", new DateTime(2019,12,16), new DateTime(2019,12,24), ""));
        }
        //A method which adds a new Offer to the list of offers.
        public void AddOffer(Offer offer)
        {
            OfferCollection.Add(offer);
        }
    }
}
