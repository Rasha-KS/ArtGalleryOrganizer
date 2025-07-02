using ArtGalleryOrganizer.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ArtGalleryOrganizer.Forms
{
    public partial class Services : Form
    {
        public Services()
        {
            InitializeComponent();
        }

       int  selectedSaleIndex = -1;

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void Services_Load(object sender, EventArgs e)
        {
            DisplaySales();
            dgvSales.ClearSelection();

        }


    

        private void btnSave_Click(object sender, EventArgs e)
        {
            string title = cmbTitle.Text.Trim();

        

            //// إيجاد الحجز المطابق
            //var booking = SharedData.Bookings.FirstOrDefault(b =>
            //    b.ArtistName.Equals(artistName, StringComparison.OrdinalIgnoreCase) &&
            //    b.Title.Equals(title, StringComparison.OrdinalIgnoreCase));


            // حساب السعر الإضافي الحالي حسب الخيارات المحددة
            double extra = 0;
            bool openBuffet = chkOpenBuffet.Checked;
            bool cafeCorner = chkCafeCorner.Checked;
            bool guidedTour = chkGuidedTour.Checked;
            bool additionalSpace = chkAdditionalSpace.Checked;
            bool photographer = chkPhotographer.Checked;

            if (openBuffet) extra += 500;
            if (cafeCorner) extra += 300;
            if (guidedTour) extra += 400;
            if (additionalSpace) extra += 350;
            if (photographer) extra += 450;

          

            if (selectedSaleIndex >= 0 && selectedSaleIndex < SharedData.Sales.Count)
            {
                // تعديل صف موجود
                var sale = SharedData.Sales[selectedSaleIndex];
                sale.Title = title;
                sale.OpenBuffet = openBuffet;
                sale.CafeCorner = cafeCorner;
                sale.GuidedTours = guidedTour;
                sale.AdditionalSpace = additionalSpace;
                sale.Photographer = photographer;
                sale.TotalPrice = extra;
            }
            else
            {
                // إضافة عملية بيع جديدة
                SharedData.Sales.Add(new Sale
                {
                    Title = title,
                    OpenBuffet = openBuffet,
                    CafeCorner = cafeCorner,
                    GuidedTours = guidedTour,
                    AdditionalSpace = additionalSpace,
                    Photographer = photographer,
                    TotalPrice = extra
                });
            }

            MessageBox.Show("Sale saved successfully!");
            DisplaySales();
            btnClear.PerformClick();

        }

        private void DisplaySales()
        {
            dgvSales.DataSource = null;
            dgvSales.DataSource = SharedData.Sales;
        }

        private void dgvSales_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var selectedSale = SharedData.Sales[e.RowIndex];
                selectedSaleIndex = e.RowIndex;

                cmbTitle.Text = selectedSale.Title;
                chkOpenBuffet.Checked = selectedSale.OpenBuffet;
                chkCafeCorner.Checked = selectedSale.CafeCorner;
                chkGuidedTour.Checked = selectedSale.GuidedTours;
                chkAdditionalSpace.Checked = selectedSale.AdditionalSpace;
                chkPhotographer.Checked = selectedSale.Photographer;

                // إعادة تعيين لون كل الصفوف
                foreach (DataGridViewRow row in dgvSales.Rows)
                {
                    row.DefaultCellStyle.BackColor = Color.White;
                }

            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            cmbTitle.SelectedIndex = -1;
          
            chkOpenBuffet.Checked = false;
            chkCafeCorner.Checked = false;
            chkGuidedTour.Checked = false;
            chkAdditionalSpace.Checked = false;
            chkPhotographer.Checked = false;

            selectedSaleIndex = -1;

            dgvSales.ClearSelection();

            // إعادة لون كل الصفوف
            foreach (DataGridViewRow row in dgvSales.Rows)
            {
                row.DefaultCellStyle.BackColor = Color.White;
            }
       
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (selectedSaleIndex < 0 || selectedSaleIndex >= SharedData.Sales.Count)
            {
                MessageBox.Show("Please select a sale to delete!");
                return;
            }

            var confirm = MessageBox.Show("Are you sure you want to delete this sale?",
                                          "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (confirm == DialogResult.Yes)
            {
                SharedData.Sales.RemoveAt(selectedSaleIndex);
                DisplaySales(); // افترضي أنها دالة تعرض المبيعات في الداتاقريد
                btnClear.PerformClick();
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void chkAdditionalSpace_CheckedChanged(object sender, EventArgs e)
        {
                
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
