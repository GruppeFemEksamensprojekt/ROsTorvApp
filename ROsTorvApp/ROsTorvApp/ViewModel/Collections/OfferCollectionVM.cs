using ROsTorvApp.Helpers;
using ROsTorvApp.Model.Center.Offers;
using System.Collections.ObjectModel;

namespace ROsTorvApp.ViewModel.Collections
{
    internal class OfferCollectionVM
    {
        public ObservableCollection<Offer> OfferCollection { get; set; }

        public OfferCollectionVM()
        {
            OfferCollection = new ObservableCollection<Offer>();
            AddOffer(new Offer(1, "Matas", "Mandeparfume", 30, 400, "/Assets/Images/Offers/MatasTilbud1.jpg"));
            AddOffer(new Offer(2, "Matas", "Kvindeparfume", 50, 500, "/Assets/Images/Offers/MatasTilbud2.jpg"));
            AddOffer(new Offer(3, "GameStop+", "Spil", 60, 349, "/Assets/Images/Offers/GameStopTilbud1.jpg"));
            AddOffer(new Offer(4, "GameStop+", "Spil", 40, 400, "/Assets/Images/Offers/GameStopTilbud2.jpg"));
            AddOffer(new Offer(5, "GameStop+", "Spil", 20, 150, "/Assets/Images/Offers/GameStopTilbud3.jpg"));
            AddOffer(new Offer(6, "GameStop+", "Spilkonsol", 50, 1499, "/Assets/Images/Offers/GameStopTilbud4.jpg"));
            AddOffer(new Offer(7, "Tøjeksperten", "Jakkesæt", 35, 1500, "/Assets/Images/Offers/ToejEkspertenTilbud1.jpg"));
            AddOffer(new Offer(8, "Tøjeksperten", "Skjorte", 50, 800, "/Assets/Images/Offers/ToejEkspertenTilbud2.jpg"));
            AddOffer(new Offer(9, "Tøjeksperten", "Jakke", 50, 2500, "/Assets/Images/Offers/ToejEkspertenTilbud3.jpg"));
        }

        //A method which adds a new Offer to the list of offers.
        public void AddOffer(Offer offer)
        {
            OfferCollection.Add(offer);
        }

        public string Time { get { return StoreCollectionVM.Time; } }
        public string UsersFullName { get { return UserHandler.CurrentUsersFullName; } }
    }
}