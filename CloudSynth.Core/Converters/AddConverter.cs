using System;
using System.Globalization;
using System.Windows.Data;

namespace CloudSynth.Core.Converters
{
    [ValueConversion(typeof(int), typeof(int))]
    public class AddConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var origin = System.Convert.ToInt32(value);
            var operand = System.Convert.ToInt32(parameter);

            return origin + operand;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var origin =System.Convert.ToInt32(value);
            var operand = System.Convert.ToInt32(parameter);

            return origin - operand;
        }
    }
}
