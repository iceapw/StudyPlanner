using CommunityToolkit.Maui.Views;
using StudyPlanner.Services;
using StudyPlanner.Models;

namespace StudyPlanner.Views.Popups;

public class APIPopup : Popup
{

    private readonly DatabaseService _dbService;

    private Entry _apiEntry;
    public APIPopup(DatabaseService dbService, Entry apiEntry)
    {
        _dbService = dbService;
        _apiEntry = apiEntry;
        var confirmButton = new Button { Text = "Confirm" };
        confirmButton.Clicked += ConfirmClicked;

        
        Content = new VerticalStackLayout
        {
            Padding = new Thickness(20),
            Children = 
            {
                new Label { Text = "Please enter your API Registration Key" },

                _apiEntry,
                
                confirmButton
            }
        };
    }

    async void ConfirmClicked(object? sender, EventArgs e)
    {
        Key item = new Key
        {
            APIKey = _apiEntry.Text
        };
        var result = await _dbService.InsertKey(item);
        await CloseAsync();
    }
    
}