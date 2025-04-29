using System.Windows.Forms.DataVisualization.Charting;

namespace CPUSchedulingSim
{
    public partial class Form1 : Form
    {
        // Variables for some helper methods
        List<Process> processesSRTF = new List<Process>();
        List<Process> processesMLFQ = new List<Process>();

        double srtfAvgWaitingTime, srtfAvgTurnaroundTime, srtfCPUPerc, srtfThroughput;
        double mlfqAvgWaitingTime, mlfqAvgTurnaroundTime, mlfqCPUPerc, mlfqThroughput;

        bool srtfResultsAvailable = false;
        bool mlfqResultsAvailable = false;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            chartPerformanceCompare.Series.Clear();
            chartPerformanceCompare.ChartAreas.Clear();

            ChartArea chartWArea = new ChartArea();
            chartPerformanceCompare.ChartAreas.Add(chartWArea);

            chartTurnaroundCompare.Series.Clear();
            chartTurnaroundCompare.ChartAreas.Clear();

            ChartArea chartTArea = new ChartArea();
            chartTurnaroundCompare.ChartAreas.Add(chartTArea);

            chartCPUPercCompare.Series.Clear();
            chartCPUPercCompare.ChartAreas.Clear();

            ChartArea chartCArea = new ChartArea();
            chartCPUPercCompare.ChartAreas.Add(chartCArea);

            chartThroughputCompare.Series.Clear();
            chartThroughputCompare.ChartAreas.Clear();

            ChartArea chartThrArea = new ChartArea();
            chartThroughputCompare.ChartAreas.Add(chartThrArea);
        }

        // Helper Methods

        // Generate user-inputted number of processes w/ random args
        private List<Process> GenerateRandomProcesses(int count)
        {
            Random rand = new Random();
            List<Process> processes = new List<Process>();

            for (int i = 0; i < count; i++)
            {
                processes.Add(new Process
                (
                    i + 1,
                    rand.Next(0, 10),
                    rand.Next(1, 10),
                    rand.Next(0, 2)
                ));
            }

            return processes;
        }

        // Calculate averages and other comparison results.
        private double CalculateAvgWaitTime(List<Process> processes)
        {
            double sum = 0.0;
            double numP = 0.0;
            double avg = 0.0;

            foreach (Process process in processes)
            {
                sum += process.WaitingTime;
                numP++;
            }

            avg = sum / numP;
            return avg;
        }
        private double CalculateAvgTurnaroundTime(List<Process> processes)
        {
            double sum = 0.0;
            double numP = 0.0;
            double avg = 0.0;

            foreach (Process process in processes)
            {
                sum += process.TurnaroundTime;
                numP++;
            }

            avg = sum / numP;
            return avg;
        }
        private double CalculateCPUUsePercent(List<Process> processes)
        {
            if (processes == null || processes.Count == 0) return 0.0;

            int totalBurstTime = 0;
            int totalTime = 0;

            foreach (var p in processes)
            {
                totalBurstTime += p.BurstTime;
            }

            //Total time will be the latest completion time.
            totalTime = processes.Max(p => p.CompletionTime);

            if (totalTime == 0) return 0.0;

            double cpuUtilization = ((double)totalBurstTime / totalTime) * 100;

            return cpuUtilization;
        }
        private double CalculateThroughput(List<Process> processes) //In Processes/second
        {
            if (processes == null || processes.Count == 0) return 0.0;

            int totalTime = processes.Max(p => p.CompletionTime);

            if (totalTime == 0) return 0;

            double throughput = (double)processes.Count / totalTime;

            return throughput;
        }

        // Update the GUI results labels
        private void UpdateResultLabels(List<Process> processes, string algorithm)
        {
            double avgWaitingTime = CalculateAvgWaitTime(processes);
            double avgTurnaroundTime = CalculateAvgTurnaroundTime(processes);
            double cpuUtilization = CalculateCPUUsePercent(processes);
            double throughput = CalculateThroughput(processes);

            if (algorithm == "SRTF")
            {
                srtfAvgWaitingTime = avgWaitingTime;
                srtfAvgTurnaroundTime = avgTurnaroundTime;
                srtfCPUPerc = cpuUtilization;
                srtfThroughput = throughput;
            }
            else if (algorithm == "MLFQ")
            {
                mlfqAvgWaitingTime = avgWaitingTime;
                mlfqAvgTurnaroundTime = avgTurnaroundTime;
                mlfqCPUPerc = cpuUtilization;
                mlfqThroughput = throughput;
            }

            lblAvgWaitTime.Text = $"Average Waiting Time: {avgWaitingTime:F2} ms";
            lblAvgTurnaroundTime.Text = $"Average Turnaround Time: {avgTurnaroundTime:F2} ms";
            lblCPUPercent.Text = $"CPU Utilization: {cpuUtilization:F2} %";
            lblThroughput.Text = $"Throughput (Processes/Sec): {throughput:F2} P/s";

            //Flag that a set of results are available for comparison.
            if (algorithm == "SRTF") srtfResultsAvailable = true;
            if (algorithm == "MLFQ") mlfqResultsAvailable = true;
        }

        private void UpdateWaitCompareChart()
        {
            chartPerformanceCompare.Series.Clear();
            chartPerformanceCompare.ChartAreas.Clear();

            ChartArea chartArea = new ChartArea();
            chartPerformanceCompare.ChartAreas.Add(chartArea);

            // Series for SRTF Metrics
            Series srtfSeries = new Series("SRTF");
            srtfSeries.ChartType = SeriesChartType.Column;
            srtfSeries.Points.AddXY("Avg Wait Time (ms)", srtfAvgWaitingTime);

            // Series for MLFQ Metrics
            Series mlfqSeries = new Series("MLFQ");
            mlfqSeries.ChartType = SeriesChartType.Column;
            mlfqSeries.Points.AddXY("Avg Wait Time (ms)", mlfqAvgWaitingTime);

            // Add both series to chart
            chartPerformanceCompare.Series.Add(srtfSeries);
            chartPerformanceCompare.Series.Add(mlfqSeries);

            // Add title
            chartPerformanceCompare.Titles.Clear();
            chartPerformanceCompare.Titles.Add("SRTF vs MLFQ Avg. Wait Time Comparison");

            // Optional: show a legend
            if (chartPerformanceCompare.Legends.Count == 0)
                chartPerformanceCompare.Legends.Add(new Legend());

            chartPerformanceCompare.Legends[0].Docking = Docking.Top;
        }

        private void UpdateTurnaroundCompareChart()
        {
            chartTurnaroundCompare.Series.Clear();
            chartTurnaroundCompare.ChartAreas.Clear();

            ChartArea chartArea = new ChartArea();
            chartTurnaroundCompare.ChartAreas.Add(chartArea);

            // Series for SRTF Metrics
            Series srtfSeries = new Series("SRTF");
            srtfSeries.ChartType = SeriesChartType.Column;
            srtfSeries.Points.AddXY("Avg Turnaround Time (ms)", srtfAvgTurnaroundTime);

            // Series for MLFQ Metrics
            Series mlfqSeries = new Series("MLFQ");
            mlfqSeries.ChartType = SeriesChartType.Column;
            mlfqSeries.Points.AddXY("Avg Turnaround Time (ms)", mlfqAvgTurnaroundTime);

            // Add both series to chart
            chartTurnaroundCompare.Series.Add(srtfSeries);
            chartTurnaroundCompare.Series.Add(mlfqSeries);

            // Add title
            chartTurnaroundCompare.Titles.Clear();
            chartTurnaroundCompare.Titles.Add("SRTF vs MLFQ Avg. Turnaround Comparison");

            // Optional: show a legend
            if (chartPerformanceCompare.Legends.Count == 0)
                chartPerformanceCompare.Legends.Add(new Legend());

            chartTurnaroundCompare.Legends[0].Docking = Docking.Top;
        }

        private void UpdateCPUPercCompareChart()
        {
            chartCPUPercCompare.Series.Clear();
            chartCPUPercCompare.ChartAreas.Clear();

            ChartArea chartArea = new ChartArea();
            chartCPUPercCompare.ChartAreas.Add(chartArea);

            // Series for SRTF Metrics
            Series srtfSeries = new Series("SRTF");
            srtfSeries.ChartType = SeriesChartType.Column;
            srtfSeries.Points.AddXY("CPU Utilization (%)", srtfCPUPerc);

            // Series for MLFQ Metrics
            Series mlfqSeries = new Series("MLFQ");
            mlfqSeries.ChartType = SeriesChartType.Column;
            mlfqSeries.Points.AddXY("CPU Utilization (%)", mlfqCPUPerc);

            // Add both series to chart
            chartCPUPercCompare.Series.Add(srtfSeries);
            chartCPUPercCompare.Series.Add(mlfqSeries);

            // Add title
            chartCPUPercCompare.Titles.Clear();
            chartCPUPercCompare.Titles.Add("SRTF vs MLFQ CPU Percentage Comparison");

            // Optional: show a legend
            if (chartPerformanceCompare.Legends.Count == 0)
                chartPerformanceCompare.Legends.Add(new Legend());

            chartCPUPercCompare.Legends[0].Docking = Docking.Top;
        }

        private void UpdateThroughputCompareChart()
        {
            chartThroughputCompare.Series.Clear();
            chartThroughputCompare.ChartAreas.Clear();

            ChartArea chartArea = new ChartArea();
            chartThroughputCompare.ChartAreas.Add(chartArea);

            // Series for SRTF Metrics
            Series srtfSeries = new Series("SRTF");
            srtfSeries.ChartType = SeriesChartType.Column;
            srtfSeries.Points.AddXY("Throughput (P/s)", srtfThroughput);

            // Series for MLFQ Metrics
            Series mlfqSeries = new Series("MLFQ");
            mlfqSeries.ChartType = SeriesChartType.Column;
            mlfqSeries.Points.AddXY("Throughput (P/s)", mlfqThroughput);

            // Add both series to chart
            chartThroughputCompare.Series.Add(srtfSeries);
            chartThroughputCompare.Series.Add(mlfqSeries);

            // Add title
            chartThroughputCompare.Titles.Clear();
            chartThroughputCompare.Titles.Add("SRTF vs MLFQ Throughput Comparison");

            // Optional: show a legend
            if (chartPerformanceCompare.Legends.Count == 0)
                chartPerformanceCompare.Legends.Add(new Legend());

            chartThroughputCompare.Legends[0].Docking = Docking.Top;
        }

        private void RunSRTFAlg(List<Process> processes)
        {
            CPUSchedulerAlgs.SRTFAlg(processes);
        }
        private void RunMLFQAlg(List<Process> processes)
        {
            //MessageBox.Show("MLFQ algorithm is starting!"); // Debugging
            CPUSchedulerAlgs.MLFQAlg(processes);
        }

        // Button Handler Code
        private void btnRunSRTFAlg_Click(object sender, EventArgs e)
        {
            int numProcesses;
            if (int.TryParse(inputNumProcesses.Text, out numProcesses) && numProcesses > 0)
            {
                processesSRTF = GenerateRandomProcesses(numProcesses);
                processesDGV.DataSource = processesSRTF; // Show the proceesses in the grid!

                RunSRTFAlg(processesSRTF); // Run SRTF

                UpdateResultLabels(processesSRTF, "SRTF"); // Update analysis values

                lblNumProcesses.Text = $"Number of Processes Running: {numProcesses}";
            }
            else
            {
                MessageBox.Show("!! - Please input a valid positive Num. Processes!");
            }
        }

        private void btnRunMLFQAlg_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("Running MLFQ algorithm..."); // Check if the click event is firing
            int numProcesses;
            if (int.TryParse(inputNumProcesses.Text, out numProcesses) && numProcesses > 0)
            {
                processesMLFQ = GenerateRandomProcesses(numProcesses);
                processesDGV.DataSource = processesMLFQ; // Show the proceesses in the grid!

                RunMLFQAlg(processesMLFQ); // Run MLFQ

                UpdateResultLabels(processesMLFQ, "MLFQ"); // Update analysis values

                lblNumProcesses.Text = $"Number of Processes Running: {numProcesses}";
            }
            else
            {
                MessageBox.Show("!! - Please input a valid positive Num. Processes!");
            }
        }

        private void btnCompare_Click(object sender, EventArgs e)
        {
            if (srtfResultsAvailable && mlfqResultsAvailable)
            {
                UpdateWaitCompareChart();
                UpdateTurnaroundCompareChart();
                UpdateCPUPercCompareChart();
                UpdateThroughputCompareChart();
            }
            else
            {
                MessageBox.Show("!! - Please run both SRTF and MLFQ before trying to Compare!");
            }
        }

        //
        // Test Case Buttons
        //
        private void btnBasicTest1_Click(object sender, EventArgs e)
        {
            // Run SRTF w/ test case
            processesSRTF = SchedulerTestCases.GetBasicTest1();
            dgvSRTFTestCases.DataSource = processesSRTF; // Show the proceesses in the grid!

            RunSRTFAlg(processesSRTF); // Run SRTF

            UpdateResultLabels(processesSRTF, "SRTF"); // Update analysis values

            // Run MLFQ w/ test case
            processesMLFQ = SchedulerTestCases.GetBasicTest1();
            dgvMLFQTestCases.DataSource = processesMLFQ; // Show the proceesses in the grid!

            RunMLFQAlg(processesMLFQ); // Run MLFQ

            UpdateResultLabels(processesMLFQ, "MLFQ"); // Update analysis values

            lblCurrentTest.Text = "Currently Running: \"Basic Test 1\" Test!";
        }

        private void btnBasicTest2_Click(object sender, EventArgs e)
        {
            // Run SRTF w/ test case
            processesSRTF = SchedulerTestCases.GetBasicTest2();
            dgvSRTFTestCases.DataSource = processesSRTF; // Show the proceesses in the grid!

            RunSRTFAlg(processesSRTF); // Run SRTF

            UpdateResultLabels(processesSRTF, "SRTF"); // Update analysis values

            // Run MLFQ w/ test case
            processesMLFQ = SchedulerTestCases.GetBasicTest2();
            dgvMLFQTestCases.DataSource = processesMLFQ; // Show the proceesses in the grid!

            RunMLFQAlg(processesMLFQ); // Run MLFQ

            UpdateResultLabels(processesMLFQ, "MLFQ"); // Update analysis values

            lblCurrentTest.Text = "Currently Running: \"Basic Test 2\" Test!";
        }

        private void btnRandomProcTest_Click(object sender, EventArgs e)
        {
            int numProcesses;
            if (int.TryParse(txtUserInputRand.Text, out numProcesses) && numProcesses >= 10 && numProcesses <= 50)
            {
                // Run SRTF w/ test case
                processesSRTF = SchedulerTestCases.GenerateRandomProcesses(numProcesses);
                dgvSRTFTestCases.DataSource = processesSRTF; // Show the proceesses in the grid!

                RunSRTFAlg(processesSRTF); // Run SRTF

                UpdateResultLabels(processesSRTF, "SRTF"); // Update analysis values

                // Run MLFQ w/ test case
                processesMLFQ = SchedulerTestCases.GenerateRandomProcesses(50);
                dgvMLFQTestCases.DataSource = processesMLFQ; // Show the proceesses in the grid!

                RunMLFQAlg(processesMLFQ); // Run MLFQ

                UpdateResultLabels(processesMLFQ, "MLFQ"); // Update analysis values

                lblNumProcesses.Text = $"Number of Processes Running: {numProcesses}";
                lblCurrentTest.Text = "Currently Running: \"Randomized Processes\" Test!";
            }
            else
            {
                MessageBox.Show("!! - Please input a valid positive Num. Processes! (10-50)");
            }
        }

        private void btnIdenATTest_Click(object sender, EventArgs e)
        {
            // Run SRTF w/ test case
            processesSRTF = SchedulerTestCases.GetIdenticalArrivalBurst();
            dgvSRTFTestCases.DataSource = processesSRTF; // Show the proceesses in the grid!

            RunSRTFAlg(processesSRTF); // Run SRTF

            UpdateResultLabels(processesSRTF, "SRTF"); // Update analysis values

            // Run MLFQ w/ test case
            processesMLFQ = SchedulerTestCases.GetIdenticalArrivalBurst();
            dgvMLFQTestCases.DataSource = processesMLFQ; // Show the proceesses in the grid!

            RunMLFQAlg(processesMLFQ); // Run MLFQ

            UpdateResultLabels(processesMLFQ, "MLFQ"); // Update analysis values

            lblCurrentTest.Text = "Currently Running: \"Identical Arrival and Burst Time\" Test!";
        }

        private void btnLongvShortTest_Click(object sender, EventArgs e)
        {
            // Run SRTF w/ test case
            processesSRTF = SchedulerTestCases.GetLongVsShortBursts();
            dgvSRTFTestCases.DataSource = processesSRTF; // Show the proceesses in the grid!

            RunSRTFAlg(processesSRTF); // Run SRTF

            UpdateResultLabels(processesSRTF, "SRTF"); // Update analysis values

            // Run MLFQ w/ test case
            processesMLFQ = SchedulerTestCases.GetLongVsShortBursts();
            dgvMLFQTestCases.DataSource = processesMLFQ; // Show the proceesses in the grid!

            RunMLFQAlg(processesMLFQ); // Run MLFQ

            UpdateResultLabels(processesMLFQ, "MLFQ"); // Update analysis values

            lblCurrentTest.Text = "Currently Running: \"Long vs. Short Burst Times\" Test!";
        }

        private void btnPrioritySkewed_Click(object sender, EventArgs e)
        {
            // Run SRTF w/ test case
            processesSRTF = SchedulerTestCases.GetPrioritySkewed();
            dgvSRTFTestCases.DataSource = processesSRTF; // Show the proceesses in the grid!

            RunSRTFAlg(processesSRTF); // Run SRTF

            UpdateResultLabels(processesSRTF, "SRTF"); // Update analysis values

            // Run MLFQ w/ test case
            processesMLFQ = SchedulerTestCases.GetPrioritySkewed();
            dgvMLFQTestCases.DataSource = processesMLFQ; // Show the proceesses in the grid!

            RunMLFQAlg(processesMLFQ); // Run MLFQ

            UpdateResultLabels(processesMLFQ, "MLFQ"); // Update analysis values

            lblCurrentTest.Text = "Currently Running: \"Priority Skewed\" Test!";
        }
    }
}
