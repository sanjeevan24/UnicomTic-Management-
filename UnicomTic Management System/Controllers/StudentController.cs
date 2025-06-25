using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnicomTic_Management_System.Repositories;

namespace UnicomTic_Management_System.Controllers
{
    internal class StudentController
    {
        public async Task AddStudentAsync(string name, int courseId)
        {
            await DatabaseManager.Instance.AddStudentAsync(name, courseId);
        }

        public async Task<DataTable> GetStudentsAsync()
        {
            return await DatabaseManager.Instance.GetStudentsAsync();
        }

        public async Task UpdateStudentAsync(int studentId, string name, int courseId)
        {
            await DatabaseManager.Instance.UpdateStudentAsync(studentId, name, courseId);
        }

        public async Task DeleteStudentAsync(int studentId)
        {
            await DatabaseManager.Instance.DeleteStudentAsync(studentId);
        }

        public async Task<DataTable> GetCoursesAsync()
        {
            return await DatabaseManager.Instance.GetCoursesAsync();
        }
        public async Task<DataTable> GetStudentByNameAsync(string name)
        {
            return await DatabaseManager.Instance.GetStudentByNameAsync(name);
        }

    }
}
