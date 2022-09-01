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
        //Create subject
        Task<int> AddSubject(SubjectModel subjectModel);
        //Read list of subjects
        Task<List<SubjectModel>> GetSubjectList();
        //Update subject
        Task<int> EditSubject(SubjectModel subjectModel);
        //Delete subject
        Task<int> DeleteSubject(SubjectModel subjectModel);

    }
}
