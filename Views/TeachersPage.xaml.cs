using EduCube.ViewModels;

namespace EduCube;

public partial class TeachersPage : ContentPage
{
    //link viewmodel to view
    private StaffViewModel _viewModel;
    public TeachersPage(StaffViewModel vm)
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
        _viewModel.GetStaffListCommand.Execute(null);
    }
}



