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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea4 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend4 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
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
            btnBasicTest1 = new Button();
            btnBasicTest2 = new Button();
            btnRandomProcTest = new Button();
            btnPrioritySkewed = new Button();
            btnLongvShortTest = new Button();
            btnIdenATTest = new Button();
            lblTestCases = new Label();
            dgvSRTFTestCases = new DataGridView();
            dgvMLFQTestCases = new DataGridView();
            lblCurrentTest = new Label();
            lblRandNumProc = new Label();
            txtUserInputRand = new TextBox();
            chartTurnaroundCompare = new System.Windows.Forms.DataVisualization.Charting.Chart();
            chartCPUPercCompare = new System.Windows.Forms.DataVisualization.Charting.Chart();
            chartThroughputCompare = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)processesDGV).BeginInit();
            ((System.ComponentModel.ISupportInitialize)chartPerformanceCompare).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvSRTFTestCases).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvMLFQTestCases).BeginInit();
            ((System.ComponentModel.ISupportInitialize)chartTurnaroundCompare).BeginInit();
            ((System.ComponentModel.ISupportInitialize)chartCPUPercCompare).BeginInit();
            ((System.ComponentModel.ISupportInitialize)chartThroughputCompare).BeginInit();
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
            chartArea1.Name = "ChartArea1";
            chartPerformanceCompare.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            chartPerformanceCompare.Legends.Add(legend1);
            chartPerformanceCompare.Location = new Point(931, 71);
            chartPerformanceCompare.Name = "chartPerformanceCompare";
            chartPerformanceCompare.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Pastel;
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            chartPerformanceCompare.Series.Add(series1);
            chartPerformanceCompare.Size = new Size(359, 276);
            chartPerformanceCompare.TabIndex = 9;
            chartPerformanceCompare.Text = "chart1";
            // 
            // btnCompare
            // 
            btnCompare.BackColor = SystemColors.Info;
            btnCompare.Location = new Point(620, 445);
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
            // btnBasicTest1
            // 
            btnBasicTest1.Location = new Point(202, 721);
            btnBasicTest1.Name = "btnBasicTest1";
            btnBasicTest1.Size = new Size(160, 43);
            btnBasicTest1.TabIndex = 12;
            btnBasicTest1.Text = "Load Basic Test 1";
            btnBasicTest1.UseVisualStyleBackColor = true;
            btnBasicTest1.Click += btnBasicTest1_Click;
            // 
            // btnBasicTest2
            // 
            btnBasicTest2.Location = new Point(202, 787);
            btnBasicTest2.Name = "btnBasicTest2";
            btnBasicTest2.Size = new Size(160, 43);
            btnBasicTest2.TabIndex = 13;
            btnBasicTest2.Text = "Load Basic Test 2";
            btnBasicTest2.UseVisualStyleBackColor = true;
            btnBasicTest2.Click += btnBasicTest2_Click;
            // 
            // btnRandomProcTest
            // 
            btnRandomProcTest.Location = new Point(202, 852);
            btnRandomProcTest.Name = "btnRandomProcTest";
            btnRandomProcTest.Size = new Size(172, 43);
            btnRandomProcTest.TabIndex = 14;
            btnRandomProcTest.Text = "Load Random Test";
            btnRandomProcTest.UseVisualStyleBackColor = true;
            btnRandomProcTest.Click += btnRandomProcTest_Click;
            // 
            // btnPrioritySkewed
            // 
            btnPrioritySkewed.Location = new Point(545, 852);
            btnPrioritySkewed.Name = "btnPrioritySkewed";
            btnPrioritySkewed.Size = new Size(225, 43);
            btnPrioritySkewed.TabIndex = 17;
            btnPrioritySkewed.Text = "Load Priority Skewed Test";
            btnPrioritySkewed.UseVisualStyleBackColor = true;
            btnPrioritySkewed.Click += btnPrioritySkewed_Click;
            // 
            // btnLongvShortTest
            // 
            btnLongvShortTest.Location = new Point(518, 787);
            btnLongvShortTest.Name = "btnLongvShortTest";
            btnLongvShortTest.Size = new Size(290, 43);
            btnLongvShortTest.TabIndex = 16;
            btnLongvShortTest.Text = "Load Long vs. Short Bursts Test";
            btnLongvShortTest.UseVisualStyleBackColor = true;
            btnLongvShortTest.Click += btnLongvShortTest_Click;
            // 
            // btnIdenATTest
            // 
            btnIdenATTest.Location = new Point(545, 721);
            btnIdenATTest.Name = "btnIdenATTest";
            btnIdenATTest.Size = new Size(225, 43);
            btnIdenATTest.TabIndex = 15;
            btnIdenATTest.Text = "Load Identical AT Test";
            btnIdenATTest.UseVisualStyleBackColor = true;
            btnIdenATTest.Click += btnIdenATTest_Click;
            // 
            // lblTestCases
            // 
            lblTestCases.AutoSize = true;
            lblTestCases.Location = new Point(378, 647);
            lblTestCases.Name = "lblTestCases";
            lblTestCases.Size = new Size(155, 25);
            lblTestCases.TabIndex = 18;
            lblTestCases.Text = "Test Case Buttons!";
            // 
            // dgvSRTFTestCases
            // 
            dgvSRTFTestCases.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvSRTFTestCases.Location = new Point(106, 969);
            dgvSRTFTestCases.Name = "dgvSRTFTestCases";
            dgvSRTFTestCases.RowHeadersWidth = 62;
            dgvSRTFTestCases.Size = new Size(371, 276);
            dgvSRTFTestCases.TabIndex = 19;
            // 
            // dgvMLFQTestCases
            // 
            dgvMLFQTestCases.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvMLFQTestCases.Location = new Point(487, 969);
            dgvMLFQTestCases.Name = "dgvMLFQTestCases";
            dgvMLFQTestCases.RowHeadersWidth = 62;
            dgvMLFQTestCases.Size = new Size(371, 276);
            dgvMLFQTestCases.TabIndex = 20;
            // 
            // lblCurrentTest
            // 
            lblCurrentTest.AutoSize = true;
            lblCurrentTest.Location = new Point(352, 687);
            lblCurrentTest.Name = "lblCurrentTest";
            lblCurrentTest.Size = new Size(224, 25);
            lblCurrentTest.TabIndex = 21;
            lblCurrentTest.Text = "Currently Running: /// Test!";
            // 
            // lblRandNumProc
            // 
            lblRandNumProc.AutoSize = true;
            lblRandNumProc.Location = new Point(48, 898);
            lblRandNumProc.Name = "lblRandNumProc";
            lblRandNumProc.Size = new Size(250, 25);
            lblRandNumProc.TabIndex = 22;
            lblRandNumProc.Text = "Input Num. Processes (10-50):";
            // 
            // txtUserInputRand
            // 
            txtUserInputRand.BackColor = SystemColors.ControlDark;
            txtUserInputRand.Location = new Point(304, 901);
            txtUserInputRand.Name = "txtUserInputRand";
            txtUserInputRand.Size = new Size(60, 31);
            txtUserInputRand.TabIndex = 23;
            // 
            // chartTurnaroundCompare
            // 
            chartArea2.Name = "ChartArea1";
            chartTurnaroundCompare.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            chartTurnaroundCompare.Legends.Add(legend2);
            chartTurnaroundCompare.Location = new Point(931, 372);
            chartTurnaroundCompare.Name = "chartTurnaroundCompare";
            chartTurnaroundCompare.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Pastel;
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            chartTurnaroundCompare.Series.Add(series2);
            chartTurnaroundCompare.Size = new Size(359, 276);
            chartTurnaroundCompare.TabIndex = 24;
            chartTurnaroundCompare.Text = "chart1";
            // 
            // chartCPUPercCompare
            // 
            chartArea3.Name = "ChartArea1";
            chartCPUPercCompare.ChartAreas.Add(chartArea3);
            legend3.Name = "Legend1";
            chartCPUPercCompare.Legends.Add(legend3);
            chartCPUPercCompare.Location = new Point(931, 671);
            chartCPUPercCompare.Name = "chartCPUPercCompare";
            chartCPUPercCompare.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Pastel;
            series3.ChartArea = "ChartArea1";
            series3.Legend = "Legend1";
            series3.Name = "Series1";
            chartCPUPercCompare.Series.Add(series3);
            chartCPUPercCompare.Size = new Size(359, 276);
            chartCPUPercCompare.TabIndex = 25;
            chartCPUPercCompare.Text = "chart1";
            // 
            // chartThroughputCompare
            // 
            chartArea4.Name = "ChartArea1";
            chartThroughputCompare.ChartAreas.Add(chartArea4);
            legend4.Name = "Legend1";
            chartThroughputCompare.Legends.Add(legend4);
            chartThroughputCompare.Location = new Point(931, 969);
            chartThroughputCompare.Name = "chartThroughputCompare";
            chartThroughputCompare.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Pastel;
            series4.ChartArea = "ChartArea1";
            series4.Legend = "Legend1";
            series4.Name = "Series1";
            chartThroughputCompare.Series.Add(series4);
            chartThroughputCompare.Size = new Size(359, 276);
            chartThroughputCompare.TabIndex = 26;
            chartThroughputCompare.Text = "chart1";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1323, 1338);
            Controls.Add(chartThroughputCompare);
            Controls.Add(chartCPUPercCompare);
            Controls.Add(chartTurnaroundCompare);
            Controls.Add(txtUserInputRand);
            Controls.Add(lblRandNumProc);
            Controls.Add(lblCurrentTest);
            Controls.Add(dgvMLFQTestCases);
            Controls.Add(dgvSRTFTestCases);
            Controls.Add(lblTestCases);
            Controls.Add(btnPrioritySkewed);
            Controls.Add(btnLongvShortTest);
            Controls.Add(btnIdenATTest);
            Controls.Add(btnRandomProcTest);
            Controls.Add(btnBasicTest2);
            Controls.Add(btnBasicTest1);
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
            ((System.ComponentModel.ISupportInitialize)dgvSRTFTestCases).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvMLFQTestCases).EndInit();
            ((System.ComponentModel.ISupportInitialize)chartTurnaroundCompare).EndInit();
            ((System.ComponentModel.ISupportInitialize)chartCPUPercCompare).EndInit();
            ((System.ComponentModel.ISupportInitialize)chartThroughputCompare).EndInit();
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
        private Button btnBasicTest1;
        private Button btnBasicTest2;
        private Button btnRandomProcTest;
        private Button btnPrioritySkewed;
        private Button btnLongvShortTest;
        private Button btnIdenATTest;
        private Label lblTestCases;
        private DataGridView dgvSRTFTestCases;
        private DataGridView dgvMLFQTestCases;
        private Label lblCurrentTest;
        private Label lblRandNumProc;
        private TextBox txtUserInputRand;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartTurnaroundCompare;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartCPUPercCompare;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartThroughputCompare;
    }
}
