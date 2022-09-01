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
    public partial class StaffViewModel : ObservableObject
    {
        //Observable collection to populate frontend with list of staff
        public ObservableCollection<StaffModel> Staff { get; set; } = new ObservableCollection<StaffModel>();

        //Initialize Interface for CRUD functions
        private readonly IStaffService _staffRepository;
        public StaffViewModel(IStaffService staffService)
        {
            _staffRepository = staffService;
        }

        //count total admin
        [ObservableProperty]
        int totalAdmin;
        //count total lecturers
        [ObservableProperty]
        int totalLecturers;

        //observe entry on frontend for keywords to search
        [ObservableProperty]
        string search;

        //Get list of staff
        [ICommand]
        public async void GetStaffList()
        {
            //get list of staff
            var staffList = await _staffRepository.GetStaffList();
            if (staffList?.Count > 0)
            {
                //clear staff
                Staff.Clear();
                foreach (var staff in staffList)
                {
                    //populate list of staff
                    Staff.Add(staff);
                    //count total admin vs lecturers
                    if(staff.StaffRole == "Admin")
                    {
                      TotalAdmin++; 
                    }
                    else if(staff.StaffRole == "Lecturer")
                    {
                      TotalLecturers++;
                    }
                    //set prefrences
                    Preferences.Set("TotalAdmin", TotalAdmin);
                    Preferences.Set("TotalLecturer", TotalLecturers);
                }
            }
        }

        //Search funtionality
        [ICommand]
        public async void GetStaffListSearch()
        {
            //get list of subjects
            var staffList = await _staffRepository.GetStaffList();
            //filter through list and get new list containing the keyword from the entry
            var filteredItems = staffList.Where(value => value.StaffFirstName.Contains(Search)).ToList();
            //filter through list and get new list containing the keyword from the entry
            var filteredItems2 = staffList.Where(value => value.StaffPersonalID.ToString().Contains(Search)).ToList();
            //clear staff
            Staff.Clear();
            //loop through list and populate new list with contained staff name
            foreach (var staff in filteredItems)
            {
                Staff.Add(staff);
            }
            //loop through list and populate new list with contained staff id
            foreach (var staff in filteredItems2)
            {
                Staff.Add(staff);
            }
        }

        //navigate to add/edit page
        [ICommand]
        public async void AddUpdateStaff()
        {
            await AppShell.Current.GoToAsync(nameof(AddUpdateStaffPage));
        }

        //get id of item and let user decide if the want to edit or delete
        [ICommand]
        public async void DisplayAction(StaffModel staffModel)
        {
            var response = await AppShell.Current.DisplayActionSheet("Select Option", "OK", null, "Edit", "Delete");
            if (response == "Edit")
            {
                //go to edit page and transfer data theough navigation paramaters
                var navParam = new Dictionary<string, object>();
                navParam.Add("StaffDetail", staffModel);
                await AppShell.Current.GoToAsync(nameof(AddUpdateStaffPage), navParam);

            }
            else if (response == "Delete")
            {
                //else delete item
                var delResponse = await _staffRepository.DeleteStaff(staffModel);
                if (delResponse > 0)
                {
                    GetStaffList();
                }
            }
        }
    }
}

