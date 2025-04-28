namespace CPUSchedulingSim
{
    partial class Form1
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
            userInputPromptLabel = new Label();
            inputNumProcesses = new TextBox();
            btnRunSRTFAlg = new Button();
            btnRunMLFQAlg = new Button();
            processesDGV = new DataGridView();
            lblAvgWaitTime = new Label();
            lblAvgTurnaroundTime = new Label();
            lblCPUPercent = new Label();
            lblThroughput = new Label();
            chartPerformanceCompare = new System.Windows.Forms.DataVisualization.Charting.Chart();
            btnCompare = new Button();
            lblNumProcesses = new Label();
            ((System.ComponentModel.ISupportInitialize)processesDGV).BeginInit();
            ((System.ComponentModel.ISupportInitialize)chartPerformanceCompare).BeginInit();
            SuspendLayout();
            // 
            // userInputPromptLabel
            // 
            userInputPromptLabel.AutoSize = true;
            userInputPromptLabel.Location = new Point(134, 89);
            userInputPromptLabel.Name = "userInputPromptLabel";
            userInputPromptLabel.Size = new Size(188, 25);
            userInputPromptLabel.TabIndex = 0;
            userInputPromptLabel.Text = "Input Num. Processes:";
            // 
            // inputNumProcesses
            // 
            inputNumProcesses.BackColor = SystemColors.ControlDark;
            inputNumProcesses.Location = new Point(357, 86);
            inputNumProcesses.Name = "inputNumProcesses";
            inputNumProcesses.Size = new Size(451, 31);
            inputNumProcesses.TabIndex = 1;
            inputNumProcesses.TextAlign = HorizontalAlignment.Center;
            // 
            // btnRunSRTFAlg
            // 
            btnRunSRTFAlg.Location = new Point(134, 180);
            btnRunSRTFAlg.Name = "btnRunSRTFAlg";
            btnRunSRTFAlg.Size = new Size(164, 34);
            btnRunSRTFAlg.TabIndex = 2;
            btnRunSRTFAlg.Text = "Run SRTF Alg.";
            btnRunSRTFAlg.UseVisualStyleBackColor = true;
            btnRunSRTFAlg.Click += btnRunSRTFAlg_Click;
            // 
            // btnRunMLFQAlg
            // 
            btnRunMLFQAlg.Location = new Point(635, 180);
            btnRunMLFQAlg.Name = "btnRunMLFQAlg";
            btnRunMLFQAlg.Size = new Size(173, 34);
            btnRunMLFQAlg.TabIndex = 3;
            btnRunMLFQAlg.Text = "Run MLFQ Alg.";
            btnRunMLFQAlg.UseVisualStyleBackColor = true;
            btnRunMLFQAlg.Click += btnRunMLFQAlg_Click;
            // 
            // processesDGV
            // 
            processesDGV.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            processesDGV.Location = new Point(106, 314);
            processesDGV.Name = "processesDGV";
            processesDGV.RowHeadersWidth = 62;
            processesDGV.Size = new Size(350, 318);
            processesDGV.TabIndex = 4;
            // 
            // lblAvgWaitTime
            // 
            lblAvgWaitTime.AutoSize = true;
            lblAvgWaitTime.Location = new Point(74, 243);
            lblAvgWaitTime.Name = "lblAvgWaitTime";
            lblAvgWaitTime.Size = new Size(244, 25);
            lblAvgWaitTime.TabIndex = 5;
            lblAvgWaitTime.Text = "Average Waiting Time: /// ms";
            // 
            // lblAvgTurnaroundTime
            // 
            lblAvgTurnaroundTime.AutoSize = true;
            lblAvgTurnaroundTime.Location = new Point(74, 268);
            lblAvgTurnaroundTime.Name = "lblAvgTurnaroundTime";
            lblAvgTurnaroundTime.Size = new Size(276, 25);
            lblAvgTurnaroundTime.TabIndex = 6;
            lblAvgTurnaroundTime.Text = "Average Turnaround Time: /// ms";
            // 
            // lblCPUPercent
            // 
            lblCPUPercent.AutoSize = true;
            lblCPUPercent.Location = new Point(565, 243);
            lblCPUPercent.Name = "lblCPUPercent";
            lblCPUPercent.Size = new Size(178, 25);
            lblCPUPercent.TabIndex = 7;
            lblCPUPercent.Text = "CPU Utilization: /// %";
            // 
            // lblThroughput
            // 
            lblThroughput.AutoSize = true;
            lblThroughput.Location = new Point(566, 269);
            lblThroughput.Name = "lblThroughput";
            lblThroughput.Size = new Size(292, 25);
            lblThroughput.TabIndex = 8;
            lblThroughput.Text = "Throughput (Processes/Sec): /// P/s";
            // 
            // chartPerformanceCompare
            // 
            chartArea2.Name = "ChartArea1";
            chartPerformanceCompare.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            chartPerformanceCompare.Legends.Add(legend2);
            chartPerformanceCompare.Location = new Point(487, 366);
            chartPerformanceCompare.Name = "chartPerformanceCompare";
            chartPerformanceCompare.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Pastel;
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            chartPerformanceCompare.Series.Add(series2);
            chartPerformanceCompare.Size = new Size(321, 266);
            chartPerformanceCompare.TabIndex = 9;
            chartPerformanceCompare.Text = "chart1";
            // 
            // btnCompare
            // 
            btnCompare.BackColor = SystemColors.Info;
            btnCompare.Location = new Point(565, 314);
            btnCompare.Name = "btnCompare";
            btnCompare.Size = new Size(173, 34);
            btnCompare.TabIndex = 10;
            btnCompare.Text = "Compare!";
            btnCompare.UseVisualStyleBackColor = false;
            btnCompare.Click += btnCompare_Click;
            // 
            // lblNumProcesses
            // 
            lblNumProcesses.AutoSize = true;
            lblNumProcesses.Location = new Point(326, 136);
            lblNumProcesses.Name = "lblNumProcesses";
            lblNumProcesses.Size = new Size(282, 25);
            lblNumProcesses.TabIndex = 11;
            lblNumProcesses.Text = "Number of Processes Running: ///";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(945, 644);
            Controls.Add(lblNumProcesses);
            Controls.Add(btnCompare);
            Controls.Add(chartPerformanceCompare);
            Controls.Add(lblThroughput);
            Controls.Add(lblCPUPercent);
            Controls.Add(lblAvgTurnaroundTime);
            Controls.Add(lblAvgWaitTime);
            Controls.Add(processesDGV);
            Controls.Add(btnRunMLFQAlg);
            Controls.Add(btnRunSRTFAlg);
            Controls.Add(inputNumProcesses);
            Controls.Add(userInputPromptLabel);
            Name = "Form1";
            Text = "CPU Scheduling Alg. Analyzer";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)processesDGV).EndInit();
            ((System.ComponentModel.ISupportInitialize)chartPerformanceCompare).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label userInputPromptLabel;
        private TextBox inputNumProcesses;
        private Button btnRunSRTFAlg;
        private Button btnRunMLFQAlg;
        private DataGridView processesDGV;
        private Label lblAvgWaitTime;
        private Label lblAvgTurnaroundTime;
        private Label lblCPUPercent;
        private Label lblThroughput;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartPerformanceCompare;
        private Button btnCompare;
        private Label lblNumProcesses;
    }
}
