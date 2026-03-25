namespace StudyPlanner.Views.Auth;

public partial class RegisterPage : ContentPage
{
	public RegisterPage()
	{
		InitializeComponent();
	}

    private async void OnBackToLoginTapped(object sender, EventArgs e)
    {
        await DisplayAlert("back", "back tapped (placeholder)", "OK");
    }

    private async void OnRegisterClicked(object sender, EventArgs e)
    {
        await DisplayAlert("register", "register tapped (placeholder)", "OK");
    }
}