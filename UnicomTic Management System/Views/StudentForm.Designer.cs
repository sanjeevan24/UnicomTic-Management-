namespace UnicomTic_Management_System.Views
{
    partial class StudentForm
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
            lblStudentName = new Label();
            lblCourse = new Label();
            txtStudentName = new TextBox();
            cmbCourse = new ComboBox();
            btnAddStudent = new Button();
            btnUpdateStudent = new Button();
            btnDeleteStudent = new Button();
            dataGridViewStudents = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dataGridViewStudents).BeginInit();
            SuspendLayout();
            // 
            // lblStudentName
            // 
            lblStudentName.AutoSize = true;
            lblStudentName.Location = new Point(246, 95);
            lblStudentName.Name = "lblStudentName";
            lblStudentName.Size = new Size(120, 25);
            lblStudentName.TabIndex = 0;
            lblStudentName.Text = "StudentName";
            // 
            // lblCourse
            // 
            lblCourse.AutoSize = true;
            lblCourse.Location = new Point(256, 140);
            lblCourse.Name = "lblCourse";
            lblCourse.Size = new Size(67, 25);
            lblCourse.TabIndex = 1;
            lblCourse.Text = "Course";
            // 
            // txtStudentName
            // 
            txtStudentName.Location = new Point(372, 89);
            txtStudentName.Name = "txtStudentName";
            txtStudentName.Size = new Size(150, 31);
            txtStudentName.TabIndex = 2;
            // 
            // cmbCourse
            // 
            cmbCourse.FormattingEnabled = true;
            cmbCourse.Location = new Point(357, 132);
            cmbCourse.Name = "cmbCourse";
            cmbCourse.Size = new Size(182, 33);
            cmbCourse.TabIndex = 3;
            // 
            // btnAddStudent
            // 
            btnAddStudent.Location = new Point(217, 183);
            btnAddStudent.Name = "btnAddStudent";
            btnAddStudent.Size = new Size(112, 34);
            btnAddStudent.TabIndex = 4;
            btnAddStudent.Text = "Add";
            btnAddStudent.UseVisualStyleBackColor = true;
            btnAddStudent.Click += btnAddStudent_Click;
            // 
            // btnUpdateStudent
            // 
            btnUpdateStudent.Location = new Point(335, 183);
            btnUpdateStudent.Name = "btnUpdateStudent";
            btnUpdateStudent.Size = new Size(112, 34);
            btnUpdateStudent.TabIndex = 5;
            btnUpdateStudent.Text = "Update";
            btnUpdateStudent.UseVisualStyleBackColor = true;
            btnUpdateStudent.Click += btnUpdateStudent_Click;
            // 
            // btnDeleteStudent
            // 
            btnDeleteStudent.Location = new Point(453, 183);
            btnDeleteStudent.Name = "btnDeleteStudent";
            btnDeleteStudent.Size = new Size(112, 34);
            btnDeleteStudent.TabIndex = 6;
            btnDeleteStudent.Text = "Delete";
            btnDeleteStudent.UseVisualStyleBackColor = true;
            btnDeleteStudent.Click += btnDeleteStudent_Click;
            // 
            // dataGridViewStudents
            // 
            dataGridViewStudents.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewStudents.Location = new Point(205, 223);
            dataGridViewStudents.Name = "dataGridViewStudents";
            dataGridViewStudents.RowHeadersWidth = 62;
            dataGridViewStudents.Size = new Size(360, 225);
            dataGridViewStudents.TabIndex = 7;
            dataGridViewStudents.CellContentClick += dataGridViewStudents_CellContentClick;
            // 
            // StudentForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(dataGridViewStudents);
            Controls.Add(btnDeleteStudent);
            Controls.Add(btnUpdateStudent);
            Controls.Add(btnAddStudent);
            Controls.Add(cmbCourse);
            Controls.Add(txtStudentName);
            Controls.Add(lblCourse);
            Controls.Add(lblStudentName);
            Name = "StudentForm";
            Text = "StudentForm";
            ((System.ComponentModel.ISupportInitialize)dataGridViewStudents).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblStudentName;
        private Label lblCourse;
        private TextBox txtStudentName;
        private ComboBox cmbCourse;
        private Button btnAddStudent;
        private Button btnUpdateStudent;
        private Button btnDeleteStudent;
        private DataGridView dataGridViewStudents;
    }
}