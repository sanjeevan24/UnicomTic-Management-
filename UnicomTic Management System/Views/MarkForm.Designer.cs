namespace UnicomTic_Management_System.Views
{
    partial class MarkForm
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
            lblStudent = new Label();
            label2 = new Label();
            lblScore = new Label();
            cmbStudent = new ComboBox();
            cmbExam = new ComboBox();
            txtScore = new TextBox();
            btnAddMark = new Button();
            btnUpdateMark = new Button();
            btnDeleteMark = new Button();
            dataGridViewMarks = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dataGridViewMarks).BeginInit();
            SuspendLayout();
            // 
            // lblStudent
            // 
            lblStudent.AutoSize = true;
            lblStudent.Location = new Point(221, 61);
            lblStudent.Name = "lblStudent";
            lblStudent.Size = new Size(73, 25);
            lblStudent.TabIndex = 0;
            lblStudent.Text = "Student";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(221, 108);
            label2.Name = "label2";
            label2.Size = new Size(54, 25);
            label2.TabIndex = 1;
            label2.Text = "Exam";
            // 
            // lblScore
            // 
            lblScore.AutoSize = true;
            lblScore.Location = new Point(221, 145);
            lblScore.Name = "lblScore";
            lblScore.Size = new Size(61, 25);
            lblScore.TabIndex = 2;
            lblScore.Text = " Score";
            // 
            // cmbStudent
            // 
            cmbStudent.FormattingEnabled = true;
            cmbStudent.Location = new Point(338, 61);
            cmbStudent.Name = "cmbStudent";
            cmbStudent.Size = new Size(182, 33);
            cmbStudent.TabIndex = 3;
            // 
            // cmbExam
            // 
            cmbExam.FormattingEnabled = true;
            cmbExam.Location = new Point(338, 100);
            cmbExam.Name = "cmbExam";
            cmbExam.Size = new Size(182, 33);
            cmbExam.TabIndex = 4;
            // 
            // txtScore
            // 
            txtScore.Location = new Point(338, 139);
            txtScore.Name = "txtScore";
            txtScore.Size = new Size(150, 31);
            txtScore.TabIndex = 5;
            // 
            // btnAddMark
            // 
            btnAddMark.Location = new Point(237, 203);
            btnAddMark.Name = "btnAddMark";
            btnAddMark.Size = new Size(112, 34);
            btnAddMark.TabIndex = 6;
            btnAddMark.Text = "Add";
            btnAddMark.UseVisualStyleBackColor = true;
            btnAddMark.Click += btnAddMark_Click;
            // 
            // btnUpdateMark
            // 
            btnUpdateMark.Location = new Point(355, 203);
            btnUpdateMark.Name = "btnUpdateMark";
            btnUpdateMark.Size = new Size(112, 34);
            btnUpdateMark.TabIndex = 7;
            btnUpdateMark.Text = "update";
            btnUpdateMark.UseVisualStyleBackColor = true;
            btnUpdateMark.Click += btnUpdateMark_Click;
            // 
            // btnDeleteMark
            // 
            btnDeleteMark.Location = new Point(473, 203);
            btnDeleteMark.Name = "btnDeleteMark";
            btnDeleteMark.Size = new Size(112, 34);
            btnDeleteMark.TabIndex = 8;
            btnDeleteMark.Text = "Delete";
            btnDeleteMark.UseVisualStyleBackColor = true;
            btnDeleteMark.Click += btnDeleteMark_Click;
            // 
            // dataGridViewMarks
            // 
            dataGridViewMarks.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewMarks.Location = new Point(221, 243);
            dataGridViewMarks.Name = "dataGridViewMarks";
            dataGridViewMarks.RowHeadersWidth = 62;
            dataGridViewMarks.Size = new Size(388, 209);
            dataGridViewMarks.TabIndex = 9;
            dataGridViewMarks.CellContentClick += dataGridViewMarks_CellContentClick;
            // 
            // MarkForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(dataGridViewMarks);
            Controls.Add(btnDeleteMark);
            Controls.Add(btnUpdateMark);
            Controls.Add(btnAddMark);
            Controls.Add(txtScore);
            Controls.Add(cmbExam);
            Controls.Add(cmbStudent);
            Controls.Add(lblScore);
            Controls.Add(label2);
            Controls.Add(lblStudent);
            Name = "MarkForm";
            Text = "MarkForm";
            ((System.ComponentModel.ISupportInitialize)dataGridViewMarks).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblStudent;
        private Label label2;
        private Label lblScore;
        private ComboBox cmbStudent;
        private ComboBox cmbExam;
        private TextBox txtScore;
        private Button btnAddMark;
        private Button btnUpdateMark;
        private Button btnDeleteMark;
        private DataGridView dataGridViewMarks;
    }
}