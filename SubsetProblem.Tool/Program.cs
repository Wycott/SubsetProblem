using System;
using System.Diagnostics;

namespace SubsetProblem.Tool
{
    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            //const int maxRuns = 1000000;
            const int maxRuns = 10;
            int run = 0;
            while (true)
            {
                run++;
                var seed = Guid.NewGuid().ToString();
                var candidate = new Candidate(seed);

                Console.WriteLine($"Run                 : {run} of {maxRuns}");
                Console.WriteLine($"Seed was            : {seed}");
                Console.WriteLine($"Members in set      : {candidate.NumberSet.Count}");
                Console.WriteLine($"Set                 : {candidate.GetDisplayNumberSet()}");
                Console.WriteLine($"Target              : {candidate.Target}");

                string literal = candidate.ActualSolveSet.Count == 0 ? "None" : candidate.ActualSolveSet.Count.ToString();
                Console.WriteLine($"Number of solutions : {literal}");
                if (candidate.ActualSolveSet.Count > 0)
                    Console.WriteLine($"Solutions           : {candidate.GetSolveSet()}");
                Console.WriteLine();
                //System.Threading.Thread.Sleep(1000);                
                if (run == maxRuns)
                    break;
            }
            sw.Stop();
            Console.WriteLine();
            Console.WriteLine($"Ran in: {sw.ElapsedMilliseconds/1000} s");
            Console.WriteLine($"        {sw.ElapsedMilliseconds} ms");
            Console.WriteLine($"        {sw.ElapsedTicks} ticks");
        }
    }
}
