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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ArtGalleryOrganizer
{

    public partial class ArtistsManagement : Form
    {
        //------------------------------------------------------------
        //Artist information 

        BindingList<Artist> artistsList = new BindingList<Artist>();
        int selectedRowIndex = -1;
        int c = 3;

        //------------------------------------------------------------
        //Artist work Style 

        List<ArtistWorkStyle> workStyleList = new List<ArtistWorkStyle>();
        int selectedWorkStyleIndex = -1;
       


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

        //------------------------------------------------------------
        //Artist information 


        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null && dataGridView1.CurrentRow.Index >= 0)
            {
                var result = MessageBox.Show("Are you sure you want to delete this artist and related work styles?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    int index = dataGridView1.CurrentRow.Index;

                    // اسم الفنان المحدد
                    string artistName = artistsList[index].Name;

                    // حذف الفنان من القائمة
                    artistsList.RemoveAt(index);

                    // حذف الأنماط المرتبطة بالفنان
                    workStyleList.RemoveAll(ws => ws.ArtistName == artistName);

                    // تحديث الكومبو بوكس
                    comboBoxArtistName.DataSource = artistsList.Select(a => a.Name).ToList();
                    comboBoxArtistName.SelectedIndex = -1;

                    // تحديث الـ DataGrids
                    LoadArtistsToGrid();
                    RefreshWorkStyleGrid();
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

                  
                    comboBoxArtistName.DataSource = artistsList.Select(a => a.Name).ToList();
                    comboBoxArtistName.SelectedIndex = -1;

                    MessageBox.Show("Artist updated successfully.", "Edit Mode", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    //  Original Add logic (no change here)
                 
                    newArtist.Id = artistsList.Max(a => a.Id)+1;
                    artistsList.Add(newArtist);
                    dataGridView1.Rows.Add(newArtist.Id, newArtist.Name, newArtist.Email, newArtist.Nationality, newArtist.Phone);
                   
                    
                    //----------------------------------------------------------------------------------
                    //Artist work style
                    comboBoxArtistName.DataSource = artistsList.Select(a => a.Name).ToList();
                    comboBoxArtistName.SelectedIndex = -1;

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

            //------------------------------------------------------------
            //Artist information 

            artistsList = new BindingList<Artist>(Artist.GetDefaultArtists()); 

            // Load into DataGridView
            foreach (var artist in artistsList)
            {
                dataGridView1.Rows.Add(artist.Id, artist.Name, artist.Email, artist.Nationality, artist.Phone);
            }



            //---------------------------------------------------------------------
            //Artist Work style
            comboBoxArtistName.Focus();
            comboBoxArtistName.DataSource = artistsList.Select(a => a.Name).ToList();
            comboBoxArtistName.SelectedIndex = -1;
            // Set default items in work style
            comboBoxWorkStyle.Items.Clear();
            comboBoxWorkStyle.Items.AddRange(new string[] { "Realism", "Impressionism", "Abstract", "Surrealism" });
            comboBoxWorkStyle.SelectedIndex = -1;

           
            // Load default work styles
            workStyleList = ArtistWorkStyle.GetDefaultWorkStyles();

            // Update comboBox data source
            comboBoxArtistName.DataSource = artistsList.Select(a => a.Name).ToList();
            comboBoxArtistName.SelectedIndex = -1;

            // Refresh both data grids
          
            RefreshWorkStyleGrid();       // لعرض جدول work style

        }

        //------------------------------------------------------------
        //Artist information 

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
                var selected = artistsList[e.RowIndex];

                txtName.Text = selected.Name;
                txtEmail.Text =selected.Email;
                txtNationality.Text = selected.Nationality;
                txtPhone.Text = selected.Phone;
            }
        }

        //---------------------------------------------------------------------------------------------------------
        //ARTIST WORK STYLE
        //---------------------------------------------------------------------------------------------------------
        
        
        private void btnSaveWorkStyle_Click(object sender, EventArgs e)
        {
            try
            {
                // Check required fields
                if (comboBoxArtistName.SelectedIndex == -1 ||
                    string.IsNullOrWhiteSpace(comboBoxWorkStyle.Text) ||
                    string.IsNullOrWhiteSpace(txtWorkExperience.Text))
                {
                    MessageBox.Show("Please fill all the fields.", "Missing Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                ArtistWorkStyle workStyle = new ArtistWorkStyle
                {
                    ArtistName = comboBoxArtistName.Text,
                    WorkStyle = comboBoxWorkStyle.Text,
                    WorkExperience = txtWorkExperience.Text
                };

                // Edit mode
                if (selectedWorkStyleIndex >= 0)
                {
                    workStyleList[selectedWorkStyleIndex] = workStyle;

                    DataGridViewRow row = dataGridViewWorkStyles.Rows[selectedWorkStyleIndex];
                    row.Cells[0].Value = workStyle.ArtistName;
                    row.Cells[1].Value = workStyle.WorkStyle;
                    row.Cells[2].Value = workStyle.WorkExperience;

                    MessageBox.Show("Work style updated successfully.", "Edit Mode", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    selectedWorkStyleIndex = -1;
                }
                else
                {
                    // Add new
                    workStyleList.Add(workStyle);
                    dataGridViewWorkStyles.Rows.Add(workStyle.ArtistName, workStyle.WorkStyle, workStyle.WorkExperience);

                    MessageBox.Show("Work style added successfully.", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                ClearWorkStyleFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while saving work style: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void RefreshWorkStyleGrid()
        {
            dataGridViewWorkStyles.Rows.Clear();

            foreach (var workStyle in workStyleList)
            {
                dataGridViewWorkStyles.Rows.Add(
                    workStyle.ArtistName,
                    workStyle.WorkStyle,
                    workStyle.WorkExperience
                );
            }
        }


        private void ClearWorkStyleFields()
        {
            comboBoxArtistName.SelectedIndex = -1;
            comboBoxWorkStyle.SelectedIndex = -1;
            txtWorkExperience.Clear();
            selectedWorkStyleIndex = -1;
            comboBoxArtistName.Focus();
        }

        private void dataGridViewWorkStyles_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                selectedWorkStyleIndex = e.RowIndex;
                var selected = workStyleList[e.RowIndex];

                comboBoxArtistName.Text = selected.ArtistName;
                comboBoxWorkStyle.Text = selected.WorkStyle;
                txtWorkExperience.Text = selected.WorkExperience;
            }
        }

        private void btnDeleteWorkStyle_Click(object sender, EventArgs e)
        {
            if (selectedWorkStyleIndex >= 0 && selectedWorkStyleIndex < workStyleList.Count)
            {
                var result = MessageBox.Show("Are you sure you want to delete this work style?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    // Remove from the list
                    workStyleList.RemoveAt(selectedWorkStyleIndex);

                    // Reset selection
                    selectedWorkStyleIndex = -1;

                    // Refresh grid and clear input fields
                    RefreshWorkStyleGrid();
                    ClearWorkStyleFields();
                }

                ClearWorkStyleFields();
            }
            else
            {
                MessageBox.Show("Please select a work style to delete.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnClearWorkStyle_Click(object sender, EventArgs e)
        {
            ClearWorkStyleFields();
        }


    }
}
