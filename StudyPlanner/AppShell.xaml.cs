namespace StudyPlanner;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();
		Routing.RegisterRoute("CourseDetailPage", typeof(Views.Courses.CourseDetailPage));
	}




	protected override void OnNavigating(ShellNavigatingEventArgs args)
	{
    	base.OnNavigating(args);

    	// Resets the stack when the user switches to a different tab
    	if (args.Source == ShellNavigationSource.ShellSectionChanged)
    	{
        	var navigation = Shell.Current.Navigation;
        	var pages = navigation.NavigationStack;

        	// Remove all pages except the root (index 0)
        	for (int i = pages.Count - 1; i >= 1; i--)
        	{
            	navigation.RemovePage(pages[i]);
        	}
    	}
	}
}