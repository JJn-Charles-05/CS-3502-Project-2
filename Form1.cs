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

            ChartArea chartArea = new ChartArea();
            chartPerformanceCompare.ChartAreas.Add(chartArea);
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

        private void UpdateCompareChart()
        {
            chartPerformanceCompare.Series.Clear();
            chartPerformanceCompare.ChartAreas.Clear();

            ChartArea chartArea = new ChartArea();
            chartPerformanceCompare.ChartAreas.Add(chartArea);

            Series seriesWaiting = new Series("Average Waiting Time");
            seriesWaiting.ChartType = SeriesChartType.Column;
            seriesWaiting.Points.AddXY("SRTF", srtfAvgWaitingTime);
            seriesWaiting.Points.AddXY("MLFQ", mlfqAvgWaitingTime);

            Series seriesTurnaround = new Series("Average Turnaround Time");
            seriesTurnaround.ChartType = SeriesChartType.Column;
            seriesTurnaround.Points.AddXY("SRTF", srtfAvgTurnaroundTime);
            seriesTurnaround.Points.AddXY("MLFQ", mlfqAvgTurnaroundTime);

            chartPerformanceCompare.Series.Add(seriesWaiting);
            chartPerformanceCompare.Series.Add(seriesTurnaround);

            chartPerformanceCompare.Titles.Clear();
            chartPerformanceCompare.Titles.Add("Comparison: SRTF vs MLFQ");
        }

        private void RunSRTFAlg (List<Process> processes)
        {
            CPUSchedulerAlgs.SRTFAlg(processes);
        }
        private void RunMLFQAlg (List<Process> processes)
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
                UpdateCompareChart();
            }
            else
            {
                MessageBox.Show("!! - Please run both SRTF and MLFQ before trying to Compare!");
            }
        }


        // Graph Handler Code
    }
}
