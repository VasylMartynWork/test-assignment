using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows;

namespace TestAssignment
{
    public class CurrencyInformationViewModel : INotifyPropertyChanged
    {
        private readonly HttpClient client = new HttpClient();

        private List<Currency> currencies;
        public List<Currency> Currencies
        {
            get { return currencies; }
            set
            {
                currencies = value;
                OnPropertyChanged("Currencies");
            }
        }

        private string searchTerm;
        public string SearchTerm
        {
            get { return searchTerm; }
            set
            {
                searchTerm = value;
                OnPropertyChanged("SearchTerm");
            }
        }

        private Currency foundCurrency;
        public Currency FoundCurrency
        {
            get { return foundCurrency; }
            set
            {
                foundCurrency = value;
                OnPropertyChanged("FoundCurrency");
            }
        }
        public RelayCommand searchCurrenciesCommand { get; set; }
        public RelayCommand switchWindowCommand { get; set; }

        public CurrencyInformationViewModel()
        {
            switchWindowCommand = new RelayCommand(obj =>
            {
                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();
                App.Current.Windows.OfType<CurrencyInformationWindow>().First().Close();
            });
            searchCurrenciesCommand = new RelayCommand(async obj =>
            {
                await GetCurrenciesAsync();
            });

        }

        public async Task GetCurrenciesAsync()
        {
            var assetsResponse = await client.GetAsync("https://api.coincap.io/v2/assets");
            var currenciesJson = await assetsResponse.Content.ReadAsStringAsync();
            var currenciesFromJson = JsonConvert.DeserializeObject<CoinCapAssetsResponse>(currenciesJson);

            var marketsResponse = await client.GetAsync("https://api.coincap.io/v2/markets?limit=200");
            var marketsJson = await marketsResponse.Content.ReadAsStringAsync();
            var marketsFromJson = JsonConvert.DeserializeObject<CoinCapMarketsResponse>(marketsJson);

            currenciesFromJson.Data.ForEach(currency =>
            { currency.Markets.AddRange(marketsFromJson.data.Where(market => market.BaseSymbol == currency.Symbol).ToList()); });


            Currencies = currenciesFromJson.Data;

            FilterCurrencies();
        }

        private void FilterCurrencies()
        {
            if (!string.IsNullOrWhiteSpace(SearchTerm))
            {
                try
                {
                    FoundCurrency = Currencies.Where(c => c.Name.Contains(SearchTerm, StringComparison.OrdinalIgnoreCase) || c.Symbol.Contains(SearchTerm, StringComparison.OrdinalIgnoreCase)).First();
                }
                catch(InvalidOperationException e) 
                { 
                    MessageBox.Show("Such currency does not exist", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
