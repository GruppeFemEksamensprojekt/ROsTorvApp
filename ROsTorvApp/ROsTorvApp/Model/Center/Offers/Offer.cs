namespace ROsTorvApp.Model.Center.Offers
{
    public class Offer
    {
        public int OfferId { get; set; }
        public string Description { get; set; }
        public decimal Discount { get; set; }
        public string ItemCategory { get; set; }
        public decimal Price { get; set; }
        public string OfferImage { get; set; }

        public Offer(int offerId, string description, string itemCategory, decimal discount, decimal price, string offerImage)
        {
            OfferId = offerId;
            Description = description;
            ItemCategory = itemCategory;
            Discount = discount;
            Price = price;
            OfferImage = offerImage;
        }

        public decimal PriceAfterDiscount
        {
            get { return (100 - Discount) * (Price / 100); }
        }

        public string DiscountPercentage { get { return $"- {Discount.ToString()}%"; } }
    }
}