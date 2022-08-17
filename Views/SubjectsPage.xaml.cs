using EduCube.ViewModels;

namespace EduCube;

public partial class SubjectsPage : ContentPage
{
	//create link for viewmodel
	private SubjectViewModel _viewModel;

    //pass viewmodel
    public SubjectsPage(SubjectViewModel vm)
	{
		InitializeComponent();
		//link viewmodel
        _viewModel = vm;	
        //bind viewmodel
        this.BindingContext = vm;
	}


}