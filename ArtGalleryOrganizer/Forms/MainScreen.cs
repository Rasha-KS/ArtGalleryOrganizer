using ArtGalleryOrganizer.Classes;
using ArtGalleryOrganizer.Forms;
using StudentProject1.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ArtGalleryOrganizer
{

    public partial class MainScreen : Form
    {
        private void MainScreen_Load(object sender, EventArgs e)
        {


            labelDate.Text = DateTime.Now.ToString("dddd, dd MMMM yyyy - hh:mm tt");


            // بيانات تجريبية
            BindingList<Artist> artists = new BindingList<Artist>();
            artists = new BindingList<Artist>(Artist.GetDefaultArtists());



            //---------------------------------------------------
            List<Booking> bookings = new List<Booking>
        {
        new Booking { ArtistName = "Amira", Session = "Morning", Date = DateTime.Now, TotalHours = 3, ArtworksCount = 6 },
        new Booking { ArtistName = "Ali", Session = "Evening", Date = DateTime.Now.AddDays(1), TotalHours = 2, ArtworksCount = 4 }
        };

           dataGridView3.DataSource = bookings;


            // عرض الإحصائيات
            lblArtistCount.Text = artists.Count.ToString();
            lblBookingCount.Text = bookings.Count.ToString();


        }

        public MainScreen()
        {
            InitializeComponent();
            this.Load += MainScreen_Load;
        }

        ResizeControls r = new ResizeControls();

        private void MainScreen_HandleCreated(object sender, EventArgs e)
        {
            r.Container = this;
        }

        private void MainScreen_Resize(object sender, EventArgs e)
        {
            r.ResizeControl();
        }

        private void btnArtists_Click(object sender, EventArgs e)
        {
            ArtistsManagement am = new ArtistsManagement();
            am.ShowDialog();
        }

      

        private void btnSales_Click(object sender, EventArgs e)
        {
            Services sales = new Services();
            sales.ShowDialog();
        }

        private void btnExhibitions_Click(object sender, EventArgs e)
        {
            BookingManagement exhibitionsManagement = new BookingManagement();
            exhibitionsManagement.ShowDialog();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {

        }

       
    }
       
}
