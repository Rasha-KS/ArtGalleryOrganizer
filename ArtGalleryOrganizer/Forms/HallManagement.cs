using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using ArtGalleryOrganizer.Classes;

namespace ArtGalleryOrganizer.Forms
{
    public partial class HallManagement : Form
    {
        public HallManagement()
        {
            InitializeComponent();
            LoadHalls();
        }

        private void LoadHalls()
        {
            comboBoxHallName.Items.Clear();
            DataTable dt = DBHelper.GetData("SELECT HallName FROM Halls");
            foreach (DataRow row in dt.Rows)
            {
                comboBoxHallName.Items.Add(row["HallName"].ToString());
            }
        }



        

        private void ClearForm()
        {
            comboBoxHallName.Text = "";
            textBoxCapacity.Clear();
            textBoxPrice.Clear();
            comboBoxStatus.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void btnSave_Click_1(object sender, EventArgs e)
        {

            string hallName = comboBoxHallName.Text;
            int capacity = int.Parse(textBoxCapacity.Text);
            decimal price = decimal.Parse(textBoxPrice.Text);
            string status = comboBoxStatus.Text;

            string checkQuery = "SELECT COUNT(*) FROM Halls WHERE HallName = @HallName";
            int exists = (int)DBHelper.GetData($"SELECT COUNT(*) AS C FROM Halls WHERE HallName = '{hallName}'").Rows[0]["C"];

            if (exists > 0)
            {
                // Update
                string updateQuery = "UPDATE Halls SET Capacity = @Capacity, Price = @Price, Status = @Status WHERE HallName = @HallName";
                DBHelper.Execute(updateQuery,
                    new SqlParameter("@Capacity", capacity),
                    new SqlParameter("@Price", price),
                    new SqlParameter("@Status", status),
                    new SqlParameter("@HallName", hallName)
                );
                MessageBox.Show("Hall updated successfully.");
            }
            else
            {
                // Insert
                string insertQuery = "INSERT INTO Halls (HallName, Capacity, Price, Status) VALUES (@HallName, @Capacity, @Price, @Status)";
                DBHelper.Execute(insertQuery,
                    new SqlParameter("@HallName", hallName),
                    new SqlParameter("@Capacity", capacity),
                    new SqlParameter("@Price", price),
                    new SqlParameter("@Status", status)
                );
                MessageBox.Show("Hall added successfully.");
            }
            ClearForm();
            LoadHalls();
        }

        private void comboBoxHallName_SelectedIndexChanged(object sender, EventArgs e)
        {
            string hallName = comboBoxHallName.Text;
            string query = "SELECT * FROM Halls WHERE HallName = @HallName";
            DataTable dt = DBHelper.GetData(query.Replace("@HallName", $"'{hallName}'"));

            if (dt.Rows.Count > 0)
            {
                DataRow row = dt.Rows[0];
                textBoxCapacity.Text = row["Capacity"].ToString();
                textBoxPrice.Text = row["Price"].ToString();
                comboBoxStatus.Text = row["Status"].ToString();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string hallName = comboBoxHallName.Text;
            DialogResult result = MessageBox.Show("Are you sure you want to delete this hall?", "Confirm Delete", MessageBoxButtons.YesNo);

            if (result == DialogResult.Yes)
            {
                string deleteQuery = "DELETE FROM Halls WHERE HallName = @HallName";
                DBHelper.Execute(deleteQuery, new SqlParameter("@HallName", hallName));
                MessageBox.Show("Hall deleted.");
                ClearForm();
                LoadHalls();
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

        private void textBoxCapacity_TextChanged(object sender, EventArgs e)
        {
           
                // إزالة الحروف إن وجدت
                textBoxCapacity.Text = new string(textBoxCapacity.Text.Where(char.IsDigit).ToArray());
                textBoxCapacity.SelectionStart = textBoxCapacity.Text.Length;

                // التحقق من الحد الأقصى
                if (int.TryParse(textBoxCapacity.Text, out int capacityValue) && capacityValue > 2000)
                {
                    MessageBox.Show("Capacity cannot exceed 2000.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    textBoxCapacity.Text = "2000";
                    textBoxCapacity.SelectionStart = textBoxCapacity.Text.Length;
                }
            }

        private void textBoxPrice_TextChanged(object sender, EventArgs e)
        {
            string input = textBoxPrice.Text;
            if (!decimal.TryParse(input, out _) && !string.IsNullOrEmpty(input))
            {
                MessageBox.Show("Only numeric values are allowed in Price.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBoxPrice.Text = new string(input.Where(c => char.IsDigit(c) || c == '.').ToArray());
                textBoxPrice.SelectionStart = textBoxPrice.Text.Length;
            }
        }
    }
}
