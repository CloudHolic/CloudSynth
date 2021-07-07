using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Markup;
using CloudSynth.Core.Models;

namespace CloudSynth.Core.Converters
{
    [ContentProperty("Converters")]
    [ContentWrapper(typeof(ValueConverterCollection))]
    public class CombiningConverter : IValueConverter
    {
        private readonly ValueConverterCollection _converters = new ValueConverterCollection();

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
