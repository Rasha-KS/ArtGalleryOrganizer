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
            return new List<ArtistWorkStyle>
             {
        new ArtistWorkStyle { ArtistName = "Sarah Ali", WorkStyle = "Impressionism", WorkExperience = "5 years" },
        new ArtistWorkStyle { ArtistName = "Omar Yassin", WorkStyle = "Realism", WorkExperience = "7 years" },
        new ArtistWorkStyle { ArtistName = "Lina Hariri", WorkStyle = "Abstract", WorkExperience = "3 years" }
              };
        }

        public int ArtistId { get; set; }
        public string ArtistName { get; set; }
        public string WorkStyle { get; set; }
        public string WorkExperience { get; set; }
    }

}
