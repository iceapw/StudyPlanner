namespace StudyPlanner.Views.Auth;


public partial class LoginPage : ContentPage
{
	public LoginPage()
	{
		InitializeComponent();
	}

    private async void OnSignUpTapped(object sender, EventArgs e)
    {
        await DisplayAlert("Sign Up", "Sign Up tapped (placeholder)", "OK");
    }

    private async void OnLoginClicked(object sender, EventArgs e)
    {
        await DisplayAlert("Login", "Login tapped (placeholder)", "OK");
    }

}