using System.Windows.Forms.DataVisualization.Charting;
using Newtonsoft.Json.Linq;

namespace WinFormsApp3
{
    public class ChartManager
    {
        private Chart _chart;
        private DataGridView _dataGridView;
        private ListView listView1;

        public ChartManager(Chart chart, DataGridView dataGridView, ListView listView)
        {
            _chart = chart;
            _dataGridView = dataGridView;
            listView1 = listView;
        }
        public void DisplayNews(JArray newsData)
        {
            listView1.Clear();
            listView1.View = View.Details;
            listView1.Columns.Add("Headline", -2, HorizontalAlignment.Left);
            listView1.Columns.Add("Summary", -2, HorizontalAlignment.Left);
            listView1.Columns.Add("Source", -2, HorizontalAlignment.Left);
            listView1.Columns.Add("url", -2, HorizontalAlignment.Left);
            foreach (var item in newsData)
            {
                ListViewItem lvi = new ListViewItem(item["headline"].ToString());
                lvi.SubItems.Add(item["summary"].ToString());
                lvi.SubItems.Add(item["source"].ToString());
                lvi.SubItems.Add(item["url"].ToString());


                listView1.Items.Add(lvi);
            }
            //to make every second row a different color
            foreach (ListViewItem item in listView1.Items)
            {
                if (item.Index % 2 == 0)
                {
                    item.BackColor = Color.LightGray;
                }
            }
        }
        public void DisplayStockData(JObject jsonData)
        {
           

            // Ensure we have the time series data in the expected format
            if (jsonData["Time Series (5min)"] is not JObject timeSeriesData)
            {
                throw new InvalidOperationException("Invalid JSON data format.");
            }

            var seriesHigh = new Series("High") { ChartType = SeriesChartType.Line };
            var seriesLow = new Series("Low") { ChartType = SeriesChartType.Line };
            var seriesClose = new Series("Close") { ChartType = SeriesChartType.Line };

            decimal maxYValue = 0;
            decimal minYValue = decimal.MaxValue;

            foreach (var entry in timeSeriesData)
            {
                string timestamp = entry.Key;
                decimal.TryParse(entry.Value["1. open"].ToString(), out decimal open);
                decimal.TryParse(entry.Value["2. high"].ToString(), out decimal high);
                decimal.TryParse(entry.Value["3. low"].ToString(), out decimal low);
                decimal.TryParse(entry.Value["4. close"].ToString(), out decimal close);

                seriesHigh.Points.AddXY(timestamp, high);
                seriesLow.Points.AddXY(timestamp, low);
                seriesClose.Points.AddXY(timestamp, close);

                // Update maxYValue and minYValue
                maxYValue = Math.Max(maxYValue, high);
                minYValue = new decimal[] { minYValue, open, high, low, close }.Min();
            }

            // Adjust maxYValue for chart scaling
            maxYValue += 1; // Adding 1 as margin
            minYValue -= 1; // Subtracting 1 as margin

            _chart.Series.Clear();
            _chart.Series.Add(seriesHigh);
            _chart.Series.Add(seriesLow);
            _chart.Series.Add(seriesClose);
            // Apply maximum and minimum Y values to the chart area
            _chart.ChartAreas[0].AxisY.Maximum = (double)maxYValue;
            _chart.ChartAreas[0].AxisY.Minimum = (double)minYValue;

            // Assuming the DataGridView should show the raw data
            var gridData = timeSeriesData.Properties().Select(p => new
            {
                Time = p.Name,
                Open = decimal.TryParse(p.Value["1. open"].ToString(), out decimal open) ? open : 0,
                High = decimal.TryParse(p.Value["2. high"].ToString(), out decimal high) ? high : 0,
                Low = decimal.TryParse(p.Value["3. low"].ToString(), out decimal low) ? low : 0,
                Close = decimal.TryParse(p.Value["4. close"].ToString(), out decimal close) ? close : 0,
                Volume = decimal.TryParse(p.Value["5. volume"].ToString(), out decimal volume) ? volume : 0
            }).ToList();
            
            _dataGridView.DataSource = gridData;
            _dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }


        public void DisplayStockDataJson(string jsonString)
        {
            if (string.IsNullOrWhiteSpace(jsonString))
            {
                throw new ArgumentException("JSON string cannot be null or whitespace.", nameof(jsonString));
            }

            JObject jsonData = JObject.Parse(jsonString);

            // Ensure we have the time series data in the expected format
            if (jsonData["Time Series (5min)"] is not JObject timeSeriesData)
            {
                throw new InvalidOperationException("Invalid JSON data format.");
            }

            var seriesHigh = new Series("High") { ChartType = SeriesChartType.Line };
            var seriesLow = new Series("Low") { ChartType = SeriesChartType.Line };
            var seriesClose = new Series("Close") { ChartType = SeriesChartType.Line };

            decimal maxYValue = 0;
            decimal minYValue = decimal.MaxValue;

            foreach (var entry in timeSeriesData)
            {
                string timestamp = entry.Key;
                decimal.TryParse(entry.Value["1. open"].ToString(), out decimal open);
                decimal.TryParse(entry.Value["2. high"].ToString(), out decimal high);
                decimal.TryParse(entry.Value["3. low"].ToString(), out decimal low);
                decimal.TryParse(entry.Value["4. close"].ToString(), out decimal close);

                seriesHigh.Points.AddXY(timestamp, high);
                seriesLow.Points.AddXY(timestamp, low);
                seriesClose.Points.AddXY(timestamp, close);

                // Update maxYValue and minYValue
                maxYValue = Math.Max(maxYValue, high);
                minYValue = new decimal[] { minYValue, open, high, low, close }.Min();
            }

            // Adjust maxYValue for chart scaling
            maxYValue += 1; // Adding 1 as margin
            minYValue -= 1; // Subtracting 1 as margin

            _chart.Series.Clear();
            _chart.Series.Add(seriesHigh);
            _chart.Series.Add(seriesLow);
            _chart.Series.Add(seriesClose);
            // Apply maximum and minimum Y values to the chart area
            _chart.ChartAreas[0].AxisY.Maximum = (double)maxYValue;
            _chart.ChartAreas[0].AxisY.Minimum = (double)minYValue;

            // Assuming the DataGridView should show the raw data
            var gridData = timeSeriesData.Properties().Select(p => new
            {
                Time = p.Name,
                Open = decimal.TryParse(p.Value["1. open"].ToString(), out decimal open) ? open : 0,
                High = decimal.TryParse(p.Value["2. high"].ToString(), out decimal high) ? high : 0,
                Low = decimal.TryParse(p.Value["3. low"].ToString(), out decimal low) ? low : 0,
                Close = decimal.TryParse(p.Value["4. close"].ToString(), out decimal close) ? close : 0,
                Volume = decimal.TryParse(p.Value["5. volume"].ToString(), out decimal volume) ? volume : 0
            }).ToList();

            _dataGridView.DataSource = gridData;
            _dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

    }
}
