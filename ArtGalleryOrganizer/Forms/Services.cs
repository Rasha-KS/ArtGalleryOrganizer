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
using ArtGalleryOrganizer.Classes;

namespace ArtGalleryOrganizer.Forms
{
    public partial class Services : Form
    {
        public Services()
        {
            InitializeComponent();
        }

        private int? currentInvoiceID = null;


        private void Services_Load(object sender, EventArgs e)
        {
            LoadServiceInvoices();
            dgvServiceInvoices.ClearSelection();
            LoadBookingIDs();
            ClearForm();
        }


        private void LoadBookingIDs()
        {
            string query = "SELECT BookingID FROM Bookings";
            DataTable dt = DBHelper.GetData(query);
            cmbBookingID.DataSource = dt;
            cmbBookingID.DisplayMember = "BookingID";
            cmbBookingID.ValueMember = "BookingID";
            cmbBookingID.SelectedIndex = -1;
        }

        private void LoadServiceInvoices()
        {
            string query = @"
            SELECT *  FROM ServiceInvoices";

            DataTable dt = DBHelper.GetData(query);
            dgvServiceInvoices.DataSource = dt;

            // تنسيق الأعمدة حسب الحاجة
            dgvServiceInvoices.Columns["InvoiceID"].HeaderText = "Invoice ID";
            dgvServiceInvoices.Columns["BookingID"].HeaderText = "Booking ID";
            dgvServiceInvoices.Columns["OpenBuffet"].HeaderText = "Open Buffet";
            dgvServiceInvoices.Columns["CafeCorner"].HeaderText = "Cafe Corner";
            dgvServiceInvoices.Columns["GuidedTours"].HeaderText = "Guided Tours";
            dgvServiceInvoices.Columns["AdditionalSpace"].HeaderText = "Additional Space";
            dgvServiceInvoices.Columns["Photographer"].HeaderText = "Photographer";
            dgvServiceInvoices.Columns["ServiceTotalPrice"].HeaderText = "Service Total Price";
            dgvServiceInvoices.Columns["ServiceTotalPrice"].DefaultCellStyle.Format = "F2";
        }

        private void ClearForm()
        {
            cmbBookingID.SelectedIndex = -1;
            chkOpenBuffet.Checked = false;
            chkCafeCorner.Checked = false;
            chkGuidedTour.Checked = false;
            chkAdditionalSpace.Checked = false;
            chkPhotographer.Checked = false;
            txtServiceTotalPrice.Text = "";
            txtTotalPrice.Text = "";
            currentInvoiceID = null;
            dgvServiceInvoices.ClearSelection();    
            foreach (DataGridViewRow row in dgvServiceInvoices.Rows)
            {
                row.DefaultCellStyle.BackColor = Color.White;
            }
        }



        private void btnSave_Click(object sender, EventArgs e)
        {
            if (cmbBookingID.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a BookingID.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!int.TryParse(cmbBookingID.SelectedValue?.ToString(), out int bookingID))
            {
                MessageBox.Show("Please select a valid booking ID.");
                return;
            }

            if (!decimal.TryParse(txtServiceTotalPrice.Text, out decimal serviceTotalPrice))
            {
                MessageBox.Show("Please enter a valid service total price.");
                return;
            }

            bool hasAtLeastOneService = chkOpenBuffet.Checked ||
                            chkCafeCorner.Checked ||
                            chkGuidedTour.Checked ||
                            chkAdditionalSpace.Checked ||
                            chkPhotographer.Checked;

            if (!hasAtLeastOneService)
            {
                MessageBox.Show("Please select at least one service before saving the invoice.",
                                "Validation Error",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                return;
            }

            // ✅ تحقق إذا كان الحجز له خدمة مسبقاً
            string checkQuery = "SELECT InvoiceID FROM ServiceInvoices WHERE BookingID = @BookingID";
            DataTable dt = DBHelper.GetData(checkQuery, new System.Data.SqlClient.SqlParameter("@BookingID", bookingID));

            if (currentInvoiceID == null && dt.Rows.Count > 0)
            {
                // فيه خدمة مسبقاً، حدد الصف وبلغ المستخدم
                int existingInvoiceID = Convert.ToInt32(dt.Rows[0]["InvoiceID"]);

                // حدد الصف في DataGridView
                foreach (DataGridViewRow row in dgvServiceInvoices.Rows)
                {
                    if (Convert.ToInt32(row.Cells["InvoiceID"].Value) == existingInvoiceID)
                    {
                        row.Selected = true;
                        dgvServiceInvoices.FirstDisplayedScrollingRowIndex = row.Index; // يطلع الصف قدام المستخدم
                        break;
                    }
                }

                MessageBox.Show("This booking already has a service invoice. Please update the existing invoice instead.",
                                "Duplicate Invoice",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                return;
            }

            if (currentInvoiceID == null)
            {
                string insertQuery = @"
            INSERT INTO ServiceInvoices 
            (BookingID, OpenBuffet, CafeCorner, GuidedTours, AdditionalSpace, Photographer, ServiceTotalPrice)
            VALUES (@BookingID, @OpenBuffet, @CafeCorner, @GuidedTours, @AdditionalSpace, @Photographer, @ServiceTotalPrice);";

                int rows = DBHelper.Execute(insertQuery,
                    new System.Data.SqlClient.SqlParameter("@BookingID", bookingID),
                    new System.Data.SqlClient.SqlParameter("@OpenBuffet", chkOpenBuffet.Checked),
                    new System.Data.SqlClient.SqlParameter("@CafeCorner", chkCafeCorner.Checked),
                    new System.Data.SqlClient.SqlParameter("@GuidedTours", chkGuidedTour.Checked),
                    new System.Data.SqlClient.SqlParameter("@AdditionalSpace", chkAdditionalSpace.Checked),
                    new System.Data.SqlClient.SqlParameter("@Photographer", chkPhotographer.Checked),
                    new System.Data.SqlClient.SqlParameter("@ServiceTotalPrice", serviceTotalPrice)
                );

                if (rows > 0)
                {
                    MessageBox.Show("Service invoice added successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearForm();
                    LoadBookingIDs();
                    LoadServiceInvoices();
                }
            }
            else
            {
                string updateQuery = @"
            UPDATE ServiceInvoices SET
            BookingID = @BookingID,
            OpenBuffet = @OpenBuffet,
            CafeCorner = @CafeCorner,
            GuidedTours = @GuidedTours,
            AdditionalSpace = @AdditionalSpace,
            Photographer = @Photographer,
            ServiceTotalPrice = @ServiceTotalPrice
            WHERE InvoiceID = @InvoiceID";

                int rows = DBHelper.Execute(updateQuery,
                    new System.Data.SqlClient.SqlParameter("@BookingID", bookingID),
                    new System.Data.SqlClient.SqlParameter("@OpenBuffet", chkOpenBuffet.Checked),
                    new System.Data.SqlClient.SqlParameter("@CafeCorner", chkCafeCorner.Checked),
                    new System.Data.SqlClient.SqlParameter("@GuidedTours", chkGuidedTour.Checked),
                    new System.Data.SqlClient.SqlParameter("@AdditionalSpace", chkAdditionalSpace.Checked),
                    new System.Data.SqlClient.SqlParameter("@Photographer", chkPhotographer.Checked),
                    new System.Data.SqlClient.SqlParameter("@ServiceTotalPrice", serviceTotalPrice),
                    new System.Data.SqlClient.SqlParameter("@InvoiceID", currentInvoiceID.Value)
                );

                if (rows > 0)
                {
                    MessageBox.Show("Service invoice updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearForm();
                    LoadBookingIDs();
                    LoadServiceInvoices();
                    dgvServiceInvoices.ClearSelection();
                    foreach (DataGridViewRow row in dgvServiceInvoices.Rows)
                    {
                        row.DefaultCellStyle.BackColor = Color.White;
                    }
                }
            }

        }

        private decimal CalculateServiceTotalPrice()
        {
            decimal total = 0;
            if (chkOpenBuffet.Checked) total += 300;
            if (chkCafeCorner.Checked) total += 150;
            if (chkGuidedTour.Checked) total += 200;
            if (chkAdditionalSpace.Checked) total += 500;
            if (chkPhotographer.Checked) total += 150;
            return total;
        }

        private decimal GetBookingPrice(int bookingID)
        {
            string query = "SELECT Price FROM Bookings WHERE BookingID = @BookingID";
            var dt = DBHelper.GetData(query, new System.Data.SqlClient.SqlParameter("@BookingID", bookingID));
            if (dt.Rows.Count > 0)
            {
                return Convert.ToDecimal(dt.Rows[0]["Price"]);
            }
            return 0;
        }

        private void dgvSales_CellClick(object sender, DataGridViewCellEventArgs e)
        {


            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvServiceInvoices.Rows[e.RowIndex];

                // قراءة البيانات من الصف المختار
                currentInvoiceID = Convert.ToInt32(row.Cells["InvoiceID"].Value);
                cmbBookingID.SelectedValue = Convert.ToInt32(row.Cells["BookingID"].Value);
                chkOpenBuffet.Checked = Convert.ToBoolean(row.Cells["OpenBuffet"].Value);
                chkCafeCorner.Checked = Convert.ToBoolean(row.Cells["CafeCorner"].Value);
                chkGuidedTour.Checked = Convert.ToBoolean(row.Cells["GuidedTours"].Value);
                chkAdditionalSpace.Checked = Convert.ToBoolean(row.Cells["AdditionalSpace"].Value);
                chkPhotographer.Checked = Convert.ToBoolean(row.Cells["Photographer"].Value);
                txtServiceTotalPrice.Text = Convert.ToDecimal(row.Cells["ServiceTotalPrice"].Value).ToString("F2");

                // يمكن تحديث السعر الكلي إذا عندك طريقة لجلب سعر الحجز
                int bookingID = Convert.ToInt32(row.Cells["BookingID"].Value);
                decimal bookingPrice = GetBookingPrice(bookingID);
                decimal servicePrice = Convert.ToDecimal(row.Cells["ServiceTotalPrice"].Value);
                txtTotalPrice.Text = (bookingPrice + servicePrice).ToString("F2");
            }

            // إعادة تعيين لون كل الصفوف
            foreach (DataGridViewRow row in dgvServiceInvoices.Rows)
                {
                    row.DefaultCellStyle.BackColor = Color.White;
                }

            }

        private void chkOpenBuffet_CheckedChanged(object sender, EventArgs e)
        {
            UpdateTotalPrice();

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (currentInvoiceID == null)
            {
                MessageBox.Show("No service invoice selected to delete.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult dr = MessageBox.Show("Are you sure you want to delete this service invoice?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                string deleteQuery = "DELETE FROM ServiceInvoices WHERE InvoiceID = @InvoiceID";
                int rows = DBHelper.Execute(deleteQuery,
                    new System.Data.SqlClient.SqlParameter("@InvoiceID", currentInvoiceID.Value));

                if (rows > 0)
                {
                    MessageBox.Show("Service invoice deleted successfully.", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearForm();
                    LoadBookingIDs();
                    LoadServiceInvoices();
                }
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearForm();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmbBookingID_SelectionChangeCommitted(object sender, EventArgs e)
        {
            UpdateTotalPrice();

        }


        private void UpdateTotalPrice()
        {
            if (cmbBookingID.SelectedIndex == -1)
            {
                // ما في حجز مختار، نقدر نصفر الحقول أو نتركها فارغة
                txtServiceTotalPrice.Text = "0.00";
                txtTotalPrice.Text = "0.00";
                return;
            }

            int bookingID = Convert.ToInt32(cmbBookingID.SelectedValue);
            decimal bookingPrice = GetBookingPrice(bookingID);
            decimal serviceTotalPrice = CalculateServiceTotalPrice();
            decimal totalPrice = bookingPrice + serviceTotalPrice;

            txtServiceTotalPrice.Text = serviceTotalPrice.ToString("F2");
            txtTotalPrice.Text = totalPrice.ToString("F2");
        }











    }

}

