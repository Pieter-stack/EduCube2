using EduCube.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduCube.Services
{
    internal class SubjectRepository : ISubjectService
    {
        private SQLiteAsyncConnection _dbConnection;

        //setup using path
        private async Task SetUpDb()
        {
            if (_dbConnection == null)
            {
                string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Subject.db3");
                _dbConnection = new SQLiteAsyncConnection(dbPath);
                await _dbConnection.CreateTableAsync<SubjectModel>();
            }
        }

        public async Task<int> AddSubject(SubjectModel subjectModel)
        {
            await SetUpDb();
            return await _dbConnection.InsertAsync(subjectModel);
        }

        public async Task<List<SubjectModel>> GetSubjectList()
        {
            await SetUpDb();
            var subjectList = await _dbConnection.Table<SubjectModel>().ToListAsync();
            return subjectList;
        }

        public async Task<int> EditSubject(SubjectModel subjectModel)
        {
            await SetUpDb();
            return await _dbConnection.UpdateAsync(subjectModel);
        }

        public async Task<int> DeleteSubject(SubjectModel subjectModel)
        {
            await SetUpDb();
            return await _dbConnection.DeleteAsync(subjectModel);
        }

    }
}
