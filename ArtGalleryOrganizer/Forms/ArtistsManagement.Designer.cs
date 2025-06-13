namespace ArtGalleryOrganizer
{
    partial class ArtistsManagement
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Column_artistId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_Email = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_Nationality = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_Phone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtWorkExperience = new System.Windows.Forms.TextBox();
            this.btnClearWorkStyle = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.dataGridViewWorkStyles = new System.Windows.Forms.DataGridView();
            this.Column_ArtistName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_WorkStyle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_WorkExperience = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnDeleteWorkStyle = new System.Windows.Forms.Button();
            this.btnSaveWorkStyle = new System.Windows.Forms.Button();
            this.comboBoxArtistName = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.comboBoxWorkStyle = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnSaveArtist = new System.Windows.Forms.Button();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.txtNationality = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewWorkStyles)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(237)))), ((int)(((byte)(226)))));
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(223)))), ((int)(((byte)(253)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(122)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(237)))), ((int)(((byte)(226)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(122)))));
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column_artistId,
            this.Column_Name,
            this.Column_Email,
            this.Column_Nationality,
            this.Column_Phone});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(122)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(223)))), ((int)(((byte)(253)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(223)))), ((int)(((byte)(253)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(122)))));
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView1.EnableHeadersVisualStyles = false;
            this.dataGridView1.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(122)))));
            this.dataGridView1.Location = new System.Drawing.Point(566, 27);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(122)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(237)))), ((int)(((byte)(226)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(122)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 26;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(657, 325);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // Column_artistId
            // 
            this.Column_artistId.HeaderText = "Id";
            this.Column_artistId.MinimumWidth = 6;
            this.Column_artistId.Name = "Column_artistId";
            this.Column_artistId.ReadOnly = true;
            // 
            // Column_Name
            // 
            this.Column_Name.HeaderText = "Name";
            this.Column_Name.MinimumWidth = 6;
            this.Column_Name.Name = "Column_Name";
            this.Column_Name.ReadOnly = true;
            // 
            // Column_Email
            // 
            this.Column_Email.HeaderText = "Email";
            this.Column_Email.MinimumWidth = 6;
            this.Column_Email.Name = "Column_Email";
            this.Column_Email.ReadOnly = true;
            // 
            // Column_Nationality
            // 
            this.Column_Nationality.HeaderText = "Nationality";
            this.Column_Nationality.MinimumWidth = 6;
            this.Column_Nationality.Name = "Column_Nationality";
            this.Column_Nationality.ReadOnly = true;
            // 
            // Column_Phone
            // 
            this.Column_Phone.HeaderText = "Phone";
            this.Column_Phone.MinimumWidth = 6;
            this.Column_Phone.Name = "Column_Phone";
            this.Column_Phone.ReadOnly = true;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Times New Roman", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(223)))), ((int)(((byte)(253)))));
            this.label1.Location = new System.Drawing.Point(14, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(146, 37);
            this.label1.TabIndex = 1;
            this.label1.Text = "Artist Name";
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Times New Roman", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(223)))), ((int)(((byte)(253)))));
            this.label2.Location = new System.Drawing.Point(14, 96);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(138, 37);
            this.label2.TabIndex = 2;
            this.label2.Text = "Work Style";
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(122)))));
            this.groupBox1.Controls.Add(this.txtWorkExperience);
            this.groupBox1.Controls.Add(this.btnClearWorkStyle);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.dataGridViewWorkStyles);
            this.groupBox1.Controls.Add(this.btnDeleteWorkStyle);
            this.groupBox1.Controls.Add(this.btnSaveWorkStyle);
            this.groupBox1.Controls.Add(this.comboBoxArtistName);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.comboBoxWorkStyle);
            this.groupBox1.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(223)))), ((int)(((byte)(253)))));
            this.groupBox1.Location = new System.Drawing.Point(24, 411);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Size = new System.Drawing.Size(1238, 254);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Artists Work Styles";
            // 
            // txtWorkExperience
            // 
            this.txtWorkExperience.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(237)))), ((int)(((byte)(226)))));
            this.txtWorkExperience.Font = new System.Drawing.Font("Times New Roman", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtWorkExperience.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(122)))));
            this.txtWorkExperience.Location = new System.Drawing.Point(256, 150);
            this.txtWorkExperience.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtWorkExperience.Name = "txtWorkExperience";
            this.txtWorkExperience.Size = new System.Drawing.Size(227, 32);
            this.txtWorkExperience.TabIndex = 26;
            // 
            // btnClearWorkStyle
            // 
            this.btnClearWorkStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(119)))), ((int)(((byte)(102)))), ((int)(((byte)(198)))));
            this.btnClearWorkStyle.Font = new System.Drawing.Font("Times New Roman", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClearWorkStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(223)))), ((int)(((byte)(253)))));
            this.btnClearWorkStyle.Location = new System.Drawing.Point(393, 200);
            this.btnClearWorkStyle.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnClearWorkStyle.Name = "btnClearWorkStyle";
            this.btnClearWorkStyle.Size = new System.Drawing.Size(143, 37);
            this.btnClearWorkStyle.TabIndex = 24;
            this.btnClearWorkStyle.Text = "Clear";
            this.btnClearWorkStyle.UseVisualStyleBackColor = false;
            this.btnClearWorkStyle.Click += new System.EventHandler(this.btnClearWorkStyle_Click);
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("Times New Roman", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(223)))), ((int)(((byte)(253)))));
            this.label7.Location = new System.Drawing.Point(14, 151);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(203, 32);
            this.label7.TabIndex = 25;
            this.label7.Text = "Work Experience";
            // 
            // dataGridViewWorkStyles
            // 
            this.dataGridViewWorkStyles.AllowUserToAddRows = false;
            this.dataGridViewWorkStyles.AllowUserToResizeColumns = false;
            this.dataGridViewWorkStyles.AllowUserToResizeRows = false;
            this.dataGridViewWorkStyles.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewWorkStyles.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(237)))), ((int)(((byte)(226)))));
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(223)))), ((int)(((byte)(253)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(122)))));
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(237)))), ((int)(((byte)(226)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(122)))));
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewWorkStyles.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridViewWorkStyles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewWorkStyles.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column_ArtistName,
            this.Column_WorkStyle,
            this.Column_WorkExperience});
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(122)))));
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(223)))), ((int)(((byte)(253)))));
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(223)))), ((int)(((byte)(253)))));
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(122)))));
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewWorkStyles.DefaultCellStyle = dataGridViewCellStyle5;
            this.dataGridViewWorkStyles.EnableHeadersVisualStyles = false;
            this.dataGridViewWorkStyles.Location = new System.Drawing.Point(566, 27);
            this.dataGridViewWorkStyles.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataGridViewWorkStyles.MultiSelect = false;
            this.dataGridViewWorkStyles.Name = "dataGridViewWorkStyles";
            this.dataGridViewWorkStyles.ReadOnly = true;
            this.dataGridViewWorkStyles.RowHeadersVisible = false;
            this.dataGridViewWorkStyles.RowHeadersWidth = 51;
            this.dataGridViewWorkStyles.RowTemplate.Height = 26;
            this.dataGridViewWorkStyles.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewWorkStyles.Size = new System.Drawing.Size(657, 210);
            this.dataGridViewWorkStyles.TabIndex = 24;
            this.dataGridViewWorkStyles.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewWorkStyles_CellClick);
            // 
            // Column_ArtistName
            // 
            this.Column_ArtistName.HeaderText = "Artist Name";
            this.Column_ArtistName.MinimumWidth = 6;
            this.Column_ArtistName.Name = "Column_ArtistName";
            this.Column_ArtistName.ReadOnly = true;
            // 
            // Column_WorkStyle
            // 
            this.Column_WorkStyle.HeaderText = "Work Style ";
            this.Column_WorkStyle.MinimumWidth = 6;
            this.Column_WorkStyle.Name = "Column_WorkStyle";
            this.Column_WorkStyle.ReadOnly = true;
            // 
            // Column_WorkExperience
            // 
            this.Column_WorkExperience.HeaderText = "Work Experience";
            this.Column_WorkExperience.MinimumWidth = 6;
            this.Column_WorkExperience.Name = "Column_WorkExperience";
            this.Column_WorkExperience.ReadOnly = true;
            // 
            // btnDeleteWorkStyle
            // 
            this.btnDeleteWorkStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(119)))), ((int)(((byte)(102)))), ((int)(((byte)(198)))));
            this.btnDeleteWorkStyle.Font = new System.Drawing.Font("Times New Roman", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeleteWorkStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(223)))), ((int)(((byte)(253)))));
            this.btnDeleteWorkStyle.Location = new System.Drawing.Point(199, 200);
            this.btnDeleteWorkStyle.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnDeleteWorkStyle.Name = "btnDeleteWorkStyle";
            this.btnDeleteWorkStyle.Size = new System.Drawing.Size(144, 37);
            this.btnDeleteWorkStyle.TabIndex = 23;
            this.btnDeleteWorkStyle.Text = "Delete";
            this.btnDeleteWorkStyle.UseVisualStyleBackColor = false;
            this.btnDeleteWorkStyle.Click += new System.EventHandler(this.btnDeleteWorkStyle_Click);
            // 
            // btnSaveWorkStyle
            // 
            this.btnSaveWorkStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(119)))), ((int)(((byte)(102)))), ((int)(((byte)(198)))));
            this.btnSaveWorkStyle.Font = new System.Drawing.Font("Times New Roman", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSaveWorkStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(223)))), ((int)(((byte)(253)))));
            this.btnSaveWorkStyle.Location = new System.Drawing.Point(18, 200);
            this.btnSaveWorkStyle.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSaveWorkStyle.Name = "btnSaveWorkStyle";
            this.btnSaveWorkStyle.Size = new System.Drawing.Size(143, 37);
            this.btnSaveWorkStyle.TabIndex = 22;
            this.btnSaveWorkStyle.Text = "Save";
            this.btnSaveWorkStyle.UseVisualStyleBackColor = false;
            this.btnSaveWorkStyle.Click += new System.EventHandler(this.btnSaveWorkStyle_Click);
            // 
            // comboBoxArtistName
            // 
            this.comboBoxArtistName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(237)))), ((int)(((byte)(226)))));
            this.comboBoxArtistName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxArtistName.Font = new System.Drawing.Font("Times New Roman", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxArtistName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(122)))));
            this.comboBoxArtistName.FormattingEnabled = true;
            this.comboBoxArtistName.Location = new System.Drawing.Point(256, 41);
            this.comboBoxArtistName.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboBoxArtistName.Name = "comboBoxArtistName";
            this.comboBoxArtistName.Size = new System.Drawing.Size(227, 33);
            this.comboBoxArtistName.TabIndex = 15;
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Times New Roman", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(223)))), ((int)(((byte)(253)))));
            this.label6.Location = new System.Drawing.Point(14, 43);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(146, 37);
            this.label6.TabIndex = 14;
            this.label6.Text = "Artist Name";
            // 
            // comboBoxWorkStyle
            // 
            this.comboBoxWorkStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(237)))), ((int)(((byte)(226)))));
            this.comboBoxWorkStyle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxWorkStyle.Font = new System.Drawing.Font("Times New Roman", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxWorkStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(122)))));
            this.comboBoxWorkStyle.FormattingEnabled = true;
            this.comboBoxWorkStyle.Location = new System.Drawing.Point(256, 94);
            this.comboBoxWorkStyle.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboBoxWorkStyle.Name = "comboBoxWorkStyle";
            this.comboBoxWorkStyle.Size = new System.Drawing.Size(227, 33);
            this.comboBoxWorkStyle.TabIndex = 6;
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(122)))));
            this.groupBox2.Controls.Add(this.btnClear);
            this.groupBox2.Controls.Add(this.btnDelete);
            this.groupBox2.Controls.Add(this.btnSaveArtist);
            this.groupBox2.Controls.Add(this.txtPhone);
            this.groupBox2.Controls.Add(this.dataGridView1);
            this.groupBox2.Controls.Add(this.txtNationality);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.txtName);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.txtEmail);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(223)))), ((int)(((byte)(253)))));
            this.groupBox2.Location = new System.Drawing.Point(24, 23);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox2.Size = new System.Drawing.Size(1238, 370);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Artists Information";
            // 
            // btnClear
            // 
            this.btnClear.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(119)))), ((int)(((byte)(102)))), ((int)(((byte)(198)))));
            this.btnClear.Font = new System.Drawing.Font("Times New Roman", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(223)))), ((int)(((byte)(253)))));
            this.btnClear.Location = new System.Drawing.Point(393, 314);
            this.btnClear.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(143, 37);
            this.btnClear.TabIndex = 21;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(119)))), ((int)(((byte)(102)))), ((int)(((byte)(198)))));
            this.btnDelete.Font = new System.Drawing.Font("Times New Roman", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(223)))), ((int)(((byte)(253)))));
            this.btnDelete.Location = new System.Drawing.Point(199, 314);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(144, 37);
            this.btnDelete.TabIndex = 20;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnSaveArtist
            // 
            this.btnSaveArtist.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(119)))), ((int)(((byte)(102)))), ((int)(((byte)(198)))));
            this.btnSaveArtist.Font = new System.Drawing.Font("Times New Roman", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSaveArtist.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(223)))), ((int)(((byte)(253)))));
            this.btnSaveArtist.Location = new System.Drawing.Point(18, 314);
            this.btnSaveArtist.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSaveArtist.Name = "btnSaveArtist";
            this.btnSaveArtist.Size = new System.Drawing.Size(143, 37);
            this.btnSaveArtist.TabIndex = 19;
            this.btnSaveArtist.Text = "Save";
            this.btnSaveArtist.UseVisualStyleBackColor = false;
            this.btnSaveArtist.Click += new System.EventHandler(this.btnSaveArtist_Click);
            // 
            // txtPhone
            // 
            this.txtPhone.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(237)))), ((int)(((byte)(226)))));
            this.txtPhone.Font = new System.Drawing.Font("Times New Roman", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPhone.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(122)))));
            this.txtPhone.Location = new System.Drawing.Point(165, 234);
            this.txtPhone.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtPhone.MaxLength = 10;
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Size = new System.Drawing.Size(227, 32);
            this.txtPhone.TabIndex = 13;
            this.txtPhone.TextChanged += new System.EventHandler(this.txtPhone_TextChanged);
            // 
            // txtNationality
            // 
            this.txtNationality.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(237)))), ((int)(((byte)(226)))));
            this.txtNationality.Font = new System.Drawing.Font("Times New Roman", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNationality.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(122)))));
            this.txtNationality.Location = new System.Drawing.Point(165, 173);
            this.txtNationality.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtNationality.Name = "txtNationality";
            this.txtNationality.Size = new System.Drawing.Size(227, 32);
            this.txtNationality.TabIndex = 11;
            this.txtNationality.TextChanged += new System.EventHandler(this.txtNationality_TextChanged);
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Times New Roman", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(223)))), ((int)(((byte)(253)))));
            this.label5.Location = new System.Drawing.Point(15, 236);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(81, 41);
            this.label5.TabIndex = 12;
            this.label5.Text = "Phone";
            // 
            // txtName
            // 
            this.txtName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(237)))), ((int)(((byte)(226)))));
            this.txtName.Font = new System.Drawing.Font("Times New Roman", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(122)))));
            this.txtName.Location = new System.Drawing.Point(165, 54);
            this.txtName.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(227, 32);
            this.txtName.TabIndex = 7;
            this.txtName.TextChanged += new System.EventHandler(this.txtName_TextChanged);
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Times New Roman", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(223)))), ((int)(((byte)(253)))));
            this.label4.Location = new System.Drawing.Point(15, 114);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(98, 32);
            this.label4.TabIndex = 10;
            this.label4.Text = "Email";
            // 
            // txtEmail
            // 
            this.txtEmail.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(237)))), ((int)(((byte)(226)))));
            this.txtEmail.Font = new System.Drawing.Font("Times New Roman", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEmail.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(122)))));
            this.txtEmail.Location = new System.Drawing.Point(165, 114);
            this.txtEmail.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(227, 32);
            this.txtEmail.TabIndex = 9;
            this.txtEmail.TextChanged += new System.EventHandler(this.txtEmail_TextChanged);
            this.txtEmail.Leave += new System.EventHandler(this.txtEmail_Leave);
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Times New Roman", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(223)))), ((int)(((byte)(253)))));
            this.label3.Location = new System.Drawing.Point(14, 176);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(137, 32);
            this.label3.TabIndex = 8;
            this.label3.Text = "Nationality";
            // 
            // ArtistsManagement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(223)))), ((int)(((byte)(253)))));
            this.ClientSize = new System.Drawing.Size(1287, 685);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "ArtistsManagement";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ArtistsManagement";
            this.Load += new System.EventHandler(this.ArtistsManagement_Load);
            this.HandleCreated += new System.EventHandler(this.ArtistsManagement_HandleCreated);
            this.Resize += new System.EventHandler(this.ArtistsManagement_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewWorkStyles)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox comboBoxWorkStyle;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.TextBox txtNationality;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox comboBoxArtistName;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnSaveArtist;
        private System.Windows.Forms.Button btnClearWorkStyle;
        private System.Windows.Forms.Button btnDeleteWorkStyle;
        private System.Windows.Forms.Button btnSaveWorkStyle;
        private System.Windows.Forms.TextBox txtWorkExperience;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DataGridView dataGridViewWorkStyles;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_artistId;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_Email;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_Nationality;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_Phone;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_ArtistName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_WorkStyle;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_WorkExperience;
    }
}