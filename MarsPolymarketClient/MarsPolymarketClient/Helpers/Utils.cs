using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace MarsPolymarketClient.Helpers
{
    public class Utils
    {
        const string DEFAULT_SALTS = "11152025";

        public static string EncryptData(string data, string key, string iv)
        {
            byte[] array;

            using (Aes aes = Aes.Create())
            {
                aes.Key = Encoding.UTF8.GetBytes(key);
                aes.IV = Encoding.UTF8.GetBytes(iv); ;

                ICryptoTransform encryptor = aes.CreateEncryptor(aes.Key, aes.IV);

                using (MemoryStream memoryStream = new MemoryStream())
                {
                    using (CryptoStream cryptoStream = new CryptoStream((Stream)memoryStream, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter streamWriter = new StreamWriter((Stream)cryptoStream))
                        {
                            streamWriter.Write(data);
                        }

                        array = memoryStream.ToArray();
                    }
                }
            }

            return Convert.ToBase64String(array);
        }

        public static string DecryptData(string data, string key, string iv)
        {
            byte[] buffer = Convert.FromBase64String(data);

            using (Aes aes = Aes.Create())
            {
                aes.Key = Encoding.UTF8.GetBytes(key);
                aes.IV = Encoding.UTF8.GetBytes(iv);

                ICryptoTransform decryptor = aes.CreateDecryptor(aes.Key, aes.IV);

                using (MemoryStream memoryStream = new MemoryStream(buffer))
                {
                    using (CryptoStream cryptoStream = new CryptoStream((Stream)memoryStream, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader streamReader = new StreamReader((Stream)cryptoStream))
                        {
                            return streamReader.ReadToEnd();
                        }
                    }
                }
            }
        }

        public static string Encrypt(string plainText, string password)
        {
            byte[] salt = Encoding.UTF8.GetBytes(DEFAULT_SALTS);

            using var key = new Rfc2898DeriveBytes(
                password,
                salt,
                100000,
                HashAlgorithmName.SHA256);

            using Aes aes = Aes.Create();
            aes.Key = key.GetBytes(32);
            aes.IV = key.GetBytes(16);

            using MemoryStream ms = new MemoryStream();
            using CryptoStream cs = new CryptoStream(ms, aes.CreateEncryptor(), CryptoStreamMode.Write);

            byte[] data = Encoding.UTF8.GetBytes(plainText);
            cs.Write(data, 0, data.Length);
            cs.Close();

            return Convert.ToBase64String(ms.ToArray());
        }

        public static string Decrypt(string cipherText, string password)
        {
            byte[] salt = Encoding.UTF8.GetBytes(DEFAULT_SALTS);

            using var key = new Rfc2898DeriveBytes(
                password,
                salt,
                100000,
                HashAlgorithmName.SHA256);

            using Aes aes = Aes.Create();
            aes.Key = key.GetBytes(32);
            aes.IV = key.GetBytes(16);

            using MemoryStream ms = new MemoryStream(Convert.FromBase64String(cipherText));
            using CryptoStream cs = new CryptoStream(ms, aes.CreateDecryptor(), CryptoStreamMode.Read);
            using StreamReader sr = new StreamReader(cs);

            return sr.ReadToEnd();
        }

        public static string RandomHex(int length)
        {
            int byteLength = (length + 1) / 2;
            byte[] bytes = new byte[byteLength];

            RandomNumberGenerator.Fill(bytes);

            string hex = Convert.ToHexString(bytes);
            return hex.Substring(0, length);
        }

        public static string ConvertToBase64String(string data)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(data);

            return Convert.ToBase64String(bytes);
        }

        public static string ConvertToLocalTimeString(string utcTimeString)
        {
            DateTime dateTime = DateTime.Parse(utcTimeString);

            return dateTime.ToLocalTime().ToString("yyyy-MM-dd HH:mm:ss");
        }

        public static long GetDateNowSeconds()
        {
            DateTime unixEpoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            DateTime nowUtc = DateTime.UtcNow;

            TimeSpan diff = nowUtc - unixEpoch;

            return (long)diff.TotalSeconds;
        }

        public static string ConvertEpochToLocalTimeString(long epoch)
        {
            return DateTimeOffset.FromUnixTimeSeconds(epoch).UtcDateTime.ToLocalTime().ToString("yyyy-MM-dd HH:mm:ss");
        }

        public static long GetCurrentSlugTimeStamp(string prefix)
        {
            long now = GetDateNowSeconds();
            int timeframe = GetTimeframeSeconds(prefix);
            long timestamp = 0;

            if (prefix.Contains("-4h"))
                timestamp = now - ((now - 3600) % timeframe); // 1 hour offset of 4h events
            else
                timestamp = now - (now % timeframe);

            return timestamp;
        }

        public static DateTime EpochToDate(long epoch)
        {
            // Convert seconds to milliseconds if necessary
            if (epoch < 10_000_000_000)
            {
                epoch *= 1000;
            }

            DateTime utcDate = DateTimeOffset
                .FromUnixTimeMilliseconds((long)epoch)
                .UtcDateTime;

            TimeSpan localOffset = TimeZoneInfo.Local.GetUtcOffset(utcDate);

            return utcDate + localOffset;
        }

        public static int GetTimeframeSeconds(string prefix)
        {
            if (prefix.Contains("-5m")) return 5 * 60;
            if (prefix.Contains("-15m")) return 15 * 60;
            if (prefix.EndsWith("up-or-down")) return 60 * 60;
            if (prefix.Contains("-4h")) return 4 * 60 * 60;
            if (prefix.EndsWith("up-or-down-on")) return 24 * 60 * 60;

            return 0;
        }

        public static string GetFullSlugName(string prefix, long timestamp)
        {
            if (prefix.Contains("-5m") || prefix.Contains("-15m") || prefix.Contains("-4h"))
                return $"{prefix}-{timestamp}";
            if (prefix.EndsWith("up-or-down"))
                return $"{prefix}-{EpochToPolymarketFormat(timestamp, "et")}";
            if (prefix.EndsWith("up-or-down-on"))
                return $"{prefix}-{EpochToPolymarketFormat(timestamp, "utc", true)}";

            return "";
        }

        private static string EpochToPolymarketFormat(long epochSeconds, string timezone, bool onlyDate = false)
        {
            DateTime date = EpochToDate(epochSeconds);

            int offset = 0;

            switch (timezone.ToLowerInvariant())
            {
                case "et":
                    offset = -5; // EST
                    break;

                case "pt":
                    offset = -8; // PST
                    break;

                case "utc":
                    offset = 0;
                    break;
            }

            // Adjust for timezone
            DateTime localDate = date.AddHours(offset);

            string[] months =
            {
                "january",
                "february",
                "march",
                "april",
                "may",
                "june",
                "july",
                "august",
                "september",
                "october",
                "november",
                "december"
            };

            string month = months[localDate.Month - 1];
            int day = localDate.Day;

            int hour = localDate.Hour;

            string ampm = hour >= 12 ? "pm" : "am";

            hour = hour % 12;

            if (hour == 0)
                hour = 12;

            return onlyDate ? $"{month}-{day}" : 
                $"{month}-{day}-{hour}{ampm}-{timezone.ToLowerInvariant()}";
        }
    }
}
