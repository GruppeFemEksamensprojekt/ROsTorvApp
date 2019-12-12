using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ROsTorvApp.Model.Center.Offers
{
    public class Offer
    {
        public int OfferId { get; set; }
        public string Description { get; set; }
        public decimal Discount { get; set; }
        public decimal PriceBefore { get; set; }
        public string Location { get; set; }
        public string OfferImage { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }

        public Offer(int offerId, string description, decimal discount, decimal priceBefore, string location, DateTime startTime,DateTime endTime, string offerImage)
        {
            OfferId = offerId;
            Description = description;
            Discount = discount;
            PriceBefore = priceBefore;
            Location = location;
            StartTime = startTime;
            EndTime = endTime;
            OfferImage = offerImage;
        }
    
    }
}
