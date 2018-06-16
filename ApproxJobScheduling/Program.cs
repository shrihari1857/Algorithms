using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApproxJobScheduling
{
    class Program
    {
        static void Main(string[] args)
        {
            var jobs = new List<Job> {
                new Job{ Size = 3, Time = 4 },
                new Job{ Size = 4, Time = 5 },
                new Job{ Size = 1, Time = 3 },
                new Job{ Size = 5, Time = 6 } };

            jobs = (from item in jobs.AsEnumerable()
                    orderby item.Time descending
                    select item).ToList();
                    
            var totalMachineTime = new int[] { 0, 0};
            var totalMachineJobSets = new[]{
                            new List<Job>(),
                            new List<Job>()
                        };

            for (int i = 0; i < jobs.Count; i++)
            {
                var minLoadMachine = totalMachineTime.ToList().IndexOf(totalMachineTime.Min());
                totalMachineJobSets[minLoadMachine].Add(jobs[i]);
                totalMachineTime[minLoadMachine] = totalMachineTime[minLoadMachine] + jobs[i].Time;
            }

            var m = 0;
            foreach (var machine in totalMachineJobSets)
            {
                Console.WriteLine(m.ToString() + " has following jobs");
                foreach (var job in machine)
                {
                    Console.WriteLine("Size: " + job.Size + ", Time: " + job.Time.ToString());
                }
                m++;
            }
        }
    }

    public class Job
    {
        public int Size { get; set; }
        public int Time { get; set; }
    }
}
