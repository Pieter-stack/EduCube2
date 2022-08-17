using EduCube.Views.AddUpdateViews;

namespace EduCube;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();
        //initialise routes
        Routing.RegisterRoute("DashboardPage", typeof(DashboardPage));
        Routing.RegisterRoute("StudentsPage", typeof(StudentsPage));
        Routing.RegisterRoute("SubjectsPage", typeof(SubjectsPage));
        Routing.RegisterRoute("TeachersPage", typeof(TeachersPage));
        Routing.RegisterRoute("FundsPage", typeof(FundsPage));
        Routing.RegisterRoute("MainPage", typeof(MainPage));
        //initialize add and update pages
        Routing.RegisterRoute(nameof(AddUpdateSubjectPage), typeof(AddUpdateSubjectPage));
    }
}
