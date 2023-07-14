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
using System.Windows.Input;

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
        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            string searchString = txtSearch.Text;
            if (string.IsNullOrEmpty(searchString))
            {
                cryptoViewModel.CurrentCurrencies = cryptoViewModel.Cryptocurrencies;
                lbResults.ItemsSource = cryptoViewModel.CurrentCurrencies;
            }
            else
            {
                cryptoViewModel.PerformSearch(searchString);
                lbResults.ItemsSource = cryptoViewModel.CurrentCurrencies;
            }
        }
        private void SortByRank(object sender, MouseButtonEventArgs e)
        {

            if (DataContext is CryptoViewModel viewModel)
            {
                viewModel.SortByRank(sender, e);
                lbResults.ItemsSource = viewModel.CurrentCurrencies;
            }
        }
        private void SortByPrice(object sender, MouseButtonEventArgs e)
        {
            if (DataContext is CryptoViewModel viewModel)
            {
                viewModel.SortByPrice(sender, e);
                lbResults.ItemsSource = viewModel.CurrentCurrencies;
            }
        }
        private void SortByName(object sender, MouseButtonEventArgs e)
        {
            if (DataContext is CryptoViewModel viewModel)
            {
                viewModel.SortByName(sender, e);
                lbResults.ItemsSource = viewModel.CurrentCurrencies;
            }
        }
        private void SortByMarketCap(object sender, MouseButtonEventArgs e)
        {
            if (DataContext is CryptoViewModel viewModel)
            {
                viewModel.SortByMarketCap(sender, e);
                lbResults.ItemsSource = viewModel.CurrentCurrencies;
            }
        }
        private void SortByVwap(object sender, MouseButtonEventArgs e)
        {
            if (DataContext is CryptoViewModel viewModel)
            {
                viewModel.SortByVwap(sender, e);
                lbResults.ItemsSource = viewModel.CurrentCurrencies;
            }
        }
        private void SortBySupply(object sender, MouseButtonEventArgs e)
        {
            if (DataContext is CryptoViewModel viewModel)
            {
                viewModel.SortBySupply(sender, e);
                lbResults.ItemsSource = viewModel.CurrentCurrencies;
            }
        }
        private void SortByChange(object sender, MouseButtonEventArgs e)
        {
            if (DataContext is CryptoViewModel viewModel)
            {
                viewModel.SortByChange(sender, e);
                lbResults.ItemsSource = viewModel.CurrentCurrencies;
            }
        }
        private void SortByVolume(object sender, MouseButtonEventArgs e)
        {
            if (DataContext is CryptoViewModel viewModel)
            {
                viewModel.SortByVolume(sender, e);
                lbResults.ItemsSource = viewModel.CurrentCurrencies;
            }
        }

        private void lbResults_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {

        }
    }

}
