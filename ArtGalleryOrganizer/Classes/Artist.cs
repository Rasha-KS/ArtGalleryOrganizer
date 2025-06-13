using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtGalleryOrganizer.Classes
{
    
    public class Artist
    {
        public static List<Artist> GetDefaultArtists()
        {
            return new List<Artist>
               {
        new Artist { Id = 1, Name = "Sarah Ali", Email = "sarah@example.com", Nationality = "Egyptian", Phone = "01012345678" },
        new Artist { Id = 2, Name = "Omar Yassin", Email = "omar@example.com", Nationality = "Moroccan", Phone = "0612345678" },
        new Artist { Id = 3, Name = "Lina Hariri", Email = "lina@example.com", Nationality = "Lebanese", Phone = "70123456" }
             };
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Nationality { get; set; }
       
        public string Phone { get; set; }

    }
}
