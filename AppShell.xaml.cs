using EduCube.Views.AddUpdateViews;

namespace EduCube;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();
        // Initialize Routes
        Routing.RegisterRoute("DashboardPage", typeof(DashboardPage));
        Routing.RegisterRoute("StudentsPage", typeof(StudentsPage));
        Routing.RegisterRoute("SubjectsPage", typeof(SubjectsPage));
        Routing.RegisterRoute("TeachersPage", typeof(TeachersPage));
        Routing.RegisterRoute("FundsPage", typeof(FundsPage));
        Routing.RegisterRoute("MainPage", typeof(MainPage));
        // Initialize Add & Update Pages
        Routing.RegisterRoute(nameof(AddUpdateStudentPage), typeof(AddUpdateStudentPage));
        Routing.RegisterRoute(nameof(AddUpdateSubjectPage), typeof(AddUpdateSubjectPage));
        Routing.RegisterRoute(nameof(AddUpdateStaffPage), typeof(AddUpdateStaffPage));
    }
}
