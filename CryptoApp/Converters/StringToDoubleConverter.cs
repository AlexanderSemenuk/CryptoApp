using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Markup;

namespace CryptoApp.Converters
{
    public class StringToDoubleConverter : MarkupExtension, IValueConverter
    {
        private static StringToDoubleConverter _instance;
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            if (_instance == null)
            {
                _instance = new StringToDoubleConverter();
            }
            return _instance;
        }
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is string stringValue)
            {
                if (double.TryParse(stringValue, NumberStyles.Any, CultureInfo.InvariantCulture, out double result))
                {
                    return result;
                }
            }

            return DependencyProperty.UnsetValue;
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

    }
}
