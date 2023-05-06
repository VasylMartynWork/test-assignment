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
        private List<Coin> coins;

        public MainViewModel()
        {
            LoadData();
        }

        public List<Coin> Coins
        {
            get => coins;
            set
            {
                coins = value;
                OnPropertyChanged("Coins");
            }
        }

        private async void LoadData()
        {
            var response = await client.GetAsync("https://api.coincap.io/v2/assets?limit=10");
            var coinsJson = await response.Content.ReadAsStringAsync();
            var coinCapResponse = JsonConvert.DeserializeObject<CoinCapResponse>(coinsJson);

            Coins = result.Data;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
