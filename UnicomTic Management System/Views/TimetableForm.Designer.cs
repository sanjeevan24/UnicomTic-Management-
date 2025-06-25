namespace UnicomTic_Management_System.Views
{
    partial class TimetableForm
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
            lblSubject = new Label();
            lblTimeSlot = new Label();
            lblRoom = new Label();
            cmbSubject = new ComboBox();
            cmbRoom = new ComboBox();
            txtTimeSlot = new TextBox();
            btnAddTimetable = new Button();
            btnUpdateTimetable = new Button();
            btnDeleteTimetable = new Button();
            dataGridViewTimetables = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dataGridViewTimetables).BeginInit();
            SuspendLayout();
            // 
            // lblSubject
            // 
            lblSubject.AutoSize = true;
            lblSubject.Location = new Point(146, 73);
            lblSubject.Name = "lblSubject";
            lblSubject.Size = new Size(70, 25);
            lblSubject.TabIndex = 0;
            lblSubject.Text = "Subject";
            // 
            // lblTimeSlot
            // 
            lblTimeSlot.AutoSize = true;
            lblTimeSlot.Location = new Point(146, 122);
            lblTimeSlot.Name = "lblTimeSlot";
            lblTimeSlot.Size = new Size(81, 25);
            lblTimeSlot.TabIndex = 1;
            lblTimeSlot.Text = "TimeSlot";
            // 
            // lblRoom
            // 
            lblRoom.AutoSize = true;
            lblRoom.Location = new Point(146, 175);
            lblRoom.Name = "lblRoom";
            lblRoom.Size = new Size(60, 25);
            lblRoom.TabIndex = 2;
            lblRoom.Text = "Room";
            // 
            // cmbSubject
            // 
            cmbSubject.FormattingEnabled = true;
            cmbSubject.Location = new Point(293, 65);
            cmbSubject.Name = "cmbSubject";
            cmbSubject.Size = new Size(182, 33);
            cmbSubject.TabIndex = 3;
            // 
            // cmbRoom
            // 
            cmbRoom.FormattingEnabled = true;
            cmbRoom.Location = new Point(293, 167);
            cmbRoom.Name = "cmbRoom";
            cmbRoom.Size = new Size(182, 33);
            cmbRoom.TabIndex = 4;
            // 
            // txtTimeSlot
            // 
            txtTimeSlot.Location = new Point(293, 116);
            txtTimeSlot.Name = "txtTimeSlot";
            txtTimeSlot.Size = new Size(150, 31);
            txtTimeSlot.TabIndex = 5;
            // 
            // btnAddTimetable
            // 
            btnAddTimetable.Location = new Point(198, 211);
            btnAddTimetable.Name = "btnAddTimetable";
            btnAddTimetable.Size = new Size(112, 34);
            btnAddTimetable.TabIndex = 6;
            btnAddTimetable.Text = "Add";
            btnAddTimetable.UseVisualStyleBackColor = true;
            btnAddTimetable.Click += btnAddTimetable_Click;
            // 
            // btnUpdateTimetable
            // 
            btnUpdateTimetable.Location = new Point(319, 211);
            btnUpdateTimetable.Name = "btnUpdateTimetable";
            btnUpdateTimetable.Size = new Size(112, 34);
            btnUpdateTimetable.TabIndex = 7;
            btnUpdateTimetable.Text = "Update";
            btnUpdateTimetable.UseVisualStyleBackColor = true;
            btnUpdateTimetable.Click += btnUpdateTimetable_Click;
            // 
            // btnDeleteTimetable
            // 
            btnDeleteTimetable.Location = new Point(446, 211);
            btnDeleteTimetable.Name = "btnDeleteTimetable";
            btnDeleteTimetable.Size = new Size(112, 34);
            btnDeleteTimetable.TabIndex = 8;
            btnDeleteTimetable.Text = "Delete";
            btnDeleteTimetable.UseVisualStyleBackColor = true;
            btnDeleteTimetable.Click += btnDeleteTimetable_Click;
            // 
            // dataGridViewTimetables
            // 
            dataGridViewTimetables.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewTimetables.Location = new Point(198, 251);
            dataGridViewTimetables.Name = "dataGridViewTimetables";
            dataGridViewTimetables.RowHeadersWidth = 62;
            dataGridViewTimetables.Size = new Size(360, 225);
            dataGridViewTimetables.TabIndex = 9;
            dataGridViewTimetables.CellContentClick += dataGridViewTimetables_CellContentClick;
            // 
            // TimetableForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(dataGridViewTimetables);
            Controls.Add(btnDeleteTimetable);
            Controls.Add(btnUpdateTimetable);
            Controls.Add(btnAddTimetable);
            Controls.Add(txtTimeSlot);
            Controls.Add(cmbRoom);
            Controls.Add(cmbSubject);
            Controls.Add(lblRoom);
            Controls.Add(lblTimeSlot);
            Controls.Add(lblSubject);
            Name = "TimetableForm";
            Text = "TimetableForm";
            ((System.ComponentModel.ISupportInitialize)dataGridViewTimetables).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblSubject;
        private Label lblTimeSlot;
        private Label lblRoom;
        private ComboBox cmbSubject;
        private ComboBox cmbRoom;
        private TextBox txtTimeSlot;
        private Button btnAddTimetable;
        private Button btnUpdateTimetable;
        private Button btnDeleteTimetable;
        private DataGridView dataGridViewTimetables;
    }
}