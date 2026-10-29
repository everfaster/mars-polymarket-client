
using MarsPolymarketClient.Forms;
using MarsPolymarketClient.Global;
using MarsPolymarketClient.Helpers;
using MarsPolymarketClient.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SocketIOClient;
using System.Net;
using System.Text.Json.Nodes;
using System.Text.RegularExpressions;

namespace MarsPolymarketClient.Services
{
    public class PolymarketService
    {
        static string GAMMA_API_URL = "https://gamma-api.polymarket.com";
        static string LOGIN_URL = $"{AppSettings.ServerAddress}/api/session/login";
        static string START_SESSION_URL = $"{AppSettings.ServerAddress}/api/session/start";
        static string STOP_SESSION_URL = $"{AppSettings.ServerAddress}/api/session/stop";
        static string GET_STRATEGIES_URL = $"{AppSettings.ServerAddress}/api/trade/strategies";
        static string START_TRADE_URL = $"{AppSettings.ServerAddress}/api/trade/start";
        static string STOP_TRADE_URL = $"{AppSettings.ServerAddress}/api/trade/stop";
        static string GET_TRADE_STATUS_URL = $"{AppSettings.ServerAddress}/api/trade/status";
        static string SET_TRADE_OPTIONS_URL = $"{AppSettings.ServerAddress}/api/trade/options";
        static string CLAIM_TRADE_URL = $"{AppSettings.ServerAddress}/api/trade/claim";

        public static bool ServerConnected = false;

        public static void Initialize()
        {
            var socketClient = new SocketIO(new Uri(AppSettings.SocketServerAddress), new SocketIOOptions());

            socketClient.OnConnected += (sender, e) =>
            {
                OnServerConnected(true);
            };

            socketClient.OnDisconnected += (sender, e) =>
            {
                OnServerConnected(false);
            };

            socketClient.ConnectAsync();

            Directory.CreateDirectory(AppSettings.DatabasePath);
            Directory.CreateDirectory($"{AppSettings.DatabasePath}//markets");
            Directory.CreateDirectory($"{AppSettings.DatabasePath}//trades");
        }

        private static void OnServerConnected(bool connected)
        {
            ServerConnected = connected;

            var mainForm = MainForm.GetInstance();
            if (mainForm != null)
                mainForm.SetServerStatus(ServerConnected);
        }

        public static async Task<string> Login(string encryptionKey)
        {
            HttpClient client = new HttpClient();

            var content = new FormUrlEncodedContent(new[] {
                new KeyValuePair<string, string>("password", Utils.ConvertToBase64String(encryptionKey))
            });
            var response = await client.PostAsync(LOGIN_URL, content);
            var jsonString = await response.Content.ReadAsStringAsync();

            if (jsonString.StartsWith("{\"error\""))
            {
                var jObject = JObject.Parse(jsonString);
                throw new Exception(jObject["error"]?.ToString());
            }

            return jsonString;
        }

        public static async Task<ClientAccount?> StartService(string apiKey, string apiSecret, string apiPass = "")
        {
            HttpClient client = new HttpClient();

            JObject parameter = new JObject();
            parameter["privateKey"] = apiKey;

            var data = Utils.EncryptData(parameter.ToString(), AppSettings.EncryptionKey, AppSettings.EncryptionIv);
            var content = new FormUrlEncodedContent(new[] {
                new KeyValuePair<string, string>("data", Utils.ConvertToBase64String(data))
            });
            var response = await client.PostAsync(START_SESSION_URL, content);

            var jsonString = await response.Content.ReadAsStringAsync();
            var jObject = JObject.Parse(jsonString);

            if (jObject["error"] != null)
                throw new Exception(jObject["error"]?.ToString());

            return JsonConvert.DeserializeObject<ClientAccount>(jsonString);
        }

        public static async Task<bool> StopService(string sessionKey)
        {
            HttpClient client = new HttpClient();

            JObject parameter = new JObject();
            parameter["sessionKey"] = sessionKey;

            var data = Utils.EncryptData(parameter.ToString(), AppSettings.EncryptionKey, AppSettings.EncryptionIv);
            var content = new FormUrlEncodedContent(new[] {
                new KeyValuePair<string, string>("data", Utils.ConvertToBase64String(data))
            });
            var response = await client.PostAsync(STOP_SESSION_URL, content);

            var jsonString = await response.Content.ReadAsStringAsync();

            if (jsonString.StartsWith("{\"error\""))
            {
                var jObject = JObject.Parse(jsonString);
                throw new Exception(jObject["error"]?.ToString());
            }

            return true;
        }

        public static async Task<bool> StartTrade(string sessionKey, string strategyType, string tradeOptions)
        {
            HttpClient client = new HttpClient();

            JObject parameter = new JObject();
            parameter["sessionKey"] = sessionKey;
            parameter["strategyType"] = strategyType;
            parameter["tradeOptions"] = tradeOptions;

            var data = Utils.EncryptData(parameter.ToString(), AppSettings.EncryptionKey, AppSettings.EncryptionIv);
            var content = new FormUrlEncodedContent(new[] {
                new KeyValuePair<string, string>("data", Utils.ConvertToBase64String(data))
            });
            var response = await client.PostAsync(START_TRADE_URL, content);

            var jsonString = await response.Content.ReadAsStringAsync();
            var jObject = JObject.Parse(jsonString);

            if (jObject["error"] != null)
                throw new Exception(jObject["error"]?.ToString());

            return jObject["running"]?.ToObject<bool>() ?? false;
        }

        public static async Task<bool> StopTrade(string sessionKey)
        {
            HttpClient client = new HttpClient();

            JObject parameter = new JObject();
            parameter["sessionKey"] = sessionKey;

            var data = Utils.EncryptData(parameter.ToString(), AppSettings.EncryptionKey, AppSettings.EncryptionIv);
            var content = new FormUrlEncodedContent(new[] {
                new KeyValuePair<string, string>("data", Utils.ConvertToBase64String(data))
            });
            var response = await client.PostAsync(STOP_TRADE_URL, content);

            var jsonString = await response.Content.ReadAsStringAsync();
            var jObject = JObject.Parse(jsonString);

            if (jObject["error"] != null)
                throw new Exception(jObject["error"]?.ToString());

            return true;
        }

        public static async Task<bool> SetTradeOptions(string sessionKey, string tradeOptions)
        {
            HttpClient client = new HttpClient();

            JObject parameter = new JObject();
            parameter["sessionKey"] = sessionKey;
            parameter["tradeOptions"] = tradeOptions;

            var data = Utils.EncryptData(parameter.ToString(), AppSettings.EncryptionKey, AppSettings.EncryptionIv);
            var content = new FormUrlEncodedContent(new[] {
                new KeyValuePair<string, string>("data", Utils.ConvertToBase64String(data))
            });
            var response = await client.PostAsync(SET_TRADE_OPTIONS_URL, content);

            var jsonString = await response.Content.ReadAsStringAsync();
            var jObject = JObject.Parse(jsonString);

            if (jObject["error"] != null)
                throw new Exception(jObject["error"]?.ToString());

            return jObject["running"]?.ToObject<bool>() ?? false;
        }

        public static async Task<List<Strategy>> GetStrategies()
        {
            HttpClient client = new HttpClient();

            var response = await client.GetAsync(GET_STRATEGIES_URL);

            response.EnsureSuccessStatusCode();
            
            var jsonString = await response.Content.ReadAsStringAsync();
            var strategies = JArray.Parse(jsonString).ToObject<List<Strategy>>() ?? new List<Strategy>();

            return strategies;
        }

        public static async Task<TradeStatus?> GetTradeStatus(string sessionKey)
        {
            HttpClient client = new HttpClient();

            JObject parameter = new JObject();
            parameter["sessionKey"] = sessionKey;

            var data = Utils.EncryptData(parameter.ToString(), AppSettings.EncryptionKey, AppSettings.EncryptionIv);
            var content = new FormUrlEncodedContent(new[] {
                new KeyValuePair<string, string>("data", Utils.ConvertToBase64String(data))
            });
            var response = await client.PostAsync(GET_TRADE_STATUS_URL, content);

            var jsonString = await response.Content.ReadAsStringAsync();
            var jObject = JObject.Parse(jsonString);

            if (jObject["error"] != null)
                throw new Exception(jObject["error"]?.ToString());

            return jObject.ToObject<TradeStatus?>();
        }

        public static async Task<bool> ClaimTrades(string sessionKey)
        {
            HttpClient client = new HttpClient();

            JObject parameter = new JObject();
            parameter["sessionKey"] = sessionKey;

            var data = Utils.EncryptData(parameter.ToString(), AppSettings.EncryptionKey, AppSettings.EncryptionIv);
            var content = new FormUrlEncodedContent(new[] {
                new KeyValuePair<string, string>("data", Utils.ConvertToBase64String(data))
            });
            var response = await client.PostAsync(CLAIM_TRADE_URL, content);

            var jsonString = await response.Content.ReadAsStringAsync();
            var jObject = JObject.Parse(jsonString);

            if (jObject["error"] != null)
                throw new Exception(jObject["error"]?.ToString());

            return true;
        }

        public static bool IsDataExists(string slug)
        {
            string filePath = $"{AppSettings.DatabasePath}//markets//{slug}.json";
            return File.Exists(filePath);
        }

        public static List<string> ParseJsonArrayString(string array)
        {
            return JArray.Parse(array).ToObject<List<string>>() ?? new List<string>();
        }

        public static async Task<Market> GetMarketBySlug(string slug)
        {
            // load if already exits in database folder
            string filePath = $"{AppSettings.DatabasePath}//markets//{slug}.json";
            if (File.Exists(filePath))
                return JsonConvert.DeserializeObject<Market>(File.ReadAllText(filePath)) ?? new Market();

            try
            {
                HttpClient client = new HttpClient();
                var url = $"{GAMMA_API_URL}/markets/slug/{slug}";
                var response = await client.GetAsync(url);
                response.EnsureSuccessStatusCode();
                var jsonString = await response.Content.ReadAsStringAsync();

                if (jsonString.StartsWith("{\"error\""))
                {
                    var jObject = JObject.Parse(jsonString);
                    throw new Exception(jObject["error"]?.ToString());
                }

                JObject data = JObject.Parse(jsonString);
                var market = new Market
                {
                    Id = data["id"]?.ToString() ?? "",
                    Question = data["question"]?.ToString() ?? "",
                    ConditionId = data["conditionId"]?.ToString() ?? "",
                    Slug = data["slug"]?.ToString() ?? "",
                    StartTime = data["eventStartTime"]?.Value<DateTime>().ToString("yyyy-MM-ddTHH:mm:ssZ") ?? "",
                    EndTime = data["endDate"]?.Value<DateTime>().ToString("yyyy-MM-ddTHH:mm:ssZ") ?? "",
                    Outcomes = ParseJsonArrayString(data["outcomes"]?.ToString() ?? ""),
                    OutcomePrices = ParseJsonArrayString(data["outcomePrices"]?.ToString() ?? ""),
                    ClobTokenIds = ParseJsonArrayString(data["clobTokenIds"]?.ToString() ?? ""),
                    OrderPriceMinTickSize = data["orderPriceMinTickSize"]?.Value<decimal>() ?? 0,
                    OrderMinSize = data["orderMinSize"]?.Value<decimal>() ?? 0
                };

                // save to database file
                if (market.OutcomePrices[0] == "1" || market.OutcomePrices[1] == "1")
                {
                    File.WriteAllText(filePath, JObject.FromObject(market).ToString());
                }

                return market;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static async Task<List<Trade>> GetAllTrades(string conditionId)
        {
            // load if already exits in database folder
            string filePath = $"{AppSettings.DatabasePath}//trades//{conditionId}.json";
            if (File.Exists(filePath))
                return JsonConvert.DeserializeObject<List<Trade>>(File.ReadAllText(filePath)) ?? new List<Trade>();

            var all = new JArray();
            const int limit = 500, maxTrades = 20000;
            int offset = 0;

            try
            {
                HttpClient client = new HttpClient();
                while (all.Count < maxTrades)
                {
                    string url =
                        $"https://data-api.polymarket.com/trades" +
                        $"?takerOnly=false" +
                        $"&user=" +
                        $"&market={Uri.EscapeDataString(conditionId)}" +
                        $"&limit={limit}" +
                        $"&offset={offset}";

                    var response = await client.GetAsync(url);
                    response.EnsureSuccessStatusCode();

                    string json = await response.Content.ReadAsStringAsync();
                    if (json.StartsWith("{\"error\""))
                    {
                        var jObject = JObject.Parse(json);
                        throw new Exception(jObject["error"]?.ToString());
                    }

                    JArray? batch = JArray.Parse(json);
                    if (batch.Count == 0)
                        break;

                    foreach (JObject trade in batch.OfType<JObject>())
                    {
                        trade.Remove("icon");
                        trade.Remove("eventSlug");
                        trade.Remove("pseudonym");
                        trade.Remove("bio");
                        trade.Remove("profileImage");
                        trade.Remove("profileImageOptimized");
                        trade.Add("IsTaker", false);

                        all.Add(trade);

                        if (all.Count >= maxTrades)
                            break;
                    }

                    offset += batch.Count;
                }

                // taker only = true
                string url2 =
                    $"https://data-api.polymarket.com/trades" +
                    $"?takerOnly=true" +
                    $"&user=" +
                    $"&market={Uri.EscapeDataString(conditionId)}" +
                    $"&limit={all.Count}" +
                    $"&offset=0";

                var response2 = await client.GetAsync(url2);
                response2.EnsureSuccessStatusCode();

                string json2 = await response2.Content.ReadAsStringAsync();
                JArray? batch2 = JArray.Parse(json2);

                foreach (JObject trade in batch2.OfType<JObject>())
                {
                    foreach (JObject item in all)
                    {
                        if (trade["transactionHash"]?.ToString() == item["transactionHash"]?.ToString())
                        {
                            item["IsTaker"] = true;
                            break;
                        }
                    }
                }
            }
            catch (Exception)
            {
                //throw new Exception(ex.Message);
            }

            // save to database file
            File.WriteAllText(filePath, all.ToString());

            return all.ToObject<List<Trade>>() ?? new List<Trade>();
        }
    }
}
