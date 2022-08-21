using EduCube.ViewModels;
using EduCube.ViewModels.AddUpdateViewModels;

namespace EduCube;

public partial class StudentsPage : ContentPage
{
	private StudentViewModel _viewModel;
	public StudentsPage(StudentViewModel vm)
	{
		InitializeComponent();
		_viewModel = vm;
		this.BindingContext = vm;
	}

	protected override void OnAppearing()
	{
		base.OnAppearing();
		_viewModel.GetStudentListCommand.Execute(null);
	}
}