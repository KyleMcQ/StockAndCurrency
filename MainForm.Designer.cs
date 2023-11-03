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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            OutputTextBox = new TextBox();
            label1 = new Label();
            SymbolTextBox = new TextBox();
            FetchDataButton_Async = new Button();
            dataGridView1 = new DataGridView();
            labelTimeZone = new Label();
            labelInformation = new Label();
            labelSymbol = new Label();
            labelLastRefreshed = new Label();
            chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            UseJson = new Button();
            FindVolume = new Button();
            FinVolumeAsync = new Button();
            btnCallApi = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)chart1).BeginInit();
            SuspendLayout();
            // 
            // OutputTextBox
            // 
            OutputTextBox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            OutputTextBox.Location = new Point(12, 12);
            OutputTextBox.Name = "OutputTextBox";
            OutputTextBox.Size = new Size(777, 23);
            OutputTextBox.TabIndex = 0;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            label1.AutoSize = true;
            label1.Location = new Point(329, 139);
            label1.Name = "label1";
            label1.Size = new Size(38, 15);
            label1.TabIndex = 1;
            label1.Text = "label1";
            // 
            // SymbolTextBox
            // 
            SymbolTextBox.Location = new Point(12, 41);
            SymbolTextBox.Name = "SymbolTextBox";
            SymbolTextBox.PlaceholderText = "Stock Symbol ";
            SymbolTextBox.Size = new Size(100, 23);
            SymbolTextBox.TabIndex = 2;
            // 
            // FetchDataButton_Async
            // 
            FetchDataButton_Async.Location = new Point(126, 41);
            FetchDataButton_Async.Name = "FetchDataButton_Async";
            FetchDataButton_Async.Size = new Size(123, 20);
            FetchDataButton_Async.TabIndex = 3;
            FetchDataButton_Async.Text = "Find Stock Prices";
            FetchDataButton_Async.UseVisualStyleBackColor = true;
            FetchDataButton_Async.Click += FetchDataButton_Async_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(12, 139);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.RowTemplate.Height = 25;
            dataGridView1.Size = new Size(776, 52);
            dataGridView1.TabIndex = 4;
            // 
            // labelTimeZone
            // 
            labelTimeZone.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            labelTimeZone.AutoSize = true;
            labelTimeZone.Location = new Point(12, 71);
            labelTimeZone.Name = "labelTimeZone";
            labelTimeZone.Size = new Size(85, 15);
            labelTimeZone.TabIndex = 5;
            labelTimeZone.Text = "labelTimeZone";
            // 
            // labelInformation
            // 
            labelInformation.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            labelInformation.AutoSize = true;
            labelInformation.Location = new Point(12, 101);
            labelInformation.Name = "labelInformation";
            labelInformation.Size = new Size(95, 15);
            labelInformation.TabIndex = 6;
            labelInformation.Text = "labelInformation";
            // 
            // labelSymbol
            // 
            labelSymbol.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            labelSymbol.AutoSize = true;
            labelSymbol.Location = new Point(12, 86);
            labelSymbol.Name = "labelSymbol";
            labelSymbol.Size = new Size(72, 15);
            labelSymbol.TabIndex = 7;
            labelSymbol.Text = "labelSymbol";
            // 
            // labelLastRefreshed
            // 
            labelLastRefreshed.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            labelLastRefreshed.AutoSize = true;
            labelLastRefreshed.Location = new Point(12, 116);
            labelLastRefreshed.Name = "labelLastRefreshed";
            labelLastRefreshed.Size = new Size(105, 15);
            labelLastRefreshed.TabIndex = 8;
            labelLastRefreshed.Text = "labelLastRefreshed";
            // 
            // chart1
            // 
            chart1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            chartArea2.Name = "ChartArea1";
            chart1.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            chart1.Legends.Add(legend2);
            chart1.Location = new Point(12, 208);
            chart1.Margin = new Padding(3, 2, 3, 2);
            chart1.Name = "chart1";
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            chart1.Series.Add(series2);
            chart1.Size = new Size(776, 413);
            chart1.TabIndex = 9;
            chart1.Text = "chart1";
            // 
            // UseJson
            // 
            UseJson.Location = new Point(347, 41);
            UseJson.Margin = new Padding(3, 2, 3, 2);
            UseJson.Name = "UseJson";
            UseJson.Size = new Size(82, 20);
            UseJson.TabIndex = 11;
            UseJson.Text = "Use JSON";
            UseJson.UseVisualStyleBackColor = true;
            //UseJson.Click += UseJson_Click;
            // 
            // FindVolume
            // 
            FindVolume.Location = new Point(435, 41);
            FindVolume.Margin = new Padding(3, 2, 3, 2);
            FindVolume.Name = "FindVolume";
            FindVolume.Size = new Size(94, 20);
            FindVolume.TabIndex = 12;
            FindVolume.Text = "Volume JSON";
            FindVolume.UseVisualStyleBackColor = true;
            //FindVolume.Click += FindVolume_Click;
            // 
            // FinVolumeAsync
            // 
            FinVolumeAsync.Location = new Point(255, 41);
            FinVolumeAsync.Margin = new Padding(3, 2, 3, 2);
            FinVolumeAsync.Name = "FinVolumeAsync";
            FinVolumeAsync.Size = new Size(88, 20);
            FinVolumeAsync.TabIndex = 13;
            FinVolumeAsync.Text = "Find Volume";
            FinVolumeAsync.UseVisualStyleBackColor = true;
            //FinVolumeAsync.Click += FinVolumeAsync_Click;
            // 
            // btnCallApi
            // 
            btnCallApi.Location = new Point(535, 41);
            btnCallApi.Name = "btnCallApi";
            btnCallApi.Size = new Size(75, 23);
            btnCallApi.TabIndex = 14;
            btnCallApi.Text = "button1";
            btnCallApi.UseVisualStyleBackColor = true;
            //btnCallApi.Click += btnCallApi_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(803, 631);
            Controls.Add(btnCallApi);
            Controls.Add(FinVolumeAsync);
            Controls.Add(FindVolume);
            Controls.Add(UseJson);
            Controls.Add(chart1);
            Controls.Add(labelLastRefreshed);
            Controls.Add(labelSymbol);
            Controls.Add(labelInformation);
            Controls.Add(labelTimeZone);
            Controls.Add(dataGridView1);
            Controls.Add(FetchDataButton_Async);
            Controls.Add(SymbolTextBox);
            Controls.Add(label1);
            Controls.Add(OutputTextBox);
            Name = "MainForm";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)chart1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox OutputTextBox;
        private Label label1;
        private TextBox SymbolTextBox;
        private Button FetchDataButton_Async;
        private DataGridView dataGridView1;
        private Label labelTimeZone;
        private Label labelInformation;
        private Label labelSymbol;
        private Label labelLastRefreshed;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private Button UseJson;
        private Button FindVolume;
        private Button FinVolumeAsync;
        private Button btnCallApi;
    }
}