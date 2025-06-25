using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnicomTic_Management_System.Repositories
{
    internal class DatabaseManager
    {
        private static DatabaseManager _instance;
        public static DatabaseManager Instance => _instance ??= new DatabaseManager();

        public SQLiteConnection Connection { get; private set; }

        private DatabaseManager()
        {
            Connection = new SQLiteConnection("Data Source=UnicomTic.db;Version=3;");
            Connection.Open();
            InitializeDatabase();
        }

        public void InitializeDatabase()
        {
            // USERS
            string users = @"CREATE TABLE IF NOT EXISTS Users (
                UserID INTEGER PRIMARY KEY AUTOINCREMENT,
                Username TEXT NOT NULL UNIQUE,
                Password TEXT NOT NULL,
                Role TEXT NOT NULL
            );";
            using (var cmd = new SQLiteCommand(users, Connection)) { cmd.ExecuteNonQuery(); }
            string insertUsers = @"INSERT OR IGNORE INTO Users (Username, Password, Role) VALUES
                ('admin', '123', 'Admin'),
                ('staff', '123', 'Staff'),
                ('student', '123', 'Student'),
                ('lecturer', '123', 'Lecturer');";
            using (var cmd = new SQLiteCommand(insertUsers, Connection)) { cmd.ExecuteNonQuery(); }

            // COURSES
            string courses = @"CREATE TABLE IF NOT EXISTS Courses (
                               CourseID INTEGER PRIMARY KEY AUTOINCREMENT,
                               CourseName TEXT NOT NULL
                                );";
            using (var cmd = new SQLiteCommand(courses, Connection)) { cmd.ExecuteNonQuery(); }

            // SUBJECTS
            string subjects = @"CREATE TABLE IF NOT EXISTS Subjects (
                SubjectID INTEGER PRIMARY KEY AUTOINCREMENT,
                SubjectName TEXT NOT NULL,
                CourseID INTEGER NOT NULL,
                FOREIGN KEY (CourseID) REFERENCES Courses(CourseID)
            );";
            using (var cmd = new SQLiteCommand(subjects, Connection)) { cmd.ExecuteNonQuery(); }

            // STUDENTS
            string students = @"CREATE TABLE IF NOT EXISTS Students (
                StudentID INTEGER PRIMARY KEY AUTOINCREMENT,
                Name TEXT NOT NULL,
                CourseID INTEGER NOT NULL,
                FOREIGN KEY (CourseID) REFERENCES Courses(CourseID)
            );";
            using (var cmd = new SQLiteCommand(students, Connection)) { cmd.ExecuteNonQuery(); }

            // EXAMS
            string exams = @"CREATE TABLE IF NOT EXISTS Exams (
                ExamID INTEGER PRIMARY KEY AUTOINCREMENT,
                ExamName TEXT NOT NULL,
                SubjectID INTEGER NOT NULL,
                FOREIGN KEY (SubjectID) REFERENCES Subjects(SubjectID)
            );";
            using (var cmd = new SQLiteCommand(exams, Connection)) { cmd.ExecuteNonQuery(); }

            // MARKS
            string marks = @"CREATE TABLE IF NOT EXISTS Marks (
                MarkID INTEGER PRIMARY KEY AUTOINCREMENT,
                StudentID INTEGER NOT NULL,
                ExamID INTEGER NOT NULL,
                Score INTEGER NOT NULL CHECK (Score >= 0 AND Score <= 100),
                FOREIGN KEY (StudentID) REFERENCES Students(StudentID),
                FOREIGN KEY (ExamID) REFERENCES Exams(ExamID)
            );";
            using (var cmd = new SQLiteCommand(marks, Connection)) { cmd.ExecuteNonQuery(); }

            // ROOMS
            string rooms = @"CREATE TABLE IF NOT EXISTS Rooms (
                RoomID INTEGER PRIMARY KEY AUTOINCREMENT,
                RoomName TEXT NOT NULL,
                RoomType TEXT NOT NULL
            );";
            using (var cmd = new SQLiteCommand(rooms, Connection)) { cmd.ExecuteNonQuery(); }
            string insertRooms = @"INSERT OR IGNORE INTO Rooms (RoomID, RoomName, RoomType) VALUES
                (1, 'Lab 1', 'Lab'),
                (2, 'Lab 2', 'Lab'),
                (3, 'Hall A', 'Hall'),
                (4, 'Hall B', 'Hall');";
            using (var cmd = new SQLiteCommand(insertRooms, Connection)) { cmd.ExecuteNonQuery(); }

            // TIMETABLES
            string timetables = @"CREATE TABLE IF NOT EXISTS Timetables (
                TimetableID INTEGER PRIMARY KEY AUTOINCREMENT,
                SubjectID INTEGER NOT NULL,
                TimeSlot TEXT NOT NULL,
                RoomID INTEGER NOT NULL,
                FOREIGN KEY (SubjectID) REFERENCES Subjects(SubjectID),
                FOREIGN KEY (RoomID) REFERENCES Rooms(RoomID)
            );";
            using (var cmd = new SQLiteCommand(timetables, Connection)) { cmd.ExecuteNonQuery(); }
        }

        public async Task<bool> ValidateUserAsync(string username, string password)
        {
            string sql = "SELECT 1 FROM Users WHERE Username=@username AND Password=@password";
            using var cmd = new SQLiteCommand(sql, Connection);
            cmd.Parameters.AddWithValue("@username", username);
            cmd.Parameters.AddWithValue("@password", password);
            var result = await cmd.ExecuteScalarAsync();
            return result != null;
        }

       
        public async Task<string> GetUserRoleAsync(string username)
        {
            string sql = "SELECT Role FROM Users WHERE Username=@username";
            using var cmd = new SQLiteCommand(sql, Connection);
            cmd.Parameters.AddWithValue("@username", username);
            var result = await cmd.ExecuteScalarAsync();
            return result?.ToString();
        }

        // Add Course (let SQLite generate CourseID)
        public async Task AddCourseAsync(string courseName)
        {
            string sql = "INSERT INTO Courses (CourseName) VALUES (@name)";
            using var cmd = new SQLiteCommand(sql, Connection);
            cmd.Parameters.AddWithValue("@name", courseName);
            await cmd.ExecuteNonQueryAsync();
        }

        // Get All Courses
        public async Task<DataTable> GetCoursesAsync()
        {
            string sql = "SELECT * FROM Courses";
            using var adapter = new SQLiteDataAdapter(sql, Connection);
            var dt = new DataTable();
            adapter.Fill(dt);
            return dt;
        }

        // Update Course
        public async Task UpdateCourseAsync(int courseId, string courseName)
        {
            string sql = "UPDATE Courses SET CourseName=@name WHERE CourseID=@id";
            using var cmd = new SQLiteCommand(sql, Connection);
            cmd.Parameters.AddWithValue("@name", courseName);
            cmd.Parameters.AddWithValue("@id", courseId);
            await cmd.ExecuteNonQueryAsync();
        }

        // Delete Course
        public async Task DeleteCourseAsync(int courseId)
        {
            string sql = "DELETE FROM Courses WHERE CourseID=@id";
            using var cmd = new SQLiteCommand(sql, Connection);
            cmd.Parameters.AddWithValue("@id", courseId);
            await cmd.ExecuteNonQueryAsync();
        }


        // SUBJECTS
        public async Task AddSubjectAsync(string subjectName, int courseId)
        {
            string sql = "INSERT INTO Subjects (SubjectName, CourseID) VALUES (@name, @courseId)";
            using var cmd = new SQLiteCommand(sql, Connection);
            cmd.Parameters.AddWithValue("@name", subjectName);
            cmd.Parameters.AddWithValue("@courseId", courseId);
            await cmd.ExecuteNonQueryAsync();
        }
        public async Task<DataTable> GetSubjectsAsync()
        {
            string sql = @"SELECT s.SubjectID, s.SubjectName, c.CourseName, s.CourseID
                           FROM Subjects s
                           JOIN Courses c ON s.CourseID = c.CourseID";
            using var adapter = new SQLiteDataAdapter(sql, Connection);
            var dt = new DataTable();
            adapter.Fill(dt);
            return dt;
        }
        public async Task UpdateSubjectAsync(int subjectId, string subjectName, int courseId)
        {
            string sql = "UPDATE Subjects SET SubjectName=@name, CourseID=@courseId WHERE SubjectID=@id";
            using var cmd = new SQLiteCommand(sql, Connection);
            cmd.Parameters.AddWithValue("@name", subjectName);
            cmd.Parameters.AddWithValue("@courseId", courseId);
            cmd.Parameters.AddWithValue("@id", subjectId);
            await cmd.ExecuteNonQueryAsync();
        }
        public async Task DeleteSubjectAsync(int subjectId)
        {
            string sql = "DELETE FROM Subjects WHERE SubjectID=@id";
            using var cmd = new SQLiteCommand(sql, Connection);
            cmd.Parameters.AddWithValue("@id", subjectId);
            await cmd.ExecuteNonQueryAsync();
        }

       

        // STUDENTS
        public async Task AddStudentAsync(string name, int courseId)
        {
            string sql = "INSERT INTO Students (Name, CourseID) VALUES (@name, @courseId)";
            using var cmd = new SQLiteCommand(sql, Connection);
            cmd.Parameters.AddWithValue("@name", name);
            cmd.Parameters.AddWithValue("@courseId", courseId);
            await cmd.ExecuteNonQueryAsync();
        }
        public async Task<DataTable> GetStudentsAsync()
        {
            string sql = @"SELECT s.StudentID, s.Name, c.CourseName, s.CourseID
                           FROM Students s
                           JOIN Courses c ON s.CourseID = c.CourseID";
            using var adapter = new SQLiteDataAdapter(sql, Connection);
            var dt = new DataTable();
            adapter.Fill(dt);
            return dt;
        }
        public async Task UpdateStudentAsync(int studentId, string name, int courseId)
        {
            string sql = "UPDATE Students SET Name=@name, CourseID=@courseId WHERE StudentID=@id";
            using var cmd = new SQLiteCommand(sql, Connection);
            cmd.Parameters.AddWithValue("@name", name);
            cmd.Parameters.AddWithValue("@courseId", courseId);
            cmd.Parameters.AddWithValue("@id", studentId);
            await cmd.ExecuteNonQueryAsync();
        }
        public async Task DeleteStudentAsync(int studentId)
        {
            string sql = "DELETE FROM Students WHERE StudentID=@id";
            using var cmd = new SQLiteCommand(sql, Connection);
            cmd.Parameters.AddWithValue("@id", studentId);
            await cmd.ExecuteNonQueryAsync();
        }

        public async Task<DataTable> GetStudentByNameAsync(string name)
        {
            string sql = @"SELECT s.StudentID, s.Name, c.CourseName 
                   FROM Students s
                   JOIN Courses c ON s.CourseID = c.CourseID
                   WHERE s.Name = @name";
            using var cmd = new SQLiteCommand(sql, Connection);
            cmd.Parameters.AddWithValue("@name", name);
            using var adapter = new SQLiteDataAdapter(cmd);
            var dt = new DataTable();
            adapter.Fill(dt);
            return dt;
        }

        // EXAMS
        public async Task AddExamAsync(string examName, int subjectId)
        {
            string sql = "INSERT INTO Exams (ExamName, SubjectID) VALUES (@name, @subjectId)";
            using var cmd = new SQLiteCommand(sql, Connection);
            cmd.Parameters.AddWithValue("@name", examName);
            cmd.Parameters.AddWithValue("@subjectId", subjectId);
            await cmd.ExecuteNonQueryAsync();
        }
        public async Task<DataTable> GetExamsAsync()
        {
            string sql = @"SELECT e.ExamID, e.ExamName, s.SubjectName, e.SubjectID
                           FROM Exams e
                           JOIN Subjects s ON e.SubjectID = s.SubjectID";
            using var adapter = new SQLiteDataAdapter(sql, Connection);
            var dt = new DataTable();
            adapter.Fill(dt);
            return dt;
        }
        public async Task UpdateExamAsync(int examId, string examName, int subjectId)
        {
            string sql = "UPDATE Exams SET ExamName=@name, SubjectID=@subjectId WHERE ExamID=@id";
            using var cmd = new SQLiteCommand(sql, Connection);
            cmd.Parameters.AddWithValue("@name", examName);
            cmd.Parameters.AddWithValue("@subjectId", subjectId);
            cmd.Parameters.AddWithValue("@id", examId);
            await cmd.ExecuteNonQueryAsync();
        }
        public async Task DeleteExamAsync(int examId)
        {
            string sql = "DELETE FROM Exams WHERE ExamID=@id";
            using var cmd = new SQLiteCommand(sql, Connection);
            cmd.Parameters.AddWithValue("@id", examId);
            await cmd.ExecuteNonQueryAsync();
        }
        

        // MARKS
        public async Task AddMarkAsync(int studentId, int examId, int score)
        {
            string sql = "INSERT INTO Marks (StudentID, ExamID, Score) VALUES (@studentId, @examId, @score)";
            using var cmd = new SQLiteCommand(sql, Connection);
            cmd.Parameters.AddWithValue("@studentId", studentId);
            cmd.Parameters.AddWithValue("@examId", examId);
            cmd.Parameters.AddWithValue("@score", score);
            await cmd.ExecuteNonQueryAsync();
        }
        public async Task<DataTable> GetMarksAsync()
        {
            string sql = @"SELECT m.MarkID, st.Name AS StudentName, ex.ExamName, m.Score, m.StudentID, m.ExamID
                           FROM Marks m
                           JOIN Students st ON m.StudentID = st.StudentID
                           JOIN Exams ex ON m.ExamID = ex.ExamID";
            using var adapter = new SQLiteDataAdapter(sql, Connection);
            var dt = new DataTable();
            adapter.Fill(dt);
            return dt;
        }
        public async Task UpdateMarkAsync(int markId, int studentId, int examId, int score)
        {
            string sql = "UPDATE Marks SET StudentID=@studentId, ExamID=@examId, Score=@score WHERE MarkID=@id";
            using var cmd = new SQLiteCommand(sql, Connection);
            cmd.Parameters.AddWithValue("@studentId", studentId);
            cmd.Parameters.AddWithValue("@examId", examId);
            cmd.Parameters.AddWithValue("@score", score);
            cmd.Parameters.AddWithValue("@id", markId);
            await cmd.ExecuteNonQueryAsync();
        }
        public async Task DeleteMarkAsync(int markId)
        {
            string sql = "DELETE FROM Marks WHERE MarkID=@id";
            using var cmd = new SQLiteCommand(sql, Connection);
            cmd.Parameters.AddWithValue("@id", markId);
            await cmd.ExecuteNonQueryAsync();
        }
        public async Task<DataTable> GetMarksForStudentAsync(string studentName)
        {
            string sql = @"SELECT m.MarkID, st.Name AS StudentName, ex.ExamName, m.Score
                   FROM Marks m
                   JOIN Students st ON m.StudentID = st.StudentID
                   JOIN Exams ex ON m.ExamID = ex.ExamID
                   WHERE st.Name = @name";
            using var cmd = new SQLiteCommand(sql, Connection);
            cmd.Parameters.AddWithValue("@name", studentName);
            using var adapter = new SQLiteDataAdapter(cmd);
            var dt = new DataTable();
            adapter.Fill(dt);
            return dt;
        }

        // Add Room
        public async Task AddRoomAsync(string roomName, string roomType)
        {
            string sql = "INSERT INTO Rooms (RoomName, RoomType) VALUES (@name, @type)";
            using var cmd = new SQLiteCommand(sql, Connection);
            cmd.Parameters.AddWithValue("@name", roomName);
            cmd.Parameters.AddWithValue("@type", roomType);
            await cmd.ExecuteNonQueryAsync();
        }

        // Get All Rooms
        public async Task<DataTable> GetRoomsAsync()
        {
            string sql = "SELECT * FROM Rooms";
            using var adapter = new SQLiteDataAdapter(sql, Connection);
            var dt = new DataTable();
            adapter.Fill(dt);
            return dt;
        }

        // Update Room
        public async Task UpdateRoomAsync(int roomId, string roomName, string roomType)
        {
            string sql = "UPDATE Rooms SET RoomName=@name, RoomType=@type WHERE RoomID=@id";
            using var cmd = new SQLiteCommand(sql, Connection);
            cmd.Parameters.AddWithValue("@name", roomName);
            cmd.Parameters.AddWithValue("@type", roomType);
            cmd.Parameters.AddWithValue("@id", roomId);
            await cmd.ExecuteNonQueryAsync();
        }

        // Delete Room
        public async Task DeleteRoomAsync(int roomId)
        {
            string sql = "DELETE FROM Rooms WHERE RoomID=@id";
            using var cmd = new SQLiteCommand(sql, Connection);
            cmd.Parameters.AddWithValue("@id", roomId);
            await cmd.ExecuteNonQueryAsync();
        }

        // TIMETABLES
        public async Task AddTimetableAsync(int subjectId, string timeSlot, int roomId)
        {
            string sql = "INSERT INTO Timetables (SubjectID, TimeSlot, RoomID) VALUES (@sid, @slot, @rid)";
            using var cmd = new SQLiteCommand(sql, Connection);
            cmd.Parameters.AddWithValue("@sid", subjectId);
            cmd.Parameters.AddWithValue("@slot", timeSlot);
            cmd.Parameters.AddWithValue("@rid", roomId);
            await cmd.ExecuteNonQueryAsync();
        }
        public async Task<DataTable> GetTimetablesAsync()
        {
            string sql = @"SELECT t.TimetableID, s.SubjectName, t.TimeSlot, r.RoomName, r.RoomType, t.SubjectID, t.RoomID
                           FROM Timetables t
                           JOIN Subjects s ON t.SubjectID = s.SubjectID
                           JOIN Rooms r ON t.RoomID = r.RoomID";
            using var adapter = new SQLiteDataAdapter(sql, Connection);
            var dt = new DataTable();
            adapter.Fill(dt);
            return dt;
        }
        public async Task UpdateTimetableAsync(int timetableId, int subjectId, string timeSlot, int roomId)
        {
            string sql = "UPDATE Timetables SET SubjectID=@sid, TimeSlot=@slot, RoomID=@rid WHERE TimetableID=@id";
            using var cmd = new SQLiteCommand(sql, Connection);
            cmd.Parameters.AddWithValue("@sid", subjectId);
            cmd.Parameters.AddWithValue("@slot", timeSlot);
            cmd.Parameters.AddWithValue("@rid", roomId);
            cmd.Parameters.AddWithValue("@id", timetableId);
            await cmd.ExecuteNonQueryAsync();
        }
        public async Task DeleteTimetableAsync(int timetableId)
        {
            string sql = "DELETE FROM Timetables WHERE TimetableID=@id";
            using var cmd = new SQLiteCommand(sql, Connection);
            cmd.Parameters.AddWithValue("@id", timetableId);
            await cmd.ExecuteNonQueryAsync();
        }
    }
}
