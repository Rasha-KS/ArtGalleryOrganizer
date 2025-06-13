using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtGalleryOrganizer.Classes
{
    public static class SharedData
    {

            public static List<Artist> Artists = Artist.GetDefaultArtists();
            public static List<Session> Sessions = Session.GetDefaultSessions();
            public static List<Booking> Bookings = Booking.GetDefaultBookings();

    }
}
