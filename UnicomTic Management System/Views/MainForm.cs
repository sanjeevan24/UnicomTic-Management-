using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace UnicomTic_Management_System.Views
{
    public partial class MainForm : Form
    {
        private readonly string _role;
        private readonly string _username;
        public MainForm(string role, string username)
        {
            InitializeComponent();
            _role = role;
            _username = username;
            SetupDashboard();
        }



        private void SetupDashboard()
        {
            lblWelcome.Text = $"Welcome, {_username} ({_role})";

            // Admin: All enabled
            if (_role == "Admin")
            {
                btnCourses.Enabled = true;
                btnSubjects.Enabled = true;
                btnStudents.Enabled = true;
                btnExams.Enabled = true;
                btnMarks.Enabled = true;
                btnTimetable.Enabled = true;
                btnRooms.Enabled = true;
            }
            // Staff: Exams, Marks, Timetable
            else if (_role == "Staff")
            {
                btnCourses.Enabled = false;
                btnSubjects.Enabled = false;
                btnStudents.Enabled = false;
                btnExams.Enabled = true;
                btnMarks.Enabled = true;
                btnTimetable.Enabled = true;
                btnRooms.Enabled = false;
            }
            // Lecturer: Marks, Timetable
            else if (_role == "Lecturer")
            {
                btnCourses.Enabled = false;
                btnSubjects.Enabled = false;
                btnStudents.Enabled = false;
                btnExams.Enabled = false;
                btnMarks.Enabled = true;
                btnTimetable.Enabled = true;
                btnRooms.Enabled = false;
            }
            // Student: Only view timetable and marks
            else if (_role == "Student")
            {
                btnCourses.Enabled = false;
                btnSubjects.Enabled = false;
                btnStudents.Enabled = false;
                btnExams.Enabled = false;
                btnMarks.Enabled = true;      // But only VIEW, not add/edit
                btnTimetable.Enabled = true;  // Only VIEW
                btnRooms.Enabled = false;
            }
        }





        private void btnCourses_Click(object sender, EventArgs e)
        {
            var form = new CourseForm(_role);
            form.ShowDialog();

        }

        private void btnStudents_Click(object sender, EventArgs e)
        {
            var form = new StudentForm(_role, _username);
            form.ShowDialog();
        }

        private void btnSubjects_Click(object sender, EventArgs e)
        {
            var form = new SubjectForm(_role);
            form.ShowDialog();
        }

        private void btnExams_Click(object sender, EventArgs e)
        {
            var form = new ExamForm(_role);
            form.ShowDialog();
        }

        private void btnMarks_Click(object sender, EventArgs e)
        {
            var form = new MarkForm(_role, _username);
            form.ShowDialog();
        }

        private void btnTimetable_Click(object sender, EventArgs e)
        {
            var form = new TimetableForm(_role);
            form.ShowDialog();
        }

        private void btnRooms_Click(object sender, EventArgs e)
        {

            var form = new RoomForm(_role);
            form.ShowDialog();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            // Go back to login form
            LoginForm loginForm = new LoginForm();
            loginForm.Show();
            this.Close();
        }
    }
}
