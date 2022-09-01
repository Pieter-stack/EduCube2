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
    //url queries to pass between pages
    [QueryProperty(nameof(StudentDetail), "StudentDetail")]
    
    public partial class AddUpdateStudentViewModel : ObservableObject
    {
        //Observable collection to populate picker with list of Majors
        public ObservableCollection<SubjectModel> Major { get; set; } = new ObservableCollection<SubjectModel>();
        //Observable collection to populate picker with list of Theories
        public ObservableCollection<SubjectModel> Theory { get; set; } = new ObservableCollection<SubjectModel>();
        //Degree has 6 modules extra
        //Observable collection to populate picker with list of Modules
        public ObservableCollection<SubjectModel> DegreeModule { get; set; } = new ObservableCollection<SubjectModel>();

        //call db data from StudentModel Table
        [ObservableProperty]
        public StudentModel _studentDetail = new StudentModel();

        //Initialize Interface for CRUD functions
        private readonly IStudentService _studentRepository;
            public AddUpdateStudentViewModel(IStudentService studentService)
            {
                _studentRepository = studentService;

            //New instance of List for subjects
            listOfSubjects = new List<SubjectModel>();
            //call function to load GetSubjectList()
            GetListOfSubjects();

            }

        //initiate new list for Subjects
        [ObservableProperty]
        List<SubjectModel> listOfSubjects;
        //listen and populate subjects chosen from picker as selectedSubject
        [ObservableProperty]
        SubjectModel selectedSubject;
        //listen and populate major chosen from picker as selectedSubject
        [ObservableProperty]
        SubjectModel selectedSubjectMajor;
        //listen and populate theory chosen from picker as selectedSubject
        [ObservableProperty]
        SubjectModel selectedSubjectTheory;
        //listen and populate module chosen from picker as selectedSubject
        [ObservableProperty]
        SubjectModel selectedSubjectModule1;
        //listen and populate module chosen from picker as selectedSubject
        [ObservableProperty]
        SubjectModel selectedSubjectModule2;
        //listen and populate module chosen from picker as selectedSubject
        [ObservableProperty]
        SubjectModel selectedSubjectModule3;
        //listen and populate module chosen from picker as selectedSubject
        [ObservableProperty]
        SubjectModel selectedSubjectModule4;
        //listen and populate module chosen from picker as selectedSubject
        [ObservableProperty]
        SubjectModel selectedSubjectModule5;
        //listen and populate module chosen from picker as selectedSubject
        [ObservableProperty]
        SubjectModel selectedSubjectModule6;



        //function to load GetSubjectList()
        public async void GetListOfSubjects()
        {
            // T<List> -> <List> 
            //get list of subjects from repository
            ListOfSubjects = await App.SubjectRepo.GetSubjectList();

            //loop through list of subjects
            foreach (var listOfSubjects in ListOfSubjects.ToList())
            {
                //populate observable collection with only major
                if (listOfSubjects.SubjectCategory == "Major")
                {
                    Major.Add(listOfSubjects);
                }
                //populate observable collection with only theory
                else if (listOfSubjects.SubjectCategory == "Theory")
                {
                    Theory.Add(listOfSubjects);
                }
                //populate observable collection with only module
                else if (listOfSubjects.SubjectCategory == "Module")
                {
                    DegreeModule.Add(listOfSubjects);

                }
            }

        }
        //Add and Edit function
        [ICommand]
            public async void AddUpdateStudent()
            {
            int response = -1;
            if (StudentDetail.StudentID > 0)
            {
                //edit student details
                response = await _studentRepository.EditStudent(StudentDetail);
            }
            else
            {
                //add new student to table
                response = await _studentRepository.AddStudent(new Models.StudentModel
                {
                    StudentPersonalID = StudentDetail.StudentPersonalID,
                    StudentEmail = StudentDetail.StudentEmail,
                    StudentFirstName = StudentDetail.StudentFirstName,
                    StudentLastName = StudentDetail.StudentLastName,
                    StudentSubjects = StudentDetail.StudentType == "Diploma" ? SelectedSubjectMajor.SubjectCode + "," + SelectedSubjectTheory.SubjectCode  : SelectedSubjectMajor.SubjectCode + 
                    "," + SelectedSubjectTheory.SubjectCode + "," + SelectedSubjectModule1.SubjectCode + "," + SelectedSubjectModule2.SubjectCode + "," + SelectedSubjectModule3.SubjectCode + 
                    "," + SelectedSubjectModule4.SubjectCode + "," + SelectedSubjectModule5.SubjectCode + "," + SelectedSubjectModule6.SubjectCode,
                    StudentSubjectsMajor = SelectedSubjectMajor.SubjectCode,
                    StudentSubjectsTheory = SelectedSubjectTheory.SubjectCode,
                    StudentSubjectsModule1 = StudentDetail.StudentType == "Diploma" ? "No Module Due to Diploma status" : SelectedSubjectModule1.SubjectCode,
                    StudentSubjectsModule2 = StudentDetail.StudentType == "Diploma" ? "No Module Due to Diploma status" : SelectedSubjectModule2.SubjectCode,
                    StudentSubjectsModule3 = StudentDetail.StudentType == "Diploma" ? "No Module Due to Diploma status" : SelectedSubjectModule3.SubjectCode,
                    StudentSubjectsModule4 = StudentDetail.StudentType == "Diploma" ? "No Module Due to Diploma status" : SelectedSubjectModule4.SubjectCode,
                    StudentSubjectsModule5 = StudentDetail.StudentType == "Diploma" ? "No Module Due to Diploma status" : SelectedSubjectModule5.SubjectCode,
                    StudentSubjectsModule6 = StudentDetail.StudentType == "Diploma" ? "No Module Due to Diploma status" : SelectedSubjectModule6.SubjectCode,
                    StudentImage = StudentDetail.StudentImage,
                    StudentCredits = StudentDetail.StudentType == "Diploma" ? 60 : 180,
                    StudentTuition = StudentDetail.StudentType == "Diploma" ? SelectedSubjectMajor.SubjectPrice + SelectedSubjectTheory.SubjectPrice :
                   SelectedSubjectMajor.SubjectPrice + SelectedSubjectTheory.SubjectPrice + SelectedSubjectModule1.SubjectPrice  + SelectedSubjectModule2.SubjectPrice  + SelectedSubjectModule3.SubjectPrice  + SelectedSubjectModule4.SubjectPrice 
                    + SelectedSubjectModule5.SubjectPrice  + SelectedSubjectModule6.SubjectPrice,
                    StudentType = StudentDetail.StudentType
                });
            }
            //respond if added to table or error occured
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
