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
        //changeable Fields
        [ObservableProperty]
        string email;

        [ObservableProperty]
        string password;

        [ObservableProperty]
        string errorMessage;

        [ICommand]
        public async Task LoginValidAsync()
        {
            bool search = await App.StaffRepo.AdminLoginAuth(email, password);
            //encrtypt pw
            //save name and image of user

               if (search)
               {
                   Debug.WriteLine("Found User");
                   ErrorMessage = "";
                await Shell.Current.GoToAsync("//DashboardPage");
                
               }
                else
               {
                   Debug.WriteLine("User Not Found");
                   ErrorMessage = "Invalid Email or Password. Please try again!";
               }


        }




    }
}


