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
    public partial class ArtistsManagement : Form
    {
        public ArtistsManagement()
        {
            InitializeComponent();
        }

        ResizeControls r = new ResizeControls();


        private void ArtistsManagement_Load(object sender, EventArgs e)
        {

        }

        private void ArtistsManagement_Resize(object sender, EventArgs e)
        {
            r.ResizeControl();
        }

        private void ArtistsManagement_HandleCreated(object sender, EventArgs e)
        {
            r.Container = this;
        }
    }
}
