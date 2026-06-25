using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace final1
{
    internal class Database
    {
        private static readonly string file = "data.json";
        private static readonly string logs = "logs.txt";

        public static List<UserAccount> getKnownAccounts()
        {
            try
            {
                if (!File.Exists(file))
                {
                    logError($"{file} file was not found");
                    return new List<UserAccount>();
                }

                string jsonText = File.ReadAllText(file);
                var accounts = JsonConvert.DeserializeObject<List<UserAccount>>(jsonText);
                
                if (accounts == null)
                {
                    return new List<UserAccount>();
                }
                return accounts;
            }
            catch (Exception e)
            {
                logError($"Couldn't fetch accounts: {e.Message}");
                return new List<UserAccount>();
            }
        }

        public static void saveTransactions(List<UserAccount> accounts)
        {
            try
            {
                string jsonText = JsonConvert.SerializeObject(accounts, Formatting.Indented);
                File.WriteAllText(file, jsonText);
            }
            catch (Exception e)
            {
                logError($"error updating transactions in json file: {e.Message}");
            }
        }

        public static void logError(string e)
        {
            string message = $"{DateTime.Now} ERROR: {e}\n";
            try
            {
                File.AppendAllText(logs, message);
            }
            catch
            {
                
            }
        }

        public static void log(string l)
        {
            string message = $"{DateTime.Now} {l}\n";
            try
            {
                File.AppendAllText(logs, message);
            }
            catch
            {
                
            }
        }
    }
}
