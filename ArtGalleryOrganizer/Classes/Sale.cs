using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtGalleryOrganizer.Classes
{
    public class Sale
    {
        public string ArtistName { get; set; }
        public string Title { get; set; }
        public bool OpenBuffet { get; set; }
        public bool CafeCorner { get; set; }
        public bool GuidedTours { get; set; }
        public bool AdditionalSpace { get; set; }
        public bool Photographer { get; set; }
        public double TotalPrice { get; set; }

        public static List<Sale> GetDefaultSales()
        {
            return new List<Sale>
    {
        new Sale{ArtistName="Sarah Ali",Title="Spring Vibes",OpenBuffet=true,CafeCorner=false,GuidedTours=true,AdditionalSpace=false,Photographer=true,TotalPrice=1350},
        new Sale{ArtistName="Omar Yassin",Title="Shadows",OpenBuffet=false,CafeCorner=true,GuidedTours=false,AdditionalSpace=false,Photographer=false,TotalPrice=300},
        new Sale{ArtistName="Lina Hassan",Title="City Lights",OpenBuffet=true,CafeCorner=true,GuidedTours=false,AdditionalSpace=true,Photographer=false,TotalPrice=1550},
        new Sale{ArtistName="Khaled Mansour",Title="Abstract Flow",OpenBuffet=false,CafeCorner=false,GuidedTours=true,AdditionalSpace=false,Photographer=true,TotalPrice=850},
        new Sale{ArtistName="Maya Nabil",Title="Nature's Whisper",OpenBuffet=true,CafeCorner=false,GuidedTours=false,AdditionalSpace=true,Photographer=false,TotalPrice=850},
        new Sale{ArtistName="Youssef Abdel",Title="Silent Echoes",OpenBuffet=false,CafeCorner=true,GuidedTours=false,AdditionalSpace=false,Photographer=true,TotalPrice=750}
    };
        }
    }
}
