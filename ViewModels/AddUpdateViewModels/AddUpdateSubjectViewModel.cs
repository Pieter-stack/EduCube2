
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using EduCube.Models;
using EduCube.Services;
using Microsoft.Toolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace EduCube.ViewModels.AddUpdateViewModels
{
    //url queries to pass between pages
    [QueryProperty(nameof(SubjectDetail), "SubjectDetail")]

    public partial class AddUpdateSubjectViewModel : ObservableObject
    {
        //Observable collection to populate picker with list of lecturers
        public ObservableCollection<StaffModel> Lec { get; set; } = new ObservableCollection<StaffModel>();

        //call db data from SubjectModel Table
        [ObservableProperty]
        public SubjectModel _subjectDetail = new SubjectModel();

        //Initialize Interface for CRUD functions
        private readonly ISubjectService _subjectRepository;
        public  AddUpdateSubjectViewModel(ISubjectService subjectService)
        {
        _subjectRepository = subjectService;

            //New instance of List for lecturers
            listOfLecturers = new List<StaffModel>();
            //call function to load GetStaffList()
            GetListOfLecturers();

        }

        //initiate new list for lecturers
        [ObservableProperty]
        List<StaffModel> listOfLecturers;

        //listen and populate lecturer chosen from picker as selectedLecturer
        [ObservableProperty]
        StaffModel selectedLecturer;

        //function to load GetStaffList()
        public async void GetListOfLecturers()
        {
            // T<List> -> <List> 
            //get list of lecturers from repository
            ListOfLecturers = await App.StaffRepo.GetStaffList();

            //loop through list of staff
            foreach (var listOfLecturer in listOfLecturers.ToList())
            {
                //populate observable collection with only lecturers
              if(listOfLecturer.StaffRole == "Lecturer"){
                Lec.Add(listOfLecturer);
              }
            }
        }

        //Add and Edit function
        [ICommand]
        public async void AddUpdateSubject()
        {
        int response = -1;

        if (SubjectDetail.SubjectID > 0)
        {
                //edit subject details
            response = await _subjectRepository.EditSubject(SubjectDetail);
        }
        else
        {
                //add new subject to table
            response = await _subjectRepository.AddSubject(new Models.SubjectModel
            {
                SubjectTitle = SubjectDetail.SubjectTitle,
                SubjectCode = SubjectDetail.SubjectCode,
                SubjectLecturer = SelectedLecturer.StaffFirstName,
                SubjectDescription = SubjectDetail.SubjectDescription,
                SubjectCredits = SubjectDetail.SubjectCategory == "Major" ? 40 : SubjectDetail.SubjectCategory == "Theory" ? 20 : SubjectDetail.SubjectCategory == "Module" ? 20 : 0 ,
                SubjectPrice = SubjectDetail.SubjectPrice,
                SubjectDate = SubjectDetail.SubjectDate,
                SubjectTime = SubjectDetail.SubjectTime,
                SubjectImage = SubjectDetail.SubjectImage,
                SubjectHours = SubjectDetail.SubjectHours,
                SubjectVenue = SubjectDetail.SubjectVenue,
                SubjectCategory = SubjectDetail.SubjectCategory,
                SubjectStudentCount = "0",
            });
        }
            //respond if added to table or error occured
            if (response > 0)
            {
                await Shell.Current.DisplayAlert("Subject info saved", "Record Saved", "OK");               
            }
            else
            {
                await Shell.Current.DisplayAlert("Not added", "Something went wrong while adding record", "OK");
            }
        }     
    }
}

