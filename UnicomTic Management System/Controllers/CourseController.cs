using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnicomTic_Management_System.Models;
using UnicomTic_Management_System.Repositories;

namespace UnicomTic_Management_System.Controllers
{
    internal class CourseController
    {
        public async Task AddCourseAsync(string courseName)
        {
            await DatabaseManager.Instance.AddCourseAsync(courseName);
        }

        public async Task<DataTable> GetCoursesAsync()
        {
            return await DatabaseManager.Instance.GetCoursesAsync();
        }

        public async Task UpdateCourseAsync(int courseId, string courseName)
        {
            await DatabaseManager.Instance.UpdateCourseAsync(courseId, courseName);
        }

        public async Task DeleteCourseAsync(int courseId)
        {
            await DatabaseManager.Instance.DeleteCourseAsync(courseId);
        }
    }
}
