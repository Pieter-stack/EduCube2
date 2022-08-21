using EduCube.ViewModels.AddUpdateViewModels;

namespace EduCube.Views.AddUpdateViews;

public partial class AddUpdateStudentPage : ContentPage
{
	public AddUpdateStudentPage(AddUpdateStudentViewModel vm)
	{
		InitializeComponent();
		this.BindingContext = vm; 
	}
}