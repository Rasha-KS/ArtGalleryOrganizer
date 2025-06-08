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
        public MainScreen()
        {
            InitializeComponent();
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
            ExhibitionsManagement exhibitionsManagement = new ExhibitionsManagement();
            exhibitionsManagement.ShowDialog();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {

        }
    }
       
}
