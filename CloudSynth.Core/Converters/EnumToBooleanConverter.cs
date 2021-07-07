using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;
using CloudSynth.Core.Models;

namespace CloudSynth.Core.Converters
{
    [ValueConversion(typeof(Series), typeof(bool))]
    public class EnumToBooleanConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (parameter is not string paramString)
                return DependencyProperty.UnsetValue;

            if (value == null || !Enum.IsDefined(value.GetType(), value))
                return DependencyProperty.UnsetValue;

            var paramValue = Enum.Parse(value.GetType(), paramString);

            return paramValue.Equals(value);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return parameter is not string paramString
                ? DependencyProperty.UnsetValue
                : Enum.Parse(targetType, paramString);
        }
    }
}
