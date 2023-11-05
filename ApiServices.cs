using Microsoft.Azure.Amqp.Encoding;
using Newtonsoft.Json.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace WinFormsApp3
{
    public class ApiServices
    {
        private static readonly HttpClient _httpClient = new HttpClient();
        private const string AlphaVantageApiKey = "UJ9VDJQJTTQ4FWGQ";
        private const string finnHubApiKey = "cl3qbn9r01qp2kg94fagcl3qbn9r01qp2kg94fb0";
        public async Task<JObject> GetTimeSeriesAsync(string symbol)
        {
            string url = $"https://www.alphavantage.co/query?function=TIME_SERIES_INTRADAY&symbol={symbol}&interval=5min&apikey={AlphaVantageApiKey}";
            var response = await _httpClient.GetAsync(url);
            string jsonResponse = await response.Content.ReadAsStringAsync();
            return JObject.Parse(jsonResponse);
        }

        public async Task<JArray> GetCompanyNewsAsync(string symbol, string from, string to)
        {
            string url = $"https://finnhub.io/api/v1/company-news?symbol={symbol}&from={from}&to={to}&token={finnHubApiKey}";

            var response = await _httpClient.GetAsync(url);
            if (!response.IsSuccessStatusCode)
            {
                throw new HttpRequestException($"Error fetching company news: {response.StatusCode}");
            }

            string jsonResponse = await response.Content.ReadAsStringAsync();
            return JArray.Parse(jsonResponse);
        }
    }
}
