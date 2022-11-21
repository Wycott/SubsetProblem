using System;
using System.Diagnostics;
using static System.Console;

namespace SubsetProblem.Tool
{
    internal static class Program
    {
        private static void Main()
        {
            const bool SingleSolutionsOnly = true;
            const int MaxRuns = 100;

            var sw = new Stopwatch();
            sw.Start();

            var run = 0;

            while (true)
            {
                run++;

                var seed = Guid.NewGuid().ToString();
                var candidate = new Candidate(seed);
                int solutions = candidate.TargetSolutionSet.Count;

                if (!SingleSolutionsOnly || (SingleSolutionsOnly && solutions == 1))
                {

                    WriteLine($"Run                 : {run} of {MaxRuns}");
                    WriteLine($"Seed was            : {seed}");
                    WriteLine($"Members in set      : {candidate.SourceNumberSet.Count}");
                    WriteLine($"Set                 : {candidate.GetDisplayNumberSet()}");
                    WriteLine($"TargetSum              : {candidate.TargetSum}");

                    var literal = solutions == 0 ? "None" : solutions.ToString();

                    WriteLine($"Number of solutions : {literal}");

                    if (candidate.TargetSolutionSet.Count > 0)
                    {
                        WriteLine($"Solutions           : {candidate.GetSolveSet()}");
                    }

                    WriteLine();
                }

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
