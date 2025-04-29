using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPUSchedulingSim
{
    internal class SchedulerTestCases
    {
        //
        // Test Cases
        //

        // 7.1 Basic Functionality Tests

        // Test 1: Simple different arrival times
        public static List<Process> GetBasicTest1()
        {
            return new List<Process>
        {
            new Process(1, 0, 5, 1),
            new Process(2, 2, 3, 2),
            new Process(3, 4, 1, 0)
        };
        }

        // Test 2: All processes arrive at the same time
        public static List<Process> GetBasicTest2()
        {
            return new List<Process>
        {
            new Process(1, 0, 6, 0),
            new Process(2, 0, 4, 1),
            new Process(3, 0, 5, 2)
        };
        }

        // 7.2 Larger Scale Tests

        // Randomized batch of processes
        public static List<Process> GenerateRandomProcesses(int count)
        {
            Random rand = new Random();
            List<Process> processes = new List<Process>();

            for (int i = 0; i < count; i++)
            {
                processes.Add(new Process(
                    id: i + 1,
                    arrivalTime: rand.Next(0, 20),    // Arrival between 0–20
                    burstTime: rand.Next(1, 15),      // Burst between 1–15
                    priority: rand.Next(0, 3)         // Priority 0, 1, or 2
                ));
            }

            return processes;
        }

        // 7.3 Edge Cases

        // Edge Case 1: All arrive at time 0 + identical burst times
        public static List<Process> GetIdenticalArrivalBurst()
        {
            return new List<Process>
        {
            new Process(1, 0, 5, 0),
            new Process(2, 0, 5, 1),
            new Process(3, 0, 5, 2),
            new Process(4, 0, 5, 0)
        };
        }

        // Edge Case 2: Very long vs very short burst times
        public static List<Process> GetLongVsShortBursts()
        {
            return new List<Process>
        {
            new Process(1, 0, 30, 0),
            new Process(2, 1, 2, 1),
            new Process(3, 2, 1, 2)
        };
        }

        // Edge Case 3: Random priorities skewed
        public static List<Process> GetPrioritySkewed()
        {
            return new List<Process>
        {
            new Process(1, 0, 2, 2),
            new Process(2, 1, 3, 0),
            new Process(3, 2, 4, 2),
            new Process(4, 3, 5, 1)
        };
        }
    }
}
