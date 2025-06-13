using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtGalleryOrganizer.Classes
{
    public static class SharedData
    {


        public static BindingList<Artist> Artists = new BindingList<Artist>(Artist.GetDefaultArtists());
        public static BindingList<ArtistWorkStyle> ArtistWorkStyles = new BindingList<ArtistWorkStyle>(ArtistWorkStyle.GetDefaultWorkStyles());
        public static BindingList<Session> Sessions = new BindingList<Session>(Session.GetDefaultSessions());
        public static BindingList<Booking> Bookings = new BindingList<Booking>(Booking.GetDefaultBookings());
   
    }
}
