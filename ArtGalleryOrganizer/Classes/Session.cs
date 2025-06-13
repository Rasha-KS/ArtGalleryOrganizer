using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtGalleryOrganizer.Classes
{
    public class Session
    {
        public string Name { get; set; }
        public double sessionPrice { get; set; }

        public Session(string name, double price)
        {
            Name = name;
            sessionPrice = price;
        }

        public static List<Session> GetDefaultSessions()
        {
            return new List<Session>
        {
            new Session("A1", 6000),
            new Session("A2", 4500),
            new Session("B1", 3150)
        };
        }

    }
}
