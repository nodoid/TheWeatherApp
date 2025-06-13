namespace TheWeatherApp.Views.Popups;

public partial class ErrorMessagePopupPage : Mopups.Pages.PopupPage
{
    public ErrorMessagePopupPage(string title, string message)
    {
        InitializeComponent();
        ViewModel.ErrorTitle = title;
        ViewModel.ErrorText = message;
    }

    protected override bool OnBackButtonPressed()
    {
        return base.OnBackButtonPressed();
        ViewModel.ReturnToCallerCommand.Execute(null);
    }

    protected override bool OnBackgroundClicked()
    {
        return base.OnBackgroundClicked();
        ViewModel.ReturnToCallerCommand.Execute(null);
    }
}

