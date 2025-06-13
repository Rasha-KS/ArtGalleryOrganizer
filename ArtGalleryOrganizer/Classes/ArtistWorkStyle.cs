using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtGalleryOrganizer.Classes
{
    public class ArtistWorkStyle
    {

        public static List<ArtistWorkStyle> GetDefaultWorkStyles()
        {
            return new List<ArtistWorkStyle> {
    new ArtistWorkStyle { ArtistName = "Sarah Ali", WorkStyle = "Impressionism", WorkExperience = "5 years" },
    new ArtistWorkStyle { ArtistName = "Omar Yassin", WorkStyle = "Realism", WorkExperience = "7 years" },
    new ArtistWorkStyle { ArtistName = "Lina Hassan", WorkStyle = "Abstract", WorkExperience = "4 years" },
    new ArtistWorkStyle { ArtistName = "Khaled Mansour", WorkStyle = "Surrealism", WorkExperience = "6 years" },
    new ArtistWorkStyle { ArtistName = "Maya Nabil", WorkStyle = "Impressionism", WorkExperience = "3 years" },
    new ArtistWorkStyle { ArtistName = "Youssef Abdel", WorkStyle = "Realism", WorkExperience = "5 years" }
};
        }

      
        public string ArtistName { get; set; }
        public string WorkStyle { get; set; }
        public string WorkExperience { get; set; }
    }

}
