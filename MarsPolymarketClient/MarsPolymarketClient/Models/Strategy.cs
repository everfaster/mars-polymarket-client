using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MarsPolymarketClient.Models;

namespace MarsPolymarketClient.Models
{
    public class Strategy
    {
        public string StrategyType { get; set; } = string.Empty;
        public string DefaultOptions { get; set; } = string.Empty;
    }
}
