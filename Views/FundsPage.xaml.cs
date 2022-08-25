using EduCube.ViewModels;

namespace EduCube;

public partial class FundsPage : ContentPage
{
	public FundsPage(FundViewModel vm)
	{
		InitializeComponent();
        this.BindingContext = vm;
    }
}