using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;

namespace TestAssignment
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private readonly HttpClient client = new HttpClient();
        private List<Currency> currencies;
        public RelayCommand switchWindowCommand { get; set; }

        public MainViewModel()
        {
            LoadAndOutputData();
            switchWindowCommand = new RelayCommand(obj =>
            {
                CurrencyInformationWindow currencyInformationWindow = new CurrencyInformationWindow();
                currencyInformationWindow.Show();
                App.Current.MainWindow.Close();
            });
            //switchWindowCommand = new ICommand()
            //{
            //    CurrencyInformationWindow window = new CurrencyInformationWindow();
            //window.Show();
            //}
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
