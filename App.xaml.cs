using EduCube.Handlers;
using EduCube.Services;

namespace EduCube;

public partial class App : Application
{
    public static IStaffService StaffRepo { get; private set; }
    public static IStudentService StudentRepo { get; private set; }
    public static ISubjectService SubjectRepo { get; private set; }

    public App(IStaffService staffRepo, IStudentService studentRepo, ISubjectService subjectRepo)
	{
		InitializeComponent();
        //borderless entry code for Windows machines
        Microsoft.Maui.Handlers.EntryHandler.Mapper.AppendToMapping(nameof(BorderlessEnrty), (handler, view) =>
        {
        #if WINDOWS
              handler.PlatformView.BorderThickness = new Microsoft.UI.Xaml.Thickness(0);

            #endif
        });

        MainPage = new AppShell();
        //Initializing our repos
        StaffRepo = staffRepo;
        StudentRepo = studentRepo;
        SubjectRepo = subjectRepo;
    }
}

//https://docs.microsoft.com/en-us/answers/questions/893844/how-to-remove-underline-when-entry-receives-focus.html