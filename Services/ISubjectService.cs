using EduCube.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduCube.Services
{
    public interface ISubjectService
    {
        //Initialize CRUD operations
        Task<int> AddSubject(SubjectModel subjectModel);
        Task<List<SubjectModel>> GetSubjectList();
        Task<int> EditSubject(SubjectModel subjectModel);
        Task<int> DeleteSubject(SubjectModel subjectModel);

    }
}
