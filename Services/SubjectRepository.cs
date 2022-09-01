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
                //connect db
                string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Subject.db3");
                var options = new SQLiteConnectionString(dbPath, true, "password", postKeyAction: c =>
                {
                    c.Execute("PRAGMA cipher_compatability = 3");
                });
                _dbConnection = new SQLiteAsyncConnection(options);
                await _dbConnection.CreateTableAsync<SubjectModel>();
            }
        }

        //Create a new subject
        public async Task<int> AddSubject(SubjectModel subjectModel)
        {
            await SetUpDb();
            return await _dbConnection.InsertAsync(subjectModel);
        }
        //Get list of subjects
        public async Task<List<SubjectModel>> GetSubjectList()
        {
            await SetUpDb();
            var subjectList = await _dbConnection.Table<SubjectModel>().ToListAsync();
            return subjectList;
        }
        //Edit subject details
        public async Task<int> EditSubject(SubjectModel subjectModel)
        {
            await SetUpDb();
            return await _dbConnection.UpdateAsync(subjectModel);
        }
        //Delete a subject
        public async Task<int> DeleteSubject(SubjectModel subjectModel)
        {
            await SetUpDb();
            return await _dbConnection.DeleteAsync(subjectModel);
        }

    }
}
