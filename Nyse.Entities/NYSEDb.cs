//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Nyse.Entities
{
    using System;
    using System.Collections.Generic;
    
    public partial class NYSEDb
    {
        public string exchange { get; set; }
        public string stockSymbol { get; set; }
        public Nullable<System.DateTime> date { get; set; }
        public Nullable<double> stockPriceOpen { get; set; }
        public Nullable<double> stockPriceHigh { get; set; }
        public Nullable<double> stockPriceLow { get; set; }
        public Nullable<double> stockPriceClose { get; set; }
        public Nullable<double> stockVolume { get; set; }
        public Nullable<double> stockPriceAdjClose { get; set; }
        public int ID { get; set; }
    }
}
