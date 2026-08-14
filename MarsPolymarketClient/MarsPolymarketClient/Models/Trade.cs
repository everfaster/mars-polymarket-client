using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MarsPolymarketClient.Models;

namespace MarsPolymarketClient.Models
{
    public class Trade
    {
        public string ProxyWallet { get; set; } = string.Empty;
        public string Side { get; set; } = string.Empty;
        public string Asset { get; set; } = string.Empty;
        public string ConditionId { get; set; } = string.Empty;
        public decimal Size { get; set; } = 0;
        public decimal Price { get; set; } = 0;
        public long Timestamp { get; set; } = 0;
        public string Title { get; set; } = string.Empty;
        public string Slug { get; set; } = string.Empty;
        public string Outcome { get; set; } = string.Empty;
        public int OutcomeIndex { get; set; } = -1;
        public string Name { get; set; } = string.Empty;
        public string TransactionHash { get; set; } = string.Empty;
    }

    public class TradeSummary
    {
        public string Name { get; set; } = string.Empty;
        public string ProxyWallet { get; set; } = string.Empty;
        public decimal UpBuy { get; set; } = 0;
        public decimal UpSell { get; set; } = 0;
        public decimal UpProfit { get; set; } = 0;
        public decimal DownBuy { get; set; } = 0;
        public decimal DownSell { get; set; } = 0;
        public decimal DownProfit { get; set; } = 0;
        public decimal TotalProfit { get; set; } = 0;
        public int TradeCount { get; set; } = 0;
        public decimal TotalAmount { get; set; } = 0;
    }

    public class UserSummary
    {
        public string Name { get; set; } = string.Empty;
        public string ProxyWallet { get; set; } = string.Empty;
        public List<string> Slugs { get; set; } = new List<string>();
        public int EventCount { get; set; } = 0;
        public int WinCount { get; set; } = 0;
        public int LoseCount { get; set; } = 0;
        public decimal WinAmount { get; set; } = 0;
        public decimal LoseAmount { get; set; } = 0;
        public decimal TotalProfit { get; set; } = 0;
    }
}
