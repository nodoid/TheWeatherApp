namespace TheWeatherApp.Views;

public partial class TidesView : ContentPage
{
	public TidesView()
	{
		InitializeComponent();
	}

	protected override void OnAppearing()
	{
		base.OnAppearing();
		Task.Run(ViewModel.Init);
	}
}