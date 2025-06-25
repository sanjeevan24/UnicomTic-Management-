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
    public partial class CourseForm : Form
    {
        private readonly CourseController courseController = new CourseController();
        private readonly string _role;
        public CourseForm(string role)
        {
            InitializeComponent();
            LoadCourses();
           
        }

        

        private async void LoadCourses()
        {
            dataGridViewCourses.DataSource = await courseController.GetCoursesAsync();
            if (dataGridViewCourses.Columns.Contains("CourseID"))
                dataGridViewCourses.Columns["CourseID"].Visible = true;
        }



        private async void btnAddCourse_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCourseName.Text))
            {
                MessageBox.Show("Course name requested...");
                return;
            }
            await courseController.AddCourseAsync(txtCourseName.Text.Trim());
            txtCourseName.Clear();
            LoadCourses();

        }

        private async void btnUpdateCourse_Click(object sender, EventArgs e)
        {
            if (dataGridViewCourses.SelectedRows.Count == 0)
            {
                MessageBox.Show("Select a course to update.");
                return;
            }
            int id = Convert.ToInt32(dataGridViewCourses.SelectedRows[0].Cells["CourseID"].Value);
            string name = txtCourseName.Text.Trim();
            await courseController.UpdateCourseAsync(id, name);
            LoadCourses();
        }

        private async void btnDeleteCourse_Click(object sender, EventArgs e)
        {
            if (dataGridViewCourses.SelectedRows.Count == 0)
            {
                MessageBox.Show("Select a course to delete.");
                return;
            }
            int id = Convert.ToInt32(dataGridViewCourses.SelectedRows[0].Cells["CourseID"].Value);
            await courseController.DeleteCourseAsync(id);
            txtCourseName.Clear();
            LoadCourses();
        }

        private void dataGridViewCourses_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridViewCourses.SelectedRows.Count > 0)
            {
                txtCourseName.Text = dataGridViewCourses.SelectedRows[0].Cells["CourseName"].Value.ToString();
            }
        }
    }
}
