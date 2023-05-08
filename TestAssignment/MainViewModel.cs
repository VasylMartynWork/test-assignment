using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel;
using System.Net.Http;
using System.Runtime.CompilerServices;

namespace TestAssignment
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private readonly HttpClient client = new HttpClient();
        private List<Currency> currencies;

        public MainViewModel()
        {
            LoadAndOutputData();
        }

        public List<Currency> Currencies
        {
            get => currencies;
            set
            {
                currencies = value;
                OnPropertyChanged("Currencies");
            }
        }

        private async void LoadAndOutputData()
        {
            var currenciesResponse = await client.GetAsync("https://api.coincap.io/v2/assets?limit=10");
            var currenciesJson = await currenciesResponse.Content.ReadAsStringAsync();
            var currenciesFromJson = JsonConvert.DeserializeObject<CoinCapAssetsResponse>(currenciesJson);

            var marketsResponse = await client.GetAsync("https://api.coincap.io/v2/markets");
            var marketsJson = await marketsResponse.Content.ReadAsStringAsync();
            var marketsFromJson = JsonConvert.DeserializeObject<CoinCapMarketsResponse>(marketsJson);

            Currencies = currenciesFromJson.Data;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
