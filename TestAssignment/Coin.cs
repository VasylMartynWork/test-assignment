using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace TestAssignment
{
    public class Coin : INotifyPropertyChanged
    {
        public string id { get; set; }
        public string rank { get; set; }
        public string symbol { get; set; }
        public string name { get; set; }
        public string supply { get; set; }
        public string maxSupply { get; set; }
        public string marketCapUsd { get; set; }
        public string volumeUsd24Hr { get; set; }
        public string priceUsd { get; set; }
        public string changePercent24H { get; set; }

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
