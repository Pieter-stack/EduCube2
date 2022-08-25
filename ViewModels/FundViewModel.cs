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

         private readonly IStaffService _staffRepository;
         private readonly IStudentService _studentRepository;
         private readonly IFundService _fundRepository;
         public FundViewModel(IStudentService studentService, IStaffService staffService, IFundService fundRepository)
          {
             _staffRepository = staffService;
             _studentRepository = studentService;
              _fundRepository = fundRepository;
          }


           [ObservableProperty]
           private int _totalFunds = Preferences.Get("MonthlyFunds", 50000); 

          [ObservableProperty]
          private int _totalTuition;

          [ObservableProperty]
         private int _totalSalary;





          [ICommand]
          public async void AddUpdateFunds()
         {



            
             var studentList = await _studentRepository.GetStudentList();
         
                  foreach (var student in studentList)
                  {
                     Debug.WriteLine(TotalTuition + student.StudentTuition);
                     TotalTuition = TotalTuition + student.StudentTuition;

                }

            var staffList = await _staffRepository.GetStaffList();

            foreach (var staff in staffList)
            {
                Debug.WriteLine(TotalSalary + staff.StaffSalary);
                TotalSalary = TotalSalary + staff.StaffSalary;

            }

            TotalFunds = TotalFunds + TotalTuition - TotalSalary;

            //prefrences save last months total FundsPool

            Preferences.Set("MonthlyFunds", TotalFunds);
            Preferences.Set("FundsSalary", TotalSalary);
            Preferences.Set("FundsTuition", TotalTuition);






        }

    }
}
