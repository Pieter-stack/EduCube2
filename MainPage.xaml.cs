using EduCube.ViewModels;

namespace EduCube;

public partial class MainPage : ContentPage
{
    //link viewmodel to view
    private LoginViewModel _viewModel;
    public MainPage(LoginViewModel vm)
	{
		InitializeComponent();
        _viewModel = vm;
        //bind viewmodel
        this.BindingContext = vm;
	}

    protected override void OnAppearing()
    {
        //run getsubjects when page loads
        base.OnAppearing();
        _viewModel.GoToDashboardCommand.Execute(null);
    }

}

