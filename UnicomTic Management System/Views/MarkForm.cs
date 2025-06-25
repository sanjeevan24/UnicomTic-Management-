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
    public partial class MarkForm : Form
    {
        private readonly MarkController markController = new MarkController();
        private readonly string _role;
        private readonly string _username;
        public MarkForm(string role, string username)
        {
            InitializeComponent();
            _role = role;
            _username = username;
            LoadStudents();
            LoadExams();
            LoadMarks();
            SetRoleAccess();
        }

        private void SetRoleAccess()
        {
            // Only Admin, Staff, Lecturer can add/edit/delete
            bool canEdit = (_role == "Admin" || _role == "Staff" || _role == "Lecturer");
            btnAddMark.Enabled = canEdit;
            btnUpdateMark.Enabled = canEdit;
            btnDeleteMark.Enabled = canEdit;
            cmbStudent.Enabled = canEdit;
            cmbExam.Enabled = canEdit;
            txtScore.Enabled = canEdit;

            // If Student, show only their own marks
            if (_role == "Student")
            {
                btnAddMark.Visible = false;
                btnUpdateMark.Visible = false;
                btnDeleteMark.Visible = false;
                cmbStudent.Visible = false;
                cmbExam.Visible = false;
                txtScore.Visible = false;
                LoadStudentMarks();
            }
        }

        private async void LoadStudents()
        {
            cmbStudent.DataSource = await markController.GetStudentsAsync();
            cmbStudent.DisplayMember = "Name";
            cmbStudent.ValueMember = "StudentID";
            cmbStudent.SelectedIndex = -1;
        }

        private async void LoadExams()
        {
            cmbExam.DataSource = await markController.GetExamsAsync();
            cmbExam.DisplayMember = "ExamName";
            cmbExam.ValueMember = "ExamID";
            cmbExam.SelectedIndex = -1;
        }

        private async void LoadMarks()
        {
            if (_role == "Student")
                return;
            dataGridViewMarks.DataSource = await markController.GetMarksAsync();
            if (dataGridViewMarks.Columns.Contains("MarkID"))
                dataGridViewMarks.Columns["MarkID"].Visible = false;
            if (dataGridViewMarks.Columns.Contains("StudentID"))
                dataGridViewMarks.Columns["StudentID"].Visible = false;
            if (dataGridViewMarks.Columns.Contains("ExamID"))
                dataGridViewMarks.Columns["ExamID"].Visible = false;
        }

        private async void LoadStudentMarks()
        {
            var dt = await markController.GetMarksForStudentAsync(_username);
            dataGridViewMarks.DataSource = dt;
        }



        private void dataGridViewMarks_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridViewMarks.SelectedRows.Count > 0)
            {
                if (cmbStudent.Visible)
                    cmbStudent.SelectedValue = dataGridViewMarks.SelectedRows[0].Cells["StudentID"].Value;
                if (cmbExam.Visible)
                    cmbExam.SelectedValue = dataGridViewMarks.SelectedRows[0].Cells["ExamID"].Value;
                if (txtScore.Visible)
                    txtScore.Text = dataGridViewMarks.SelectedRows[0].Cells["Score"].Value.ToString();
            }

        }

        private async void btnAddMark_Click(object sender, EventArgs e)
        {
            if (cmbStudent.SelectedValue == null || cmbExam.SelectedValue == null)
            {
                MessageBox.Show("Select a student and an exam.");
                return;
            }
            if (!int.TryParse(txtScore.Text.Trim(), out int score) || score < 0 || score > 100)
            {
                MessageBox.Show("Enter a valid score (0-100).");
                return;
            }
            int studentId = (int)cmbStudent.SelectedValue;
            int examId = (int)cmbExam.SelectedValue;
            await markController.AddMarkAsync(studentId, examId, score);
            txtScore.Clear();
            LoadMarks();
        }

        private async void btnUpdateMark_Click(object sender, EventArgs e)
        {
            if (dataGridViewMarks.SelectedRows.Count == 0)
            {
                MessageBox.Show("Select a mark to update.");
                return;
            }
            int markId = Convert.ToInt32(dataGridViewMarks.SelectedRows[0].Cells["MarkID"].Value);
            int studentId = (int)cmbStudent.SelectedValue;
            int examId = (int)cmbExam.SelectedValue;
            if (!int.TryParse(txtScore.Text.Trim(), out int score) || score < 0 || score > 100)
            {
                MessageBox.Show("Enter a valid score (0-100).");
                return;
            }
            await markController.UpdateMarkAsync(markId, studentId, examId, score);
            LoadMarks();
        }

        private async void btnDeleteMark_Click(object sender, EventArgs e)
        {
            if (dataGridViewMarks.SelectedRows.Count == 0)
            {
                MessageBox.Show("Select a mark to delete.");
                return;
            }
            int markId = Convert.ToInt32(dataGridViewMarks.SelectedRows[0].Cells["MarkID"].Value);
            await markController.DeleteMarkAsync(markId);
            txtScore.Clear();
            LoadMarks();
        }
    }
}
