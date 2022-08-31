using CommunityToolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Input;
using EduCube.Models;
using EduCube.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduCube.ViewModels.AddUpdateViewModels
{
    [QueryProperty(nameof(StudentDetail), "StudentDetail")]
    
    public partial class AddUpdateStudentViewModel : ObservableObject
    {
        public ObservableCollection<SubjectModel> Major { get; set; } = new ObservableCollection<SubjectModel>();
        public ObservableCollection<SubjectModel> Theory { get; set; } = new ObservableCollection<SubjectModel>();
        //Degree has 6 modules extra
        public ObservableCollection<SubjectModel> DegreeModule { get; set; } = new ObservableCollection<SubjectModel>();

        [ObservableProperty]
        public StudentModel _studentDetail = new StudentModel();

        private readonly IStudentService _studentRepository;
        public AddUpdateStudentViewModel(IStudentService studentService)
        {
            _studentRepository = studentService;
            listOfSubjects = new List<SubjectModel>();
            GetListOfSubjects();
        }

        [ObservableProperty]
        List<SubjectModel> listOfSubjects;

        [ObservableProperty]
        SubjectModel selectedSubject;

        [ObservableProperty]
        SubjectModel selectedSubjectMajor;

        [ObservableProperty]
        SubjectModel selectedSubjectTheory;

        [ObservableProperty]
        SubjectModel selectedSubjectModule1;

        [ObservableProperty]
        SubjectModel selectedSubjectModule2;

        [ObservableProperty]
        SubjectModel selectedSubjectModule3;

        [ObservableProperty]
        SubjectModel selectedSubjectModule4;

        [ObservableProperty]
        SubjectModel selectedSubjectModule5;

        [ObservableProperty]
        SubjectModel selectedSubjectModule6;

        public async void GetListOfSubjects()
        {
            ListOfSubjects = await App.SubjectRepo.GetSubjectList();

            foreach (var listOfSubjects in ListOfSubjects.ToList())
            {
                if (listOfSubjects.SubjectCategory == "Major")
                {
                    Major.Add(listOfSubjects);
                }
                else if(listOfSubjects.SubjectCategory == "Theory")
                {
                    Theory.Add(listOfSubjects);
                }
                else if(listOfSubjects.SubjectCategory == "Module")
                {
                    DegreeModule.Add(listOfSubjects);
                }
            }
        }

        [ICommand]
        public async void AddUpdateStudent()
        {
            int response = -1;

        if (StudentDetail.StudentID > 0)
        {
            response = await _studentRepository.EditStudent(StudentDetail);
        }
        else
        {
            response = await _studentRepository.AddStudent(new Models.StudentModel
            {
                StudentPersonalID = StudentDetail.StudentPersonalID,
                StudentEmail = StudentDetail.StudentEmail,
                StudentFirstName = StudentDetail.StudentFirstName,
                StudentLastName = StudentDetail.StudentLastName,
                StudentSubjects = SelectedSubjectMajor.SubjectCode + "," + SelectedSubjectTheory.SubjectCode + StudentDetail.StudentType == "Diploma" ? "" : SelectedSubjectModule1.SubjectCode + "," + SelectedSubjectModule2.SubjectCode + "," + SelectedSubjectModule3.SubjectCode + "," + SelectedSubjectModule4.SubjectCode + "," + SelectedSubjectModule5.SubjectCode + "," + SelectedSubjectModule6.SubjectCode,
                StudentSubjectsMajor = SelectedSubjectMajor.SubjectCode,
                StudentSubjectsTheory = SelectedSubjectTheory.SubjectCode,
                StudentSubjectsModule1 = StudentDetail.StudentType == "Diploma" ? "" : SelectedSubjectModule1.SubjectCode,
                StudentSubjectsModule2 = StudentDetail.StudentType == "Diploma" ? "" : SelectedSubjectModule2.SubjectCode,
                StudentSubjectsModule3 = StudentDetail.StudentType == "Diploma" ? "" : SelectedSubjectModule3.SubjectCode,
                StudentSubjectsModule4 = StudentDetail.StudentType == "Diploma" ? "" : SelectedSubjectModule4.SubjectCode,
                StudentSubjectsModule5 = StudentDetail.StudentType == "Diploma" ? "" : SelectedSubjectModule5.SubjectCode,
                StudentSubjectsModule6 = StudentDetail.StudentType == "Diploma" ? "" : SelectedSubjectModule6.SubjectCode,
                StudentImage = StudentDetail.StudentImage,
                StudentCredits = StudentDetail.StudentType == "Diploma" ? 60 : 180,
                StudentTuition = StudentDetail.StudentTuition,
                StudentType = StudentDetail.StudentType
            });
        }
            if (response > 0)
            {
                await Shell.Current.DisplayAlert("Student information saved.", "Record Saved", "OK");
            }
            else
            {
                await Shell.Current.DisplayAlert("Information not added.", "Something went wrong while adding record.", "OK");
            }
        }
    }
}
