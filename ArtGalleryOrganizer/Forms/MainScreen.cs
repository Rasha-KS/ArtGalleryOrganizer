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


        private void MainScreen_Load(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
       
}
