using ArtGalleryOrganizer.Classes;
using ArtGalleryOrganizer.Forms;
using ArtGalleryOrganizer.Reports;
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

    public partial class MainScreen : Form
    {
        private void MainScreen_Load(object sender, EventArgs e)
        {


           
        }

        public MainScreen()
        {
            InitializeComponent();
            this.Load += MainScreen_Load;
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
            BookingManagement exhibitionsManagement = new BookingManagement();
            exhibitionsManagement.ShowDialog();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {

        }

        private void MainScreen_Activated(object sender, EventArgs e)
        {
            labelDate.Text = DateTime.Now.ToString("dddd, dd MMMM yyyy - hh:mm tt");

            // عدد الفنانين
            string artistCountQuery = "SELECT COUNT(*) FROM Artists";
            lblArtistCount.Text = DBHelper.GetData(artistCountQuery).Rows[0][0].ToString();

            // عدد الحجوزات
            string bookingCountQuery = "SELECT COUNT(*) FROM Bookings";
            lblBookingCount.Text = DBHelper.GetData(bookingCountQuery).Rows[0][0].ToString();

            // الاستعلام الرئيسي لعرض البيانات المطلوبة فقط
            string query = @"
        SELECT 
            A.ArtistName AS [Artist Name],
            H.HallName AS [Hall Name],
            B.Date AS [Booking Date],
            B.TotalHours AS [Total Hours]
        FROM Bookings B
        INNER JOIN Artists A ON B.ArtistID = A.ArtistID
        INNER JOIN Halls H ON B.HallID = H.HallID
        WHERE B.Date >= @Today";

            DataTable dt = DBHelper.GetData(query, new SqlParameter("@Today", DateTime.Today));
            dataGridView3.DataSource = dt;
        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            HallManagement hallManagement = new HallManagement();
            hallManagement.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void btnPrint_Click(object sender, EventArgs e)
        {
            DateTime fromDate = dtpFromDate.Value.Date;
            DateTime toDate = dtpToDate.Value.Date;

            if (toDate < fromDate)
            {
                MessageBox.Show("End date must be same or after start date.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // تحقق هل فيه حجوزات بين هالتواريخ
            string query = "SELECT * FROM Bookings WHERE Date BETWEEN @FromDate AND @ToDate";
            DataTable dt = DBHelper.GetData(query,
                new SqlParameter("@FromDate", fromDate),
                new SqlParameter("@ToDate", toDate)
            );

            if (dt.Rows.Count == 0)
            {
                MessageBox.Show("No bookings found for the selected period.", "No Data", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var f = new FrmReport();
            var rpt = new FromToBookings();
            rpt.SetParameterValue("FromDate", fromDate);
            rpt.SetParameterValue("ToDate", toDate);

            f.crystalReportViewer1.ReportSource = rpt;
            f.crystalReportViewer1.ShowRefreshButton = false;
            f.Text = "Bookings From - To";
            f.WindowState = FormWindowState.Maximized;
            f.Show();

        }

    }
       
}
