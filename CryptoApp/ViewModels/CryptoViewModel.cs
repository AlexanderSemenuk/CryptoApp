using CryptoApp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.DirectoryServices;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace CryptoApp.ViewModels
{
    public class CryptoViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<Cryptocurrency> _cryptocurrencies;
        public ObservableCollection<Cryptocurrency> Cryptocurrencies
        {
            get { return _cryptocurrencies; }
            set
            {
                _cryptocurrencies = value;
                OnPropertyChanged(nameof(Cryptocurrencies));
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
        }
        public List<Cryptocurrency> SearchCryptocurrencies(string searchString)
        {
            return PerformSearch(searchString);
        }
        private List<Cryptocurrency> PerformSearch(string searchString)
        {
            List <Cryptocurrency> results = new List<Cryptocurrency>();
            foreach (Cryptocurrency crypto in Cryptocurrencies)
            {
                if (crypto.name.Contains(searchString, StringComparison.OrdinalIgnoreCase))
                {
                    results.Add(crypto);
                }

            }
            return results;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
