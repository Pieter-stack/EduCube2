using EduCube.ViewModels.AddUpdateViewModels;

namespace EduCube.Views.AddUpdateViews;

public partial class AddUpdateStaffPage : ContentPage
{
	public AddUpdateStaffPage(AddUpdateStaffViewModel vm)
	{
		InitializeComponent();
        this.BindingContext = vm;
    }
}