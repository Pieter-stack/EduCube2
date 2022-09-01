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
        //Observable collection to populate frontend with list of students
        public ObservableCollection<StudentModel> Students { get; set; } = new ObservableCollection<StudentModel>();

        //Initialize Interface for CRUD functions
        private readonly IStudentService _studentRepository;
        public StudentViewModel(IStudentService studentService)
        {
            _studentRepository = studentService;

        }


        //count total degree students
        [ObservableProperty]
        int totalDegree;
        //count total diploma students
        [ObservableProperty]
        int totalDiploma;

        //observe entry on frontend for keywords to search
        [ObservableProperty]
        string search;


        //Get list of students
        [ICommand]
        public async void GetStudentList()
        {
            //get list of students
            var studentList = await _studentRepository.GetStudentList();    
            if (studentList?.Count > 0)
            {
                //clear students
                Students.Clear();
                //loop through list
                foreach(var student in studentList)
                {
                   //populate list with students
                    Students.Add(student);
                    //count total degree vs diploma students
                    if (student.StudentType == "Degree")
                    {
                        totalDegree++;
                    }
                    else if (student.StudentType == "Diploma")
                    {
                        totalDiploma++;
                    }
                    //set prefrences
                    Preferences.Set("TotalDegree", totalDegree);
                    Preferences.Set("TotalDiploma", totalDiploma);
                }
            }
        }

        //Search funtionality
        [ICommand]
        public async void GetStudentListSearch()
        {   
            //get list of students
            var studentList = await _studentRepository.GetStudentList();
            //filter through list and get new list containing the keyword from the entry
            var filteredItems = studentList.Where(value => value.StudentFirstName.Contains(Search)).ToList();
            //filter through list and get new list containing the keyword from the entry
            var filteredItems2 = studentList.Where(value => value.StudentPersonalID.ToString().Contains(Search)).ToList();
            //clear students
            Students.Clear();
            //loop through list and populate new list with contained students name
            foreach (var student in filteredItems)
            {
                Students.Add(student);
            }
            //loop through list and populate new list with contained students id
            foreach (var student in filteredItems2)
            {
                Students.Add(student);
            }
        }

        //navigate to add/edit page
        [ICommand]
        public async void AddUpdateStudent()
        {
            await AppShell.Current.GoToAsync(nameof(AddUpdateStudentPage));
        }

        //get id of item and let user decide if the want to edit or delete
        [ICommand]
        public async void DisplayAction(StudentModel studentModel)
        {
            var response = await AppShell.Current.DisplayActionSheet("Select an action", "OK", null, "Edit", "Delete");
            if (response == "Edit")
            {
                //go to edit page and transfer data theough navigation paramaters
                var navParam = new Dictionary<string, object>();
                navParam.Add("StudentDetail", studentModel);
                await AppShell.Current.GoToAsync(nameof(AddUpdateStudentPage), navParam);
            }
            else if (response == "Delete")
            {
                //else delete item
                var delResponse = await _studentRepository.DeleteStudent(studentModel);
                if (delResponse > 0)
                {
                    GetStudentList();
                }
            }
        }

    }
}



