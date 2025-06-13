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
                new Booking{ArtistName="Sarah Ali",Session="A1",TotalPrice=6180,Date=DateTime.Today.AddDays(10).AddHours(16),TotalHours=2,PlusHours=1,ArtworksCount=5,Title="Spring Vibes",StartTime=DateTime.Today.AddHours(9)},
                new Booking{ArtistName="Omar Yassin",Session="B1",TotalPrice=3150,Date=DateTime.Today.AddDays(1),TotalHours=3,PlusHours=0,ArtworksCount=3,Title="Shadows",StartTime=DateTime.Today.AddDays(1).AddHours(18)},
                new Booking{ArtistName="Lina Hassan",Session="A2",TotalPrice=4500,Date=DateTime.Today.AddDays(5).AddHours(14),TotalHours=4,PlusHours=0,ArtworksCount=4,Title="City Lights",StartTime=DateTime.Today.AddDays(5).AddHours(10)},
                new Booking{ArtistName="Khaled Mansour",Session="A2",TotalPrice=4500,Date=DateTime.Today.AddDays(7).AddHours(17),TotalHours=3,PlusHours=0,ArtworksCount=6,Title="Abstract Flow",StartTime=DateTime.Today.AddDays(7).AddHours(11)},
                new Booking{ArtistName="Maya Nabil",Session="A1",TotalPrice=6000,Date=DateTime.Today.AddDays(3).AddHours(13),TotalHours=2,PlusHours=0,ArtworksCount=2,Title="Nature's Whisper",StartTime=DateTime.Today.AddDays(3).AddHours(9)},
                new Booking{ArtistName="Youssef Abdel",Session="B1",TotalPrice=3150,Date=DateTime.Today.AddDays(9).AddHours(15),TotalHours=3,PlusHours=0,ArtworksCount=4,Title="Silent Echoes",StartTime=DateTime.Today.AddDays(9).AddHours(12)}
                      };

        }
          
  
    
    
    }


}

