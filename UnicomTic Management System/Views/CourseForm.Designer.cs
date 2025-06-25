namespace UnicomTic_Management_System.Views
{
    partial class CourseForm
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
            lblCourseName = new Label();
            txtCourseName = new TextBox();
            btnAddCourse = new Button();
            btnUpdateCourse = new Button();
            btnDeleteCourse = new Button();
            dataGridViewCourses = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dataGridViewCourses).BeginInit();
            SuspendLayout();
            // 
            // lblCourseName
            // 
            lblCourseName.AutoSize = true;
            lblCourseName.Location = new Point(341, 142);
            lblCourseName.Name = "lblCourseName";
            lblCourseName.Size = new Size(114, 25);
            lblCourseName.TabIndex = 0;
            lblCourseName.Text = "CourseName";
            // 
            // txtCourseName
            // 
            txtCourseName.Location = new Point(462, 139);
            txtCourseName.Name = "txtCourseName";
            txtCourseName.Size = new Size(150, 31);
            txtCourseName.TabIndex = 1;
            // 
            // btnAddCourse
            // 
            btnAddCourse.Location = new Point(259, 227);
            btnAddCourse.Name = "btnAddCourse";
            btnAddCourse.Size = new Size(112, 34);
            btnAddCourse.TabIndex = 2;
            btnAddCourse.Text = "ADD";
            btnAddCourse.UseVisualStyleBackColor = true;
            btnAddCourse.Click += btnAddCourse_Click;
            // 
            // btnUpdateCourse
            // 
            btnUpdateCourse.Location = new Point(419, 227);
            btnUpdateCourse.Name = "btnUpdateCourse";
            btnUpdateCourse.Size = new Size(112, 34);
            btnUpdateCourse.TabIndex = 3;
            btnUpdateCourse.Text = "Update";
            btnUpdateCourse.UseVisualStyleBackColor = true;
            btnUpdateCourse.Click += btnUpdateCourse_Click;
            // 
            // btnDeleteCourse
            // 
            btnDeleteCourse.Location = new Point(586, 227);
            btnDeleteCourse.Name = "btnDeleteCourse";
            btnDeleteCourse.Size = new Size(112, 34);
            btnDeleteCourse.TabIndex = 4;
            btnDeleteCourse.Text = "Delete";
            btnDeleteCourse.UseVisualStyleBackColor = true;
            btnDeleteCourse.Click += btnDeleteCourse_Click;
            // 
            // dataGridViewCourses
            // 
            dataGridViewCourses.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCourses.Location = new Point(234, 267);
            dataGridViewCourses.Name = "dataGridViewCourses";
            dataGridViewCourses.RowHeadersWidth = 62;
            dataGridViewCourses.Size = new Size(464, 225);
            dataGridViewCourses.TabIndex = 5;
            dataGridViewCourses.CellContentClick += dataGridViewCourses_CellContentClick;
            // 
            // CourseForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(942, 504);
            Controls.Add(dataGridViewCourses);
            Controls.Add(btnDeleteCourse);
            Controls.Add(btnUpdateCourse);
            Controls.Add(btnAddCourse);
            Controls.Add(txtCourseName);
            Controls.Add(lblCourseName);
            Name = "CourseForm";
            Text = "CourseForm";
            ((System.ComponentModel.ISupportInitialize)dataGridViewCourses).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblCourseName;
        private TextBox txtCourseName;
        private Button btnAddCourse;
        private Button btnUpdateCourse;
        private Button btnDeleteCourse;
        private DataGridView dataGridViewCourses;
    }
}