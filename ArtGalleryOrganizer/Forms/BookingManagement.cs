using ArtGalleryOrganizer.Classes;
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
    public partial class BookingManagement : Form
    {
        public BookingManagement()
        {
            InitializeComponent();
        }

        ResizeControls r = new ResizeControls();
        private int selectedBookingIndex = -1;




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

            cmbArtistName.DataSource = SharedData.Artists;
            cmbArtistName.DisplayMember = "Name";
            cmbSessions.DataSource = SharedData.Sessions;
            cmbSessions.DisplayMember = "Name";

            cmbSessions.SelectedIndex = -1;
            cmbArtistName.SelectedIndex = -1;
            
            dgvBookings.ClearSelection();

            dgvBookings.MultiSelect = false;
            txtTotalPrice.Text = "";

        }

        private void cmbSessions_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session selectedSession = cmbSessions.SelectedItem as Session;
            if (selectedSession != null)
            {
                txtPrice.Text = selectedSession.sessionPrice.ToString();
                txtTotalPrice.Text = selectedSession.sessionPrice.ToString();
            }
            else
            {
                txtPrice.Text = "";
            }

            if (cmbSessions.Text == "") { txtPrice.Text = ""; }

        }

        private void btnSaveSession_Click(object sender, EventArgs e)
        {

            string sessionName = cmbSessions.Text.Trim();
            string priceText = txtPrice.Text.Trim();

            if (string.IsNullOrEmpty(sessionName))
            {
                MessageBox.Show("Please enter session name!");
                return;
            }

            if (!double.TryParse(priceText, out double price))
            {
                MessageBox.Show("Please enter a proper price!");
                return;
            }

            Session existingSession = null;
            foreach (var s in SharedData.Sessions)
            {
                if (s.Name.Equals(sessionName, StringComparison.OrdinalIgnoreCase))
                {
                    existingSession = s;
                    break;
                }
            }


            if (existingSession != null)
            {
                existingSession.sessionPrice = price;
                MessageBox.Show("Session updated successfully!");
            }
            else
            {
                SharedData.Sessions.Add(new Session(sessionName, price));
                MessageBox.Show("Session Added successfully!");

            }

            RefreshComboBox();

        }

        private void RefreshComboBox()
        {
            cmbSessions.DataSource = null;
            cmbSessions.DataSource = SharedData.Sessions;
            cmbSessions.DisplayMember = "Name";
            cmbSessions.SelectedIndex = -1;
        }

        private void btnDeleteSession_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(cmbSessions.Text))
            {
                MessageBox.Show("Please select a session to remove!");
                return;
            }

            string sessionName = cmbSessions.Text;
            Session sessionToRemove = null;

            foreach (var s in SharedData.Sessions)
            {
                if (s.Name.Equals(sessionName, StringComparison.OrdinalIgnoreCase))
                {
                    sessionToRemove = s;
                    break;
                }
            }


            if (sessionToRemove != null)
            {
                SharedData.Sessions.Remove(sessionToRemove);
                RefreshComboBox();
                MessageBox.Show($"Session \"{sessionName}\" deleted!");
            }
            else
            {
                MessageBox.Show("Session not exists");
            }
        }

        //////////////////////////////////////////////////////////////////////////////

        private void DisplayBookings()
        {

            dgvBookings.DataSource = null;
            dgvBookings.DataSource = SharedData.Bookings;

            dgvBookings.Columns["Date"].DefaultCellStyle.Format = "dd/MM/yyyy";
            dgvBookings.Columns["StartTime"].DefaultCellStyle.Format = "hh:mm tt";
            dgvBookings.Columns["TotalPrice"].DefaultCellStyle.Format = "N0";
     
        }

        private void btnSaveBooking_Click(object sender, EventArgs e)
        {
            if (!ValidateInputs())
                return;

            string artistName = cmbArtistName.Text.Trim();
            string sessionName = cmbSessions.Text.Trim();
            string title = txtTitle.Text.Trim();
            double plusHours = Convert.ToDouble(txtPlusHours.Text);
            double totalHours = Convert.ToDouble(txtTotalHours.Text);
            DateTime startTime = dtpTime.Value;
            DateTime bookingDate = dtpBookingDate.Value;
            int artworksCount = Convert.ToInt32(txtArtworksCount.Text);


            // البحث عن سعر القسم من قائمة الاقسام
            var session = SharedData.Sessions.FirstOrDefault(s => s.Name == sessionName);
            if (session == null)
            {
                MessageBox.Show("Session not exist!");
                return;
            }

            double totalPrice = new Booking().CalculateTotalPrice(session.sessionPrice, plusHours);


            if (selectedBookingIndex >= 0 && selectedBookingIndex < SharedData.Bookings.Count)
            {
                // تعديل
                var booking = SharedData.Bookings[selectedBookingIndex];
                booking.ArtistName = artistName;
                booking.Session = sessionName;
                booking.Date = bookingDate;
                booking.TotalHours = totalHours;
                booking.PlusHours = plusHours;
                booking.ArtworksCount = artworksCount;
                booking.Title = title;
                booking.StartTime = startTime;
                booking.TotalPrice = totalPrice;
            }
            else
            {
                // إضافة
                SharedData.Bookings.Add(new Booking
                {
                    ArtistName = artistName,
                    Session = sessionName,
                    Date = bookingDate,
                    TotalHours = totalHours,
                    PlusHours = plusHours,
                    ArtworksCount = artworksCount,
                    Title = title,
                    StartTime = startTime,
                    TotalPrice = totalPrice
                });
            }

            DisplayBookings();
            MessageBox.Show("Booking saved successfully! Total bookings: " + SharedData.Bookings.Count);
            btnClear.PerformClick();

        }


        private void btnClear_Click(object sender, EventArgs e)
        {
            cmbArtistName.SelectedIndex = -1;
            cmbSessions.SelectedIndex = -1;
            cmbArtistName.Text = "";
            txtTotalHours.Clear();
            txtPlusHours.Text = "0";
            txtTotalPrice.Clear();
            txtArtworksCount.Clear();
            txtTitle.Clear();
            dtpBookingDate.Value = DateTime.Today;
            dtpTime.Value = DateTime.Now;
            dgvBookings.ClearSelection();
            selectedBookingIndex = -1;


        }




        private bool ValidateInputs()
        {

            if (string.IsNullOrWhiteSpace(cmbArtistName.Text) ||
                string.IsNullOrWhiteSpace(cmbSessions.Text) ||
                string.IsNullOrWhiteSpace(txtTotalHours.Text) ||
                string.IsNullOrWhiteSpace(txtPlusHours.Text) ||
                string.IsNullOrWhiteSpace(txtArtworksCount.Text) ||
                string.IsNullOrWhiteSpace(txtTitle.Text))
            {
                MessageBox.Show("Please enter all fields!!");
                return false;
            }


            if (!DateTime.TryParse(dtpBookingDate.Value.ToString(), out DateTime date))
            {
                MessageBox.Show("Please select a valid date.");
                dtpBookingDate.Focus();
                return false;
            }

            if (!DateTime.TryParse(dtpTime.Text, out DateTime startTime))
            {
                MessageBox.Show("Please enter a valid start time");
                dtpTime.Focus();
                return false;
            }

            if (!double.TryParse(txtTotalHours.Text, out double totalHours) || totalHours <= 0)
            {
                MessageBox.Show("Please enter a valid total hours greater than zero.");
                txtTotalHours.Focus();
                return false;
            }

            if (!double.TryParse(txtPlusHours.Text, out double plusHours) || plusHours < 0)
            {
                MessageBox.Show("Please enter a valid additional hours (zero or more).");
                txtPlusHours.Focus();
                return false;
            }

            if (!int.TryParse(txtArtworksCount.Text, out int artworksCount) || artworksCount < 0)
            {
                MessageBox.Show("Please enter a valid non-negative number of artworks.");
                txtArtworksCount.Focus();
                return false;
            }

            return true; // All validations passed
        }

        private void btnDeleteBooking_Click(object sender, EventArgs e)
        {
            if (!(selectedBookingIndex >= 0 && selectedBookingIndex < SharedData.Bookings.Count))
            {
                MessageBox.Show("Please select a booking to delete.");
                return;
            }

            var removed = SharedData.Bookings[selectedBookingIndex];

            var confirmResult = MessageBox.Show(
                $"Are you sure you want to delete the booking for \"{removed.ArtistName}\"?",
                "Confirm Delete",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirmResult == DialogResult.Yes)
            {
                SharedData.Bookings.RemoveAt(selectedBookingIndex);
                DisplayBookings();
                btnClear_Click(sender, e); // نمسح الحقول بعد الحذف
            }
        }

        private void dgvBookings_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var selectedBooking = SharedData.Bookings[e.RowIndex];
                selectedBookingIndex = e.RowIndex;

                cmbArtistName.Text = selectedBooking.ArtistName;
                cmbSessions.Text = selectedBooking.Session;
                txtTotalHours.Text = selectedBooking.TotalHours.ToString();
                txtPlusHours.Text = selectedBooking.PlusHours.ToString();
                txtArtworksCount.Text = selectedBooking.ArtworksCount.ToString();
                txtTitle.Text = selectedBooking.Title;
                dtpBookingDate.Value = selectedBooking.Date;
                dtpTime.Value = selectedBooking.StartTime;
                txtTotalPrice.Text = selectedBooking.TotalPrice.ToString();

                // إعادة تعيين لون كل الصفوف
                foreach (DataGridViewRow row in dgvBookings.Rows)
                {
                    row.DefaultCellStyle.BackColor = Color.White;
                }

              
            }
        }
    }
}
