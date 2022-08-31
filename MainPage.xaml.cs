using EduCube.ViewModels;

namespace EduCube;

public partial class MainPage : ContentPage
{
	public MainPage(LoginViewModel vm)
	{
		InitializeComponent();
		this.BindingContext = vm;
	}
}

