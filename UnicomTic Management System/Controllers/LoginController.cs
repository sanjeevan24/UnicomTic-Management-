using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnicomTic_Management_System.Repositories;

namespace UnicomTic_Management_System.Controllers
{
    internal class LoginController
    {
        public async Task<bool> AuthenticateAsync(string username, string password, string role)
        {
            string sql = "SELECT COUNT(*) FROM Users WHERE Username = @username AND Password = @password AND Role = @role";
            using var cmd = new SQLiteCommand(sql, DatabaseManager.Instance.Connection);
            cmd.Parameters.AddWithValue("@username", username);
            cmd.Parameters.AddWithValue("@password", password);
            cmd.Parameters.AddWithValue("@role", role);
            var result = await cmd.ExecuteScalarAsync();
            return Convert.ToInt32(result) > 0;
        }

        public async Task<(bool, string)> LoginAsync(string username, string password)
        {
            bool valid = await DatabaseManager.Instance.ValidateUserAsync(username, password);
            if (!valid) return (false, null);
            string role = await DatabaseManager.Instance.GetUserRoleAsync(username);
            return (true, role);
        }
    }
}
