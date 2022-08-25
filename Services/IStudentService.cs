using EduCube.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduCube.Services
{
    public interface IStudentService
    {
        Task<int> AddStudent(StudentModel studentModel);
        Task<List<StudentModel>> GetStudentList();
        Task<int> EditStudent(StudentModel studentModel);
        Task<int> DeleteStudent(StudentModel studentModel);
    }
}
