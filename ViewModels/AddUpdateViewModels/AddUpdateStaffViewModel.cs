using CommunityToolkit.Mvvm.ComponentModel;
using EduCube.Models;
using EduCube.Services;
using Microsoft.Toolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduCube.ViewModels.AddUpdateViewModels
{
    [QueryProperty(nameof(StaffDetail), "StaffDetail")]

    public partial class AddUpdateStaffViewModel : ObservableObject
    {
        [ObservableProperty]
        public StaffModel _staffDetail = new StaffModel();

        private readonly IStaffService _staffRepository;
        public AddUpdateStaffViewModel(IStaffService staffService)
        {
            _staffRepository = staffService;
        }
        //add display action to assign active state
        [ICommand]
        public async void AddUpdateStaff()
        {
            int response = -1;
            if (StaffDetail.StaffID > 0)
            {
                response = await _staffRepository.EditStaff(StaffDetail);
            }
            else
            {
                response = await _staffRepository.AddStaff(new Models.StaffModel
                {
                    StaffPersonalID = StaffDetail.StaffPersonalID,
                    StaffEmail = StaffDetail.StaffEmail,
                    StaffFirstName = StaffDetail.StaffFirstName,
                    StaffLastName = StaffDetail.StaffLastName,
                    StaffRole = StaffDetail.StaffRole,
                    StaffImage = StaffDetail.StaffImage,
                    StaffHours = StaffDetail.StaffHours,
                    StaffSalary = StaffDetail.StaffRole == "Admin" ? (15000) : (StaffDetail.StaffHours * 400),
                    StaffPassword = StaffDetail.StaffPassword
                });
            }

            if (response > 0)
            {
                await Shell.Current.DisplayAlert("staff info saved", "Record Saved", "OK");
            }
            else
            {
                await Shell.Current.DisplayAlert("Not added", "Something went wrong while adding record", "OK");
            }
        }
    }
}



