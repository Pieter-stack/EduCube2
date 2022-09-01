using CommunityToolkit.Mvvm.ComponentModel;
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

namespace EduCube.ViewModels
{
    public partial class FundViewModel : ObservableObject
    {
        //Initialize Interface for CRUD functions
        private readonly IStaffService _staffRepository;
        private readonly IStudentService _studentRepository;
        private readonly IFundService _fundRepository;
        public FundViewModel(IStudentService studentService, IStaffService staffService, IFundService fundRepository)
        {
        _staffRepository = staffService;
        _studentRepository = studentService;
        _fundRepository = fundRepository;
        }

        //set total funds
        [ObservableProperty]
        private int _totalFunds = Preferences.Get("MonthlyFunds", 50000); 
        //for getting students fees
        [ObservableProperty]
        private int _totalTuition;
        //for getting staff salaries
        [ObservableProperty]
        private int _totalSalary;

        //add funds to db
        [ICommand]
        public async void AddUpdateFunds()
        {
        //get list of students
        var studentList = await _studentRepository.GetStudentList();
         //loop through students to get tatal tuition fees
        foreach (var student in studentList)
        {
            Debug.WriteLine(TotalTuition + student.StudentTuition);
            TotalTuition = TotalTuition + student.StudentTuition;
        }
        //get list of staff
        var staffList = await _staffRepository.GetStaffList();
            //loop through staff to get total staff salary
        foreach (var staff in staffList)
        {
            Debug.WriteLine(TotalSalary + staff.StaffSalary);
            TotalSalary = TotalSalary + staff.StaffSalary;
        }
        //calculate new total
        TotalFunds = TotalFunds + TotalTuition - TotalSalary;

        //prefrences save last months total FundsPool
        Preferences.Set("MonthlyFunds", TotalFunds);
        Preferences.Set("FundsSalary", TotalSalary);
        Preferences.Set("FundsTuition", TotalTuition);

        }


        //end month function
        [ICommand]
        public async void EndMonthFunds()
        {
            int response = -1;

            //update funds table with new entry
                response = await _fundRepository.AddFunds(new Models.FundModel
                {
                    Date = DateTime.Now.ToString(),
                    TotalFunds = TotalFunds,
                    TotalTuition = TotalTuition,
                    TotalSalary =TotalSalary
                });
            
            //resply with popup
            if (response > 0)
            {
                await Shell.Current.DisplayAlert("Funds info saved", "Record Saved", "OK");
            }
            else
            {
                await Shell.Current.DisplayAlert("Not added", "Something went wrong while adding record", "OK");
            }


        }

    }
}
