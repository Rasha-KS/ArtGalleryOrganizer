namespace ArtGalleryOrganizer
{
    partial class BookingManagement
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvBookings = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnSaveBooking = new System.Windows.Forms.Button();
            this.btnDeleteBooking = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.txtArtworksCount = new System.Windows.Forms.TextBox();
            this.txtTotalHours = new System.Windows.Forms.TextBox();
            this.dtpBookingDate = new System.Windows.Forms.DateTimePicker();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnPrint = new System.Windows.Forms.Button();
            this.lblStatus = new System.Windows.Forms.Label();
            this.lblCapacity = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtTotalPrice = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.cmbHall = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.cmbArtistName = new System.Windows.Forms.ComboBox();
            this.dtpTime = new System.Windows.Forms.DateTimePicker();
            this.txtPlusHours = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBookings)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvBookings
            // 
            this.dgvBookings.AllowUserToAddRows = false;
            this.dgvBookings.AllowUserToResizeRows = false;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.Transparent;
            this.dgvBookings.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle7;
            this.dgvBookings.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvBookings.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(122)))));
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(223)))), ((int)(((byte)(253)))));
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(122)))));
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvBookings.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle8;
            this.dgvBookings.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(122)))));
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvBookings.DefaultCellStyle = dataGridViewCellStyle9;
            this.dgvBookings.EnableHeadersVisualStyles = false;
            this.dgvBookings.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(237)))), ((int)(((byte)(226)))));
            this.dgvBookings.Location = new System.Drawing.Point(25, 266);
            this.dgvBookings.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgvBookings.MultiSelect = false;
            this.dgvBookings.Name = "dgvBookings";
            this.dgvBookings.ReadOnly = true;
            this.dgvBookings.RowHeadersVisible = false;
            this.dgvBookings.RowHeadersWidth = 51;
            this.dgvBookings.RowTemplate.Height = 26;
            this.dgvBookings.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvBookings.Size = new System.Drawing.Size(839, 328);
            this.dgvBookings.TabIndex = 0;
            this.dgvBookings.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvBookings_CellClick);
            this.dgvBookings.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvBookings_CellFormatting);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(122)))));
            this.label1.Location = new System.Drawing.Point(557, 70);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(104, 31);
            this.label1.TabIndex = 1;
            this.label1.Text = "Plus Hours";
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(122)))));
            this.label2.Location = new System.Drawing.Point(342, 116);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 29);
            this.label2.TabIndex = 2;
            this.label2.Text = " Date";
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(122)))));
            this.label3.Location = new System.Drawing.Point(343, 30);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(106, 31);
            this.label3.TabIndex = 3;
            this.label3.Text = "Start Time";
            // 
            // btnSaveBooking
            // 
            this.btnSaveBooking.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(122)))));
            this.btnSaveBooking.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSaveBooking.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(237)))), ((int)(((byte)(226)))));
            this.btnSaveBooking.Location = new System.Drawing.Point(30, 165);
            this.btnSaveBooking.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSaveBooking.Name = "btnSaveBooking";
            this.btnSaveBooking.Size = new System.Drawing.Size(167, 38);
            this.btnSaveBooking.TabIndex = 4;
            this.btnSaveBooking.Text = "Save Booking";
            this.btnSaveBooking.UseVisualStyleBackColor = false;
            this.btnSaveBooking.Click += new System.EventHandler(this.btnSaveBooking_Click);
            // 
            // btnDeleteBooking
            // 
            this.btnDeleteBooking.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(122)))));
            this.btnDeleteBooking.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeleteBooking.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(237)))), ((int)(((byte)(226)))));
            this.btnDeleteBooking.Location = new System.Drawing.Point(236, 165);
            this.btnDeleteBooking.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnDeleteBooking.Name = "btnDeleteBooking";
            this.btnDeleteBooking.Size = new System.Drawing.Size(167, 38);
            this.btnDeleteBooking.TabIndex = 5;
            this.btnDeleteBooking.Text = "Delete Booking";
            this.btnDeleteBooking.UseVisualStyleBackColor = false;
            this.btnDeleteBooking.Click += new System.EventHandler(this.btnDeleteBooking_Click);
            // 
            // btnClear
            // 
            this.btnClear.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(122)))));
            this.btnClear.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(237)))), ((int)(((byte)(226)))));
            this.btnClear.Location = new System.Drawing.Point(455, 165);
            this.btnClear.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(167, 38);
            this.btnClear.TabIndex = 6;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // txtArtworksCount
            // 
            this.txtArtworksCount.BackColor = System.Drawing.Color.White;
            this.txtArtworksCount.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtArtworksCount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(122)))));
            this.txtArtworksCount.Location = new System.Drawing.Point(485, 67);
            this.txtArtworksCount.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtArtworksCount.Name = "txtArtworksCount";
            this.txtArtworksCount.Size = new System.Drawing.Size(67, 29);
            this.txtArtworksCount.TabIndex = 7;
            this.txtArtworksCount.TextChanged += new System.EventHandler(this.txtArtworksCount_TextChanged);
            // 
            // txtTotalHours
            // 
            this.txtTotalHours.BackColor = System.Drawing.Color.White;
            this.txtTotalHours.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotalHours.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(122)))));
            this.txtTotalHours.Location = new System.Drawing.Point(765, 25);
            this.txtTotalHours.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtTotalHours.Name = "txtTotalHours";
            this.txtTotalHours.Size = new System.Drawing.Size(79, 29);
            this.txtTotalHours.TabIndex = 8;
            this.txtTotalHours.Leave += new System.EventHandler(this.txtTotalHours_Leave);
            // 
            // dtpBookingDate
            // 
            this.dtpBookingDate.CustomFormat = "dd/MM/yyyy";
            this.dtpBookingDate.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpBookingDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpBookingDate.Location = new System.Drawing.Point(422, 114);
            this.dtpBookingDate.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dtpBookingDate.Name = "dtpBookingDate";
            this.dtpBookingDate.Size = new System.Drawing.Size(171, 29);
            this.dtpBookingDate.TabIndex = 10;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnPrint);
            this.groupBox1.Controls.Add(this.lblStatus);
            this.groupBox1.Controls.Add(this.lblCapacity);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.txtTotalPrice);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.cmbHall);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.cmbArtistName);
            this.groupBox1.Controls.Add(this.txtArtworksCount);
            this.groupBox1.Controls.Add(this.dtpBookingDate);
            this.groupBox1.Controls.Add(this.dtpTime);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtTotalHours);
            this.groupBox1.Controls.Add(this.txtPlusHours);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.btnSaveBooking);
            this.groupBox1.Controls.Add(this.btnClear);
            this.groupBox1.Controls.Add(this.btnDeleteBooking);
            this.groupBox1.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(122)))));
            this.groupBox1.Location = new System.Drawing.Point(16, 11);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Size = new System.Drawing.Size(858, 239);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Booking Management";
            // 
            // btnPrint
            // 
            this.btnPrint.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(122)))));
            this.btnPrint.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrint.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(237)))), ((int)(((byte)(226)))));
            this.btnPrint.Location = new System.Drawing.Point(677, 165);
            this.btnPrint.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(167, 38);
            this.btnPrint.TabIndex = 28;
            this.btnPrint.Text = "Print Invoice";
            this.btnPrint.UseVisualStyleBackColor = false;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // lblStatus
            // 
            this.lblStatus.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblStatus.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(122)))));
            this.lblStatus.Location = new System.Drawing.Point(196, 117);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(135, 31);
            this.lblStatus.TabIndex = 27;
            this.lblStatus.Text = "Status";
            // 
            // lblCapacity
            // 
            this.lblCapacity.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblCapacity.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCapacity.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(122)))));
            this.lblCapacity.Location = new System.Drawing.Point(30, 117);
            this.lblCapacity.Name = "lblCapacity";
            this.lblCapacity.Size = new System.Drawing.Size(135, 31);
            this.lblCapacity.TabIndex = 26;
            this.lblCapacity.Text = "Hall capacity";
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(122)))));
            this.label7.Location = new System.Drawing.Point(26, 73);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(68, 31);
            this.label7.TabIndex = 25;
            this.label7.Text = "Hall";
            // 
            // txtTotalPrice
            // 
            this.txtTotalPrice.BackColor = System.Drawing.Color.White;
            this.txtTotalPrice.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotalPrice.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(122)))));
            this.txtTotalPrice.Location = new System.Drawing.Point(696, 114);
            this.txtTotalPrice.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtTotalPrice.Name = "txtTotalPrice";
            this.txtTotalPrice.Size = new System.Drawing.Size(148, 29);
            this.txtTotalPrice.TabIndex = 22;
            // 
            // label10
            // 
            this.label10.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(122)))));
            this.label10.Location = new System.Drawing.Point(633, 116);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(57, 31);
            this.label10.TabIndex = 23;
            this.label10.Text = "Price";
            // 
            // cmbHall
            // 
            this.cmbHall.BackColor = System.Drawing.Color.White;
            this.cmbHall.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbHall.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(122)))));
            this.cmbHall.FormattingEnabled = true;
            this.cmbHall.Items.AddRange(new object[] {
            "A1",
            "A2",
            "B1",
            "C1",
            "D1",
            "D2"});
            this.cmbHall.Location = new System.Drawing.Point(109, 73);
            this.cmbHall.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmbHall.Name = "cmbHall";
            this.cmbHall.Size = new System.Drawing.Size(222, 30);
            this.cmbHall.TabIndex = 24;
            this.cmbHall.SelectedIndexChanged += new System.EventHandler(this.cmbHall_SelectedIndexChanged);
            this.cmbHall.SelectionChangeCommitted += new System.EventHandler(this.cmbHall_SelectionChangeCommitted);
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(122)))));
            this.label8.Location = new System.Drawing.Point(747, 73);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(101, 46);
            this.label8.TabIndex = 19;
            this.label8.Text = "3% For Hour";
            // 
            // cmbArtistName
            // 
            this.cmbArtistName.BackColor = System.Drawing.Color.White;
            this.cmbArtistName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbArtistName.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbArtistName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(122)))));
            this.cmbArtistName.FormattingEnabled = true;
            this.cmbArtistName.Location = new System.Drawing.Point(109, 28);
            this.cmbArtistName.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmbArtistName.Name = "cmbArtistName";
            this.cmbArtistName.Size = new System.Drawing.Size(222, 30);
            this.cmbArtistName.TabIndex = 18;
            // 
            // dtpTime
            // 
            this.dtpTime.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpTime.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpTime.Location = new System.Drawing.Point(455, 26);
            this.dtpTime.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dtpTime.Name = "dtpTime";
            this.dtpTime.ShowUpDown = true;
            this.dtpTime.Size = new System.Drawing.Size(170, 29);
            this.dtpTime.TabIndex = 13;
            this.dtpTime.Leave += new System.EventHandler(this.dtpTime_Leave);
            // 
            // txtPlusHours
            // 
            this.txtPlusHours.BackColor = System.Drawing.Color.White;
            this.txtPlusHours.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPlusHours.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(122)))));
            this.txtPlusHours.Location = new System.Drawing.Point(662, 67);
            this.txtPlusHours.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtPlusHours.Name = "txtPlusHours";
            this.txtPlusHours.Size = new System.Drawing.Size(79, 29);
            this.txtPlusHours.TabIndex = 13;
            this.txtPlusHours.Text = "0";
            this.txtPlusHours.TextChanged += new System.EventHandler(this.txtPlusHours_TextChanged);
            this.txtPlusHours.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPlusHours_KeyPress);
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(122)))));
            this.label6.Location = new System.Drawing.Point(343, 70);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(145, 31);
            this.label6.TabIndex = 12;
            this.label6.Text = "Artworks Count";
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(122)))));
            this.label5.Location = new System.Drawing.Point(26, 31);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(95, 31);
            this.label5.TabIndex = 14;
            this.label5.Text = "Artist";
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(122)))));
            this.label4.Location = new System.Drawing.Point(650, 28);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(109, 31);
            this.label4.TabIndex = 12;
            this.label4.Text = "Total Hours";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(122)))));
            this.button1.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(237)))), ((int)(((byte)(226)))));
            this.button1.Location = new System.Drawing.Point(653, 606);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(211, 38);
            this.button1.TabIndex = 26;
            this.button1.Text = "Exit";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // BookingManagement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(237)))), ((int)(((byte)(226)))));
            this.ClientSize = new System.Drawing.Size(889, 655);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dgvBookings);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(122)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "BookingManagement";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "S";
            this.Load += new System.EventHandler(this.ExhibitionsManagement_Load);
            this.HandleCreated += new System.EventHandler(this.ExhibitionsManagement_HandleCreated);
            this.Resize += new System.EventHandler(this.ExhibitionsManagement_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.dgvBookings)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvBookings;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnSaveBooking;
        private System.Windows.Forms.Button btnDeleteBooking;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.TextBox txtArtworksCount;
        private System.Windows.Forms.TextBox txtTotalHours;
        private System.Windows.Forms.DateTimePicker dtpBookingDate;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cmbArtistName;
        private System.Windows.Forms.DateTimePicker dtpTime;
        private System.Windows.Forms.TextBox txtPlusHours;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbHall;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtTotalPrice;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label lblCapacity;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Button btnPrint;
    }
}