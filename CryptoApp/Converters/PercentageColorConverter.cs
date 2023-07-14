using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;
using System.Windows.Markup;
using System.Windows.Media;

namespace CryptoApp.Converters
{
    public class PercentageColorConverter : MarkupExtension, IValueConverter
    {
        private static PercentageColorConverter _instance;

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            if (_instance == null)
            {
                _instance = new PercentageColorConverter();
            }
            return _instance;
        }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is string stringValue)
            {
                if (double.TryParse(stringValue, NumberStyles.Any, CultureInfo.InvariantCulture, out double result))
                {
                    return result >= 0 ? Brushes.Green : Brushes.Red;
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
