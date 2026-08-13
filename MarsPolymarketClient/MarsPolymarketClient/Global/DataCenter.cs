using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MarsPolymarketClient.Models;

namespace MarsPolymarketClient.Global
{
    public class DataCenter
    {
        public static ClientAccount? ActiveAccount = null;

        public static Dictionary<string, Event> Events = new Dictionary<string, Event>();
    }
}
