
using MarsPolymarketClient.Forms;
using MarsPolymarketClient.Global;
using MarsPolymarketClient.Helpers;
using MarsPolymarketClient.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SocketIOClient;
using System.Net;
using System.Text.Json.Nodes;

namespace MarsPolymarketClient.Services
{
    public class PolymarketService
    {
        static string DATABASE = "database";
        static string DATABASE_FOLDER_PATH = Path.Combine(AppContext.BaseDirectory, DATABASE);

        static string GAMMA_API_URL = "https://gamma-api.polymarket.com";
        static string LOGIN_URL = $"{AppSettings.ServerAddress}/api/session/login";
        static string START_SESSION_URL = $"{AppSettings.ServerAddress}/api/session/start";
        static string STOP_SESSION_URL = $"{AppSettings.ServerAddress}/api/session/stop";
        static string START_TRADE_URL = $"{AppSettings.ServerAddress}/api/session/trade/start";
        static string STOP_TRADE_URL = $"{AppSettings.ServerAddress}/api/session/trade/stop";
        static string GET_TRADE_STATUS_URL = $"{AppSettings.ServerAddress}/api/session/trade/status";
        static string SET_TRADE_OPTIONS_URL = $"{AppSettings.ServerAddress}/api/session/trade/options";
        static string CLAIM_TRADE_URL = $"{AppSettings.ServerAddress}/api/session/trade/claim";

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

            Directory.CreateDirectory(DATABASE_FOLDER_PATH);
            Directory.CreateDirectory($"{DATABASE_FOLDER_PATH}//markets");
            Directory.CreateDirectory($"{DATABASE_FOLDER_PATH}//trades");
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

        public static async Task<bool> StartTrade(string sessionKey, string tradeOptions)
        {
            HttpClient client = new HttpClient();

            JObject parameter = new JObject();
            parameter["sessionKey"] = sessionKey;
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
            string filePath = $"{DATABASE_FOLDER_PATH}//markets//{slug}.json";
            return File.Exists(filePath);
        }

        public static List<string> ParseJsonArrayString(string array)
        {
            return JArray.Parse(array).ToObject<List<string>>() ?? new List<string>();
        }

        public static async Task<Market> GetMarketBySlug(string slug)
        {
            // load if already exits in database folder
            string filePath = $"{DATABASE_FOLDER_PATH}//markets//{slug}.json";
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
            string filePath = $"{DATABASE_FOLDER_PATH}//trades//{conditionId}.json";
            if (File.Exists(filePath))
                return JsonConvert.DeserializeObject<List<Trade>>(File.ReadAllText(filePath)) ?? new List<Trade>();

            //HttpClient client = new HttpClient();

            //JObject parameter = new JObject();
            //parameter["conditionId"] = conditionId;

            //var data = Utils.EncryptData(parameter.ToString(), AppSettings.EncryptionKey, AppSettings.EncryptionIv);
            //var content = new FormUrlEncodedContent(new[] {
            //    new KeyValuePair<string, string>("data", Utils.ConvertToBase64String(data))
            //});
            //var response = await client.PostAsync(ALL_TRADES_URL, content);

            //var jsonString = await response.Content.ReadAsStringAsync();

            //if (jsonString.StartsWith("{\"error\""))
            //{
            //    var jObject = JObject.Parse(jsonString);
            //    throw new Exception(jObject["error"]?.ToString());
            //}

            // save to database file
            //File.WriteAllText(filePath, jsonString);

            //return JsonConvert.DeserializeObject<List<Trade>>(jsonString) ?? new List<Trade>();

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

                        all.Add(trade);

                        if (all.Count >= maxTrades)
                            break;
                    }

                    offset += batch.Count;
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
