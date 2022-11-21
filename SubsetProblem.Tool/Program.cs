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
                var seed = GetSeed();
                var candidate = new Candidate(seed);
                var solutions = candidate.TargetSolutionSet.Count;

                if (!SingleSolutionsOnly || (SingleSolutionsOnly && solutions == 1))
                {
                    DisplayOutputSet(run, MaxRuns, seed, candidate, solutions);
                }

                if (run == MaxRuns)
                {
                    break;
                }
            }

            sw.Stop();

            DisplayTimingInformation(sw);
        }

        private static string GetSeed()
        {
            return Guid.NewGuid().ToString();
        }

        private static void DisplayOutputSet(int run, int maxRuns, string seed, Candidate candidate, int solutions)
        {
            WriteLine($"Run                 : {run} of {maxRuns}");
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

        private static void DisplayTimingInformation(Stopwatch sw)
        {
            WriteLine();
            WriteLine($"Ran in: {sw.ElapsedMilliseconds / 1000} s");
            WriteLine($"        {sw.ElapsedMilliseconds} ms");
            WriteLine($"        {sw.ElapsedTicks} ticks");
        }
    }
}
