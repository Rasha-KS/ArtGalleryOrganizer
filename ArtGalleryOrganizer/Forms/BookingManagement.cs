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
        private List<Session> sessions;
        private List<Booking> bookings;



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
          


            cmbSessions.DataSource = SharedData.Sessions;
            cmbSessions.DisplayMember = "Name";

            if (cmbSessions.Items.Count > 0)
            {
                cmbSessions.SelectedIndex = -1; 
            }



        }

        private void cmbSessions_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session selectedSession = cmbSessions.SelectedItem as Session;
            if (selectedSession != null)
            {
                txtPrice.Text = selectedSession.sessionPrice.ToString();
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
            dgvBookings.DataSource = bookings;
        }

        private void btnSaveBooking_Click(object sender, EventArgs e)
        {
            if (!ValidateInputs())
                return;

            string artistName = cmbArtistName.Text.Trim();
            string sessionName = cmbSessions.Text.Trim();
            string title = txtTitle.Text.Trim();
            double plusHours = Convert.ToDouble(txtPlusHours.Text);
            double totalHours = Convert.ToDouble(txtPlusHours.Text);
            DateTime startTime = dtpTime.Value;
            DateTime bookingDate = dtpBookingDate.Value;
            int artworksCount = Convert.ToInt32(txtArtworksCount.Text);


            // البحث عن سعر القسم من قائمة الاقسام
            var session = sessions.FirstOrDefault(s => s.Name == sessionName);
            if (session == null)
            {
                MessageBox.Show("Session not exist!");
                return;
            }

            double totalPrice = new Booking().CalculateTotalPrice(session.sessionPrice, plusHours);


            // تحقق هل هناك صف محدد للتعديل
            if (dgvBookings.CurrentRow != null && dgvBookings.CurrentRow.Index >= 0)
            {
                // تحديث الحجز الموجود
                int index = dgvBookings.CurrentRow.Index;
                bookings[index].ArtistName = artistName;
                bookings[index].Session = sessionName;
                bookings[index].Date = bookingDate;
                bookings[index].TotalHours = totalHours;
                bookings[index].PlusHours = plusHours;
                bookings[index].ArtworksCount = artworksCount;
                bookings[index].Title = title;
                bookings[index].StartTime = startTime;
                bookings[index].TotalPrice = totalPrice;
            }
            else
            {
                // إضافة حجز جديد
                bookings.Add(new Booking
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
            MessageBox.Show("Booking saved successfully!");

        }


        private void btnClear_Click(object sender, EventArgs e)
        {
            cmbArtistName.SelectedIndex = -1;
            cmbSessions.SelectedIndex = -1;
            txtTotalHours.Clear();
            txtPlusHours.Clear();
            txtArtworksCount.Clear();
            txtTitle.Clear();
            dtpBookingDate.Value = DateTime.Today;
            dtpTime.Value = DateTime.Now;
            dgvBookings.ClearSelection();
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

    }
}
