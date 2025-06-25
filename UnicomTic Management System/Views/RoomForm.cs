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

    public partial class RoomForm : Form
    {
        private readonly RoomController roomController = new RoomController();
        private readonly string _role;
        public RoomForm(string role)
        {
            InitializeComponent();
            _role = role;
            cmbRoomType.Items.AddRange(new string[] { "Lab", "Hall" });
            LoadRooms();
            SetRoleAccess();
        }

        private void SetRoleAccess()
        {
            // Only Admin can add/edit/delete
            bool isAdmin = (_role == "Admin");
            btnAddRoom.Enabled = isAdmin;
            btnUpdateRoom.Enabled = isAdmin;
            btnDeleteRoom.Enabled = isAdmin;
            txtRoomName.Enabled = isAdmin;
            cmbRoomType.Enabled = isAdmin;
        }

        private async void LoadRooms()
        {
            dataGridViewRooms.DataSource = await roomController.GetRoomsAsync();
            if (dataGridViewRooms.Columns.Contains("RoomID"))
                dataGridViewRooms.Columns["RoomID"].Visible = false;
        }
        private async void dataGridViewRooms_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            if (dataGridViewRooms.SelectedRows.Count > 0)
            {
                txtRoomName.Text = dataGridViewRooms.SelectedRows[0].Cells["RoomName"].Value.ToString();
                cmbRoomType.SelectedItem = dataGridViewRooms.SelectedRows[0].Cells["RoomType"].Value.ToString();
            }


        }

        private async void btnUpdateRoom_Click(object sender, EventArgs e)
        {
            if (dataGridViewRooms.SelectedRows.Count == 0)
            {
                MessageBox.Show("Select a room to update.");
                return;
            }
            int id = Convert.ToInt32(dataGridViewRooms.SelectedRows[0].Cells["RoomID"].Value);
            string name = txtRoomName.Text.Trim();
            string type = cmbRoomType.SelectedItem?.ToString();
            await roomController.UpdateRoomAsync(id, name, type);
            LoadRooms();
        }

        private async void btnDeleteRoom_Click(object sender, EventArgs e)
        {
            if (dataGridViewRooms.SelectedRows.Count == 0)
            {
                MessageBox.Show("Select a room to delete.");
                return;
            }
            int id = Convert.ToInt32(dataGridViewRooms.SelectedRows[0].Cells["RoomID"].Value);
            await roomController.DeleteRoomAsync(id);
            txtRoomName.Clear();
            cmbRoomType.SelectedIndex = -1;
            LoadRooms();
        }

        private async void btnAddRoom_Click(object sender, EventArgs e)
        {
            string name = txtRoomName.Text.Trim();
            string type = cmbRoomType.SelectedItem?.ToString();
            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(type))
            {
                MessageBox.Show("Please enter room name and select room type.");
                return;
            }
            await roomController.AddRoomAsync(name, type);
            txtRoomName.Clear();
            cmbRoomType.SelectedIndex = -1;
            LoadRooms();
        }
    }
}
