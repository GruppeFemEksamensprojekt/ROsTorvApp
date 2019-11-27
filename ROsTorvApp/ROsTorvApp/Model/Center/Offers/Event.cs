using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ROsTorvApp.Model.Center.Offers
{
    class Event
    {
        public string EventName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Description { get; set; }
        public Event(string eventName, DateTime startDate, DateTime endDate, string description)
        {
            EventName = eventName;
            StartDate = startDate;
            EndDate = endDate;
            Description = description;
        }
    }
}
