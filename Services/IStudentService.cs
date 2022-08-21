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
        //Initialise CRUD operations     
        //Create student
        Task<int> AddStudent(StudentModel studentModel);
        //Read student
        Task<List<StudentModel>> GetStudentList();
        //Update student
        Task<int> EditStudent(StudentModel studentModel);
        //Delete student
        Task<int> DeleteStudent(StudentModel studentModel);
    }
}
