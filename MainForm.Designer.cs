namespace WinFormsApp3
{
    partial class MainForm : Form
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            SymbolTextBox = new TextBox();
            FetchDataButton_Async = new Button();
            dataGridView1 = new DataGridView();
            labelTimeZone = new Label();
            labelInformation = new Label();
            labelSymbol = new Label();
            labelLastRefreshed = new Label();
            chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            FindData = new Button();
            chartPanel1 = new Panel();
            newsPanel1 = new Panel();
            listView1 = new ListView();
            callJson = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)chart1).BeginInit();
            chartPanel1.SuspendLayout();
            newsPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // SymbolTextBox
            // 
            SymbolTextBox.Location = new Point(12, 12);
            SymbolTextBox.Name = "SymbolTextBox";
            SymbolTextBox.PlaceholderText = "Stock Symbol ";
            SymbolTextBox.Size = new Size(100, 23);
            SymbolTextBox.TabIndex = 2;
            // 
            // FetchDataButton_Async
            // 
            FetchDataButton_Async.Location = new Point(129, 12);
            FetchDataButton_Async.Name = "FetchDataButton_Async";
            FetchDataButton_Async.Size = new Size(123, 23);
            FetchDataButton_Async.TabIndex = 3;
            FetchDataButton_Async.Text = "Find Stock Prices";
            FetchDataButton_Async.UseVisualStyleBackColor = true;
            FetchDataButton_Async.Click += FetchDataButton_Async_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(21, 80);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.RowTemplate.Height = 25;
            dataGridView1.Size = new Size(706, 84);
            dataGridView1.TabIndex = 4;
            // 
            // labelTimeZone
            // 
            labelTimeZone.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            labelTimeZone.AutoSize = true;
            labelTimeZone.Location = new Point(21, 8);
            labelTimeZone.Name = "labelTimeZone";
            labelTimeZone.Size = new Size(85, 15);
            labelTimeZone.TabIndex = 5;
            labelTimeZone.Text = "labelTimeZone";
            // 
            // labelInformation
            // 
            labelInformation.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            labelInformation.AutoSize = true;
            labelInformation.Location = new Point(21, 38);
            labelInformation.Name = "labelInformation";
            labelInformation.Size = new Size(95, 15);
            labelInformation.TabIndex = 6;
            labelInformation.Text = "labelInformation";
            // 
            // labelSymbol
            // 
            labelSymbol.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            labelSymbol.AutoSize = true;
            labelSymbol.Location = new Point(21, 23);
            labelSymbol.Name = "labelSymbol";
            labelSymbol.Size = new Size(72, 15);
            labelSymbol.TabIndex = 7;
            labelSymbol.Text = "labelSymbol";
            // 
            // labelLastRefreshed
            // 
            labelLastRefreshed.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            labelLastRefreshed.AutoSize = true;
            labelLastRefreshed.Location = new Point(21, 53);
            labelLastRefreshed.Name = "labelLastRefreshed";
            labelLastRefreshed.Size = new Size(105, 15);
            labelLastRefreshed.TabIndex = 8;
            labelLastRefreshed.Text = "labelLastRefreshed";
            // 
            // chart1
            // 
            chart1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            chartArea1.Name = "ChartArea1";
            chart1.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            chart1.Legends.Add(legend1);
            chart1.Location = new Point(21, 169);
            chart1.Margin = new Padding(3, 2, 3, 2);
            chart1.Name = "chart1";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            chart1.Series.Add(series1);
            chart1.Size = new Size(708, 381);
            chart1.TabIndex = 9;
            chart1.Text = "chart1";
            // 
            // FindData
            // 
            FindData.Location = new Point(268, 12);
            FindData.Name = "FindData";
            FindData.Size = new Size(123, 23);
            FindData.TabIndex = 10;
            FindData.Text = "Show Related News";
            FindData.UseVisualStyleBackColor = true;
            FindData.Click += FindData_Click;
            // 
            // chartPanel1
            // 
            chartPanel1.Controls.Add(dataGridView1);
            chartPanel1.Controls.Add(chart1);
            chartPanel1.Controls.Add(labelSymbol);
            chartPanel1.Controls.Add(labelTimeZone);
            chartPanel1.Controls.Add(labelLastRefreshed);
            chartPanel1.Controls.Add(labelInformation);
            chartPanel1.Location = new Point(12, 41);
            chartPanel1.Name = "chartPanel1";
            chartPanel1.Size = new Size(766, 578);
            chartPanel1.TabIndex = 12;
            // 
            // newsPanel1
            // 
            newsPanel1.Controls.Add(listView1);
            newsPanel1.Location = new Point(9, 38);
            newsPanel1.Name = "newsPanel1";
            newsPanel1.Size = new Size(777, 591);
            newsPanel1.TabIndex = 10;
            // 
            // listView1
            // 
            listView1.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            listView1.Location = new Point(23, 29);
            listView1.Name = "listView1";
            listView1.Size = new Size(717, 517);
            listView1.TabIndex = 0;
            listView1.UseCompatibleStateImageBehavior = false;
            // 
            // callJson
            // 
            callJson.Location = new Point(655, 12);
            callJson.Name = "callJson";
            callJson.Size = new Size(123, 23);
            callJson.TabIndex = 13;
            callJson.Text = "Stock JSON";
            callJson.UseVisualStyleBackColor = true;
            callJson.Click += callJson_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(790, 631);
            Controls.Add(callJson);
            Controls.Add(newsPanel1);
            Controls.Add(chartPanel1);
            Controls.Add(FindData);
            Controls.Add(FetchDataButton_Async);
            Controls.Add(SymbolTextBox);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "MainForm";
            Text = "Stock & News";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)chart1).EndInit();
            chartPanel1.ResumeLayout(false);
            chartPanel1.PerformLayout();
            newsPanel1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private TextBox SymbolTextBox;
        private Button FetchDataButton_Async;
        private DataGridView dataGridView1;
        private Label labelTimeZone;
        private Label labelInformation;
        private Label labelSymbol;
        private Label labelLastRefreshed;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private Button FindData;
        private Panel newsPanel1;
        private ListView listView1;
        private Button callJson;
    }
}