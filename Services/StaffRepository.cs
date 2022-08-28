

using EduCube.Models;
using SQLite;
using System.Diagnostics;

namespace EduCube.Services
{
    internal class StaffRepository : IStaffService
    {
        private SQLiteAsyncConnection _dbConnection;

        //Setup Connection to DB.
        private async Task SetUpDb()
        {
            if (_dbConnection == null)
            {
                string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Staff.db3");
                _dbConnection = new SQLiteAsyncConnection(dbPath);
                await _dbConnection.CreateTableAsync<StaffModel>();
            }
        }

        public async Task<int> AddStaff(StaffModel staffModel)
        {
            await SetUpDb();
            return await _dbConnection.InsertAsync(staffModel);
        }

        public async Task<List<StaffModel>> GetStaffList()
        {
            await SetUpDb();
            var staffList = await _dbConnection.Table<StaffModel>().ToListAsync();
            return staffList;
        }

        public async Task<int> EditStaff(StaffModel staffModel)
        {
            await SetUpDb();
            return await _dbConnection.UpdateAsync(staffModel);
        }

        public async Task<int> DeleteStaff(StaffModel staffModel)
        {
            await SetUpDb();
            return await _dbConnection.DeleteAsync(staffModel);
        }

        //Check Admin Authentication
        public async Task<bool> AdminLoginAuth(string email, string password)
        {
            try
            {
                await SetUpDb();
                var staffList = await _dbConnection.Table<StaffModel>().ToListAsync();
                var successAuth = staffList.Where(auth => auth.StaffEmail == email && auth.StaffPassword == password && auth.StaffRole == "Admin").FirstOrDefault();

                if (successAuth != null)
                {
                    Preferences.Set("FirstName", successAuth.StaffFirstName);
                    Preferences.Set("LastName", successAuth.StaffLastName);
                    Preferences.Set("ProfileImage", successAuth.StaffImage);
                    Debug.WriteLine("User Found");
                    return true;
                }
                else
                {
                    Debug.WriteLine("User Not Found");
                    return false;
                }
            }catch(Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return false;
            }           
        }
    }
}
