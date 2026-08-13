using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MarsPolymarketClient.Models;

namespace MarsPolymarketClient.Models
{
    public class Event
    {
        public string Slug { get; set; } = "";
        public Market Market { get; set; } = new Market();
        public List<Trade> Trades { get; set; } = new List<Trade>();
        public Dictionary<string, TradeSummary> TradeSummaries { get; set; } = new Dictionary<string, TradeSummary>();
        public bool Analyzed { get; set; } = false;
    }
}
