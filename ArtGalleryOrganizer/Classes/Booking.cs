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
        public double TotalHours { get; set; }
        public int ArtworksCount { get; set; }
        public string Title { get; set; }
        public DateTime StartTime { get; set; }
        public double PlusHours { get; set; }
        public double TotalPrice { get; set; }


        public double CalculateTotalPrice(double sessionPrice, double plusHours)
        {
            double extraCharge = plusHours * (sessionPrice * 0.03);
            return sessionPrice + extraCharge;
        }

        public static List<Booking> GetDefaultBookings()
        {
            return new List<Booking>{
               new Booking{ ArtistName = "Sarah Ali",Session = "A1",TotalPrice = 6180,
               Date = DateTime.Today.AddDays(10).AddHours(16),TotalHours = 2,PlusHours = 1,
               ArtworksCount = 5,Title = "Spring Vibes",StartTime = DateTime.Today.AddHours(9)},
               
               new Booking { ArtistName = "Omar Yassin",
               Session = "B1",TotalPrice = 3150, Date = DateTime.Today.AddDays(1),
               TotalHours = 3, PlusHours = 0, ArtworksCount = 3,Title = "Shadows",
               StartTime = DateTime.Today.AddDays(1).AddHours(18)
            }
        };
        }

  
    
    
    }


}

