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
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
            cmbRole.Items.AddRange(new string[] { "Admin", "Staff", "Student", "Lecturer" });
            cmbRole.SelectedIndex = 0;
        }

        private async void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();
            string role = cmbRole.SelectedItem?.ToString();

            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password) || string.IsNullOrWhiteSpace(role))
            {
                MessageBox.Show("Please fill all fields and select a role.");
                return;
            }

            var loginController = new LoginController();
            bool isValid = await loginController.AuthenticateAsync(username, password, role);

            if (isValid)
            {
                MainForm mainForm = new MainForm(role, username);
                mainForm.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Invalid username, password, or role.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPassword.Clear();
                txtUsername.Focus();
            }

        }
    }
}
