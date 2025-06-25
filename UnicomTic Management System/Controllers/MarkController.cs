using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnicomTic_Management_System.Repositories;

namespace UnicomTic_Management_System.Controllers
{
    internal class MarkController
    {
        public async Task AddMarkAsync(int studentId, int examId, int score)
        {
            await DatabaseManager.Instance.AddMarkAsync(studentId, examId, score);
        }

        public async Task<DataTable> GetMarksAsync()
        {
            return await DatabaseManager.Instance.GetMarksAsync();
        }

        public async Task UpdateMarkAsync(int markId, int studentId, int examId, int score)
        {
            await DatabaseManager.Instance.UpdateMarkAsync(markId, studentId, examId, score);
        }

        public async Task DeleteMarkAsync(int markId)
        {
            await DatabaseManager.Instance.DeleteMarkAsync(markId);
        }

        public async Task<DataTable> GetStudentsAsync()
        {
            return await DatabaseManager.Instance.GetStudentsAsync();
        }

        public async Task<DataTable> GetExamsAsync()
        {
            return await DatabaseManager.Instance.GetExamsAsync();
        }

        public async Task<DataTable> GetMarksForStudentAsync(string studentName)
        {
            return await DatabaseManager.Instance.GetMarksForStudentAsync(studentName);
        }
    }
}
