using Microsoft.Azure.Amqp.Encoding;
using Newtonsoft.Json.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace WinFormsApp3
{
    public class AlphaVantageService
    {
        private static readonly HttpClient _httpClient = new HttpClient();
        private const string AlphaVantageApiKey = "UJ9VDJQJTTQ4FWGQ";
        public async Task<JObject> GetTimeSeriesAsync(string symbol)
        {
            string url = $"https://www.alphavantage.co/query?function=TIME_SERIES_INTRADAY&symbol={symbol}&interval=5min&apikey={AlphaVantageApiKey}";
            var response = await _httpClient.GetAsync(url);
            string jsonResponse = await response.Content.ReadAsStringAsync();
            return JObject.Parse(jsonResponse);
        }
    }
}
