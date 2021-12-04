using System;
using System.Net.Http;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Mersenne_Twister
{
    public class Networking
    {
        public static async Task<GameResult> GetResult(string gameName, int id, long number)
        {
            using HttpClient httpClient = new HttpClient();
            var requestUrl = $"http://95.217.177.249/casino/play{gameName}?id={id}&bet=1&number={number}";
            var json = await httpClient.GetStringAsync(requestUrl);
            GameResult result = JsonConvert.DeserializeObject<GameResult>(json);
            
            return result;
        }
        
        public static async void CreateAccount(int id)
        {
            using HttpClient httpClient = new HttpClient();
            var requestUrl = $"http://95.217.177.249/casino/createacc?id={id}";
            var json = await httpClient.GetStringAsync(requestUrl);
        }
        

    }

    public struct GameResult
    {
        [JsonProperty("message")]
        public string message;
        
        [JsonProperty("account")]
        public Account account;
        
        [JsonProperty("realNumber")]
        public long realNumber;
    }

    public struct Account
    {
        [JsonProperty("id")]
        public string id;
        
        [JsonProperty("money")]
        public int money;
        
        [JsonProperty("deletionTime")]
        public string deletionTime;
    }
}