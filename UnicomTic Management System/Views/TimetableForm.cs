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
    public partial class TimetableForm : Form
    {
        private readonly TimetableController timetableController = new TimetableController();
        private readonly string _role;

        public TimetableForm(string role)
        {
            InitializeComponent();
            _role = role;
            LoadSubjects();
            LoadRooms();
            LoadTimetables();
            SetRoleAccess();
        }

        private void SetRoleAccess()
        {
            // Only Admin can add/edit/delete
            bool isAdmin = (_role == "Admin");
            btnAddTimetable.Enabled = isAdmin;
            btnUpdateTimetable.Enabled = isAdmin;
            btnDeleteTimetable.Enabled = isAdmin;
            cmbSubject.Enabled = isAdmin;
            txtTimeSlot.Enabled = isAdmin;
            cmbRoom.Enabled = isAdmin;
        }

        private async void LoadSubjects()
        {
            cmbSubject.DataSource = await timetableController.GetSubjectsAsync();
            cmbSubject.DisplayMember = "SubjectName";
            cmbSubject.ValueMember = "SubjectID";
            cmbSubject.SelectedIndex = -1;
        }

        private async void LoadRooms()
        {
            cmbRoom.DataSource = await timetableController.GetRoomsAsync();
            cmbRoom.DisplayMember = "RoomName";
            cmbRoom.ValueMember = "RoomID";
            cmbRoom.SelectedIndex = -1;
        }

        private async void LoadTimetables()
        {
            dataGridViewTimetables.DataSource = await timetableController.GetTimetablesAsync();
            if (dataGridViewTimetables.Columns.Contains("SubjectID"))
                dataGridViewTimetables.Columns["SubjectID"].Visible = false;
            if (dataGridViewTimetables.Columns.Contains("RoomID"))
                dataGridViewTimetables.Columns["RoomID"].Visible = false;
            if (dataGridViewTimetables.Columns.Contains("TimetableID"))
                dataGridViewTimetables.Columns["TimetableID"].Visible = false;
        }
        private async void btnAddTimetable_Click(object sender, EventArgs e)
        {
            if (cmbSubject.SelectedValue == null)
            {
                MessageBox.Show("Please select a subject.");
                return;
            }
            if (string.IsNullOrWhiteSpace(txtTimeSlot.Text))
            {
                MessageBox.Show("Please enter a time slot.");
                return;
            }
            if (cmbRoom.SelectedValue == null)
            {
                MessageBox.Show("Please select a room.");
                return;
            }
            int subjectId = (int)cmbSubject.SelectedValue;
            string timeSlot = txtTimeSlot.Text.Trim();
            int roomId = (int)cmbRoom.SelectedValue;
            await timetableController.AddTimetableAsync(subjectId, timeSlot, roomId);
            txtTimeSlot.Clear();
            cmbSubject.SelectedIndex = -1;
            cmbRoom.SelectedIndex = -1;
            LoadTimetables();
        }

        private async void btnUpdateTimetable_Click(object sender, EventArgs e)
        {
            if (dataGridViewTimetables.SelectedRows.Count == 0)
            {
                MessageBox.Show("Select a timetable entry to update.");
                return;
            }
            int timetableId = Convert.ToInt32(dataGridViewTimetables.SelectedRows[0].Cells["TimetableID"].Value);
            int subjectId = (int)cmbSubject.SelectedValue;
            string timeSlot = txtTimeSlot.Text.Trim();
            int roomId = (int)cmbRoom.SelectedValue;
            await timetableController.UpdateTimetableAsync(timetableId, subjectId, timeSlot, roomId);
            LoadTimetables();
        }

        private async void btnDeleteTimetable_Click(object sender, EventArgs e)
        {
            if (dataGridViewTimetables.SelectedRows.Count == 0)
            {
                MessageBox.Show("Select a timetable entry to delete.");
                return;
            }
            int timetableId = Convert.ToInt32(dataGridViewTimetables.SelectedRows[0].Cells["TimetableID"].Value);
            await timetableController.DeleteTimetableAsync(timetableId);
            txtTimeSlot.Clear();
            cmbSubject.SelectedIndex = -1;
            cmbRoom.SelectedIndex = -1;
            LoadTimetables();
        }

        private void dataGridViewTimetables_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            if (dataGridViewTimetables.SelectedRows.Count > 0)
            {
                txtTimeSlot.Text = dataGridViewTimetables.SelectedRows[0].Cells["TimeSlot"].Value.ToString();
                cmbSubject.SelectedValue = dataGridViewTimetables.SelectedRows[0].Cells["SubjectID"].Value;
                cmbRoom.SelectedValue = dataGridViewTimetables.SelectedRows[0].Cells["RoomID"].Value;
            }
        }
    }
}
