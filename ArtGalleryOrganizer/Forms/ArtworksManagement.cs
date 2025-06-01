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
    public partial class ArtworksManagement : Form
    {
        public ArtworksManagement()
        {
            InitializeComponent();
        }

        ResizeControls r = new ResizeControls();

        private void ArtworksManagement_HandleCreated(object sender, EventArgs e)
        {
            r.Container = this;
        }

        private void ArtworksManagement_Resize(object sender, EventArgs e)
        {
            r.ResizeControl();
        }

        private void ArtworksManagement_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
