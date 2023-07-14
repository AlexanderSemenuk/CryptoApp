using CryptoApp.Models;
using System;
using System.Windows.Data;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.DirectoryServices;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Globalization;

namespace CryptoApp.ViewModels
{
    public class CryptoViewModel : INotifyPropertyChanged
    {
        
        private bool isAscending = true;
        private ObservableCollection<Cryptocurrency> _cryptocurrencies;
        private ObservableCollection<Cryptocurrency> currentCurrencies;
        public ObservableCollection<Cryptocurrency> CurrentCurrencies
        {
            get { return currentCurrencies; }
            set
            {
                currentCurrencies = value;
                OnPropertyChanged(nameof(CurrentCurrencies));
            }
        }
        public ObservableCollection<Cryptocurrency> Cryptocurrencies
        {
            get { return _cryptocurrencies; }
            set
            {
                _cryptocurrencies = value;
                OnPropertyChanged(nameof(Cryptocurrencies));
            }
        }
        private string _changePercent24Hr;
        public string ChangePercent24Hr
        {
            get { return _changePercent24Hr; }
            set
            {
                _changePercent24Hr = value;
                OnPropertyChanged(nameof(ChangePercent24Hr));
            }
        }
        public CryptoViewModel()
        {
            LoadCryptocurrencies();
            
        }

        private async void LoadCryptocurrencies()
        {
            ApiContext apiContext = new ApiContext();
            List<Cryptocurrency> cryptocurrencies = await apiContext.GetCryptocurrencies();
            Cryptocurrencies = new ObservableCollection<Cryptocurrency>(cryptocurrencies);
            CurrentCurrencies = Cryptocurrencies;

            if (Cryptocurrencies.Count > 0)
            {
                ChangePercent24Hr = Cryptocurrencies[0].changePercent24Hr;
            }

        }

        public void PerformSearch(string searchString)
        {
            ObservableCollection<Cryptocurrency> results = new ObservableCollection<Cryptocurrency>();
            foreach (Cryptocurrency crypto in CurrentCurrencies)
            {
                if (crypto.name.Contains(searchString, StringComparison.OrdinalIgnoreCase))
                {
                    results.Add(crypto);
                }
            }

            CurrentCurrencies = results;
        }

        public void SortByRank(object sender, MouseButtonEventArgs e)
        {
            if (CurrentCurrencies != null)
            {
                List<Cryptocurrency> sortedCryptocurrencies;
                if (isAscending)
                {
                    sortedCryptocurrencies = CurrentCurrencies.OrderBy(crypto => crypto.rank).ToList();
                }
                else
                {
                    sortedCryptocurrencies = CurrentCurrencies.OrderByDescending(crypto => crypto.rank).ToList();
                }

                CurrentCurrencies = new ObservableCollection<Cryptocurrency>(sortedCryptocurrencies);
                isAscending = !isAscending;
            }
        }
        public void SortByPrice(object sender, MouseButtonEventArgs e)
        {
            if (CurrentCurrencies != null)
            {
                List<Cryptocurrency> sortedCryptocurrencies;
                if (isAscending)
                {
                    sortedCryptocurrencies = CurrentCurrencies.OrderBy(crypto =>
                    {
                        decimal price;
                        return decimal.TryParse(crypto.priceUsd, NumberStyles.Number, CultureInfo.InvariantCulture, out price) ? price : decimal.MinValue;
                    }).ToList();
                }
                else
                {
                    sortedCryptocurrencies = CurrentCurrencies.OrderByDescending(crypto =>
                    {
                        decimal price;
                        return decimal.TryParse(crypto.priceUsd, NumberStyles.Number, CultureInfo.InvariantCulture, out price) ? price : decimal.MinValue;
                    }).ToList();
                }

                CurrentCurrencies = new ObservableCollection<Cryptocurrency>(sortedCryptocurrencies);
                isAscending = !isAscending;
            }
        } 

        public void SortByName(object sender, MouseButtonEventArgs e)
        {
            if (CurrentCurrencies != null)
            {
                List<Cryptocurrency> sortedCryptocurrencies;
                if (isAscending)
                {
                    sortedCryptocurrencies = CurrentCurrencies.OrderBy(crypto => crypto.name).ToList();
                }
                else
                {
                    sortedCryptocurrencies = CurrentCurrencies.OrderByDescending(crypto => crypto.name).ToList();
                }

                CurrentCurrencies = new ObservableCollection<Cryptocurrency>(sortedCryptocurrencies);
                isAscending = !isAscending;
            }
        }






        public void SortByMarketCap(object sender, MouseButtonEventArgs e)
        {
            if (CurrentCurrencies != null)
            {
                List<Cryptocurrency> sortedCryptocurrencies;
                if (isAscending)
                {
                    sortedCryptocurrencies = CurrentCurrencies.OrderBy(crypto =>
                    {
                        decimal price;
                        return decimal.TryParse(crypto.marketCapUsd, NumberStyles.Number, CultureInfo.InvariantCulture, out price) ? price : decimal.MinValue;
                    }).ToList();
                }
                else
                {
                    sortedCryptocurrencies = CurrentCurrencies.OrderByDescending(crypto =>
                    {
                        decimal price;
                        return decimal.TryParse(crypto.marketCapUsd, NumberStyles.Number, CultureInfo.InvariantCulture, out price) ? price : decimal.MinValue;
                    }).ToList();
                }

                CurrentCurrencies = new ObservableCollection<Cryptocurrency>(sortedCryptocurrencies);
                isAscending = !isAscending;
            }
        }
        public void SortByVwap(object sender, MouseButtonEventArgs e)
        {
            if (CurrentCurrencies != null)
            {
                List<Cryptocurrency> sortedCryptocurrencies;
                if (isAscending)
                {
                    sortedCryptocurrencies = CurrentCurrencies.OrderBy(crypto =>
                    {
                        decimal price;
                        return decimal.TryParse(crypto.vwap24Hr, NumberStyles.Number, CultureInfo.InvariantCulture, out price) ? price : decimal.MinValue;
                    }).ToList();
                }
                else
                {
                    sortedCryptocurrencies = CurrentCurrencies.OrderByDescending(crypto =>
                    {
                        decimal price;
                        return decimal.TryParse(crypto.vwap24Hr, NumberStyles.Number, CultureInfo.InvariantCulture, out price) ? price : decimal.MinValue;
                    }).ToList();
                }

                CurrentCurrencies = new ObservableCollection<Cryptocurrency>(sortedCryptocurrencies);
                isAscending = !isAscending;
            }
        }
        public void SortBySupply(object sender, MouseButtonEventArgs e)
        {
            if (CurrentCurrencies != null)
            {
                List<Cryptocurrency> sortedCryptocurrencies;
                if (isAscending)
                {
                    sortedCryptocurrencies = CurrentCurrencies.OrderBy(crypto =>
                    {
                        decimal supply;
                        return decimal.TryParse(crypto.supply, NumberStyles.Number, CultureInfo.InvariantCulture, out supply) ? supply : decimal.MinValue;
                    }).ToList();
                }
                else
                {
                    sortedCryptocurrencies = CurrentCurrencies.OrderByDescending(crypto =>
                    {
                        decimal supply;
                        return decimal.TryParse(crypto.supply, NumberStyles.Number, CultureInfo.InvariantCulture, out supply) ? supply : decimal.MinValue;
                    }).ToList();
                }

                CurrentCurrencies = new ObservableCollection<Cryptocurrency>(sortedCryptocurrencies);
                isAscending = !isAscending;
            }
        }
        public void SortByVolume(object sender, MouseButtonEventArgs e)
        {
            if (CurrentCurrencies != null)
            {
                List<Cryptocurrency> sortedCryptocurrencies;
                if (isAscending)
                {
                    sortedCryptocurrencies = CurrentCurrencies.OrderBy(crypto =>
                    {
                        decimal volume;
                        return decimal.TryParse(crypto.volumeUsd24Hr, NumberStyles.Number, CultureInfo.InvariantCulture, out volume) ? volume : decimal.MinValue;
                    }).ToList();
                }
                else
                {
                    sortedCryptocurrencies = CurrentCurrencies.OrderByDescending(crypto =>
                    {
                        decimal volume;
                        return decimal.TryParse(crypto.volumeUsd24Hr, NumberStyles.Number, CultureInfo.InvariantCulture, out volume) ? volume : decimal.MinValue;
                    }).ToList();
                }

                CurrentCurrencies = new ObservableCollection<Cryptocurrency>(sortedCryptocurrencies);
                isAscending = !isAscending;
            }
        }
        public void SortByChange(object sender, MouseButtonEventArgs e)
        {
            if (CurrentCurrencies != null)
            {
                List<Cryptocurrency> sortedCryptocurrencies;
                if (isAscending)
                {
                    sortedCryptocurrencies = CurrentCurrencies.OrderBy(crypto =>
                    {
                        double price;
                        return double.TryParse(crypto.changePercent24Hr, NumberStyles.Number, CultureInfo.InvariantCulture, out price) ? price : double.MinValue;
                    }).ThenBy(crypto => Math.Abs(double.Parse(crypto.changePercent24Hr))).ToList();
                }
                else
                {
                    sortedCryptocurrencies = CurrentCurrencies.OrderByDescending(crypto =>
                    {
                        double price;
                        return double.TryParse(crypto.changePercent24Hr, NumberStyles.Number, CultureInfo.InvariantCulture, out price) ? price : double.MinValue;
                    }).ThenByDescending(crypto => Math.Abs(double.Parse(crypto.changePercent24Hr))).ToList();
                }

                CurrentCurrencies = new ObservableCollection<Cryptocurrency>(sortedCryptocurrencies);
                isAscending = !isAscending;
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
