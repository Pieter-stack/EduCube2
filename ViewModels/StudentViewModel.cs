using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using EduCube.Models;
using EduCube.Services;
using EduCube.Views.AddUpdateViews;
using Microsoft.Toolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduCube.ViewModels
{
    public partial class StudentViewModel : ObservableObject
    {
        public ObservableCollection<StudentModel> Students { get; set; } = new ObservableCollection<StudentModel>();
        public ObservableCollection<ClassroomModel> Classrooms { get; set; } = new ObservableCollection<ClassroomModel>();

        private readonly IStudentService _studentRepository;

        public StudentViewModel(IStudentService studentService)
        {
            _studentRepository = studentService;

        }





        [ObservableProperty]
        int totalDegree;

        [ObservableProperty]
        int totalDiploma;

        [ObservableProperty]
        string search;

        [ICommand]
        public async void GetStudentList()
        {
            var studentList = await _studentRepository.GetStudentList();    
            if (studentList?.Count > 0)
            {
                Students.Clear();
                foreach(var student in studentList)
                {
                    Students.Add(student);
                    if (student.StudentType == "Degree")
                    {
                        totalDegree++;
                    }
                    else if (student.StudentType == "Diploma")
                    {
                        totalDiploma++;
                    }
                    Preferences.Set("TotalDegree", totalDegree);
                    Preferences.Set("TotalDiploma", totalDiploma);
                }
            }
        }


        [ICommand]
        public async void GetStudentListSearch()
        {
            var studentList = await _studentRepository.GetStudentList();
            var filteredItems = studentList.Where(value => value.StudentFirstName.ToLowerInvariant().Contains(Search)).ToList();
            var filteredItems2 = studentList.Where(value => value.StudentPersonalID.ToString().Contains(Search)).ToList();

            Students.Clear();
            foreach (var student in filteredItems)
            {
                Students.Add(student);
            }
            foreach (var student in filteredItems2)
            {
                Students.Add(student);
            }
        }

        [ICommand]
        public async void AddUpdateStudent()
        {
            await AppShell.Current.GoToAsync(nameof(AddUpdateStudentPage));
        }

        [ICommand]
        public async void DisplayAction(StudentModel studentModel)
        {
            var response = await AppShell.Current.DisplayActionSheet("Select an action", "OK", null, "Edit", "Delete");
            if (response == "Edit")
            {
                var navParam = new Dictionary<string, object>();
                navParam.Add("StudentDetail", studentModel);
                await AppShell.Current.GoToAsync(nameof(AddUpdateStudentPage), navParam);
            }
            else if (response == "Delete")
            {
                var delResponse = await _studentRepository.DeleteStudent(studentModel);
                if (delResponse > 0)
                {
                    GetStudentList();
                }
            }
        }





    //    [ICommand]
    //    public async void GetClassroomList()
    //    {
     //       var classroomList = await _classroomRepository.GetClassroomList();
     //       if (classroomList?.Count > 0)
     //       {
     //           Students.Clear();
     //           foreach (var classroom in classroomList)
     //           {
                    //if statement for checking studentID to spesific subject
    //                Classrooms.Add(classroom);
    
     //           }
     //       }
    //    }





    }
}



