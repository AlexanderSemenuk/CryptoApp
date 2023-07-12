using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Markup;

namespace CryptoApp.Converters
{
    public class MarketCapConverter : MarkupExtension, IValueConverter
    {
        private static MarketCapConverter _instance;
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            if (_instance == null)
            {
                _instance = new MarketCapConverter();
            }
            return _instance;
        }
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null || !(value is string marketCapString))
                return string.Empty;

            if (decimal.TryParse(marketCapString, NumberStyles.Any, CultureInfo.InvariantCulture, out decimal marketCap))
            {
                string formattedMarketCap = "";

                if (marketCap >= 1_000_000_000_000)
                {
                    formattedMarketCap = (marketCap / 1_000_000_000_000).ToString("N2", CultureInfo.InvariantCulture) + "t";
                }
                else if (marketCap >= 1_000_000_000)
                {
                    formattedMarketCap = (marketCap / 1_000_000_000).ToString("N2", CultureInfo.InvariantCulture) + "b";
                }
                else if (marketCap >= 1_000_000)
                {
                    formattedMarketCap = (marketCap / 1_000_000).ToString("N2", CultureInfo.InvariantCulture) + "m";
                }
                else if (marketCap >= 1_000)
                {
                    formattedMarketCap = (marketCap / 1_000).ToString("N2", CultureInfo.InvariantCulture) + "k";
                }
                else
                {
                    formattedMarketCap = marketCap.ToString("N2", CultureInfo.InvariantCulture);
                }

                return formattedMarketCap;
            }

            return string.Empty;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
