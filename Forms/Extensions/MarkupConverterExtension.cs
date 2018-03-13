using System;
using System.Globalization;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace maximst.CognitiveDemo.Forms.Extensions
{
	public abstract class MarkupConverterExtension<T> : IMarkupExtension, IValueConverter 
		where T : class, IValueConverter, new()
	{
		static T _converter;

		public object ProvideValue(IServiceProvider serviceProvider)
		{
			return _converter ?? (_converter = new T());
		}

		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			return _converter.Convert(value, targetType, parameter, culture);
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			return _converter.ConvertBack(value, targetType, parameter, culture);
		}
	}
}