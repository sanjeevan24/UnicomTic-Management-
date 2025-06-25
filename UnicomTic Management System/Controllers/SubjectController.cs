using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnicomTic_Management_System.Repositories;

namespace UnicomTic_Management_System.Controllers
{
    internal class SubjectController
    {
        public async Task AddSubjectAsync(string subjectName, int courseId)
        {
            await DatabaseManager.Instance.AddSubjectAsync(subjectName, courseId);
        }

        public async Task<DataTable> GetSubjectsAsync()
        {
            return await DatabaseManager.Instance.GetSubjectsAsync();
        }

        public async Task UpdateSubjectAsync(int subjectId, string subjectName, int courseId)
        {
            await DatabaseManager.Instance.UpdateSubjectAsync(subjectId, subjectName, courseId);
        }

        public async Task DeleteSubjectAsync(int subjectId)
        {
            await DatabaseManager.Instance.DeleteSubjectAsync(subjectId);
        }

        public async Task<DataTable> GetCoursesAsync()
        {
            return await DatabaseManager.Instance.GetCoursesAsync();
        }
    }
}
