using System;
using System.Collections.Generic;
using System.Linq;

namespace SubsetProblem
{
    public class Candidate
    {
        public string RawGuid { get; private set; }
        public Stack<string> NumberSeeds { get; set; } = new Stack<string>();
        public Stack<string> NumberOptions { get; set; } = new Stack<string>();
        public int Target { get; set; }
        public List<int> NumberSet { get; set; } = new List<int>();
        public List<List<int>> ActualSolveSet { get; set; } = new List<List<int>>();

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
            string retVal = string.Empty;
            if (NumberSet.Count == 0)
                return retVal;

            NumberSet.Sort();
            foreach (var i in NumberSet)
            {
                retVal += $"{i}, ";
            }

            return "{ " + retVal.Substring(0, retVal.Length - 2) + " }";
        }

        public string GetSolveSet()
        {
            string masterRetval = string.Empty + Environment.NewLine;

            foreach (var a in ActualSolveSet)
            {
                string retVal = string.Empty;

                foreach (var s in a)
                {
                    retVal += $"{s}, ";
                }

                // A target of zero would yield the empty set as a solution so discard this should we get it
                if (retVal.Length >= 2)
                    masterRetval += "{ " + retVal.Substring(0, retVal.Length - 2) + " }" + Environment.NewLine;
            }

            return masterRetval;
        }

        private void Solve()
        {
            var set = new Powerset<int>(NumberSet);
            set.GrowTree();
            var solveSet = set.Candidates;

            foreach (var l in solveSet)
            {

                if (l.Sum() == Target)
                    ActualSolveSet.Add(l.ToList());
            }
        }

        private void BuildTarget()
        {
            Target = NumberSet.Sum() / 2;
        }

        private void InitStacks()
        {
            const string badGuy = "-";
            List<string> nums = new List<string>() { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9" };
            List<string> opts = new List<string>() { "a", "b", "c", "d", "e", "f" };
            foreach (var s in RawGuid)
            {
                var actual = s.ToString();
                if (actual == badGuy)
                    continue;

                if (nums.Contains(actual))
                    NumberSeeds.Push(actual);
                if (opts.Contains(actual))
                    NumberOptions.Push(actual);
            }
        }

        private void BuildNumberSet()
        {
            while (NumberOptions.Count > 0)
            {
                var currentOption = NumberOptions.Pop();
                string newSetMember = string.Empty;

                if (currentOption == "a" || currentOption == "b")
                {
                    if (NumberSeeds.Count > 0)
                    {
                        newSetMember = NumberSeeds.Pop();

                        int newNum = Convert.ToInt32(newSetMember);

                        if (!NumberSet.Contains(newNum) && newNum != 0)
                            NumberSet.Add(newNum);
                    }
                }

                if (currentOption == "c" || currentOption == "d")
                {
                    if (NumberSeeds.Count > 1)
                    {
                        newSetMember = NumberSeeds.Pop() + NumberSeeds.Pop();

                        int newNum = Convert.ToInt32(newSetMember);

                        if (!NumberSet.Contains(newNum) && newNum != 0)
                            NumberSet.Add(newNum);
                    }
                }

                if (currentOption == "e" || currentOption == "f")
                {
                    if (NumberSet.Count > 0)
                    {
                        var topIndex = NumberSet.Count - 1;

                        var newVal = NumberSet[topIndex] * -1;

                        if (!NumberSet.Contains(newVal))
                            NumberSet[topIndex] = NumberSet[topIndex] * -1;
                    }
                }
            }
        }
    }
}

