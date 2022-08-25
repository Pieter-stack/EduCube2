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
        [ObservableProperty]
        public StudentModel _studentDetail = new StudentModel();

            private readonly IStudentService _studentRepository;
            public AddUpdateStudentViewModel(IStudentService studentService)
            {
                _studentRepository = studentService;
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
                    StudentSubjects = StudentDetail.StudentSubjects,
                    StudentImage = StudentDetail.StudentImage,
                    StudentCredits = StudentDetail.StudentCredits,
                    StudentTuition = StudentDetail.StudentTuition,
                    StudentType = StudentDetail.StudentCredits == 60 ? ("Diploma") : ("Degree")

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
