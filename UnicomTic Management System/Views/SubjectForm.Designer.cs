namespace UnicomTic_Management_System.Views
{
    partial class SubjectForm
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
            lblSubjectName = new Label();
            lblCourse = new Label();
            txtSubjectName = new TextBox();
            cmbCourse = new ComboBox();
            btnAddSubject = new Button();
            btnUpdateSubject = new Button();
            btnDeleteSubject = new Button();
            dataGridViewSubjects = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dataGridViewSubjects).BeginInit();
            SuspendLayout();
            // 
            // lblSubjectName
            // 
            lblSubjectName.AutoSize = true;
            lblSubjectName.Location = new Point(196, 98);
            lblSubjectName.Name = "lblSubjectName";
            lblSubjectName.Size = new Size(126, 25);
            lblSubjectName.TabIndex = 0;
            lblSubjectName.Text = "SubejectName";
            // 
            // lblCourse
            // 
            lblCourse.AutoSize = true;
            lblCourse.Location = new Point(206, 137);
            lblCourse.Name = "lblCourse";
            lblCourse.Size = new Size(67, 25);
            lblCourse.TabIndex = 1;
            lblCourse.Text = "Course";
            // 
            // txtSubjectName
            // 
            txtSubjectName.Location = new Point(328, 95);
            txtSubjectName.Name = "txtSubjectName";
            txtSubjectName.Size = new Size(150, 31);
            txtSubjectName.TabIndex = 2;
            // 
            // cmbCourse
            // 
            cmbCourse.FormattingEnabled = true;
            cmbCourse.Location = new Point(296, 129);
            cmbCourse.Name = "cmbCourse";
            cmbCourse.Size = new Size(182, 33);
            cmbCourse.TabIndex = 3;
            // 
            // btnAddSubject
            // 
            btnAddSubject.Location = new Point(166, 188);
            btnAddSubject.Name = "btnAddSubject";
            btnAddSubject.Size = new Size(112, 34);
            btnAddSubject.TabIndex = 4;
            btnAddSubject.Text = "Add";
            btnAddSubject.UseVisualStyleBackColor = true;
            btnAddSubject.Click += btnAddSubject_Click;
            // 
            // btnUpdateSubject
            // 
            btnUpdateSubject.Location = new Point(296, 188);
            btnUpdateSubject.Name = "btnUpdateSubject";
            btnUpdateSubject.Size = new Size(112, 34);
            btnUpdateSubject.TabIndex = 5;
            btnUpdateSubject.Text = "Update";
            btnUpdateSubject.UseVisualStyleBackColor = true;
            btnUpdateSubject.Click += btnUpdateSubject_Click;
            // 
            // btnDeleteSubject
            // 
            btnDeleteSubject.Location = new Point(414, 188);
            btnDeleteSubject.Name = "btnDeleteSubject";
            btnDeleteSubject.Size = new Size(112, 34);
            btnDeleteSubject.TabIndex = 6;
            btnDeleteSubject.Text = "Delete";
            btnDeleteSubject.UseVisualStyleBackColor = true;
            btnDeleteSubject.Click += btnDeleteSubject_Click;
            // 
            // dataGridViewSubjects
            // 
            dataGridViewSubjects.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewSubjects.Location = new Point(166, 228);
            dataGridViewSubjects.Name = "dataGridViewSubjects";
            dataGridViewSubjects.RowHeadersWidth = 62;
            dataGridViewSubjects.Size = new Size(360, 225);
            dataGridViewSubjects.TabIndex = 7;
            dataGridViewSubjects.CellContentClick += dataGridViewSubjects_CellContentClick;
            // 
            // SubjectForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(dataGridViewSubjects);
            Controls.Add(btnDeleteSubject);
            Controls.Add(btnUpdateSubject);
            Controls.Add(btnAddSubject);
            Controls.Add(cmbCourse);
            Controls.Add(txtSubjectName);
            Controls.Add(lblCourse);
            Controls.Add(lblSubjectName);
            Name = "SubjectForm";
            Text = "SubjectForm";
            ((System.ComponentModel.ISupportInitialize)dataGridViewSubjects).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblSubjectName;
        private Label lblCourse;
        private TextBox txtSubjectName;
        private ComboBox cmbCourse;
        private Button btnAddSubject;
        private Button btnUpdateSubject;
        private Button btnDeleteSubject;
        private DataGridView dataGridViewSubjects;
    }
}