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
        Task<int> AddStaff(StaffModel staffModel);
        Task<List<StaffModel>> GetStaffList();
        Task<int> EditStaff(StaffModel staffModel);
        Task<int> DeleteStaff(StaffModel staffModel);
        Task<bool> AdminLoginAuth(string email, string password);
    }
}
