using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ROsTorvApp.Model.Center.Offers
{
    class Offer
    {
        public int OfferId { get; set; }
        public string Description { get; set; }
        public decimal Discount { get; set; } // i %???
        public decimal PriceBefore { get; set; }
        public string Location { get; set; }
        public DateTime RunTime { get; set; } // Lav om, vi skal bruge start og end date på offer's løbetid

        public Offer(int offerId, string description, decimal discount, decimal priceBefore, string location, DateTime runTime)
        {
            OfferId = offerId;
            Description = description;
            Discount = discount;
            PriceBefore = priceBefore;
            Location = location;
            RunTime = runTime;
        }
    
    }
}
