using System;
using System.Collections.Generic;
using System.Linq;

namespace SubsetProblem;

public class Candidate
{
    public string RawGuid { get; }
    public int TargetSum { get; private set; }
    public List<int> SourceNumberSet { get; } = new List<int>();
    public List<List<int>> TargetSolutionSet { get; } = new List<List<int>>();

    private Stack<string> NumberSeeds { get; } = new Stack<string>();
    private Stack<string> NumberOptions { get; } = new Stack<string>();

    public Candidate(string guid)
    {
        RawGuid = guid;
        InitStacks();
        BuildNumberSet();
        BuildTarget();
        Solve();
    }

    public string GetDisplayNumberSet()
    {
        var retVal = string.Empty;

        if (SourceNumberSet.Count == 0)
        {
            return retVal;
        }

        SourceNumberSet.Sort();

        foreach (var i in SourceNumberSet)
        {
            retVal += $"{i}, ";
        }

        return "{ " + retVal.Substring(0, retVal.Length - 2) + " }";
    }

    public string GetSolveSet()
    {
        var masterRetVal = string.Empty + Environment.NewLine;

        foreach (var a in TargetSolutionSet)
        {
            var retVal = string.Empty;

            foreach (var s in a)
            {
                retVal += $"{s}, ";
            }

            // A target of zero would yield the empty set as a solution so discard this should we get it
            if (retVal.Length >= 2)
            {
                masterRetVal += "{ " + retVal.Substring(0, retVal.Length - 2) + " }" + Environment.NewLine;
            }
        }

        return masterRetVal;
    }

    private void Solve()
    {
        var set = new Powerset<int>(SourceNumberSet);
        set.GrowTree();
        var solveSet = set.Candidates;

        foreach (var l in solveSet)
        {
            if (l.Sum() == TargetSum)
            {
                TargetSolutionSet.Add(l.ToList());
            }
        }
    }

    private void BuildTarget()
    {
        TargetSum = SourceNumberSet.Sum() / 2;
    }

    private void InitStacks()
    {
        const string BadGuy = "-";
        var numbers = new List<string>() { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9" };
        var opts = new List<string>() { "a", "b", "c", "d", "e", "f" };

        foreach (var s in RawGuid)
        {
            var actual = s.ToString();
            if (actual == BadGuy)
                continue;

            if (numbers.Contains(actual))
            {
                NumberSeeds.Push(actual);
            }

            if (opts.Contains(actual))
            {
                NumberOptions.Push(actual);
            }
        }
    }

    private void BuildNumberSet()
    {
        while (NumberOptions.Count > 0)
        {
            var currentOption = NumberOptions.Pop();
            string newSetMember;

            if (currentOption == "a" || currentOption == "b")
            {
                if (NumberSeeds.Count > 0)
                {
                    newSetMember = NumberSeeds.Pop();

                    var newNum = Convert.ToInt32(newSetMember);

                    if (!SourceNumberSet.Contains(newNum) && newNum != 0)
                        SourceNumberSet.Add(newNum);
                }
            }

            if (currentOption == "c" || currentOption == "d")
            {
                if (NumberSeeds.Count > 1)
                {
                    newSetMember = NumberSeeds.Pop() + NumberSeeds.Pop();

                    var newNum = Convert.ToInt32(newSetMember);

                    if (!SourceNumberSet.Contains(newNum) && newNum != 0)
                        SourceNumberSet.Add(newNum);
                }
            }

            if (currentOption == "e" || currentOption == "f")
            {
                if (SourceNumberSet.Count > 0)
                {
                    var topIndex = SourceNumberSet.Count - 1;

                    var newVal = SourceNumberSet[topIndex] * -1;

                    if (!SourceNumberSet.Contains(newVal))
                        SourceNumberSet[topIndex] = SourceNumberSet[topIndex] * -1;
                }
            }
        }
    }
}