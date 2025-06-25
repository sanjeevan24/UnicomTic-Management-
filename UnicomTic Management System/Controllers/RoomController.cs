using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnicomTic_Management_System.Repositories;

namespace UnicomTic_Management_System.Controllers
{
    internal class RoomController
    {
        public async Task AddRoomAsync(string roomName, string roomType)
        {
            await DatabaseManager.Instance.AddRoomAsync(roomName, roomType);
        }

        public async Task<DataTable> GetRoomsAsync()
        {
            return await DatabaseManager.Instance.GetRoomsAsync();
        }

        public async Task UpdateRoomAsync(int roomId, string roomName, string roomType)
        {
            await DatabaseManager.Instance.UpdateRoomAsync(roomId, roomName, roomType);
        }

        public async Task DeleteRoomAsync(int roomId)
        {
            await DatabaseManager.Instance.DeleteRoomAsync(roomId);
        }
    }
}
