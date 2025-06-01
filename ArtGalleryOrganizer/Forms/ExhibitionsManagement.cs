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
    public partial class ExhibitionsManagement : Form
    {
        public ExhibitionsManagement()
        {
            InitializeComponent();
        }

        ResizeControls r = new ResizeControls();

        private void ExhibitionsManagement_HandleCreated(object sender, EventArgs e)
        {
            r.Container = this;
        }

        private void ExhibitionsManagement_Resize(object sender, EventArgs e)
        {
            r.ResizeControl();
        }

        private void ExhibitionsManagement_Load(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {

        }
    }
}
