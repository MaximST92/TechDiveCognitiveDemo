using System;
using System.Globalization;
using maximst.CognitiveDemo.Forms.Extensions;

namespace maximst.CognitiveDemo.Forms.Converters
{
	public class InvertedBooleanConverter : MarkupConverterExtension<InvertedBooleanValueConverter> 
	{
	}

	public class InvertedBooleanValueConverter : Xamarin.Forms.IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			if (value is bool)
				return !(bool)value;

			return value;
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			return null;
		}
	}
}