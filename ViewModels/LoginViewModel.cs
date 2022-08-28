using CommunityToolkit.Mvvm.ComponentModel;
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
        [ObservableProperty]
        string email;

        [ObservableProperty]
        string password;

        [ObservableProperty]
        string errorMessage;

        [ObservableProperty]
        bool stayLoggedOn = false;

        [ICommand]
        public async Task LoginValidAsync()
        {
            bool search = await App.StaffRepo.AdminLoginAuth(email, password);

            if (search)
            {
                Debug.WriteLine("Found User");
                ErrorMessage = "";

                Preferences.Set("StayLoggedOn", stayLoggedOn);

                Debug.WriteLine(Preferences.Get("StayLoggedOn", false));
                Debug.WriteLine(Preferences.Get("currentUser", 0));

                await Shell.Current.GoToAsync("//DashboardPage");
            }
            else
            {
                Debug.WriteLine("User Not Found");
                ErrorMessage = "Invalid Email and/or Password. Please try again!";
            }
        }
    }
}


