using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MarsPolymarketClient.Models;

namespace MarsPolymarketClient.Models
{
    public class ClientAccount
    {
        public string SessionKey { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public TradeStatus Status { get; set; } = new TradeStatus();
    }
}
