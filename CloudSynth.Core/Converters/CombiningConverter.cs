using System;
using System.Globalization;
using System.Linq;
using System.Windows.Data;
using System.Windows.Markup;
using CloudSynth.Core.Models;

namespace CloudSynth.Core.Converters
{
    [ContentProperty("Converters")]
    [ContentWrapper(typeof(ValueConverterCollection))]
    public class CombiningConverter : IValueConverter
    {
        public ValueConverterCollection Converters { get; } = new ValueConverterCollection();

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return Converters.Aggregate(value,
                (current, converter) => converter.Convert(current, targetType, parameter, culture));
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return Converters.Reverse().Aggregate(value,
                (current, converter) => converter.ConvertBack(current, targetType, parameter, culture));
        }
    }
}
