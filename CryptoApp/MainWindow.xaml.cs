using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Net.Http;
using System.Threading.Tasks;
using CryptoApp.Models;
using System.Windows;
using CryptoApp.ViewModels;
using System.DirectoryServices;

namespace CryptoApp
{
    public partial class MainWindow : Window
    {
        private CryptoViewModel cryptoViewModel;
        public MainWindow()
        {
            InitializeComponent();
            cryptoViewModel = new CryptoViewModel();
            DataContext = cryptoViewModel;
        }

        private void ListView_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {

        }

        private void ListView_SelectionChanged_1(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {

        }
        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            string searchString = txtSearch.Text;
            List<Cryptocurrency> results = cryptoViewModel.SearchCryptocurrencies(searchString);
            ObservableCollection<Cryptocurrency> filteredCryptocurrencies = new ObservableCollection<Cryptocurrency>(results);
            lbResults.ItemsSource = filteredCryptocurrencies;
        }
    }

}
