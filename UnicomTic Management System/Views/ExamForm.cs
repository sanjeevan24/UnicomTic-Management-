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
    public partial class ExamForm : Form
    {
        private readonly ExamController examController = new ExamController();
        private readonly string _role;

        public ExamForm(string role)
        {
            InitializeComponent();
            _role = role;
            LoadSubjects();
            LoadExams();
            SetRoleAccess();
        }

        private void SetRoleAccess()
        {
            // Only Admin and Staff can add/edit/delete
            bool canEdit = (_role == "Admin" || _role == "Staff");
            btnAddExam.Enabled = canEdit;
            btnUpdateExam.Enabled = canEdit;
            btnDeleteExam.Enabled = canEdit;
            txtExamName.Enabled = canEdit;
            cmbSubject.Enabled = canEdit;
        }

        private async void LoadSubjects()
        {
            cmbSubject.DataSource = await examController.GetSubjectsAsync();
            cmbSubject.DisplayMember = "SubjectName";
            cmbSubject.ValueMember = "SubjectID";
            cmbSubject.SelectedIndex = -1;
        }
        private async void LoadExams()
        {
            dataGridViewExams.DataSource = await examController.GetExamsAsync();
            if (dataGridViewExams.Columns.Contains("SubjectID"))
                dataGridViewExams.Columns["SubjectID"].Visible = false;
            if (dataGridViewExams.Columns.Contains("ExamID"))
                dataGridViewExams.Columns["ExamID"].Visible = false;
        }

        private async void btnAddExam_Click(object sender, EventArgs e)
        {
            string examName = txtExamName.Text.Trim();
            if (string.IsNullOrWhiteSpace(examName))
            {
                MessageBox.Show("Please enter an exam name.");
                return;
            }
            if (cmbSubject.SelectedValue == null)
            {
                MessageBox.Show("Please select a subject.");
                return;
            }
            int subjectId = (int)cmbSubject.SelectedValue;

            await examController.AddExamAsync(examName, subjectId);
            txtExamName.Clear();
            cmbSubject.SelectedIndex = -1;
            LoadExams();

        }

        private async void btnUpdateExam_Click(object sender, EventArgs e)
        {
            if (dataGridViewExams.SelectedRows.Count == 0)
            {
                MessageBox.Show("Select an exam to update.");
                return;
            }
            int examId = Convert.ToInt32(dataGridViewExams.SelectedRows[0].Cells["ExamID"].Value);
            string examName = txtExamName.Text.Trim();
            int subjectId = (int)cmbSubject.SelectedValue;
            await examController.UpdateExamAsync(examId, examName, subjectId);
            LoadExams();
        }

        private async void btnDeleteExam_Click(object sender, EventArgs e)
        {
            if (dataGridViewExams.SelectedRows.Count == 0)
            {
                MessageBox.Show("Select an exam to delete.");
                return;
            }
            int examId = Convert.ToInt32(dataGridViewExams.SelectedRows[0].Cells["ExamID"].Value);
            await examController.DeleteExamAsync(examId);
            txtExamName.Clear();
            cmbSubject.SelectedIndex = -1;
            LoadExams();
        }

        private void dataGridViewExams_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridViewExams.SelectedRows.Count > 0)
            {
                txtExamName.Text = dataGridViewExams.SelectedRows[0].Cells["ExamName"].Value.ToString();
                cmbSubject.SelectedValue = dataGridViewExams.SelectedRows[0].Cells["SubjectID"].Value;
            }
        }
    }
}
