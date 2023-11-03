using System;
using System.Windows.Forms;
using Newtonsoft.Json.Linq;

namespace WinFormsApp3
{
    public partial class MainForm : Form
    {
        private AlphaVantageService _alphaVantageService;
        private ChartManager _chartManager;

        public MainForm()
        {
            InitializeComponent();
            _alphaVantageService = new AlphaVantageService();
            _chartManager = new ChartManager(chart1, dataGridView1);
        }

        private async void FetchDataButton_Async_Click(object sender, EventArgs e)
        {
            string symbol = SymbolTextBox.Text.Trim().ToUpper();
            try
            {
                JObject data = await _alphaVantageService.GetTimeSeriesAsync(symbol);
                _chartManager.DisplayStockData(data);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error occurred: " + ex.Message);
            }
        }
    }
}
