using CommunityToolkit.Mvvm.ComponentModel;
using EduCube.Models;
using EduCube.Services;
using EduCube.Views.AddUpdateViews;
using Microsoft.Toolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduCube.ViewModels
{
    public partial class SubjectViewModel : ObservableObject
    {
        //Observable collection to populate frontend with list of subjects
        public ObservableCollection<SubjectModel> Subjects { get; set; } = new ObservableCollection<SubjectModel>();

        //Initialize Interface for CRUD functions
        private readonly ISubjectService _subjectRepository;
        private readonly IStudentService _studentRepository;
        public SubjectViewModel(ISubjectService subjectService, IStudentService studentRepository)
        {
            _subjectRepository = subjectService;
            _studentRepository = studentRepository; 
        }

        //observe entry on frontend for keywords to search
        [ObservableProperty]
        string search;

        //initialize total subjects
        [ObservableProperty]
        int totalSubjects;

        //set count for all subject types to start at 0
        [ObservableProperty]
        int totalStudentsMajor = 0;
        [ObservableProperty]
        int totalStudentsTheory = 0;
        [ObservableProperty]
        int totalStudentsModule1 = 0;
        [ObservableProperty]
        int totalStudentsModule2 = 0;
        [ObservableProperty]
        int totalStudentsModule3 = 0;
        [ObservableProperty]
        int totalStudentsModule4 = 0;
        [ObservableProperty]
        int totalStudentsModule5 = 0;
        [ObservableProperty]
        int totalStudentsModule6 = 0;





        //Get list of subjects
        [ICommand]
        public async void GetSubjectList()
        {
            //get list of subjects
            var subjectList = await _subjectRepository.GetSubjectList();
            //get list of students
            var studentList = await _studentRepository.GetStudentList();

            if (subjectList?.Count > 0)
            {
                //clearing total subjects
                totalStudentsMajor = 0;               
                totalStudentsTheory = 0;              
                totalStudentsModule1 = 0;               
                totalStudentsModule2 = 0;               
                totalStudentsModule3 = 0;              
                totalStudentsModule4 = 0;               
                totalStudentsModule5 = 0;
                totalStudentsModule6 = 0;
                //clearing total subjects
                Subjects.Clear();
                //looping through subjects 
                foreach(var subject in subjectList)
                {
                    //get total subjects
                    totalSubjects++;
                    //set total subjects
                    Preferences.Set("Subjects", totalSubjects);
                    //add subject to list
                    Subjects.Add(subject);
                    //looping through students
                    foreach (var listOfStudents in studentList)
                    {
                        if (subject.SubjectCode == listOfStudents.StudentSubjectsMajor)
                        {
                           //get total student that have the subject
                            totalStudentsMajor += 1;
                           
                            //set subjectcount to new total
                            subject.SubjectStudentCount = totalStudentsMajor.ToString();

                        }
                        if (subject.SubjectCode == listOfStudents.StudentSubjectsTheory)
                        {
                            //get total student that have the subject
                            totalStudentsTheory += 1;
                            //set subjectcount to new total
                            subject.SubjectStudentCount = totalStudentsTheory.ToString();

                        }
                        if (subject.SubjectCode == listOfStudents.StudentSubjectsModule1)
                        {
                            //get total student that have the subject
                            totalStudentsModule1 += 1;
                            //set subjectcount to new total
                            subject.SubjectStudentCount = totalStudentsModule1.ToString();

                        }
                        if (subject.SubjectCode == listOfStudents.StudentSubjectsModule2)
                        {
                            //get total student that have the subject
                            totalStudentsModule2 += 1;
                            //set subjectcount to new total
                            subject.SubjectStudentCount = totalStudentsModule2.ToString();

                        }
                        if (subject.SubjectCode == listOfStudents.StudentSubjectsModule3)
                        {
                            //get total student that have the subject
                            totalStudentsModule3 += 1;
                            //set subjectcount to new total
                            subject.SubjectStudentCount = totalStudentsModule3.ToString();

                        }
                        if (subject.SubjectCode == listOfStudents.StudentSubjectsModule4)
                        {
                            //get total student that have the subject
                            totalStudentsModule4 += 1;
                            //set subjectcount to new total
                            subject.SubjectStudentCount = totalStudentsModule4.ToString();

                        }
                        if (subject.SubjectCode == listOfStudents.StudentSubjectsModule5)
                        {
                            //get total student that have the subject
                            totalStudentsModule5 += 1;
                            //set subjectcount to new total
                            subject.SubjectStudentCount = totalStudentsModule5.ToString();

                        }
                        if (subject.SubjectCode == listOfStudents.StudentSubjectsModule6)
                        {
                            //get total student that have the subject
                            totalStudentsModule6 += 1;
                            //set subjectcount to new total
                            subject.SubjectStudentCount = totalStudentsModule6.ToString();

                        }
                    }
                }
            }
        }

        //Search funtionality
        [ICommand]
        public  async void GetSubjectListSearch()
        {
            //get list of subjects
            var subjectList = await _subjectRepository.GetSubjectList();
            //filter through list and get new list containing the keyword from the entry
            var filteredItems = subjectList.Where(value => value.SubjectTitle.Contains(Search)).ToList();

            //clear subjects
            Subjects.Clear();
            //loop through list and populate new list with contained subjects
            foreach (var subject in filteredItems)
            {
                Subjects.Add(subject);
            }  
        }


        //navigate to add/edit page
        [ICommand]
        public async void AddUpdateSubject()
        {
            await AppShell.Current.GoToAsync(nameof(AddUpdateSubjectPage));
        }

        //get id of item and let user decide if the want to edit or delete
        [ICommand]
        public async void DisplayAction(SubjectModel subjectModel)
        {
           var response = await AppShell.Current.DisplayActionSheet("Select Option","OK",null,"Edit","Delete");
            if(response == "Edit")
            {
                //go to edit page and transfer data theough navigation paramaters
                var navParam = new Dictionary<string, object>();
                navParam.Add("SubjectDetail", subjectModel);
                await AppShell.Current.GoToAsync(nameof(AddUpdateSubjectPage),navParam);
            }
            else if (response == "Delete")
            {
                //else delete item
                var delResponse = await _subjectRepository.DeleteSubject(subjectModel);
                if(delResponse > 0)
                {
                    GetSubjectList();
                }
            }
        }
    }
}
