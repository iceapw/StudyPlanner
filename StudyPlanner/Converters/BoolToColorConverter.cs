using System.Globalization;

namespace StudyPlanner.Converters
{
	public class BoolToColorConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
			=> (bool)value ? Color.FromArgb("#4F46E5") : Color.FromArgb("#F3F4F6");

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
			=> throw new NotImplementedException();
	}

	public class BoolToTextColorConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
			=> (bool)value ? Color.FromArgb("#FFFFFF") : Color.FromArgb("#6B7280");

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
			=> throw new NotImplementedException();
	}
}