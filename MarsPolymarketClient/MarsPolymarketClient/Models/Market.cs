using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MarsPolymarketClient.Models;

namespace MarsPolymarketClient.Models
{
    public class Market
    {
        public string Id { get; set; } = string.Empty;
        public string Question { get; set; } = string.Empty;
        public string ConditionId { get; set; } = string.Empty;
        public string Slug { get; set; } = string.Empty;
        public string StartTime { get; set; } = string.Empty;
        public string EndTime { get; set; } = string.Empty;
        public List<string> Outcomes { get; set; } = new List<string>();
        public List<string> OutcomePrices { get; set; } = new List<string>();
        public List<string> ClobTokenIds { get; set; } = new List<string>();
        public decimal OrderPriceMinTickSize { get; set; } = 0;
        public decimal OrderMinSize { get; set; } = 0;
    }
}
