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
         int selectedRowIndex = -1;
      

        //------------------------------------------------------------
        //Artist work Style 
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
                    string artistName = SharedData.Artists[index].Name;

                    // حذف الفنان من القائمة
                    SharedData.Artists.RemoveAt(index);

                    // حذف الأنماط المرتبطة بالفنان
                    for (int i = SharedData.ArtistWorkStyles.Count - 1; i >= 0; i--)
                    {
                        if (SharedData.ArtistWorkStyles[i].ArtistName == artistName)
                        {
                            SharedData.ArtistWorkStyles.RemoveAt(i);
                        }
                    }

                    // تحديث الكومبو بوكس
                    refreshcomboArtistName();

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
                    string oldArtistName = SharedData.Artists[selectedRowIndex].Name;
                    string newArtistName = txtName.Text;

                    // Keep original ID
                    newArtist.Id = SharedData.Artists[selectedRowIndex].Id;

                    // Update the list and DataGridView
                    SharedData.Artists[selectedRowIndex] = newArtist;

                    DataGridViewRow row = dataGridView1.Rows[selectedRowIndex];
                    row.Cells[0].Value = newArtist.Id;
                    row.Cells[1].Value = newArtist.Name;
                    row.Cells[2].Value = newArtist.Email;
                    row.Cells[3].Value = newArtist.Nationality;
                    row.Cells[4].Value = newArtist.Phone;


                    for (int i = 0; i < SharedData.ArtistWorkStyles.Count; i++)
                    {
                        if (SharedData.ArtistWorkStyles[i].ArtistName == oldArtistName)
                        {
                            SharedData.ArtistWorkStyles[i].ArtistName = newArtistName;
                        }
                    }


                    RefreshWorkStyleGrid();
                    refreshcomboArtistName();

                    MessageBox.Show("Artist updated successfully.", "Edit Mode", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    //  Original Add logic (no change here)
                 
                    newArtist.Id = SharedData.Artists.Max(a => a.Id)+1;
                    SharedData.Artists.Add(newArtist);
                    LoadArtistsToGrid();

                    //----------------------------------------------------------------------------------
                    //Artist work style
                    refreshcomboArtistName();

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

            // Load into DataGridView
          LoadArtistsToGrid();


            //---------------------------------------------------------------------
            //Artist Work style
            refreshcomboArtistName();
               // Set default items in work style
            comboBoxWorkStyle.Items.Clear();
            comboBoxWorkStyle.Items.AddRange(new string[] { "Realism", "Impressionism", "Abstract", "Surrealism" });
            comboBoxWorkStyle.SelectedIndex = -1;


            // Refresh both data grids
          
            RefreshWorkStyleGrid();       // لعرض جدول work style

        }

        //------------------------------------------------------------
        //Artist information 
      
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                selectedRowIndex = e.RowIndex;
                var selected = SharedData.Artists[e.RowIndex];
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
                       comboBoxWorkStyle.SelectedIndex == -1 ||
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
                    SharedData.ArtistWorkStyles[selectedWorkStyleIndex] = workStyle;

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
                    SharedData.ArtistWorkStyles.Add(workStyle);
                    RefreshWorkStyleGrid();

                    MessageBox.Show("Work style added successfully.", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                ClearWorkStyleFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while saving work style: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void refreshcomboArtistName()
        {
            comboBoxArtistName.DataSource = SharedData.Artists.Select(a => a.Name).ToList();
            comboBoxArtistName.SelectedIndex = -1;

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
            // بدل تفريغ الصفوف وإضافتهم يدوياً، نربط DataGridView مباشرة مع BindingList
            dataGridView1.DataSource = null;  // لتحديث الربط إذا كان موجود
            dataGridView1.DataSource = SharedData.Artists;
        }

        private void RefreshWorkStyleGrid()
        {
           
            // نفس الشيء مع قائمة أنماط العمل
            dataGridViewWorkStyles.DataSource = null;
            dataGridViewWorkStyles.DataSource = SharedData.ArtistWorkStyles;
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
                var selected = SharedData.ArtistWorkStyles[e.RowIndex];

                comboBoxArtistName.Text = selected.ArtistName;
                comboBoxWorkStyle.Text = selected.WorkStyle;
                txtWorkExperience.Text = selected.WorkExperience;
            }
        }

        private void btnDeleteWorkStyle_Click(object sender, EventArgs e)
        {
            if (selectedWorkStyleIndex >= 0 && selectedWorkStyleIndex < SharedData.ArtistWorkStyles.Count)
            {
                var result = MessageBox.Show("Are you sure you want to delete this work style?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    // Remove from the list
                    SharedData.ArtistWorkStyles.RemoveAt(selectedWorkStyleIndex);

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
