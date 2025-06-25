using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UnicomTic_Management_System.Controllers;

namespace UnicomTic_Management_System.Views
{
    public partial class StudentForm : Form
    {
        private readonly StudentController studentController = new StudentController();
        private readonly string _role;
        private readonly string _username;
        public StudentForm(string role, string username)
        {
            InitializeComponent();
            _role = role;
            _username = username;
            LoadCourses();
            LoadStudents();
            SetRoleAccess();
            
        }

        private void SetRoleAccess()
        {
            bool isAdmin = (_role == "Admin");
            btnAddStudent.Enabled = isAdmin;
            btnUpdateStudent.Enabled = isAdmin;
            btnDeleteStudent.Enabled = isAdmin;
            txtStudentName.Enabled = isAdmin;
            cmbCourse.Enabled = isAdmin;

            // If Student, show only their own details
            if (_role == "Student")
            {
                btnAddStudent.Visible = false;
                btnUpdateStudent.Visible = false;
                btnDeleteStudent.Visible = false;
                txtStudentName.Enabled = false;
                cmbCourse.Enabled = false;
                LoadStudentSelf();
            }
        }
        private async void LoadCourses()
        {
            cmbCourse.DataSource = await studentController.GetCoursesAsync();
            cmbCourse.DisplayMember = "CourseName";
            cmbCourse.ValueMember = "CourseID";
            cmbCourse.SelectedIndex = -1;
        }

        private async void LoadStudents()
        {
            if (_role == "Student")
                return; // handled by LoadStudentSelf

            dataGridViewStudents.DataSource = await studentController.GetStudentsAsync();
            if (dataGridViewStudents.Columns.Contains("CourseID"))
                dataGridViewStudents.Columns["CourseID"].Visible = false;
            if (dataGridViewStudents.Columns.Contains("StudentID"))
                dataGridViewStudents.Columns["StudentID"].Visible = false;
        }

        private async void LoadStudentSelf()
        {
            var dt = await studentController.GetStudentByNameAsync(_username);
            dataGridViewStudents.DataSource = dt;
        }



        private async void btnAddStudent_Click(object sender, EventArgs e)

        {
            string name = txtStudentName.Text.Trim();
            if (string.IsNullOrWhiteSpace(name))
            {
                MessageBox.Show("Please enter student name.");
                return;
            }
            if (cmbCourse.SelectedValue == null)
            {
                MessageBox.Show("Please select a course.");
                return;
            }
            if (cmbCourse.SelectedValue is int courseId)
            {
                 studentController.AddStudentAsync(name, courseId);
                txtStudentName.Clear();
                cmbCourse.SelectedIndex = -1;
                LoadStudents();
            }
        }

        private async void btnUpdateStudent_Click(object sender, EventArgs e)
        {
            if (dataGridViewStudents.SelectedRows.Count == 0)
            {
                MessageBox.Show("Select a student to update.");
                return;
            }
            int studentId = Convert.ToInt32(dataGridViewStudents.SelectedRows[0].Cells["StudentID"].Value);
            string name = txtStudentName.Text.Trim();
            int courseId = (int)cmbCourse.SelectedValue;
            await studentController.UpdateStudentAsync(studentId, name, courseId);
            LoadStudents();
        }

        private async void btnDeleteStudent_Click(object sender, EventArgs e)
        {
            if (dataGridViewStudents.SelectedRows.Count == 0)
            {
                MessageBox.Show("Select a student to delete.");
                return;
            }
            int studentId = Convert.ToInt32(dataGridViewStudents.SelectedRows[0].Cells["StudentID"].Value);
            await studentController.DeleteStudentAsync(studentId);
            txtStudentName.Clear();
            cmbCourse.SelectedIndex = -1;
            LoadStudents();
        }

        private void dataGridViewStudents_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridViewStudents.SelectedRows.Count > 0)
            {
                txtStudentName.Text = dataGridViewStudents.SelectedRows[0].Cells["Name"].Value.ToString();
                cmbCourse.SelectedValue = dataGridViewStudents.SelectedRows[0].Cells["CourseID"].Value;
            }
        }
    }
}
