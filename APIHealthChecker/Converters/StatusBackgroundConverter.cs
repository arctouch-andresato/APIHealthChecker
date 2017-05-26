using System;
using System.Globalization;
using Xamarin.Forms;

namespace APIHealthChecker.Converters
{
	public class StatusBackgroundConverter : IValueConverter
	{
		public Color TrueValue { get; set; }
		public Color FalseValue { get; set; }

		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			var castedValue = bool.Parse(value.ToString());
			return (castedValue ? TrueValue : FalseValue);

		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			throw new NotImplementedException();
		}
	}
}
