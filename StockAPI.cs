using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp3
{

    public class StockAPI : MainForm
    {
        public async Task<string> MakeApiCall(string apiUrl)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                HttpResponseMessage response = await httpClient.GetAsync(apiUrl);
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadAsStringAsync();
            }
        }

        public object ParseApiData(dynamic apiData)
        {
            // Extract the rates and return as a list of objects
            var rateList = new List<object>();
            foreach (var rate in apiData.rates)
            {
                // Exclude UGX currency
                if (rate.Name != "UGX")
                {
                    rateList.Add(new { Currency = rate.Name, ExchangeRate = rate.Value });
                }
            }

            return rateList;
        }
    }   
   
}

