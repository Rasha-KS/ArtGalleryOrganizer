using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtGalleryOrganizer.Classes
{

    public class Booking
    {
        public string ArtistName { get; set; }
        public string Session { get; set; }
        public DateTime Date { get; set; }
        public int TotalHours { get; set; }
        public int ArtworksCount { get; set; }

    }
   

}

