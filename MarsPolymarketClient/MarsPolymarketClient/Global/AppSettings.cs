using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

using MarsPolymarketClient.Models;

namespace MarsPolymarketClient.Global
{
    public class AppSettings
    {
        public const string SETTINGS_FILENAME = "settings.ini";
        public static string ServerAddress = "http://localhost:3330";
        public static string SocketServerAddress = "http://localhost:3331";
        public static string EncryptionKey = "";
        public static string EncryptionIv = "";
        public static string ActiveSessionKey = "";
        public static List<ClientAccount> ClientAccounts = new List<ClientAccount>();

        public static void LoadSettings()
        {
            try
            {
                string settings = File.ReadAllText(SETTINGS_FILENAME);
                JObject jsonObj = JObject.Parse(settings);

                ServerAddress = (string?)jsonObj["ServerAddress"] ?? string.Empty;
                SocketServerAddress = (string?)jsonObj["SocketServerAddress"] ?? string.Empty;
                ActiveSessionKey = (string?)jsonObj["ActiveSessionKey"] ?? string.Empty;
                EncryptionIv = (string?)jsonObj["EncryptionIv"] ?? string.Empty;

                if (jsonObj["Accounts"] != null)
                {
                    ClientAccounts = jsonObj["Accounts"]?.ToObject<List<ClientAccount>>() ?? new List<ClientAccount>();

                    foreach (var account in ClientAccounts)
                    {
                        if (ActiveSessionKey == account.SessionKey)
                            DataCenter.ActiveAccount = account;
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public static void SaveSettings()
        {
            try
            { 
                JObject jsonObj = new JObject();

                jsonObj["ServerAddress"] = ServerAddress;
                jsonObj["SocketServerAddress"] = SocketServerAddress;
                jsonObj["ActiveSessionKey"] = ActiveSessionKey;
                jsonObj["EncryptionIv"] = EncryptionIv;

                var accounts = JArray.Parse(JsonConvert.SerializeObject(ClientAccounts));
                jsonObj["Accounts"] = accounts;

                File.WriteAllText(SETTINGS_FILENAME, jsonObj.ToString());
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public static ClientAccount GetClientAccount(string sessionKey)
        {
            return ClientAccounts?.Find(a => a.SessionKey == sessionKey) ?? throw new Exception("account not found");
        }
    }
}
