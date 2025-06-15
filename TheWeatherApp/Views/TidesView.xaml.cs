using System.ComponentModel;

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
		ViewModel.PropertyChanged += OnPropertyChanged;
	}

	protected override void OnDisappearing()
	{
		base.OnDisappearing();
		ViewModel.PropertyChanged -= OnPropertyChanged;
	}
	
	void OnPropertyChanged(object? sender, PropertyChangedEventArgs e)
	{
		if (e.PropertyName == "RefreshScreen")
		{
			if (ViewModel.RefreshScreen)
				MainThread.BeginInvokeOnMainThread(()=>stack.InvalidateMeasure());
		}
	}
}