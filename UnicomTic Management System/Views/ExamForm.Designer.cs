namespace UnicomTic_Management_System.Views
{
    partial class ExamForm
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
            lblExamName = new Label();
            lblSubject = new Label();
            txtExamName = new TextBox();
            cmbSubject = new ComboBox();
            btnAddExam = new Button();
            btnUpdateExam = new Button();
            btnDeleteExam = new Button();
            dataGridViewExams = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dataGridViewExams).BeginInit();
            SuspendLayout();
            // 
            // lblExamName
            // 
            lblExamName.AutoSize = true;
            lblExamName.Location = new Point(227, 79);
            lblExamName.Name = "lblExamName";
            lblExamName.Size = new Size(101, 25);
            lblExamName.TabIndex = 0;
            lblExamName.Text = "ExamName";
            // 
            // lblSubject
            // 
            lblSubject.AutoSize = true;
            lblSubject.Location = new Point(227, 150);
            lblSubject.Name = "lblSubject";
            lblSubject.Size = new Size(70, 25);
            lblSubject.TabIndex = 1;
            lblSubject.Text = "Subject";
            // 
            // txtExamName
            // 
            txtExamName.Location = new Point(345, 76);
            txtExamName.Name = "txtExamName";
            txtExamName.Size = new Size(150, 31);
            txtExamName.TabIndex = 2;
            // 
            // cmbSubject
            // 
            cmbSubject.FormattingEnabled = true;
            cmbSubject.Location = new Point(345, 147);
            cmbSubject.Name = "cmbSubject";
            cmbSubject.Size = new Size(182, 33);
            cmbSubject.TabIndex = 3;
            // 
            // btnAddExam
            // 
            btnAddExam.Location = new Point(244, 195);
            btnAddExam.Name = "btnAddExam";
            btnAddExam.Size = new Size(112, 34);
            btnAddExam.TabIndex = 4;
            btnAddExam.Text = "Add";
            btnAddExam.UseVisualStyleBackColor = true;
            btnAddExam.Click += btnAddExam_Click;
            // 
            // btnUpdateExam
            // 
            btnUpdateExam.Location = new Point(383, 195);
            btnUpdateExam.Name = "btnUpdateExam";
            btnUpdateExam.Size = new Size(112, 34);
            btnUpdateExam.TabIndex = 5;
            btnUpdateExam.Text = "Update";
            btnUpdateExam.UseVisualStyleBackColor = true;
            btnUpdateExam.Click += btnUpdateExam_Click;
            // 
            // btnDeleteExam
            // 
            btnDeleteExam.Location = new Point(523, 196);
            btnDeleteExam.Name = "btnDeleteExam";
            btnDeleteExam.Size = new Size(112, 34);
            btnDeleteExam.TabIndex = 6;
            btnDeleteExam.Text = "Delete";
            btnDeleteExam.UseVisualStyleBackColor = true;
            btnDeleteExam.Click += btnDeleteExam_Click;
            // 
            // dataGridViewExams
            // 
            dataGridViewExams.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewExams.Location = new Point(218, 236);
            dataGridViewExams.Name = "dataGridViewExams";
            dataGridViewExams.RowHeadersWidth = 62;
            dataGridViewExams.Size = new Size(442, 213);
            dataGridViewExams.TabIndex = 7;
            dataGridViewExams.CellContentClick += dataGridViewExams_CellContentClick;
            // 
            // ExamForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(dataGridViewExams);
            Controls.Add(btnDeleteExam);
            Controls.Add(btnUpdateExam);
            Controls.Add(btnAddExam);
            Controls.Add(cmbSubject);
            Controls.Add(txtExamName);
            Controls.Add(lblSubject);
            Controls.Add(lblExamName);
            Name = "ExamForm";
            Text = "ExamForm";
            ((System.ComponentModel.ISupportInitialize)dataGridViewExams).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblExamName;
        private Label lblSubject;
        private TextBox txtExamName;
        private ComboBox cmbSubject;
        private Button btnAddExam;
        private Button btnUpdateExam;
        private Button btnDeleteExam;
        private DataGridView dataGridViewExams;
    }
}