using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnicomTic_Management_System.Repositories;

namespace UnicomTic_Management_System.Controllers
{
    internal class ExamController
    {
        public async Task AddExamAsync(string examName, int subjectId)
        {
            await DatabaseManager.Instance.AddExamAsync(examName, subjectId);
        }

        public async Task<DataTable> GetExamsAsync()
        {
            return await DatabaseManager.Instance.GetExamsAsync();
        }

        public async Task UpdateExamAsync(int examId, string examName, int subjectId)
        {
            await DatabaseManager.Instance.UpdateExamAsync(examId, examName, subjectId);
        }

        public async Task DeleteExamAsync(int examId)
        {
            await DatabaseManager.Instance.DeleteExamAsync(examId);
        }

        public async Task<DataTable> GetSubjectsAsync()
        {
            return await DatabaseManager.Instance.GetSubjectsAsync();
        }
    }
}
