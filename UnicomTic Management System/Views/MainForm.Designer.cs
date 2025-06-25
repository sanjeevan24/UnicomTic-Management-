namespace UnicomTic_Management_System.Views
{
    partial class MainForm
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
            lblWelcome = new Label();
            btnExams = new Button();
            btnCourses = new Button();
            btnStudents = new Button();
            btnMarks = new Button();
            btnTimetable = new Button();
            btnSubjects = new Button();
            btnLogout = new Button();
            btnRooms = new Button();
            SuspendLayout();
            // 
            // lblWelcome
            // 
            lblWelcome.AutoSize = true;
            lblWelcome.Location = new Point(346, 50);
            lblWelcome.Name = "lblWelcome";
            lblWelcome.Size = new Size(85, 25);
            lblWelcome.TabIndex = 0;
            lblWelcome.Text = "Welcome";
            // 
            // btnExams
            // 
            btnExams.Location = new Point(478, 132);
            btnExams.Name = "btnExams";
            btnExams.Size = new Size(188, 34);
            btnExams.TabIndex = 2;
            btnExams.Text = "ManageExams";
            btnExams.UseVisualStyleBackColor = true;
            btnExams.Click += btnExams_Click;
            // 
            // btnCourses
            // 
            btnCourses.Location = new Point(138, 132);
            btnCourses.Name = "btnCourses";
            btnCourses.Size = new Size(188, 34);
            btnCourses.TabIndex = 3;
            btnCourses.Text = "manageCourses";
            btnCourses.UseVisualStyleBackColor = true;
            btnCourses.Click += btnCourses_Click;
            // 
            // btnStudents
            // 
            btnStudents.Location = new Point(138, 190);
            btnStudents.Name = "btnStudents";
            btnStudents.Size = new Size(188, 34);
            btnStudents.TabIndex = 4;
            btnStudents.Text = "ManageStudents";
            btnStudents.UseVisualStyleBackColor = true;
            btnStudents.Click += btnStudents_Click;
            // 
            // btnMarks
            // 
            btnMarks.Location = new Point(478, 190);
            btnMarks.Name = "btnMarks";
            btnMarks.Size = new Size(188, 34);
            btnMarks.TabIndex = 5;
            btnMarks.Text = "ManageMarks";
            btnMarks.UseVisualStyleBackColor = true;
            btnMarks.Click += btnMarks_Click;
            // 
            // btnTimetable
            // 
            btnTimetable.Location = new Point(478, 248);
            btnTimetable.Name = "btnTimetable";
            btnTimetable.Size = new Size(188, 34);
            btnTimetable.TabIndex = 6;
            btnTimetable.Text = "ManageTimetable";
            btnTimetable.UseVisualStyleBackColor = true;
            btnTimetable.Click += btnTimetable_Click;
            // 
            // btnSubjects
            // 
            btnSubjects.Location = new Point(138, 248);
            btnSubjects.Name = "btnSubjects";
            btnSubjects.Size = new Size(188, 34);
            btnSubjects.TabIndex = 7;
            btnSubjects.Text = "ManageSubject";
            btnSubjects.UseVisualStyleBackColor = true;
            btnSubjects.Click += btnSubjects_Click;
            // 
            // btnLogout
            // 
            btnLogout.Location = new Point(346, 338);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(112, 34);
            btnLogout.TabIndex = 8;
            btnLogout.Text = "Logout";
            btnLogout.UseVisualStyleBackColor = true;
            // 
            // btnRooms
            // 
            btnRooms.Location = new Point(478, 288);
            btnRooms.Name = "btnRooms";
            btnRooms.Size = new Size(186, 34);
            btnRooms.TabIndex = 9;
            btnRooms.Text = "manage room";
            btnRooms.UseVisualStyleBackColor = true;
            btnRooms.Click += btnRooms_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnRooms);
            Controls.Add(btnLogout);
            Controls.Add(btnSubjects);
            Controls.Add(btnTimetable);
            Controls.Add(btnMarks);
            Controls.Add(btnStudents);
            Controls.Add(btnCourses);
            Controls.Add(btnExams);
            Controls.Add(lblWelcome);
            Name = "MainForm";
            Text = "MainForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblWelcome;
        private Button btnExams;
        private Button btnCourses;
        private Button btnStudents;
        private Button btnMarks;
        private Button btnTimetable;
        private Button btnSubjects;
        private Button btnLogout;
        private Button btnRooms;
    }
}