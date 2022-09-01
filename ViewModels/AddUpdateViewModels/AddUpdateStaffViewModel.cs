using CommunityToolkit.Mvvm.ComponentModel;
using EduCube;
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
    [QueryProperty(nameof(StaffDetail), "StaffDetail")]


    public partial class AddUpdateStaffViewModel : ObservableObject
    {


        //Observable collection to populate picker with list of Majors
        public ObservableCollection<SubjectModel> Subjects { get; set; } = new ObservableCollection<SubjectModel>();

        //call db data from StaffModel Table
        [ObservableProperty]
        public StaffModel _staffDetail = new StaffModel();

        //Initialize Interface for CRUD functions
        private readonly IStaffService _staffRepository;
        public AddUpdateStaffViewModel(IStaffService staffService)
        {
            _staffRepository = staffService;

            //New instance of List for subjects
            listOfSubjects = new List<SubjectModel>();
            //call function to load GetSubjectList()
            GetListOfSubjects();
        }


        //initiate new list for subjects
        [ObservableProperty]
        List<SubjectModel> listOfSubjects;

        //listen and populate lecturer chosen from picker as selectedLecturer ///////////////////////////
        [ObservableProperty]
        SubjectModel selectedLecturer;

        [ObservableProperty]
        int totalhours;

        [ObservableProperty]
        int totalSalary;

        //function to load GetStaffList()
        public async void GetListOfSubjects()
        {
            // T<List> -> <List> 
            //get list of lecturers from repository
            listOfSubjects = await App.SubjectRepo.GetSubjectList();

            //loop through list of staff
            foreach (var listOfSubjects in listOfSubjects.ToList())
            {
                //populate observable collection with only lecturers
                if (listOfSubjects.SubjectLecturer == StaffDetail.StaffFirstName)
                {
                    Totalhours = listOfSubjects.SubjectHours;
 
                }
            }
            TotalSalary = Totalhours * 400;
        }




        //add display action to assign active state
        [ICommand]
        public async void AddUpdateStaff()
        {
            int response = -1;
            if (StaffDetail.StaffID > 0)
            {
                //edit staff details
                response = await _staffRepository.EditStaff(StaffDetail);
            }
            else
            {
                //add new staff to Table
                response = await _staffRepository.AddStaff(new Models.StaffModel
                {
                    StaffPersonalID = StaffDetail.StaffPersonalID,
                    StaffEmail = StaffDetail.StaffEmail,
                    StaffFirstName = StaffDetail.StaffFirstName,
                    StaffLastName = StaffDetail.StaffLastName,
                    StaffRole = StaffDetail.StaffRole,
                    //Load StaffImage from picker and set correct path
                    StaffImage = StaffDetail.StaffImage,
                    StaffHours = StaffDetail.StaffHours,
                    //Load Hours and calculate Salary from it / and if Admin then fixed salary
                    StaffSalary = StaffDetail.StaffRole == "Admin" ? (15000) : (StaffDetail.StaffHours * 400),
                    StaffPassword = StaffDetail.StaffPassword
                });
            }

            //respond if added to table or error occured
            if (response > 0)
            {
                await Shell.Current.DisplayAlert("Staff info saved", "Record Saved", "OK");
            }
            else
            {
                await Shell.Current.DisplayAlert("Not added", "Something went wrong while adding record", "OK");
            }

        }
    }
}












