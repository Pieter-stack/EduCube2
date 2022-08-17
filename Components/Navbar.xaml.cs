namespace EduCube;

public partial class Navbar : ContentView
{
	public Navbar()
	{
		InitializeComponent();
	}


    private async void mainpageroute(object sender, EventArgs e)
    {

        await Shell.Current.GoToAsync("//DashboardPage");
    }

    private async void teacherpageroute(object sender, EventArgs e)
    {

        await Shell.Current.GoToAsync("//TeachersPage");
    }

    private async void studentpageroute(object sender, EventArgs e)
    {

        await Shell.Current.GoToAsync("//StudentsPage");
    }

    private async void subjectpageroute(object sender, EventArgs e)
    {

        await Shell.Current.GoToAsync("//SubjectsPage");
    }

    private async void fundspageroute(object sender, EventArgs e)
    {

        await Shell.Current.GoToAsync("//FundsPage");
    }

}