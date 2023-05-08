using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace TestAssignment
{
    public class CurrencyInformationViewModel : INotifyPropertyChanged
    {
        private Currency selectedCurrency;
        public Currency SelectedCurrency
        {
            get { return selectedCurrency; }
            set
            {
                selectedCurrency = value;
                OnPropertyChanged("SelectedCurrency");
            }
        }

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
                FilterCurrencies();
            }
        }

        private List<Currency> foundCurrencies;
        public List<Currency> FoundCurrencies
        {
            get { return foundCurrencies; }
            set
            {
                foundCurrencies = value;
                OnPropertyChanged("FoundCurrencies");
            }
        }

        public async Task GetCurrenciesAsync()
        {
            using (var client = new HttpClient())
            {
                var assetsResponse = await client.GetAsync("https://api.coincap.io/v2/assets");
                var currenciesJson = await assetsResponse.Content.ReadAsStringAsync();
                var currenciesFromJson = JsonConvert.DeserializeObject<CoinCapAssetsResponse>(currenciesJson);

                var marketsResponse = await client.GetAsync("https://api.coincap.io/v2/markets");
                var marketsJson = await marketsResponse.Content.ReadAsStringAsync();
                var marketsFromJson = JsonConvert.DeserializeObject<CoinCapMarketsResponse>(marketsJson);

                Currencies = currenciesFromJson.Data;

                //Currencies = data.Data.Select(d => new Currency
                //{
                //    Name = d.Name,
                //    Symbol = d.Symbol,
                //    PriceUsd = d.PriceUsd,
                //    VolumeUsd24Hr = d.VolumeUsd24Hr,
                //    ChangePercent24H = d.ChangePercent24H,
                //    Markets = d.Markets.Select(m => new Market
                //    {
                //        ExchangeId = m.ExchangeId,
                //        PriceUsd = m.PriceUsd
                //    }).ToList()
                //}).ToList();

                FilterCurrencies();
            }
        }

        private void FilterCurrencies()
        {
            if (string.IsNullOrWhiteSpace(SearchTerm))
            {
                FoundCurrencies = Currencies;
            }
            else
            {
                FoundCurrencies = Currencies.Where(c => c.Name.Contains(SearchTerm, StringComparison.OrdinalIgnoreCase) || c.Symbol.Contains(SearchTerm, StringComparison.OrdinalIgnoreCase)).ToList();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
