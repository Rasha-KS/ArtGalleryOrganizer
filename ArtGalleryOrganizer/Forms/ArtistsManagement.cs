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

    public partial class ArtistsManagement : Form
    {
        BindingList<Artist> artistsList = new BindingList<Artist>();
        int selectedRowIndex = -1;
        int c = 3;
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
                int index = dataGridView1.CurrentRow.Index;

                // حذف الفنان من القائمة
                artistsList.RemoveAt(index);
                
                
                LoadArtistsToGrid();
                ClearFields();
            }
            else
            {
                MessageBox.Show("Please select a row to delete.");
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearFields();

            // (اختياري) إرجاع المؤشر لأول حقل
            txtName.Focus();
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {
           
            try
    {
        // التحقق إن كان النص يحتوي أرقام
        if (txtName.Text.Any(char.IsDigit))
        {
            MessageBox.Show("Numbers are not allowed in the name field.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            // إزالة الأرقام من النص
            txtName.Text = new string(txtName.Text.Where(c => !char.IsDigit(c)).ToArray());

            // إرجاع المؤشر لنهاية النص
            txtName.SelectionStart = txtName.Text.Length;
        }
    }
    catch (Exception ex)
    {
        MessageBox.Show("An error occurred: " + ex.Message);
    }
           

        }

        private void txtNationality_TextChanged(object sender, EventArgs e)
        {
             try
                {
                    if (txtNationality.Text.Any(char.IsDigit))
                    {
                        MessageBox.Show("Numbers are not allowed in the nationality field.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                        // إزالة الأرقام
                        txtNationality.Text = new string(txtNationality.Text.Where(c => !char.IsDigit(c)).ToArray());
                        txtNationality.SelectionStart = txtNationality.Text.Length;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred: " + ex.Message);
                }
           

        }

        private void txtEmail_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtPhone_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtPhone.Text.Any(c => !char.IsDigit(c)))
                {
                    MessageBox.Show("Only digits are allowed in the phone number.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    // إزالة الحروف أو الرموز
                    txtPhone.Text = new string(txtPhone.Text.Where(char.IsDigit).ToArray());
                    txtPhone.SelectionStart = txtPhone.Text.Length;
                }

                // التحقق من الطول (اختياري)
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
            try
            {
                // Check required fields
                if (string.IsNullOrWhiteSpace(txtName.Text) ||
                    string.IsNullOrWhiteSpace(txtEmail.Text) ||
                    string.IsNullOrWhiteSpace(txtNationality.Text) ||
                    string.IsNullOrWhiteSpace(txtPhone.Text))
                {
                    MessageBox.Show("Please fill all the fields.", "Missing Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                Artist newArtist = new Artist
                {
                    Name = txtName.Text,
                    Email = txtEmail.Text,
                    Nationality = txtNationality.Text,
                    Phone = txtPhone.Text
                };

                // Check if we're editing an existing row
                if (selectedRowIndex >= 0)
                {
                    // Keep original ID
                    newArtist.Id = artistsList[selectedRowIndex].Id;

                    // Update the list and DataGridView
                    artistsList[selectedRowIndex] = newArtist;

                    DataGridViewRow row = dataGridView1.Rows[selectedRowIndex];
                    row.Cells[0].Value = newArtist.Id;
                    row.Cells[1].Value = newArtist.Name;
                    row.Cells[2].Value = newArtist.Email;
                    row.Cells[3].Value = newArtist.Nationality;
                    row.Cells[4].Value = newArtist.Phone;

                    MessageBox.Show("Artist updated successfully.", "Edit Mode", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    //  Original Add logic (no change here)
                    c = c + 1;
                    newArtist.Id = c;
                    artistsList.Add(newArtist);
                    dataGridView1.Rows.Add(newArtist.Id, newArtist.Name, newArtist.Email, newArtist.Nationality, newArtist.Phone);

                    MessageBox.Show("Artist added successfully.", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

               
                ClearFields();
              
              
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while saving artist: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ArtistsManagement_Load(object sender, EventArgs e)
        {

            artistsList = new BindingList<Artist>(Artist.GetDefaultArtists()); 

            // Load into DataGridView
            foreach (var artist in artistsList)
            {
                dataGridView1.Rows.Add(artist.Id, artist.Name, artist.Email, artist.Nationality, artist.Phone);
            }

            // Set 'c' to the last ID
            c = artistsList.Max(a => a.Id);


        }
        private void ClearFields()
        {
            txtName.Clear();
            txtEmail.Clear();
            txtNationality.Clear();
            txtPhone.Clear();
            selectedRowIndex = -1;
        }

        private void LoadArtistsToGrid()
        {
            dataGridView1.Rows.Clear(); // نحذف الصفوف القديمة
           
            foreach (var artist in artistsList)
            {
                dataGridView1.Rows.Add(artist.Id, artist.Name, artist.Email, artist.Nationality, artist.Phone);
            }

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                selectedRowIndex = e.RowIndex;

                txtName.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                txtEmail.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                txtNationality.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
                txtPhone.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            }
        }
    }
}
