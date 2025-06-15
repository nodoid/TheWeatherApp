using System.ComponentModel;

namespace TheWeatherApp.Views;

public partial class WeatherView : ContentPage
{
	public WeatherView()
	{
		InitializeComponent();
	}

    protected override void OnAppearing()
    {
        base.OnAppearing();
        ViewModel.Init().ConfigureAwait(false);
        ViewModel.PropertyChanged+= OnPropertyChanged;
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