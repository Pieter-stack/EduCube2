using EduCube.Handlers;

namespace EduCube;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();



        Microsoft.Maui.Handlers.EntryHandler.Mapper.AppendToMapping(nameof(BorderlessEnrty), (handler, view) =>
        {
#if WINDOWS
              handler.PlatformView.BorderThickness = new Microsoft.UI.Xaml.Thickness(0);

#endif
        });

        MainPage = new AppShell();
	}
}

//https://docs.microsoft.com/en-us/answers/questions/893844/how-to-remove-underline-when-entry-receives-focus.html