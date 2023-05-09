using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Animation;

namespace TestAssignment
{
    public class Currency : INotifyPropertyChanged
    {
        private string? id;
        private string? rank;
        private string? symbol;
        private string? name;
        private double? supply;
        private double? maxSupply;
        private double? marketCapUsd;
        private double? volumeUsd24Hr;
        private double? priceUsd;
        private double? changePercent24Hr;
        private List<Market> markets = new List<Market>();

        public string Id
        {
            get { return id; }
            set { id = value; }
        }
        public string Rank
        {
            get { return rank; }
            set { rank = value; }
        }
        public string Symbol
        {
            get { return symbol; }
            set { symbol = value; }
        }
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public double? Supply
        {
            get { return supply; }
            set { supply = value; }
        }
        public double? MaxSupply
        {
            get { return maxSupply; }
            set { maxSupply = value; }
        }
        public double? MarketCapUsd
        {
            get { return marketCapUsd; }
            set { marketCapUsd = value; }
        }
        public double? VolumeUsd24Hr
        {
            get { return volumeUsd24Hr; }
            set { volumeUsd24Hr = value; }
        }
        public double? PriceUsd
        {
            get { return priceUsd; }
            set { priceUsd = value; }
        }
        public double? ChangePercent24Hr
        {
            get { return changePercent24Hr; }
            set { changePercent24Hr = value; }
        }
        public List<Market> Markets
        {
            get { return markets; }
            set { markets = value; }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
