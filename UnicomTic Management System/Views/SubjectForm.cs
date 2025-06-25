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
    public partial class SubjectForm : Form
    {
        private readonly SubjectController subjectController = new SubjectController();
        private readonly string _role;
        public SubjectForm(string role)
        {
            InitializeComponent();
            _role = role;
            LoadCourses();
            LoadSubjects();
            SetRoleAccess();
        }

        private void SetRoleAccess()
        {
            // Only Admin can add/edit/delete
            bool isAdmin = (_role == "Admin");
            btnAddSubject.Enabled = isAdmin;
            btnUpdateSubject.Enabled = isAdmin;
            btnDeleteSubject.Enabled = isAdmin;
            txtSubjectName.Enabled = isAdmin;
            cmbCourse.Enabled = isAdmin;
        }

        private async void LoadCourses()
        {
            cmbCourse.DataSource = await subjectController.GetCoursesAsync();
            cmbCourse.DisplayMember = "CourseName";
            cmbCourse.ValueMember = "CourseID";
            cmbCourse.SelectedIndex = -1;
        }

        private async void LoadSubjects()
        {
            dataGridViewSubjects.DataSource = await subjectController.GetSubjectsAsync();
            if (dataGridViewSubjects.Columns.Contains("CourseID"))
                dataGridViewSubjects.Columns["CourseID"].Visible = false;
            if (dataGridViewSubjects.Columns.Contains("SubjectID"))
                dataGridViewSubjects.Columns["SubjectID"].Visible = false;
        }

        private void dataGridViewSubjects_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridViewSubjects.SelectedRows.Count > 0)
            {
                txtSubjectName.Text = dataGridViewSubjects.SelectedRows[0].Cells["SubjectName"].Value.ToString();
                // Set course in ComboBox
                cmbCourse.SelectedValue = dataGridViewSubjects.SelectedRows[0].Cells["CourseID"].Value;
            }

        }

        private async void btnAddSubject_Click(object sender, EventArgs e)
        {
            string subjectName = txtSubjectName.Text.Trim();
            if (string.IsNullOrWhiteSpace(subjectName))
            {
                MessageBox.Show("Please enter a subject name.");
                return;
            }
            if (cmbCourse.SelectedValue == null)
            {
                MessageBox.Show("Please select a course.");
                return;
            }
            int courseId = (int)cmbCourse.SelectedValue;
            await subjectController.AddSubjectAsync(subjectName, courseId);
            txtSubjectName.Clear();
            cmbCourse.SelectedIndex = -1;
            LoadSubjects();
        }

        private async void btnUpdateSubject_Click(object sender, EventArgs e)
        {
            if (dataGridViewSubjects.SelectedRows.Count == 0)
            {
                MessageBox.Show("Select a subject to update.");
                return;
            }
            int subjectId = Convert.ToInt32(dataGridViewSubjects.SelectedRows[0].Cells["SubjectID"].Value);
            string subjectName = txtSubjectName.Text.Trim();
            int courseId = (int)cmbCourse.SelectedValue;
            await subjectController.UpdateSubjectAsync(subjectId, subjectName, courseId);
            LoadSubjects();
        }

        private async void btnDeleteSubject_Click(object sender, EventArgs e)
        {
            if (dataGridViewSubjects.SelectedRows.Count == 0)
            {
                MessageBox.Show("Select a subject to delete.");
                return;
            }
            int subjectId = Convert.ToInt32(dataGridViewSubjects.SelectedRows[0].Cells["SubjectID"].Value);
            await subjectController.DeleteSubjectAsync(subjectId);
            txtSubjectName.Clear();
            cmbCourse.SelectedIndex = -1;
            LoadSubjects();
        }
    }
}
