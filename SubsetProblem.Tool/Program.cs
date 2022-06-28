using System;
using System.Diagnostics;
using static System.Console;

namespace SubsetProblem.Tool
{
    internal static class Program
    {
        private static void Main()
        {
            const int MaxRuns = 10;

            var sw = new Stopwatch();
            sw.Start();

            var run = 0;

            while (true)
            {
                run++;

                var seed = Guid.NewGuid().ToString();
                var candidate = new Candidate(seed);

                WriteLine($"Run                 : {run} of {MaxRuns}");
                WriteLine($"Seed was            : {seed}");
                WriteLine($"Members in set      : {candidate.NumberSet.Count}");
                WriteLine($"Set                 : {candidate.GetDisplayNumberSet()}");
                WriteLine($"Target              : {candidate.Target}");

                var literal = candidate.ActualSolveSet.Count == 0 ? "None" : candidate.ActualSolveSet.Count.ToString();

                WriteLine($"Number of solutions : {literal}");

                if (candidate.ActualSolveSet.Count > 0)
                {
                    WriteLine($"Solutions           : {candidate.GetSolveSet()}");
                }

                WriteLine();

                if (run == MaxRuns)
                {
                    break;
                }
            }

            sw.Stop();

            WriteLine();
            WriteLine($"Ran in: {sw.ElapsedMilliseconds / 1000} s");
            WriteLine($"        {sw.ElapsedMilliseconds} ms");
            WriteLine($"        {sw.ElapsedTicks} ticks");
        }
    }
}
