using CommunityToolkit.Mvvm.ComponentModel;
using EduCube.Services;
using Microsoft.Toolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduCube.ViewModels
{
    public partial class LoginViewModel : ObservableObject
    {
        //get email from input
        [ObservableProperty]
        string email;
        //get pw from input
        [ObservableProperty]
        string password;
        //display message if auth credentails is incorrect
        [ObservableProperty]
        string errorMessage;
        //switch between staying logged in or not
        [ObservableProperty]
        bool stayLoggedOn = false;



        //staying logged in functionality
        [ICommand]
        public async void GoToDashboard()
        {
            //get loggedin prefrence
            bool isLoggedOn = Preferences.Get("StayLoggedOn", false);
            if (isLoggedOn)
            {
                //navigate directly to dashboard
                 await Shell.Current.GoToAsync("/DashboardPage");
            }
            else
            {

            }
        }

        //login validation
        [ICommand]
        public async Task LoginValidAsync()
        {
            //search through staff for a user that matches criteria of email, password and role = admin
            bool search = await App.StaffRepo.AdminLoginAuth(email, password);

            //if user is found 
            if (search)
            {
                //navigate to dashboard and set stayloggedin criteria
                ErrorMessage = "";
                Preferences.Set("StayLoggedOn", stayLoggedOn);
                await Shell.Current.GoToAsync("//DashboardPage");
            }
            else
            {
                //else display message to user
                Debug.WriteLine("User Not Found");
                ErrorMessage = "Invalid Email and/or Password. Please try again!";
            }
            
        }
    }
}


