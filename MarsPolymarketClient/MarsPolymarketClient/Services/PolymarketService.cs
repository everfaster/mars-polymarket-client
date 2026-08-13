
using MarsPolymarketClient.Forms;
using MarsPolymarketClient.Global;
using MarsPolymarketClient.Helpers;
using MarsPolymarketClient.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SocketIOClient;

namespace MarsPolymarketClient.Services
{
    public class PolymarketService
    {
        static string DATABASE = "database";
        static string DATABASE_FOLDER_PATH = "";

        static string LOGIN_URL = $"{AppSettings.ServerAddress}/api/session/login";
        static string START_SESSION_URL = $"{AppSettings.ServerAddress}/api/session/start";
        static string STOP_SESSION_URL = $"{AppSettings.ServerAddress}/api/session/stop";
        static string MARKET_URL = $"{AppSettings.ServerAddress}/api/analysis/market";
        static string ALL_TRADES_URL = $"{AppSettings.ServerAddress}/api/analysis/allTrades";

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

            DATABASE_FOLDER_PATH = Path.Combine(AppContext.BaseDirectory, DATABASE);
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

        public static async Task<string> StartService(string apiKey, string apiSecret, string apiPass = "")
        {
            HttpClient client = new HttpClient();

            JObject parameter = new JObject();
            parameter["apiKey"] = apiKey;
            parameter["apiSecret"] = apiSecret;
            parameter["apiPass"] = apiPass;

            var data = Utils.EncryptData(parameter.ToString(), AppSettings.EncryptionKey, AppSettings.EncryptionIv);
            var content = new FormUrlEncodedContent(new[] {
                new KeyValuePair<string, string>("data", Utils.ConvertToBase64String(data))
            });
            var response = await client.PostAsync(START_SESSION_URL, content);

            var jsonString = await response.Content.ReadAsStringAsync();

            if (jsonString.StartsWith("{\"error\""))
            {
                var jObject = JObject.Parse(jsonString);
                throw new Exception(jObject["error"]?.ToString());
            }

            return JObject.Parse(jsonString)["sessionKey"]?.ToString() ??
                throw new Exception("sessionKey not found");
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

        public static async Task<Market> GetMarketBySlug(string slug)
        {
            // load if already exits in database folder
            string filePath = $"{DATABASE_FOLDER_PATH}//markets//{slug}.json";
            if (File.Exists(filePath))
                return JsonConvert.DeserializeObject<Market>(File.ReadAllText(filePath)) ?? new Market();

            HttpClient client = new HttpClient();

            JObject parameter = new JObject();
            parameter["slug"] = slug;

            var data = Utils.EncryptData(parameter.ToString(), AppSettings.EncryptionKey, AppSettings.EncryptionIv);
            var content = new FormUrlEncodedContent(new[] {
                new KeyValuePair<string, string>("data", Utils.ConvertToBase64String(data))
            });
            var response = await client.PostAsync(MARKET_URL, content);

            var jsonString = await response.Content.ReadAsStringAsync();

            if (jsonString.StartsWith("{\"error\""))
            {
                var jObject = JObject.Parse(jsonString);
                throw new Exception(jObject["error"]?.ToString());
            }

            // save to database file
            File.WriteAllText(filePath, jsonString);

            return JsonConvert.DeserializeObject<Market>(jsonString) ?? new Market();
        }

        public static async Task<List<Trade>> GetAllTrades(string conditionId)
        {
            // load if already exits in database folder
            string filePath = $"{DATABASE_FOLDER_PATH}//trades//{conditionId}.json";
            if (File.Exists(filePath))
                return JsonConvert.DeserializeObject<List<Trade>>(File.ReadAllText(filePath)) ?? new List<Trade>();

            HttpClient client = new HttpClient();

            JObject parameter = new JObject();
            parameter["conditionId"] = conditionId;

            var data = Utils.EncryptData(parameter.ToString(), AppSettings.EncryptionKey, AppSettings.EncryptionIv);
            var content = new FormUrlEncodedContent(new[] {
                new KeyValuePair<string, string>("data", Utils.ConvertToBase64String(data))
            });
            var response = await client.PostAsync(ALL_TRADES_URL, content);

            var jsonString = await response.Content.ReadAsStringAsync();

            if (jsonString.StartsWith("{\"error\""))
            {
                var jObject = JObject.Parse(jsonString);
                throw new Exception(jObject["error"]?.ToString());
            }

            // save to database file
            File.WriteAllText(filePath, jsonString);

            return JsonConvert.DeserializeObject<List<Trade>>(jsonString) ?? new List<Trade>();
        }
    }
}
