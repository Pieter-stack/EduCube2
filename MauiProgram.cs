using EduCube.Services;
using EduCube.ViewModels;
using EduCube.ViewModels.AddUpdateViewModels;
using EduCube.Views.AddUpdateViews;
using Microsoft.Extensions.DependencyInjection;
using SkiaSharp.Views.Maui.Controls.Hosting;

namespace EduCube;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
            .UseSkiaSharp(true)
            .UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
                //initalizing fonts for project
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                fonts.AddFont("Roboto-Bold.ttf", "Roboto-Bold");
                fonts.AddFont("Roboto-Regular.ttf", "Roboto-Regular");
                fonts.AddFont("Rubik-Bold.ttf", "Rubik-Bold");
                fonts.AddFont("Rubik-Regular.ttf", "Rubik-Regular");
            });

        //Services
        builder.Services.AddSingleton<IFundService, FundRepository>();
        builder.Services.AddSingleton<IStudentService, StudentRepository>();
        builder.Services.AddSingleton<IStaffService, StaffRepository>();
        builder.Services.AddSingleton<ISubjectService, SubjectRepository>();

        //Views
        builder.Services.AddSingleton<DashboardPage>();

        builder.Services.AddSingleton<FundsPage>();

        builder.Services.AddSingleton<StudentsPage>();
        builder.Services.AddTransient<AddUpdateStudentPage>();

        builder.Services.AddSingleton<SubjectsPage>();
        builder.Services.AddTransient<AddUpdateSubjectPage>();

        builder.Services.AddSingleton<TeachersPage>();
        builder.Services.AddTransient<AddUpdateStaffPage>();

        builder.Services.AddSingleton<MainPage>();
        

        //Viewmodels
        builder.Services.AddSingleton<FundViewModel>();

        builder.Services.AddSingleton<StaffViewModel>();
        builder.Services.AddTransient<AddUpdateStaffViewModel>();

        builder.Services.AddSingleton<StudentViewModel>();
        builder.Services.AddTransient<AddUpdateStudentViewModel>();

        builder.Services.AddSingleton<SubjectViewModel>();
        builder.Services.AddTransient<AddUpdateSubjectViewModel>();

        builder.Services.AddSingleton<LoginViewModel>();


        return builder.Build();
	}
}
