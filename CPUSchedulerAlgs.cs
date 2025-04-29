using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPUSchedulingSim
{
    internal class CPUSchedulerAlgs
    {
        // Shortest Remaining Time First Scheduling Algorithm
        public static void SRTFAlg(List<Process> processes)
        {
            int time = 0;
            Queue<Process> readyQueue = new Queue<Process>();

            while (processes.Any(p => p.RemainingTime > 0)) // While there's still remaining processes
            {
                // Store all processes in readyProcesses given their Arrival Time is met && their burst time
                // has not ended. Order them in asc. order/by least remaining time.
                var readyProcesses = processes.Where(p => p.ArrivalTime <= time && p.RemainingTime > 0).OrderBy
                    (p => p.RemainingTime).ToList();

                if (readyProcesses.Any())
                {
                    var process = readyProcesses.First(); //Choose process with shortest remaining burst time
                    process.RemainingTime--;
                    time++;
                    if (process.RemainingTime == 0)
                    {
                        process.CompletionTime = time;
                        process.TurnaroundTime = process.CompletionTime - process.ArrivalTime;
                        process.WaitingTime = process.TurnaroundTime - process.BurstTime;
                    }
                }
                else
                {
                    time++; // In the case no process is ready, increment time.
                }
            }
        }

        // Multi-Level Feedback Queue Scheduling Algorithm
        public static void MLFQAlg(List<Process> processes)
        {
            int time = 0;
            int[] timeQuantums = { 4, 8 }; // Highest priority q. allows processes 4 units CPU time slice;
                                           //middle priority q. allows 8 units.

            // Only 3 tiers of Queues for simplicity.
            Queue<Process> hiQueue = new Queue<Process>();
            Queue<Process> midQueue = new Queue<Process>();
            Queue<Process> lowQueue = new Queue<Process>();

            List <Process> allProcesses = new List<Process>(processes); // Make a copy of processes for later manipulation.

            while (processes.Any(p => p.RemainingTime > 0))
            {
                //Console.WriteLine($"Time: {time}");
                // Add NEW processes to the proper queue according to arrival time & Priority. 0 = high, 1 = mid, 2 = low
                foreach (var p in allProcesses.Where(p => p.ArrivalTime == time && !p.HasArrived))
                {
                    p.HasArrived = true; // Mark a process arrived; no longer queues.

                    if (p.Priority == 0)
                    {
                        hiQueue.Enqueue(p);
                        //Console.WriteLine($"Process {p.Id} added to High Priority Queue at Time {time}");
                    }
                    else if (p.Priority == 1)
                    {
                        midQueue.Enqueue(p);
                        //Console.WriteLine($"Process {p.Id} added to Medium Priority Queue at Time {time}");
                    }
                    else
                    {
                        lowQueue.Enqueue(p);
                        //Console.WriteLine($"Process {p.Id} added to Low Priority Queue at Time {time}");
                    }
                }

                Process current = null; // Initialize current operating process.
                int quantum = 0; // Holder for process time slice.

                // Select the queue to run a process from.
                if (hiQueue.Any())
                {
                    current = hiQueue.Dequeue();
                    quantum = timeQuantums[0]; // Time quantum for hiQueue
                }
                else if (midQueue.Any())
                {
                    current = midQueue.Dequeue();
                    quantum = timeQuantums[1]; // Time quantum for midQueue
                }
                else if (lowQueue.Any())
                {
                    current = lowQueue.Dequeue();
                    quantum = int.MaxValue; // There is no time quantum for the lowest tier.
                }

                if (current != null)
                {
                    //Console.WriteLine($"Running Process {current.Id} for {quantum} units (RemainingTime: {current.RemainingTime})");

                    int timeSpent = 0; // Time spent on a given process.

                    // Execute the process until quantum or finished.
                    while (timeSpent < quantum && current.RemainingTime > 0)
                    {
                        time++; 
                        timeSpent++;
                        current.RemainingTime--;

                        //Check for new arrivals after time++;
                        foreach (var p in allProcesses.Where(p => p.ArrivalTime == time && !p.HasArrived))
                        {
                            p.HasArrived = true; // Mark a process arrived; no longer queues.

                            if (p.Priority == 0)
                            {
                                hiQueue.Enqueue(p);
                                //Console.WriteLine($"Process {p.Id} added to High Priority Queue at Time {time}");
                            }
                            else if (p.Priority == 1)
                            {
                                midQueue.Enqueue(p);
                                //Console.WriteLine($"Process {p.Id} added to Medium Priority Queue at Time {time}");
                            }
                            else
                            {
                                lowQueue.Enqueue(p);
                                Console.WriteLine($"Process {p.Id} added to Low Priority Queue at Time {time}");
                            }
                        }
                    }

                    // In the case that the process does not finish within its quantum:
                    if (current.RemainingTime > 0)
                    {
                        if (quantum == timeQuantums[0]) // Bumped from hiQueue to midQueue.
                        { 
                            midQueue.Enqueue(current);
                            current.Priority = 1;
                            //Console.WriteLine($"Process {current.Id} moved to Medium Priority Queue.");
                        }
                        else if (quantum == timeQuantums[1]) // Bumped from midQueue to lowQueue.
                        {
                            lowQueue.Enqueue(current);
                            current.Priority = 2;
                            //Console.WriteLine($"Process {current.Id} moved to Low Priority Queue.");
                        }
                        else // Already at lowest queue; remain in place.
                        { 
                            lowQueue.Enqueue(current);
                            //Console.WriteLine($"Process {current.Id} remains in Low Priority Queue.");
                        }
                    } 
                    else
                    {
                        // Process has finished.
                        current.CompletionTime = time;
                        current.TurnaroundTime = current.CompletionTime - current.ArrivalTime;
                        current.WaitingTime = current.TurnaroundTime - current.BurstTime;
                        //Console.WriteLine($"Process {current.Id} completed at Time {time}");
                    }
                }
                if (current == null)
                {
                    time++;
                    //Console.WriteLine("No processes ready, incrementing time.");
                }
            }
        }
        //Debugging test
        /*public static void MLFQAlg(List<Process> processes)
        {
            int time = 0;
            Queue<Process> hiQueue = new Queue<Process>();
            Queue<Process> midQueue = new Queue<Process>();
            Queue<Process> lowQueue = new Queue<Process>();

            foreach (var p in processes)
            {
                if (p.ArrivalTime == time)
                {
                    if (p.Priority == 0)
                    {
                        hiQueue.Enqueue(p);
                        Console.WriteLine($"Process {p.Id} added to High Priority Queue.");
                    }
                    else if (p.Priority == 1)
                    {
                        midQueue.Enqueue(p);
                        Console.WriteLine($"Process {p.Id} added to Medium Priority Queue.");
                    }
                    else
                    {
                        lowQueue.Enqueue(p);
                        Console.WriteLine($"Process {p.Id} added to Low Priority Queue.");
                    }
                }
            }
        }*/
    }
}
