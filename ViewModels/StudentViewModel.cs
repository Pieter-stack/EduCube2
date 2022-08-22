using CommunityToolkit.Mvvm.ComponentModel;
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

        private readonly IStudentService _studentRepository;
        public StudentViewModel(IStudentService studentService)
        {
            _studentRepository = studentService;
        }

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
                }
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

        [ICommand]
        public async void GetStudentListSearch()
        {
            var studentList = await _studentRepository.GetStudentList();
            var filteredItems = studentList.Where(value => value.StudentLastName.ToLowerInvariant().Contains('a')).ToList();

            Students.Clear();
            foreach (var student in filteredItems)
            {
                Students.Add(student);
            }
        }
    }
}
