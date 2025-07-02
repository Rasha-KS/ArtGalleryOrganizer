using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using System.Data.SqlClient;
using StudentProject1.Classes;

namespace ArtGalleryOrganizer
{
    public partial class ArtistsManagement : Form
    {
        int selectedRowIndex = -1;

        public ArtistsManagement()
        {
            InitializeComponent();
        }

        ResizeControls r = new ResizeControls();

        private void ArtistsManagement_Resize(object sender, EventArgs e)
        {
            r.ResizeControl();
        }

        private void ArtistsManagement_HandleCreated(object sender, EventArgs e)
        {
            r.Container = this;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null && dataGridView1.CurrentRow.Index >= 0)
            {
                var result = MessageBox.Show("Are you sure you want to delete this artist?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    int artistId = Convert.ToInt32(dataGridView1.CurrentRow.Cells["ArtistID"].Value);
                    DBHelper.Execute("DELETE FROM Artists WHERE ArtistID = @Id", new SqlParameter("@Id", artistId));
                    LoadArtistsToGrid();
                    ClearFields();
                }
            }
            else
            {
                MessageBox.Show("Please select a row to delete.");
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearFields();
            txtName.Focus();
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtName.Text.Any(char.IsDigit))
                {
                    MessageBox.Show("Numbers are not allowed in the name field.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtName.Text = new string(txtName.Text.Where(c => !char.IsDigit(c)).ToArray());
                    txtName.SelectionStart = txtName.Text.Length;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }

        private void txtEmail_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtEmail.Text) && !IsValidEmail(txtEmail.Text))
            {
                MessageBox.Show("Invalid email format.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEmail.Focus();
            }
        }

        private bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        private void txtEmail_TextChanged(object sender, EventArgs e) { }

        private void txtPhone_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtPhone.Text.Any(c => !char.IsDigit(c)))
                {
                    MessageBox.Show("Only digits are allowed in the phone number.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtPhone.Text = new string(txtPhone.Text.Where(char.IsDigit).ToArray());
                    txtPhone.SelectionStart = txtPhone.Text.Length;
                }
                if (txtPhone.Text.Length > 10)
                {
                    txtPhone.Text = txtPhone.Text.Substring(0, 10);
                    txtPhone.SelectionStart = txtPhone.Text.Length;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }

        private void btnSaveArtist_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtName.Text) ||
                string.IsNullOrWhiteSpace(txtEmail.Text) ||
                string.IsNullOrWhiteSpace(txtNationalID.Text) ||
                string.IsNullOrWhiteSpace(txtPhone.Text))
            {
                MessageBox.Show("Please fill all the fields.", "Missing Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                if (selectedRowIndex >= 0)
                {
                    int artistId = Convert.ToInt32(dataGridView1.Rows[selectedRowIndex].Cells["ArtistID"].Value);

                    string updateQuery = @"UPDATE Artists SET ArtistName = @Name, Email = @Email, Phone = @Phone, NationalID = @NationalID WHERE ArtistID = @Id";
                    DBHelper.Execute(updateQuery,
                        new SqlParameter("@Name", txtName.Text),
                        new SqlParameter("@Email", txtEmail.Text),
                        new SqlParameter("@Phone", txtPhone.Text),
                        new SqlParameter("@NationalID", txtNationalID.Text),
                        new SqlParameter("@Id", artistId));

                    MessageBox.Show("Artist updated successfully.", "Edit Mode", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    var dt = DBHelper.GetData("SELECT ISNULL(MAX(ArtistID), 0) + 1 FROM Artists");
                    int newId = Convert.ToInt32(dt.Rows[0][0]);

                    string insertQuery = @"INSERT INTO Artists (ArtistID, ArtistName, Email, Phone, NationalID) VALUES (@Id, @Name, @Email, @Phone, @NationalID)";
                    DBHelper.Execute(insertQuery,
                        new SqlParameter("@Id", newId),
                        new SqlParameter("@Name", txtName.Text),
                        new SqlParameter("@Email", txtEmail.Text),
                        new SqlParameter("@Phone", txtPhone.Text),
                        new SqlParameter("@NationalID", txtNationalID.Text));

                    MessageBox.Show("Artist added successfully.", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                LoadArtistsToGrid();
                ClearFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while saving artist: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ArtistsManagement_Load(object sender, EventArgs e)
        {
            LoadArtistsToGrid();
            dataGridView1.ClearSelection();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex >= 0)
            {
                selectedRowIndex = e.RowIndex;
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

                txtName.Text = row.Cells["ArtistName"].Value.ToString();
                txtEmail.Text = row.Cells["Email"].Value.ToString();
                txtNationalID.Text = row.Cells["NationalID"].Value.ToString();
                txtPhone.Text = row.Cells["Phone"].Value.ToString();
            }
        }

        private void ClearFields()
        {
            txtName.Clear();
            txtEmail.Clear();
            txtNationalID.Clear();
            txtPhone.Clear();
            selectedRowIndex = -1;
            dataGridView1.ClearSelection();
        }

        private void LoadArtistsToGrid()
        {
            dataGridView1.DataSource = null;
            DataTable dt = DBHelper.GetData("SELECT * FROM Artists");
            dataGridView1.DataSource = dt;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }

    public static class DBHelper
    {
        private static string connStr = "Server=.;Database=ArtGalleryDB;Integrated Security=True;";

        public static DataTable GetData(string query)
        {
            using (var conn = new SqlConnection(connStr))
            using (var cmd = new SqlCommand(query, conn))
            using (var adapter = new SqlDataAdapter(cmd))
            {
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                return dt;
            }
        }

        public static int Execute(string query, params SqlParameter[] parameters)
        {
            using (var conn = new SqlConnection(connStr))
            using (var cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddRange(parameters);
                conn.Open();
                return cmd.ExecuteNonQuery();
            }
        }
    }
}
