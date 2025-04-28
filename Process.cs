using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPUSchedulingSim
{
    internal class Process
    {
        //Create all Process attributes for later calculations
        public int Id { get; set; }
        public int ArrivalTime { get; set; }
        public int BurstTime { get; set; }
        public int RemainingTime { get; set; }
        public int CompletionTime { get; set; }
        public int WaitingTime { get; set; }
        public int TurnaroundTime { get; set; }
        public int Priority { get; set; } // 0 = high, 1 = mid, 2 = low
        
        public bool HasArrived { get; set; } = false; // All processes start false 

        //Process constructor

        public Process(int id, int arrivalTime, int burstTime, int priority) {
            Id = id;
            ArrivalTime = arrivalTime;
            BurstTime = burstTime;
            RemainingTime = burstTime;
            Priority = priority;
        }
    }
}
