using MauiApp1.Services;
using MauiApp1.Services.PartialMethods;

namespace MauiApp1;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();

		WindowSizeHandler.CallSetWindowSize();

		MainPage = new AppShell();
	}
}
