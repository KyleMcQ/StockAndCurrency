using System.Windows.Forms.DataVisualization.Charting;
using Microsoft.VisualBasic.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace WinFormsApp3
{
    //Volume: The total number of shares or contracts traded during a specific time period(e.g., a day, an hour, or a minute).
    public partial class MainForm : Form
    {
        private const string AlphaVantageApiKey = "UJ9VDJQJTTQ4FWGQ";
        string check = "https://www.alphavantage.co/query?function=TIME_SERIES_INTRADAY&symbol={GOOGL}&interval=5min&apikey={T96G4YC9LUKLPALF}";
        string apiKeyCurrency = "8293daee53923ac907543a90d5664efd";
        private const string url = "http://data.fixer.io/api/latest?access_key=8293daee53923ac907543a90d5664efd";

        public MainForm()
        {
            InitializeComponent();
            dataGridView1.AutoGenerateColumns = true;
            InitializeChart();


        }


        private void InitializeChart()
        {
            // Assuming your form has a Chart control named chartExchangeRates
            chart1.Series.Clear();
            chart1.ChartAreas[0].AxisX.Title = "Currency";
            chart1.ChartAreas[0].AxisY.Title = "Exchange Rate";
        }

        private async void btnCallApi_Click(object sender, EventArgs e)
        {
            string apiUrl = "http://data.fixer.io/api/latest?access_key=8293daee53923ac907543a90d5664efd";

            try
            {
                string apiResponse = await MakeApiCall(apiUrl);

                // Parse the API response (assuming it's in JSON format)
                var apiData = JsonConvert.DeserializeObject<dynamic>(apiResponse);

                // Display the data in the DataGridView
                dataGridView1.DataSource = ParseApiData(apiData);

                // Display the data in the chart excluding UGX currency
                DisplayDataInChart(apiData);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "API Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task<string> MakeApiCall(string apiUrl)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                HttpResponseMessage response = await httpClient.GetAsync(apiUrl);
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadAsStringAsync();
            }
        }

        private object ParseApiData(dynamic apiData)
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

        private void DisplayDataInChart(dynamic apiData)
        {
            // Clear existing series
            chart1.Series.Clear();

            // Create a new series for the chart
            Series series = new Series("ExchangeRateSeries");
            series.ChartType = SeriesChartType.Bar;

            // Add data points to the series excluding UGX currency
            foreach (var rate in apiData.rates)
            {
                if (rate.Name != "UGX")
                {
                    string currency = rate.Name;
                    decimal exchangeRate = rate.Value;
                    series.Points.AddXY(currency, exchangeRate);
                }
            }

            // Add the series to the chart
            chart1.Series.Add(series);
        }

        private async void FetchDataButton_Async_Click(object sender, EventArgs e)
        {
            chart1.Series.Clear();
            try
            {
                string symbol = SymbolTextBox.Text.Trim().ToUpper();
                string apiUrl = $"https://www.alphavantage.co/query?function=TIME_SERIES_INTRADAY&symbol={symbol}&interval=5min&apikey={AlphaVantageApiKey}";
                //to import stock.json file
                //apiUrl = "stock.json";
                using (HttpClient client = new HttpClient())
                {
                    HttpResponseMessage response = await client.GetAsync(apiUrl);

                    if (response.IsSuccessStatusCode)
                    {
                        string responseData = await response.Content.ReadAsStringAsync();

                        // Deserialize JSON
                        JObject json = JObject.Parse(responseData);

                        // Extract time series data
                        var timeSeries = json["Time Series (5min)"].Value<JObject>();
                        List<decimal> lowValues = timeSeries
                            .Properties()
                            .Select(p => p.Value["3. low"].Value<decimal>())
                            .ToList(); var data = timeSeries.Children().Select(item => new
                            {
                                Time = item.Path,
                                Open = item.First["1. open"].ToString(),
                                High = item.First["2. high"].ToString(),
                                Low = item.First["3. low"].ToString(),
                                Close = item.First["4. close"].ToString(),
                                Volume = item.First["5. volume"].ToString()
                            }).ToList();

                        decimal minValue = lowValues.Min();

                        decimal minYAxisValue = minValue - 2;

                        // Extract timezone and other information
                        string timezone = json["Meta Data"]["6. Time Zone"].ToString();
                        string symbolText = json["Meta Data"]["2. Symbol"].ToString();
                        string information = json["Meta Data"]["1. Information"].ToString();
                        string lastRefreshed = json["Meta Data"]["3. Last Refreshed"].ToString();

                        // Display information in labels
                        labelTimeZone.Text = $"Time Zone: {timezone}";
                        labelSymbol.Text = $"Symbol: {symbolText}";
                        labelInformation.Text = $"Information: {information}";
                        labelLastRefreshed.Text = $"Last Refreshed: {lastRefreshed}";
                        OutputTextBox.Text = $"Success: {response.StatusCode}";

                        Series one = chart1.Series.Add("High");
                        Series two = chart1.Series.Add("Low");
                        Series three = chart1.Series.Add("Close");
                        one.ChartType = SeriesChartType.Line;
                        two.ChartType = SeriesChartType.Line;
                        three.ChartType = SeriesChartType.Line;
                        chart1.ChartAreas[0].AxisY.Interval = 1;
                        chart1.ChartAreas[0].AxisY.Minimum = (double)minYAxisValue;
                        chart1.ChartAreas[0].AxisY2.Title = "Additional Label";

                        foreach (var item in data)
                        {
                            one.Points.AddXY(item.Time, item.High);
                            two.Points.AddXY(item.Time, item.Low);
                            three.Points.AddXY(item.Time, item.Close);
                        }


                        // Bind data to DataGridView
                        dataGridView1.DataSource = data;


                        // Set the AutoSizeColumnsMode property to automatically adjust column sizes
                        dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                    }
                    else
                    {
                        OutputTextBox.Text = $"Error: {response.ReasonPhrase}";
                        OutputTextBox.Text = "This is an Error";

                    }
                }
            }
            catch (Exception ex)
            {
                if (ex.Message.Equals("Error: Object reference not set to an instance of an object."))
                {
                    OutputTextBox.Text = "Reached Maximum API CallBacks";
                }
                OutputTextBox.Text = "Reached Maximum API CallBacks";
                MessageBox.Show("Please Enter A Stock Symbol");
            }
        }

        private async void FinVolumeAsync_Click(object sender, EventArgs e)
        {
            chart1.Series.Clear();
            try
            {
                string symbol = SymbolTextBox.Text.Trim().ToUpper();
                string apiUrl = $"https://www.alphavantage.co/query?function=TIME_SERIES_INTRADAY&symbol={symbol}&interval=5min&apikey={AlphaVantageApiKey}";
                //to import stock.json file
                //apiUrl = "stock.json";
                using (HttpClient client = new HttpClient())
                {
                    HttpResponseMessage response = await client.GetAsync(apiUrl);

                    if (response.IsSuccessStatusCode)
                    {
                        string responseData = await response.Content.ReadAsStringAsync();

                        // Deserialize JSON
                        JObject json = JObject.Parse(responseData);

                        // Extract time series data
                        var timeSeries = json["Time Series (5min)"].Value<JObject>();
                        List<decimal> lowValues = timeSeries
                            .Properties()
                            .Select(p => p.Value["3. low"].Value<decimal>())
                            .ToList(); var data = timeSeries.Children().Select(item => new
                            {
                                Time = item.Path,
                                Open = item.First["1. open"].ToString(),
                                High = item.First["2. high"].ToString(),
                                Low = item.First["3. low"].ToString(),
                                Close = item.First["4. close"].ToString(),
                                Volume = item.First["5. volume"].ToString()
                            }).ToList();

                        decimal minValue = lowValues.Min();

                        decimal minYAxisValue = minValue - 2;

                        // Extract timezone and other information
                        string timezone = json["Meta Data"]["6. Time Zone"].ToString();
                        string symbolText = json["Meta Data"]["2. Symbol"].ToString();
                        string information = json["Meta Data"]["1. Information"].ToString();
                        string lastRefreshed = json["Meta Data"]["3. Last Refreshed"].ToString();

                        // Display information in labels
                        labelTimeZone.Text = $"Time Zone: {timezone}";
                        labelSymbol.Text = $"Symbol: {symbolText}";
                        labelInformation.Text = $"Information: {information}";
                        labelLastRefreshed.Text = $"Last Refreshed: {lastRefreshed}";
                        OutputTextBox.Text = $"Success: {response.StatusCode}";

                        Series one = chart1.Series.Add("Volume");
                        one.ChartType = SeriesChartType.Column;
                        //one.BorderWidth = 3;

                        foreach (var item in data)
                        {
                            one.Points.AddXY(item.Time, item.Volume);

                        }
                        dataGridView1.DataSource = data;
                        dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                    }
                    else
                    {
                        OutputTextBox.Text = $"Error: {response.ReasonPhrase}";
                        OutputTextBox.Text = "This is an Error";

                    }
                }
            }
            catch (Exception ex)
            {
                if (ex.Message.Equals("Error: Object reference not set to an instance of an object."))
                {
                    OutputTextBox.Text = "Reached Maximum API CallBacks";
                }
                OutputTextBox.Text = "Reached Maximum API CallBacks";
                MessageBox.Show("Please Enter A Stock Symbol");
            }
        }

       
    }
}
