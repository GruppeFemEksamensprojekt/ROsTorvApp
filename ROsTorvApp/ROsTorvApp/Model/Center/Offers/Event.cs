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
        public string EventImage { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Description { get; set; }

        
        public Event(string eventName,string eventImg, DateTime startDate, DateTime endDate, string description)
        {
            EventName = eventName;
            EventImage = eventImg;
            StartDate = startDate;
            EndDate = endDate;
            Description = description;
        }
        public string DurationDateText
        {
            get { return $"Fra {StartDate.ToString("dd/MM")} - {EndDate.ToString("dd/MM")} - {DateTime.Now.ToString("yyyy")}"; }
        }
    }
}
