using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ROsTorvApp.Model.Center.Offers;

namespace ROsTorvApp.ViewModel.Collections
{
    class EventCollectionVM
    {
        public Event Event1;
        public ObservableCollection<Event> EventCollection { get; set; }

        public EventCollectionVM()
        {
            AddEvent(Event1 = new Event("Tilbud In Føtex", new DateTime(2019, 11, 29), 
                new DateTime(2019,12,07),
                "Føtex har billig mælk 17.- for økologisk chiafrø mælk!"));
        }
        //A method which adds a new Event to the list of events.
        public void AddEvent(Event eventevent)
        {
            EventCollection.Add(eventevent);
        }




    }
}
