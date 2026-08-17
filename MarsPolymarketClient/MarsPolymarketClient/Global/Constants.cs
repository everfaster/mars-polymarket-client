using MarsPolymarketClient.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsPolymarketClient.Global
{
    public class Constants
    {
        public static readonly string BUY = "BUY";
        public static readonly string SELL = "SELL";
        public static readonly string UP = "Up";
        public static readonly string DOWN = "Down";
        public static readonly decimal FEE_RATE = 0.07m;

        public static List<(string, string)> EVENTS = new()
        {
            ("BTC Up or Down 5m", "btc-updown-5m"),
            ("BTC Up or Down 15m", "btc-updown-15m"),
            ("BTC Up or Down Hourly", "bitcoin-up-or-down"),
            ("BTC Up or Down 4h", "btc-updown-4h"),
            ("BTC Up or Down Daily", "bitcoin-up-or-down-on"),

            ("ETH Up or Down 5m", "eth-updown-5m"),
            ("ETH Up or Down 15m", "eth-updown-15m"),
            ("ETH Up or Down Hourly", "ethereum-up-or-down"),
            ("ETH Up or Down 4h", "eth-updown-4h"),
            ("ETH Up or Down Daily", "ethereum-up-or-down-on"),
            
            ("SOL Up or Down 5m", "sol-updown-5m"),
            ("SOL Up or Down 15m", "sol-updown-15m"),
            ("SOL Up or Down Hourly", "solana-up-or-down"),
            ("SOL Up or Down 4h", "sol-updown-4h"),
            ("SOL Up or Down Daily", "solana-up-or-down-on"),
            
            ("XRP Up or Down 5m", "xrp-updown-5m"),
            ("XRP Up or Down 15m", "xrp-updown-15m"),
            ("XRP Up or Down Hourly", "xrp-up-or-down"),
            ("XRP Up or Down 4h", "xrp-updown-4h"),
            ("XRP Up or Down Daily", "xrp-up-or-down-on"),
            
            ("DOGE Up or Down 5m", "doge-updown-5m"),
            ("DOGE Up or Down 15m", "doge-updown-15m"),
            ("DOGE Up or Down Hourly", "dogecoin-up-or-down"),
            ("DOGE Up or Down 4h", "doge-updown-4h"),
            ("DOGE Up or Down Daily", "dogecoin-up-or-down-on"),
            
            ("HYPE Up or Down 5m", "hype-updown-5m"),
            ("HYPE Up or Down 15m", "hype-updown-15m"),
            ("HYPE Up or Down Hourly", "hype-up-or-down"),
            ("HYPE Up or Down 4h", "hype-updown-4h"),
            ("HYPE Up or Down Daily", "hype-up-or-down-on"),
            
            ("BNB Up or Down 5m", "bnb-updown-5m"),
            ("BNB Up or Down 15m", "bnb-updown-15m"),
            ("BNB Up or Down Hourly", "bnb-up-or-down"),
            ("BNB Up or Down 4h", "bnb-updown-4h"),
            ("BNB Up or Down Daily", "bnb-up-or-down-on"),
        };
    }
}
