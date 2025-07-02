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

        private void MainScreen_Activated(object sender, EventArgs e)
        {
            lblArtistCount.Text = SharedData.Artists.Count.ToString();
            lblBookingCount.Text = SharedData.Bookings.Count.ToString();

            labelDate.Text = DateTime.Now.ToString("dddd, dd MMMM yyyy - hh:mm tt");

            dataGridView3.DataSource = SharedData.Bookings;
            dataGridView3.Columns["Title"].Visible = false;
            dataGridView3.Columns["PlusHours"].Visible = false;
            dataGridView3.Columns["TotalPrice"].Visible = false;
            dataGridView3.Columns["StartTime"].Visible = false;

        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            HallManagement hallManagement = new HallManagement();
            hallManagement.ShowDialog();
        }
    }
       
}
