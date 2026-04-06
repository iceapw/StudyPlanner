using CommunityToolkit.Maui.Views;

namespace StudyPlanner.Views.Registration;

public class APIRegistrationPopup : Popup<string>
{
    private string APIKey;
    public APIRegistrationPopup()
    {
        var apiEntry = new Entry();
        APIKey = apiEntry.Text;
        var confirmButton = new Button { Text = "Confirm" };
        confirmButton.Clicked += ConfirmClicked;

        Content = new VerticalStackLayout
        {
            Children = 
            {
                new Label { Text = "Please enter your API Registration Key" },

                apiEntry,
                
                confirmButton
            }
        };
    }

    async void ConfirmClicked(object? sender, EventArgs e)
    {
        await CloseAsync(APIKey);
    }
    
}