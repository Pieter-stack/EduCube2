using EduCube.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduCube.Services
{
    internal class StudentRepository : IStudentService
    {
        private SQLiteAsyncConnection _dbConnection;

        //Setup Connection to DB.
        private async Task SetUpDb()
        {
            if(_dbConnection == null)
            {
                string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Student.db3");
                _dbConnection = new SQLiteAsyncConnection(dbPath);
                await _dbConnection.CreateTableAsync<StudentModel>();
            }
        }
        //Create a new student.
        public async Task<int> AddStudent(StudentModel studentModel)
        {
            await SetUpDb();
            return await _dbConnection.InsertAsync(studentModel);
        }
        //Get list of students.
        public async Task<List<StudentModel>> GetStudentList()
        {
            await SetUpDb();
            var studentList = await _dbConnection.Table<StudentModel>().ToListAsync();
            return studentList;
        }
        //Update student details.
        public async Task<int> EditStudent(StudentModel studentModel)
        {
            await SetUpDb();
            return await _dbConnection.UpdateAsync(studentModel);
        }
        //Delete a student.
        public async Task<int> DeleteStudent(StudentModel studentModel)
        {
            await SetUpDb();
            return await _dbConnection.DeleteAsync(studentModel);
        }
    }
}
