using ArtGalleryOrganizer.Classes;
using StudentProject1.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ArtGalleryOrganizer
{
    public partial class BookingManagement : Form
    {
        public BookingManagement()
        {
            InitializeComponent();
        }

        ResizeControls r = new ResizeControls();
        private int selectedBookingIndex = -1;
        // متغير لحفظ السعر الأساسي للقاعة المختارة
        private decimal baseHallPrice = 0m;



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
            DisplayBookings();


            //cmbHall.SelectedIndexChanged += (s, ev) => ValidateAndShowError();
            //dtpBookingDate.ValueChanged += (s, args) => ValidateAndShowError();
            //dtpTime.ValueChanged += (s, eventArgs) => ValidateAndShowError();
            lblError.Visible = false; // نخفي اللابل بالبداية

            string query = "SELECT ArtistID, ArtistName FROM Artists";
            DataTable dt = DBHelper.GetData(query);

            cmbArtistName.DataSource = dt;
            cmbArtistName.DisplayMember = "ArtistName";
            cmbArtistName.ValueMember = "ArtistID";

            string query2 = "SELECT HallID, HallName FROM Halls";
            DataTable dt2 = DBHelper.GetData(query2);

            cmbHall.DataSource = dt2;
            cmbHall.DisplayMember = "HallName";
            cmbHall.ValueMember = "HallID";

            cmbHall.SelectedIndex = -1;
            cmbArtistName.SelectedIndex = -1;
            
            dgvBookings.ClearSelection();
            dgvBookings.MultiSelect = false;
            txtTotalPrice.Text = "";

        }


        private void ValidateAndShowError()
        {
            string errorMsg = ValidateBookingDateTimeAndHall();

            if (!string.IsNullOrEmpty(errorMsg))
            {
                lblError.Text = errorMsg;
                lblError.ForeColor = Color.Red;
                lblError.Visible = true;
            }
            else
            {
                lblError.Visible = false;
            }
        }

       



        private void DisplayBookings()
        {
            string query = @"
        SELECT 
            b.BookingID,
            a.ArtistID,
            a.ArtistName,
            h.HallID,
            h.HallName,
            b.Date,
            b.StartTime,
            b.ArtworkCount,
            b.TotalHours,
            ISNULL(b.PlusHours, 0) AS PlusHours,
            b.Price AS TotalPrice
        FROM 
            Bookings b
            INNER JOIN Artists a ON b.ArtistID = a.ArtistID
            INNER JOIN Halls h ON b.HallID = h.HallID";

            DataTable dt = DBHelper.GetData(query);

            dgvBookings.DataSource = dt;

            // إخفاء الأعمدة التي تحمل الـ IDs
            dgvBookings.Columns["ArtistID"].Visible = false;
            dgvBookings.Columns["HallID"].Visible = false;


            dgvBookings.Columns["Date"].DefaultCellStyle.Format = "dd/MM/yyyy";
            dgvBookings.Columns["StartTime"].DefaultCellStyle.Format = @"hh\:mm";
            dgvBookings.Columns["TotalPrice"].DefaultCellStyle.Format = "N0";
        }



        private void btnSaveBooking_Click(object sender, EventArgs e)
        {
            if (!ValidateInputs())
                return;

            SaveBooking();

        }

        private void SaveBooking()
        {
            // بيانات الإدخال
            int artistID = Convert.ToInt32(cmbArtistName.SelectedValue);
            int hallID = Convert.ToInt32(cmbHall.SelectedValue);
            TimeSpan startTime = dtpTime.Value.TimeOfDay;
            DateTime date = dtpBookingDate.Value.Date;
            int artworkCount = Convert.ToInt32(txtArtworksCount.Text);
            int totalHours = Convert.ToInt32(txtTotalHours.Text);
            int plusHours = string.IsNullOrWhiteSpace(txtPlusHours.Text) ? 0 : Convert.ToInt32(txtPlusHours.Text);
            decimal price = Convert.ToDecimal(txtTotalPrice.Text);

            if (selectedBookingIndex == -1)
            {
                // إضافة جديدة
                string insertQuery = @"
                    INSERT INTO Bookings 
                    (ArtistID, HallID, StartTime, Date, ArtworkCount, TotalHours, PlusHours, Price)
                    VALUES 
                    (@ArtistID, @HallID, @StartTime, @Date, @ArtworkCount, @TotalHours, @PlusHours, @Price)";

                int rows = DBHelper.Execute(insertQuery,
                    new SqlParameter("@ArtistID", artistID),
                    new SqlParameter("@HallID", hallID),
                    new SqlParameter("@StartTime", startTime),
                    new SqlParameter("@Date", date),
                    new SqlParameter("@ArtworkCount", artworkCount),
                    new SqlParameter("@TotalHours", totalHours),
                    new SqlParameter("@PlusHours", plusHours == 0 ? (object)DBNull.Value : plusHours),
                    new SqlParameter("@Price", price)
                );

                if (rows > 0)
                {
                    MessageBox.Show("Booking Added Successfully ✅");
                    DisplayBookings();
                    btnClear.PerformClick();
                }
            }
            else
            {
                // تعديل موجود
                int bookingIDToUpdate = Convert.ToInt32(dgvBookings.SelectedRows[0].Cells["BookingID"].Value);

                string updateQuery = @"
                UPDATE Bookings 
                SET ArtistID = @ArtistID, HallID = @HallID, StartTime = @StartTime, Date = @Date,
                    ArtworkCount = @ArtworkCount, TotalHours = @TotalHours, PlusHours = @PlusHours, Price = @Price
                WHERE BookingID = @BookingID";

                int rows = DBHelper.Execute(updateQuery,
                    new SqlParameter("@BookingID", bookingIDToUpdate),
                    new SqlParameter("@ArtistID", artistID),
                    new SqlParameter("@HallID", hallID),
                    new SqlParameter("@StartTime", startTime),
                    new SqlParameter("@Date", date),
                    new SqlParameter("@ArtworkCount", artworkCount),
                    new SqlParameter("@TotalHours", totalHours),
                    new SqlParameter("@PlusHours", plusHours == 0 ? (object)DBNull.Value : plusHours),
                    new SqlParameter("@Price", price)
                );

                if (rows > 0)
                {
                    MessageBox.Show("Booking Updated Successfully ✅");
                    DisplayBookings();
                    btnClear.PerformClick();
                }
            }
        }


        private void btnClear_Click(object sender, EventArgs e)
        {
            cmbArtistName.SelectedIndex = -1;
            cmbHall.SelectedIndex = -1;
            dtpBookingDate.Value = DateTime.Today;
            dtpTime.Value = DateTime.Now;
            txtArtworksCount.Text = "";
            txtTotalHours.Text = "";
            txtPlusHours.Text = "";
            txtTotalPrice.Text = "";
            selectedBookingIndex = -1;
            dgvBookings.ClearSelection();
            selectedBookingIndex = -1;


        }


        private string ValidateBookingDateTimeAndHall()
        {

            // تحقق من اختيار القاعة
            if (cmbHall.SelectedValue == null)
                return "Please select a hall.";

            // تحقق من صحة التاريخ
            if (dtpBookingDate.Value.Date < DateTime.Today)
                return "Booking date must be today or later.";

            TimeSpan startTime = dtpTime.Value.TimeOfDay;
            // تحقق حالة القاعة
            string hallStatusQuery = "SELECT Status FROM Halls WHERE HallID = @HallID";
            DataTable dtStatus = DBHelper.GetData(hallStatusQuery, new SqlParameter("@HallID", cmbHall.SelectedValue));
            if (dtStatus.Rows.Count == 0)
                return "Selected hall does not exist.";

            string status = dtStatus.Rows[0]["Status"].ToString();
            if (status.Equals("Maintenance", StringComparison.OrdinalIgnoreCase))
                return "The selected hall is under maintenance and not available for booking.";

            // تحقق عدد الساعات الكلي
            if (!double.TryParse(txtTotalHours.Text, out double totalHours) || totalHours <= 0)
                return "Please enter a valid total hours greater than zero.";

            DateTime bookingDate = dtpBookingDate.Value.Date;
            TimeSpan endTime = startTime.Add(TimeSpan.FromHours(totalHours));

            // احصل على BookingID الحالي من DataGridView عند تعديل، أو 0 عند إضافة جديد
            int currentBookingID = 0;
            if (selectedBookingIndex != -1)
            {
                currentBookingID = Convert.ToInt32(dgvBookings.Rows[selectedBookingIndex].Cells["BookingID"].Value);
            }

            string overlapQuery = @"
                SELECT COUNT(*) FROM Bookings
                WHERE HallID = @HallID
                  AND Date = @Date
                  AND (
                       (@StartTime BETWEEN StartTime AND DATEADD(hour, TotalHours, StartTime))
                    OR (@EndTime BETWEEN StartTime AND DATEADD(hour, TotalHours, StartTime))
                    OR (StartTime BETWEEN @StartTime AND @EndTime)
                  )";

            List<SqlParameter> parameters = new List<SqlParameter>()
                {
                    new SqlParameter("@HallID", cmbHall.SelectedValue),
                    new SqlParameter("@Date", bookingDate),
                    new SqlParameter("@StartTime", startTime),
                    new SqlParameter("@EndTime", endTime)
                };

            if (currentBookingID != 0)
            {
                overlapQuery += " AND BookingID <> @BookingID";
                parameters.Add(new SqlParameter("@BookingID", currentBookingID));
            }

            DataTable dtOverlap = DBHelper.GetData(overlapQuery, parameters.ToArray());
            int count = dtOverlap.Rows.Count > 0 ? Convert.ToInt32(dtOverlap.Rows[0][0]) : 0;

            if (count > 0)
                return "The selected hall is already booked for the chosen date and time.";

            return ""; // لا يوجد خطأ
        }


        private bool ValidateInputs()
        {
            // تحقق من تعبئة جميع الحقول الأساسية (بخلاف التحقق من القاعة والفنان والتاريخ والوقت الذي في الدالة السابقة)
            if (string.IsNullOrWhiteSpace(txtTotalHours.Text) ||
                string.IsNullOrWhiteSpace(txtArtworksCount.Text) ||
                string.IsNullOrWhiteSpace(txtTotalPrice.Text))
            {
                MessageBox.Show("Please fill in all required fields.");
                return false;
            }

            // تحقق من اختيار الفنان
            if (cmbArtistName.SelectedValue == null)
            {
                MessageBox.Show("Please select an artist.");
                return false;
            }
                ;
            // استدعاء دالة التحقق الشاملة
            string errorMsg = ValidateBookingDateTimeAndHall();
            if (!string.IsNullOrEmpty(errorMsg))
            {
                MessageBox.Show(errorMsg);
                return false;
            }


            if (!double.TryParse(txtPlusHours.Text, out double plusHours) || plusHours < 0)
            {
                MessageBox.Show("Please enter valid additional hours (zero or more).");
                txtPlusHours.Focus();
                return false;
            }

            if (!int.TryParse(txtArtworksCount.Text, out int artworksCount) || artworksCount < 0)
            {
                MessageBox.Show("Please enter a valid non-negative number of artworks.");
                txtArtworksCount.Focus();
                return false;
            }

            if (!decimal.TryParse(txtTotalPrice.Text, out decimal price) || price < 0)
            {
                MessageBox.Show("Please enter a valid non-negative price.");
                txtTotalPrice.Focus();
                return false;
            }

            return true;
        }


        private void btnDeleteBooking_Click(object sender, EventArgs e)
        {

            if (selectedBookingIndex < 0 || selectedBookingIndex >= dgvBookings.Rows.Count)
            {
                MessageBox.Show("Please select a booking to delete.");
                return;
            }

            int bookingIDToDelete = Convert.ToInt32(dgvBookings.Rows[selectedBookingIndex].Cells["BookingID"].Value);

            if (MessageBox.Show("Are you sure you want to delete the selected booking?",
                                "Confirm Delete",
                                MessageBoxButtons.YesNo,
                                MessageBoxIcon.Question) == DialogResult.Yes)
            {
                string deleteQuery = "DELETE FROM Bookings WHERE BookingID = @BookingID";

                int rowsAffected = DBHelper.Execute(deleteQuery, new SqlParameter("@BookingID", bookingIDToDelete));

                if (rowsAffected > 0)
                {
                    MessageBox.Show("Booking deleted successfully.");
                    DisplayBookings();
                    btnClear.PerformClick();
                    selectedBookingIndex = -1; // إعادة تعيين المؤشر
                }
                else
                {
                    MessageBox.Show("Failed to delete the booking.");
                }
            }
        }

        private void dgvBookings_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                selectedBookingIndex = e.RowIndex;

                DataGridViewRow row = dgvBookings.Rows[e.RowIndex];
                cmbArtistName.SelectedValue = Convert.ToInt32(row.Cells["ArtistID"].Value);
                cmbHall.SelectedValue = Convert.ToInt32(row.Cells["HallID"].Value);
                dtpBookingDate.Value = Convert.ToDateTime(row.Cells["Date"].Value);
                dtpTime.Value = DateTime.Today + (TimeSpan)row.Cells["StartTime"].Value;
                txtArtworksCount.Text = row.Cells["ArtworkCount"].Value.ToString();
                txtTotalHours.Text = row.Cells["TotalHours"].Value.ToString();
                txtPlusHours.Text = row.Cells["PlusHours"].Value.ToString();
                txtTotalPrice.Text = row.Cells["TotalPrice"].Value.ToString();

                // إعادة تعيين لون كل الصفوف إلى الأبيض
                foreach (DataGridViewRow row2 in dgvBookings.Rows)
                {
                    row2.DefaultCellStyle.BackColor = Color.White;
                }

                cmbHall_SelectionChangeCommitted(cmbHall, EventArgs.Empty);
            }
        }

  

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtPlusHours_KeyPress(object sender, KeyPressEventArgs e)
        {
            // السماح فقط بالأرقام والباك سبيس
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtPlusHours_TextChanged(object sender, EventArgs e)
        {
            // فقط إذا السعر الأساسي موجود (القاعة مختارة)
            if (baseHallPrice > 0)
            {
                UpdatePriceBasedOnPlusHours();
            }
        }

        // دالة تحديث السعر بناء على PlusHours وقاعدة ال 3%
        private void UpdatePriceBasedOnPlusHours()
        {
            if (!int.TryParse(txtPlusHours.Text, out int plusHours))
                plusHours = 0;

            if (plusHours <= 0)
            {
                // السعر الأساسي بدون زيادة
                txtTotalPrice.Text = baseHallPrice.ToString("F2");
            }
            else
            {
                // زيادة 3% لكل ساعة إضافية
                decimal additionalPerHour = 0.03m * baseHallPrice;
                decimal finalPrice = baseHallPrice + (plusHours * additionalPerHour);
                txtTotalPrice.Text = finalPrice.ToString("F2");
            }
        }

        private void cmbHall_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (cmbHall.SelectedValue == null) return;
            if (cmbHall.SelectedIndex == -1) return;
            int hallID = Convert.ToInt32(cmbHall.SelectedValue.ToString());

            string query = "SELECT Capacity, Status, Price FROM Halls WHERE HallID = @HallID";
            DataTable dt = DBHelper.GetData(query, new SqlParameter("@HallID", hallID));

            if (dt.Rows.Count == 0) return;

            DataRow row = dt.Rows[0];
            lblCapacity.Text = row["Capacity"].ToString();
            lblStatus.Text = row["Status"].ToString();

            baseHallPrice = Convert.ToDecimal(row["Price"]);

            // نتحقق إذا يوجد حجز محدد (مثلاً حسب وجود قيمة اي دي الحجز أو حسب اختيار مستخدم)
            bool hasBookingSelected = selectedBookingIndex != -1;

            if (!hasBookingSelected)
            {
                txtTotalPrice.Text = baseHallPrice.ToString("F2");
            }
            else
            {
                // لو يوجد حجز، نحسب السعر حسب PlusHours
                UpdatePriceBasedOnPlusHours();
            }
        }

        private void cmbHall_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
