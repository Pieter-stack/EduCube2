namespace EduCube;

public partial class Navbar : ContentView
{
	public Navbar()
	{
		InitializeComponent();
	}

    //OnClick Navigate to Dashboard
    private async void mainpageroute(object sender, EventArgs e)
    {

        await Shell.Current.GoToAsync("//DashboardPage");
    }
    //OnCLick Navigate to StaffPage
    private async void teacherpageroute(object sender, EventArgs e)
    {

        await Shell.Current.GoToAsync("//TeachersPage");
    }
    //OnClick Navigate to StudentPage
    private async void studentpageroute(object sender, EventArgs e)
    {

        await Shell.Current.GoToAsync("//StudentsPage");
    }
    //OnCLick Navigate to SubjectPage
    private async void subjectpageroute(object sender, EventArgs e)
    {

        await Shell.Current.GoToAsync("//SubjectsPage");
    }
    //OnCLick Navigate to FundsPage
    private async void fundspageroute(object sender, EventArgs e)
    {

        await Shell.Current.GoToAsync("//FundsPage");
    }
    //OnCLick Logout 
    private async void logoutroute(object sender, EventArgs e)
    {

        await Shell.Current.GoToAsync("//MainPage");
        //Set prefrences to false to avoid automatic login when app is launched
        Preferences.Set("StayLoggedOn", false);
    }

   

}