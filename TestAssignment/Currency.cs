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
        private double? changePercent24H;
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
        public double? ChangePercent24H
        {
            get { return changePercent24H; }
            set { changePercent24H = value; }
        }
        public List<Market> Markets
        {
            get { return markets; }
            set { markets = value; }
        }

        //public string Id
        //{
        //    get { return id; }
        //    set
        //    {
        //        id = value;
        //        OnPropertyChanged("Id");
        //    }
        //}
        //public string Symbol
        //{
        //    get { return Symbol; }
        //    set
        //    {
        //        symbol = value;
        //        OnPropertyChanged("Symbol");
        //    }
        //}
        //public string Name
        //{
        //    get { return name; }
        //    set
        //    {
        //        name = value;
        //        OnPropertyChanged("Name");
        //    }
        //}
        //public string Supply
        //{
        //    get { return supply; }
        //    set
        //    {
        //        supply = value;
        //        OnPropertyChanged("Supply");
        //    }
        //}
        //public string MaxSupply
        //{
        //    get { return maxSupply; }
        //    set
        //    {
        //        maxSupply = value;
        //        OnPropertyChanged("MaxSupply");
        //    }
        //}
        //public string MarketCapUsd
        //{
        //    get { return marketCapUsd; }
        //    set
        //    {
        //        marketCapUsd = value;
        //        OnPropertyChanged("MarketCapUsd");
        //    }
        //}
        //public string VolumeUsd24Hr
        //{
        //    get { return volumeUsd24Hr; }
        //    set
        //    {
        //        volumeUsd24Hr = value;
        //        OnPropertyChanged("VolumeUsd24Hr");
        //    }
        //}
        //public string PriceUsd
        //{
        //    get { return priceUsd; }
        //    set
        //    {
        //        priceUsd = value;
        //        OnPropertyChanged("PriceUsd");
        //    }
        //}
        //public string ChangePercent24H
        //{
        //    get { return changePercent24H; }
        //    set
        //    {
        //        changePercent24H = value;
        //        OnPropertyChanged("changePercent24H");
        //    }
        //}

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
