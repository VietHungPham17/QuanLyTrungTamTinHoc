namespace QuanLyTrungTamTinHoc
{
    partial class FrmFindCourse
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.cmbSearchToolStripComboBox = new System.Windows.Forms.ToolStripComboBox();
            this.txtSearchToolStripTextBox = new System.Windows.Forms.ToolStripTextBox();
            this.quitToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.selectToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.editToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.deleteToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.dgvCourse = new System.Windows.Forms.DataGridView();
            this.CourseID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CourseName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LevelID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Tuition = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Time = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Schedule = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Opening = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClosingCourse = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EmployeeID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Number = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Status = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Room = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Level = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Employee = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Attendances = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Registers = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Groups = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Transcripts = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCourse)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip
            // 
            this.toolStrip.BackColor = System.Drawing.Color.Gainsboro;
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmbSearchToolStripComboBox,
            this.txtSearchToolStripTextBox,
            this.quitToolStripButton,
            this.selectToolStripButton,
            this.toolStripSeparator4,
            this.editToolStripButton,
            this.deleteToolStripButton,
            this.toolStripSeparator1});
            this.toolStrip.Location = new System.Drawing.Point(0, 0);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Size = new System.Drawing.Size(716, 25);
            this.toolStrip.TabIndex = 59;
            this.toolStrip.Text = "toolStrip";
            // 
            // cmbSearchToolStripComboBox
            // 
            this.cmbSearchToolStripComboBox.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.cmbSearchToolStripComboBox.BackColor = System.Drawing.Color.Gainsboro;
            this.cmbSearchToolStripComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSearchToolStripComboBox.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbSearchToolStripComboBox.Items.AddRange(new object[] {
            "Mã khóa học",
            "Tên khóa học"});
            this.cmbSearchToolStripComboBox.Name = "cmbSearchToolStripComboBox";
            this.cmbSearchToolStripComboBox.Size = new System.Drawing.Size(121, 25);
            // 
            // txtSearchToolStripTextBox
            // 
            this.txtSearchToolStripTextBox.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.txtSearchToolStripTextBox.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtSearchToolStripTextBox.Name = "txtSearchToolStripTextBox";
            this.txtSearchToolStripTextBox.Size = new System.Drawing.Size(200, 25);
            // 
            // quitToolStripButton
            // 
            this.quitToolStripButton.Image = global::QuanLyTrungTamTinHoc.Properties.Resources.close;
            this.quitToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.quitToolStripButton.Name = "quitToolStripButton";
            this.quitToolStripButton.Size = new System.Drawing.Size(58, 22);
            this.quitToolStripButton.Text = "Thoát";
            this.quitToolStripButton.Click += new System.EventHandler(this.quitToolStripButton_Click);
            // 
            // selectToolStripButton
            // 
            this.selectToolStripButton.Image = global::QuanLyTrungTamTinHoc.Properties.Resources.bindingNavigatorAddNewItem_Image;
            this.selectToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.selectToolStripButton.Name = "selectToolStripButton";
            this.selectToolStripButton.Size = new System.Drawing.Size(56, 22);
            this.selectToolStripButton.Text = "Chọn";
            this.selectToolStripButton.Click += new System.EventHandler(this.selectToolStripButton_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
            // 
            // editToolStripButton
            // 
            this.editToolStripButton.Image = global::QuanLyTrungTamTinHoc.Properties.Resources.saveToolStripButton_Image;
            this.editToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.editToolStripButton.Name = "editToolStripButton";
            this.editToolStripButton.Size = new System.Drawing.Size(46, 22);
            this.editToolStripButton.Text = "Sửa";
            this.editToolStripButton.Click += new System.EventHandler(this.editToolStripButton_Click);
            // 
            // deleteToolStripButton
            // 
            this.deleteToolStripButton.Image = global::QuanLyTrungTamTinHoc.Properties.Resources.bindingNavigatorDeleteItem_Image;
            this.deleteToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.deleteToolStripButton.Name = "deleteToolStripButton";
            this.deleteToolStripButton.Size = new System.Drawing.Size(47, 22);
            this.deleteToolStripButton.Text = "Xóa";
            this.deleteToolStripButton.Click += new System.EventHandler(this.deleteToolStripButton_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // dgvCourse
            // 
            this.dgvCourse.AllowUserToAddRows = false;
            this.dgvCourse.AllowUserToOrderColumns = true;
            this.dgvCourse.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            this.dgvCourse.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvCourse.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dgvCourse.BackgroundColor = System.Drawing.Color.White;
            this.dgvCourse.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvCourse.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.Gainsboro;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvCourse.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvCourse.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCourse.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CourseID,
            this.CourseName,
            this.LevelID,
            this.Tuition,
            this.Time,
            this.Schedule,
            this.Opening,
            this.ClosingCourse,
            this.EmployeeID,
            this.Number,
            this.Status,
            this.Room,
            this.Level,
            this.Employee,
            this.Attendances,
            this.Registers,
            this.Groups,
            this.Transcripts});
            this.dgvCourse.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvCourse.Location = new System.Drawing.Point(0, 25);
            this.dgvCourse.Name = "dgvCourse";
            this.dgvCourse.ReadOnly = true;
            this.dgvCourse.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvCourse.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.Black;
            this.dgvCourse.RowsDefaultCellStyle = dataGridViewCellStyle7;
            this.dgvCourse.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCourse.Size = new System.Drawing.Size(716, 249);
            this.dgvCourse.TabIndex = 60;
            this.dgvCourse.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvCourse_CellMouseDoubleClick);
            // 
            // CourseID
            // 
            this.CourseID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.CourseID.DataPropertyName = "CourseID";
            this.CourseID.Frozen = true;
            this.CourseID.HeaderText = "Mã khóa học";
            this.CourseID.Name = "CourseID";
            this.CourseID.ReadOnly = true;
            this.CourseID.Width = 120;
            // 
            // CourseName
            // 
            this.CourseName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.CourseName.DataPropertyName = "CourseName";
            this.CourseName.HeaderText = "Tên khóa học";
            this.CourseName.Name = "CourseName";
            this.CourseName.ReadOnly = true;
            this.CourseName.Width = 120;
            // 
            // LevelID
            // 
            this.LevelID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.LevelID.DataPropertyName = "LevelID";
            this.LevelID.HeaderText = "Mã cấp độ";
            this.LevelID.Name = "LevelID";
            this.LevelID.ReadOnly = true;
            this.LevelID.Visible = false;
            this.LevelID.Width = 120;
            // 
            // Tuition
            // 
            this.Tuition.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Tuition.DataPropertyName = "Tuition";
            dataGridViewCellStyle3.Format = "C0";
            dataGridViewCellStyle3.NullValue = null;
            this.Tuition.DefaultCellStyle = dataGridViewCellStyle3;
            this.Tuition.HeaderText = "Học phí";
            this.Tuition.Name = "Tuition";
            this.Tuition.ReadOnly = true;
            this.Tuition.Width = 120;
            // 
            // Time
            // 
            this.Time.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Time.DataPropertyName = "Time";
            this.Time.HeaderText = "Thời gian";
            this.Time.Name = "Time";
            this.Time.ReadOnly = true;
            this.Time.Width = 120;
            // 
            // Schedule
            // 
            this.Schedule.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Schedule.DataPropertyName = "Schedule";
            this.Schedule.HeaderText = "Thời khóa biểu";
            this.Schedule.Name = "Schedule";
            this.Schedule.ReadOnly = true;
            this.Schedule.Width = 120;
            // 
            // Opening
            // 
            this.Opening.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Opening.DataPropertyName = "Opening";
            dataGridViewCellStyle4.Format = "dd/MM/yyyy";
            this.Opening.DefaultCellStyle = dataGridViewCellStyle4;
            this.Opening.HeaderText = "Bắt đầu";
            this.Opening.Name = "Opening";
            this.Opening.ReadOnly = true;
            this.Opening.Width = 120;
            // 
            // ClosingCourse
            // 
            this.ClosingCourse.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.ClosingCourse.DataPropertyName = "Closing";
            dataGridViewCellStyle5.Format = "dd/MM/yyyy";
            this.ClosingCourse.DefaultCellStyle = dataGridViewCellStyle5;
            this.ClosingCourse.HeaderText = "Kết thúc";
            this.ClosingCourse.Name = "ClosingCourse";
            this.ClosingCourse.ReadOnly = true;
            this.ClosingCourse.Width = 120;
            // 
            // EmployeeID
            // 
            this.EmployeeID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.EmployeeID.DataPropertyName = "EmployeeID";
            this.EmployeeID.HeaderText = "Giáo viên";
            this.EmployeeID.Name = "EmployeeID";
            this.EmployeeID.ReadOnly = true;
            this.EmployeeID.Width = 120;
            // 
            // Number
            // 
            this.Number.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Number.DataPropertyName = "Number";
            this.Number.HeaderText = "Sỉ số";
            this.Number.Name = "Number";
            this.Number.ReadOnly = true;
            // 
            // Status
            // 
            this.Status.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Status.DataPropertyName = "Status";
            this.Status.HeaderText = "Trạng thái";
            this.Status.Name = "Status";
            this.Status.ReadOnly = true;
            this.Status.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Status.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // Room
            // 
            this.Room.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Room.DataPropertyName = "Room";
            this.Room.HeaderText = "Phòng học";
            this.Room.Name = "Room";
            this.Room.ReadOnly = true;
            // 
            // Level
            // 
            this.Level.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Level.DataPropertyName = "Level";
            this.Level.HeaderText = "Cấp độ";
            this.Level.Name = "Level";
            this.Level.ReadOnly = true;
            this.Level.Visible = false;
            // 
            // Employee
            // 
            this.Employee.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Employee.DataPropertyName = "Employee";
            this.Employee.HeaderText = "Giáo viên";
            this.Employee.Name = "Employee";
            this.Employee.ReadOnly = true;
            this.Employee.Visible = false;
            this.Employee.Width = 120;
            // 
            // Attendances
            // 
            this.Attendances.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Attendances.DataPropertyName = "Attendances";
            this.Attendances.HeaderText = "Điểm danh";
            this.Attendances.Name = "Attendances";
            this.Attendances.ReadOnly = true;
            this.Attendances.Visible = false;
            this.Attendances.Width = 77;
            // 
            // Registers
            // 
            this.Registers.DataPropertyName = "Registers";
            this.Registers.HeaderText = "Đăng ký";
            this.Registers.Name = "Registers";
            this.Registers.ReadOnly = true;
            this.Registers.Visible = false;
            this.Registers.Width = 72;
            // 
            // Groups
            // 
            this.Groups.DataPropertyName = "Groups";
            this.Groups.HeaderText = "Nhóm";
            this.Groups.Name = "Groups";
            this.Groups.ReadOnly = true;
            this.Groups.Visible = false;
            this.Groups.Width = 60;
            // 
            // Transcripts
            // 
            this.Transcripts.DataPropertyName = "Transcripts";
            this.Transcripts.HeaderText = "Bảng điểm";
            this.Transcripts.Name = "Transcripts";
            this.Transcripts.ReadOnly = true;
            this.Transcripts.Visible = false;
            this.Transcripts.Width = 83;
            // 
            // FrmFindCourse
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(716, 274);
            this.Controls.Add(this.dgvCourse);
            this.Controls.Add(this.toolStrip);
            this.Name = "FrmFindCourse";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Tìm khóa học";
            this.Load += new System.EventHandler(this.FrmFindCourse_Load);
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCourse)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ToolStripComboBox cmbSearchToolStripComboBox;
        private System.Windows.Forms.ToolStripTextBox txtSearchToolStripTextBox;
        private System.Windows.Forms.ToolStripButton quitToolStripButton;
        private System.Windows.Forms.ToolStripButton selectToolStripButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripButton editToolStripButton;
        private System.Windows.Forms.ToolStripButton deleteToolStripButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.DataGridView dgvCourse;
        private System.Windows.Forms.DataGridViewTextBoxColumn CourseID;
        private System.Windows.Forms.DataGridViewTextBoxColumn CourseName;
        private System.Windows.Forms.DataGridViewTextBoxColumn LevelID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tuition;
        private System.Windows.Forms.DataGridViewTextBoxColumn Time;
        private System.Windows.Forms.DataGridViewTextBoxColumn Schedule;
        private System.Windows.Forms.DataGridViewTextBoxColumn Opening;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClosingCourse;
        private System.Windows.Forms.DataGridViewTextBoxColumn EmployeeID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Number;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Status;
        private System.Windows.Forms.DataGridViewTextBoxColumn Room;
        private System.Windows.Forms.DataGridViewTextBoxColumn Level;
        private System.Windows.Forms.DataGridViewTextBoxColumn Employee;
        private System.Windows.Forms.DataGridViewTextBoxColumn Attendances;
        private System.Windows.Forms.DataGridViewTextBoxColumn Registers;
        private System.Windows.Forms.DataGridViewTextBoxColumn Groups;
        private System.Windows.Forms.DataGridViewTextBoxColumn Transcripts;
    }
}