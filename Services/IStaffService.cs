using EduCube.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduCube.Services
{
    public interface IStaffService
    {
        //Initialize CRUD operations
        //Create staff
        Task<int> AddStaff(StaffModel staffModel);
        //Read staff list
        Task<List<StaffModel>> GetStaffList();
        //Update staff
        Task<int> EditStaff(StaffModel staffModel);
        //Delete staff
        Task<int> DeleteStaff(StaffModel staffModel);
        //Get user login authentication
        Task<bool> AdminLoginAuth(string email, string password);
    }
}
