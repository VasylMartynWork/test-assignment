using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestAssignment
{
    public class Market
    {
        private string exchangeId;
        private string baseSymbol;
        private float? priceUsd;
        public string ExchangeId
        {
            get { return exchangeId; }
            set { exchangeId = value; }
        }
        public string BaseSymbol
        {
            get { return baseSymbol; }
            set { baseSymbol = value; }
        }
        public float? PriceUsd
        {
            get { return priceUsd; }
            set { priceUsd = value; }
        }
    }
}
