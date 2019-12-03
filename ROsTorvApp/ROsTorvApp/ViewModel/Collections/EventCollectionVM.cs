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
            EventCollection = new ObservableCollection<Event>();
            EventCollection.Add(new Event("STORT ONLINE MAGASIN","/Assets/Images/Events/Events-Onlinemagasin.jpg", new DateTime(2019, 12, 1), new DateTime(2019, 12, 31), "JULEMAGASINET FLYTTER IND PÅ DIN COMPUTER!"));
            EventCollection.Add(new Event("DANMARKS STØRSTE MISTELTEN", "/Assets/Images/Events/Events-Mistelten.jpg", new DateTime(2019, 12, 1), new DateTime(2019, 12, 23), "Nu er det snart jul og i RO’s Torv Shoppingcenter er julen for alvor skudt i gang. Her er pyntet op, så det oser af jul og vi mener det alvorligt, når vi siger ‘Kys julen ind’! Derfor præsenterer vi nu Danmarks største mistelten!\n\n Du finder den på RO’s Torv i gangen mellem Home og Imerco Home.\n\n Misteltenen er blevet til i et samarbejde med kunstner Lisbeth van Deurs. Skrædder, smed og kunstner har været i gang med det mere end 6 meter lange, traditionsinspirerede værk og traditionen er som bekendt, at står man under en mistelten, så skal der kysses! Kys koster ikke noget – kindkys, tantekys, kærestekys og kram.\n\n Vi glæder os til at se dig under misteltenen – kom og kys!"));
            EventCollection.Add(new Event("JULEMINIGOLF", "/Assets/Images/Events/Events-minigolf.jpg", new DateTime(2019, 11, 20), new DateTime(2019, 12, 31), "Der skal da være plads til hygge i en ellers travl tid. RO’s Torv inviterer til juleminigolf og fra onsdag 20. november kan hele familien slå julen ind. Ta’ en pause i juleshoppingen og spil på vores hyggelige og julede minigolfbane placeret på Torvet og andre steder på RO’s Torv. Lej køllerne i Centerinformationen på 1. sal. Det koster 20 kr. pr. lejet sæt (Golfkølle og golfbold)\n\n Juleminigolfuniverset åbner onsdag 20. november og holder åbent frem til 31. december. I kan spille minigolf i hele RO’s Torvs åbningstid:\n\n 20.-22. november kl. 10-19\n\n 23. og 24. november kl. 10-17\n\n 25.-28. november kl. 10-19\n\n 29. november kl. 8-24\n\n 30. november kl. 10-17\n\n 1.-23. december kl. 10-20\n\n 27.-30. december kl. 10-20\n\n 31. december kl. 10-14"));
            EventCollection.Add(new Event("BRÆNDTE MANDLER", "/Assets/Images/Events/Events-mandler.jpg", new DateTime(2019, 12, 1), new DateTime(2019, 12, 31), "NYHED: BRÆNDTE MANDLER!\n\n (Ved indgangen fra P-hus Øst)\n\n December er lige om hjørnet! Nyd duften af jul, der spreder sig i gangene og køb en pose lækre nylavede brændte mandler med hjem! De dufter og smager himmelsk!\n\n Mandelboden er åben:\n\n 26/11: 11-19, 27/11: 11-19, 28/11: 11-19, 29/11: 8-24, 30/11: 10-17 og alle åbningsdage i december frem til jul 10-20."));
            EventCollection.Add(new Event("VIND GAVEKORT TIL RO’S TORV", "/Assets/Images/Events/Events-Konkurrence.jpg", new DateTime(2019, 12, 1), new DateTime(2019, 12, 31), "JULEMAGASINET FLYTTER IND PÅ DIN COMPUTER!\n\n Kunne du tænke dig, at sende et julekys til en, du holder af? – og samtidig deltage i konkurrencen om dejlige gavekort til RO’s Torv? Så skal du gøre som følger:\n 1. Lav en kyssebillede af dig selv, af dine børn, af dig og din mand, af dine børnebørn, af din kæreste, et tantekys, et kindkys eller blot en dejlig og kærlig julekrammer – det er dig, der bestemmer. Du må også gerne tage dit billede under Danmarks største mistelten, som RO’s Torv har hængt op mellem Home og Imerco Home.\n 2. Slå det op på RO’s Torvs facebookside og tag RO’s Torv samt den du gerne vil sende kysset til senest 23. december 2019.\n 3. Opfordr folk til at ‘elske’ billedet – for jo flere hjerter dit billede får, jo større er din chance for at vinde.\n\n Det billede der får flest hjerter, vinder konkurrencen og dermed førstepræmien, som er et gavekort til RO’s Torv på 3.000,-. 2. præmien er et gavekort på 2.000,- (næstflest hjerter) og 3. præmien er et gavekort på 1.000,-.\n\n Vinderne kontaktes direkte på posten og via messenger på Facebook i løbet af uge 2, 2020 og alle vindernes billeder deler vi på RO’s Torvs facebookside i løbet af samme uge.\n\n Pssst. Du kan også tage dit kyssebillede i en af RO’s Torv 5 kyssezoner.\n\n Start Kissing! Held og lykke."));
            
            
        }
        //A method which adds a new Event to the list of events.
        public void AddEvent(Event eventevent)
        {
            EventCollection.Add(eventevent);
        }




    }
}
