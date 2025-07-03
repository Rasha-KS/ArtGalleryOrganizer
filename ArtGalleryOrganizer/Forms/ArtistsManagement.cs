using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using System.Data.SqlClient;
using ArtGalleryOrganizer.Classes;
using StudentProject1.Classes;

namespace ArtGalleryOrganizer
{
    public partial class ArtistsManagement : Form
    {
        int selectedRowIndex = -1;
        ResizeControls r = new ResizeControls();

        public ArtistsManagement()
        {
            InitializeComponent();
        }

        private void ArtistsManagement_HandleCreated(object sender, EventArgs e)
        {
            r.Container = this;
        }

        private void ArtistsManagement_Resize(object sender, EventArgs e)
        {
            r.ResizeControl();
        }

        private void ArtistsManagement_Load(object sender, EventArgs e)
        {
            LoadArtistsToGrid();
            dataGridView1.ClearSelection();
        }

        private void LoadArtistsToGrid()
        {
            DataTable dt = DBHelper.GetData("SELECT * FROM Artists");
            dataGridView1.DataSource = dt;
            dataGridView1.ClearSelection();
        }

        private void ClearFields()
        {
            txtName.Clear();
            txtEmail.Clear();
            txtPhone.Clear();
            txtNationalID.Clear();
            selectedRowIndex = -1;
            dataGridView1.ClearSelection();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearFields();
            txtName.Focus();
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
                    // تعديل موجود
                    int artistId = Convert.ToInt32(dataGridView1.Rows[selectedRowIndex].Cells["ArtistID"].Value);
                    string updateQuery = @"UPDATE Artists 
                                           SET ArtistName = @Name, Email = @Email, Phone = @Phone, NationalID = @NationalID 
                                           WHERE ArtistID = @Id";
                    DBHelper.Execute(updateQuery,
                        new SqlParameter("@Name", txtName.Text),
                        new SqlParameter("@Email", txtEmail.Text),
                        new SqlParameter("@Phone", txtPhone.Text),
                        new SqlParameter("@NationalID", txtNationalID.Text),
                        new SqlParameter("@Id", artistId));

                    MessageBox.Show("Artist updated successfully.", "Edit", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    // إضافة جديد - بدون ArtistID
                    string insertQuery = @"INSERT INTO Artists (ArtistName, Email, Phone, NationalID) 
                                           VALUES (@Name, @Email, @Phone, @NationalID)";
                    DBHelper.Execute(insertQuery,
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

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                selectedRowIndex = e.RowIndex;
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

                txtName.Text = row.Cells["ArtistName"].Value?.ToString();
                txtEmail.Text = row.Cells["Email"].Value?.ToString();
                txtPhone.Text = row.Cells["Phone"].Value?.ToString();
                txtNationalID.Text = row.Cells["NationalID"].Value?.ToString();
            }
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

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtNationalID_TextChanged(object sender, EventArgs e)
        {
            // إزالة أي أحرف غير أرقام
            txtNationalID.Text = new string(txtNationalID.Text.Where(char.IsDigit).ToArray());
            txtNationalID.SelectionStart = txtNationalID.Text.Length;

            // الحد من الطول إلى 12 رقم فقط
            if (txtNationalID.Text.Length > 12)
            {
                txtNationalID.Text = txtNationalID.Text.Substring(0, 12);
                txtNationalID.SelectionStart = txtNationalID.Text.Length;
                MessageBox.Show("National ID cannot exceed 12 digits.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
