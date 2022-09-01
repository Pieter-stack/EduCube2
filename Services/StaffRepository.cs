

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

              

                //connect db
                string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Staff.db3");
                var options = new SQLiteConnectionString(dbPath, true, "password", postKeyAction: c =>
                {
                    c.Execute("PRAGMA cipher_compatability = 3");
                });
                _dbConnection = new SQLiteAsyncConnection(options);
                await _dbConnection.CreateTableAsync<StaffModel>();
            }
        }

        //Create a new staff user
        public async Task<int> AddStaff(StaffModel staffModel)
        {
            await SetUpDb();
            return await _dbConnection.InsertAsync(staffModel);
        }
        //Get list of staff
        public async Task<List<StaffModel>> GetStaffList()
        {
            await SetUpDb();
            var staffList = await _dbConnection.Table<StaffModel>().ToListAsync();
            return staffList;
        }
        //Edit staff details
        public async Task<int> EditStaff(StaffModel staffModel)
        {
            await SetUpDb();
            return await _dbConnection.UpdateAsync(staffModel);
        }
        //Delete a staff
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
                //connect to db
                await SetUpDb();
                //get list of staff
                var staffList = await _dbConnection.Table<StaffModel>().ToListAsync();
                //loop through list of staff members in db and math email and pw to input on Login form where the users role is admin
                var successAuth = staffList.Where(auth => auth.StaffEmail == email && auth.StaffPassword == password && auth.StaffRole == "Admin").FirstOrDefault();

                //if user is found
                if (successAuth != null)
                {
                    //set prefrences to store data
                    Preferences.Set("FirstName", successAuth.StaffFirstName);
                    Preferences.Set("LastName", successAuth.StaffLastName);
                    Preferences.Set("ProfileImage", successAuth.StaffImage);
                    Debug.WriteLine("User Found");
                    return true;
                }
                else
                {
                    //else return user not found
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
