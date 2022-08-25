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
        public ObservableCollection<StaffModel> Staff { get; set; } = new ObservableCollection<StaffModel>();


        private readonly IStaffService _staffRepository;
        public StaffViewModel(IStaffService staffService)
        {
            _staffRepository = staffService;
        }

        [ObservableProperty]
        int totalAdmin;

        [ObservableProperty]
        int totalLecturers;

        [ObservableProperty]
        string search;

        [ICommand]
        public async void GetStaffList()
        {
            var staffList = await _staffRepository.GetStaffList();
            if (staffList?.Count > 0)
            {
                Staff.Clear();
                foreach (var staff in staffList)
                {
                    Staff.Add(staff);
                    if(staff.StaffRole == "Admin")
                    {
                      TotalAdmin++; 
                    }
                    else if(staff.StaffRole == "Lecturer")
                    {
                      TotalLecturers++;
                    }
                    Preferences.Set("TotalAdmin", TotalAdmin);
                    Preferences.Set("TotalLecturer", TotalLecturers);
                }
            }
        }


        [ICommand]
        public async void GetStaffListSearch()
        {
            var subjectList = await _staffRepository.GetStaffList();
            var filteredItems = subjectList.Where(value => value.StaffFirstName.ToLowerInvariant().Contains(Search)).ToList();
            var filteredItems2 = subjectList.Where(value => value.StaffPersonalID.ToString().Contains(Search)).ToList();


            Staff.Clear();
            foreach (var staff in filteredItems)
            {
                Staff.Add(staff);
            }
            foreach (var staff in filteredItems2)
            {
                Staff.Add(staff);
            }

        }




        [ICommand]
        public async void AddUpdateStaff()
        {
            await AppShell.Current.GoToAsync(nameof(AddUpdateStaffPage));
        }

        [ICommand]
        public async void DisplayAction(StaffModel staffModel)
        {
            var response = await AppShell.Current.DisplayActionSheet("Select Option", "OK", null, "Edit", "Delete");
            if (response == "Edit")
            {

                var navParam = new Dictionary<string, object>();
                navParam.Add("StaffDetail", staffModel);
                await AppShell.Current.GoToAsync(nameof(AddUpdateStaffPage), navParam);

            }
            else if (response == "Delete")
            {
                var delResponse = await _staffRepository.DeleteStaff(staffModel);
                if (delResponse > 0)
                {
                    GetStaffList();
                }
            }
        }


    }
}

