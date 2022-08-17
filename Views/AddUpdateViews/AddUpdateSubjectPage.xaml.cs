using EduCube.ViewModels.AddUpdateViewModels;

namespace EduCube.Views.AddUpdateViews;

public partial class AddUpdateSubjectPage : ContentPage
{
	public AddUpdateSubjectPage(AddUpdateSubjectViewModel vm)
	{
		InitializeComponent();
		this.BindingContext = vm;
	}
}