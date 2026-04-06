using System.Collections.ObjectModel;
using System.Diagnostics.Metrics;
using CommunityToolkit.Maui;
using CommunityToolkit.Maui.Core;
using CommunityToolkit.Maui.Extensions;
using StudyPlanner.Views.Registration;

namespace StudyPlanner.Views.Dashboard;

public partial class DashboardPage : ContentPage
{

	private bool hasShownPopup = false;


	public DashboardPage()
	{
		InitializeComponent();

	}


	protected override async void OnNavigatedTo(NavigatedToEventArgs args)
	{

    	base.OnNavigatedTo(args);

		if(!hasShownPopup)
		{

			var popup =  new APIRegistrationPopup();

			IPopupResult<string> result = await this.ShowPopupAsync<string>(popup);

			hasShownPopup = true;
			
		}

	}
	// protected override async void OnAppearing()
	// {
	// 	base.OnAppearing();

	// 	var popup =  new APIRegistrationPopUp();

	// 	IPopupResult<string> result = await this.ShowPopupAsync<string>(popup);

	// 	await this.ClosePopupAsync();



	// }

}