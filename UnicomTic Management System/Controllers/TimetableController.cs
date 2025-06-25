using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnicomTic_Management_System.Repositories;

namespace UnicomTic_Management_System.Controllers
{
    internal class TimetableController
    {
        public async Task AddTimetableAsync(int subjectId, string timeSlot, int roomId)
        {
            await DatabaseManager.Instance.AddTimetableAsync(subjectId, timeSlot, roomId);
        }

        public async Task<DataTable> GetTimetablesAsync()
        {
            return await DatabaseManager.Instance.GetTimetablesAsync();
        }

        public async Task UpdateTimetableAsync(int timetableId, int subjectId, string timeSlot, int roomId)
        {
            await DatabaseManager.Instance.UpdateTimetableAsync(timetableId, subjectId, timeSlot, roomId);
        }

        public async Task DeleteTimetableAsync(int timetableId)
        {
            await DatabaseManager.Instance.DeleteTimetableAsync(timetableId);
        }

        public async Task<DataTable> GetSubjectsAsync()
        {
            return await DatabaseManager.Instance.GetSubjectsAsync();
        }

        public async Task<DataTable> GetRoomsAsync()
        {
            return await DatabaseManager.Instance.GetRoomsAsync();
        }
    }
}
