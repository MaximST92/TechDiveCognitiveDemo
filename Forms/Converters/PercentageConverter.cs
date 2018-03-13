using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.Forms;

namespace maximst.CognitiveDemo.Forms.Converters
{
    public class PercentageConverter: IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is string s)
            {
                if (double.TryParse(s, out double result))
                {
                    return (result * 100).ToString("F") + "%";
                }

                return s;
            }
            else if(value is double d)
            {
                return (d * 100).ToString("F") + "%";
            }

            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}
