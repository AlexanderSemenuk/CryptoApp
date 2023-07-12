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
    public class PriceFormatterConverter : MarkupExtension, IValueConverter
    {
        private static PriceFormatterConverter _instance;
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            if (_instance == null)
            {
                _instance = new PriceFormatterConverter();
            }
            return _instance;
        }
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is string stringValue)
            {
                if (stringValue[0] == '0') {
                    StringBuilder sb = new StringBuilder();
                    bool beforeComma = true, addNext = false;
                    foreach (char c in stringValue)
                    {
                        if (beforeComma)
                        {
                            sb.Append(c);
                            if (c == ',' || c == '.') beforeComma = false;
                        }
                        else
                        {
                            if (addNext)
                            {
                                if (c != '0') sb.Append(c);
                                break;
                            }
                            if (c != '0') addNext = true;
                            sb.Append(c);
                        }
                    }
                    if (decimal.TryParse(sb.ToString(), NumberStyles.Any, CultureInfo.InvariantCulture, out decimal priceResult))
                    {
                        return priceResult;
                    }
                }
                else
                {
                    if (decimal.TryParse(stringValue, NumberStyles.Any, CultureInfo.InvariantCulture, out decimal priceResult))
                    {
                        string formatted = priceResult.ToString("F2");
                        return decimal.Parse(formatted);
                    }
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
