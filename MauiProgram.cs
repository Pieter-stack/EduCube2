using EduCube.Services;
using EduCube.ViewModels;
using EduCube.ViewModels.AddUpdateViewModels;
using EduCube.Views.AddUpdateViews;
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
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                fonts.AddFont("Roboto-Bold.ttf", "Roboto-Bold");
                fonts.AddFont("Roboto-Regular.ttf", "Roboto-Regular");
                fonts.AddFont("Rubik-Bold.ttf", "Rubik-Bold");
                fonts.AddFont("Rubik-Regular.ttf", "Rubik-Regular");
            });


        //Services
        builder.Services.AddSingleton<IAdminService, AdminRepository>();
        builder.Services.AddSingleton<IFundService, FundRepository>();
        builder.Services.AddSingleton<IStudentService, StudentRepository>();
        builder.Services.AddSingleton<IStaffService, StaffRepository>();
        builder.Services.AddSingleton<ISubjectService, SubjectRepository>();
        ////////////////////////////////////////////////////////////////////////////

        //Views
        builder.Services.AddSingleton<DashboardPage>();

        builder.Services.AddSingleton<FundsPage>();

        builder.Services.AddSingleton<StudentsPage>();

        builder.Services.AddSingleton<SubjectsPage>();
        builder.Services.AddTransient<AddUpdateSubjectPage>();

        builder.Services.AddSingleton<TeachersPage>();

        builder.Services.AddSingleton<MainPage>();


        //Viewmodels
        builder.Services.AddSingleton<AdminViewModel>();

        builder.Services.AddSingleton<FundViewModel>();

        builder.Services.AddSingleton<StaffViewModel>();

        builder.Services.AddSingleton<StudentViewModel>();

        builder.Services.AddSingleton<SubjectViewModel>();
        builder.Services.AddTransient<AddUpdateSubjectViewModel>();

        //DB Repos
        //  string userDBPath = FileAccessHelper.GetLocalFilePath("educubeDatabase.db3");
        //   builder.Services.AddSingleton<AdminRepository>(s => ActivatorUtilities.CreateInstance<AdminRepository>(s, userDBPath));
        //   builder.Services.AddSingleton<FundRepository>(s => ActivatorUtilities.CreateInstance<FundRepository>(s, userDBPath));
        //   builder.Services.AddSingleton<StaffRepository>(s => ActivatorUtilities.CreateInstance<StaffRepository>(s, userDBPath));
        //   builder.Services.AddSingleton<StudentRepository>(s => ActivatorUtilities.CreateInstance<StudentRepository>(s, userDBPath));
        //   builder.Services.AddSingleton<SubjectRepository>(s => ActivatorUtilities.CreateInstance<SubjectRepository>(s, userDBPath));


        return builder.Build();
	}
}
