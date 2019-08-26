using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nyse.Client
{
    interface IStock
    {
        string stockSymbol { get; set; }
        DateTime date { get; set; }
        double stockPriceOpen { get; set; }
        double stockPriceHigh { get; set; }
        double stockPriceLow { get; set; }
        double stockPriceClose { get; set; }
        double stockVolume { get; set; }
        double stockPriceAdjClose { get; set; }
    }
}
