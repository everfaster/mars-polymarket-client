using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MarsPolymarketClient.Models;

namespace MarsPolymarketClient.Models
{
    public class TradeStatus
    {
        public bool Running { get; set; } = false;
        public decimal Balance { get; set; } = 0;
        public decimal Profit { get; set; } = 0;
        public string TradeOptions { get; set; } = "";
    }
}
