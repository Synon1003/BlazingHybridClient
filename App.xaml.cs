namespace BlazingHybridClient;

public partial class App : Application
{
	private readonly AppState _appState;
	public App(AppState appState)
	{
		InitializeComponent();
		_appState = appState;
	}

	protected override Window CreateWindow(IActivationState? activationState)
	{
        return new Window(new MainPage(_appState))
        {
            Title = "Blazing Hybrid Client",
            MinimumWidth = 850,
            MinimumHeight = 600
        };
	}
}
