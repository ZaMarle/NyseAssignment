using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nyse.Client
{
    public class Stock
    {
        public string stockSymbol { get; set; }
        public DateTime date { get; set; }
        public double stockPriceOpen { get; set; }
        public double stockPriceHigh { get; set; }
        public double stockPriceLow { get; set; }
        public double stockPriceClose { get; set; }
        public double stockVolume { get; set; }
        public double stockPriceAdjClose { get; set; }
    }
}
