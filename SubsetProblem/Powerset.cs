using System;
using System.Collections.Generic;
using System.Linq;

namespace SubsetProblem;

/// <summary>
/// General purpose class for generating powersets and powerset subsets of size N
/// </summary>
/// <typeparam name="T">Element type</typeparam>
internal class Powerset<T>
{
    /// <summary>
    /// If the subset size is set to this value, all powerset subsets will be generated
    /// </summary>
    private const int Anyset = -1;

    /// <summary>
    /// Initialises a new instance of the Powerset class
    /// </summary>
    /// <param name="t">IList of type T</param>
    /// <param name="candidateCount">Subset size</param>
    internal Powerset(IList<T> t, int candidateCount)
    {
        InputSet = t;
        BinaryTree = new List<Node>();
        MaxGeneration = InputSet.Count;
        CandidateCount = candidateCount;
        Candidates = new List<IList<T>>();
    }

    /// <summary>
    /// Initialises a new instance of the Powerset class
    /// </summary>
    /// <param name="t">IList of type T</param>       
    internal Powerset(IList<T> t)
        : this(t, Anyset)
    {
    }

    /// <summary>
    /// Gets or sets the powerset subsets
    /// </summary>
    internal IList<IList<T>> Candidates { get; set; }

    /// <summary>
    /// Gets or sets the IList of type T used for generating the powerset
    /// </summary>
    private IList<T> InputSet { get; set; }

    /// <summary>
    /// Gets or sets the binary tree used to build the powerset
    /// </summary>
    private IList<Node> BinaryTree { get; set; }

    /// <summary>
    /// Gets or sets the last tree level. The tree will be traversed from the leaves upwards
    /// </summary>
    private int MaxGeneration { get; set; }

    /// <summary>
    /// Gets or sets the size of subsets to be included
    /// </summary>
    private int CandidateCount { get; set; }

    /// <summary>
    /// Create and traverse the tree using the input set
    /// </summary>
    internal void GrowTree()
    {
        var currentGeneration = MaxGeneration;

        foreach (var member in InputSet)
        {
            AddGeneration(member, currentGeneration);
            currentGeneration--;
        }

        TraverseTree();
    }

    /// <summary>
    /// Traverse the tree to harvest the subsets
    /// </summary>
    private void TraverseTree()
    {
        foreach (var n in BinaryTree.Where(x => x.Generation.Equals(MaxGeneration)).ToList())
        {
            IList<T> possibleSet = new List<T>();
            var leafCount = 0;

            var currentNode = n;

            while (currentNode != null)
            {
                if (currentNode.LeftMost)
                {
                    possibleSet.Add(currentNode.Element);
                    leafCount++;
                }

                currentNode = currentNode.Parent;
            }

            if (leafCount == CandidateCount || CandidateCount == Anyset)
            {
                Candidates.Add(possibleSet);
            }
        }
    }

    /// <summary>
    /// Add a node level to the tree
    /// </summary>
    /// <param name="t">Object of type T to store at this level</param>
    /// <param name="generation">The level to create the nodes at</param>
    private void AddGeneration(T t, int generation)
    {
        var x = 2.0;
        double y = generation;

        var nodesToAdd = (int)Math.Pow(x, y);

        for (var n = 0; n < nodesToAdd; n++)
        {
            var newbie = new Node(t, n % 2 == 0, generation);

            BinaryTree.Add(newbie);

            if (generation != MaxGeneration)
            {
                GetNextOrphanNode(generation + 1, true).Parent = newbie;
                GetNextOrphanNode(generation + 1, false).Parent = newbie;
            }
        }
    }

    /// <summary>
    /// Get the next orphan node of the relevant type at the given generation
    /// </summary>
    /// <param name="generation">Generation to select orphan nodes from</param>
    /// <param name="leftmost">Pick the leftmost or rightmost orphan node</param>
    /// <returns>The next orphan node</returns>
    private Node GetNextOrphanNode(int generation, bool leftmost)
    {
        return BinaryTree.FirstOrDefault(x => x.Generation.Equals(generation) && x.LeftMost.Equals(leftmost) && x.Parent == null);
    }

    /// <summary>
    /// Tree node class
    /// </summary>
    internal class Node
    {
        /// <summary>
        /// Initialises a new instance of the Node class
        /// </summary>
        /// <param name="element">Object of type T to store in the node</param>
        /// <param name="leftmost">Leftmost branch i.e. include</param>
        /// <param name="generation">Tree node level</param>
        internal Node(T element, bool leftmost, int generation)
        {
            Parent = null;
            Element = element;
            Generation = generation;
            LeftMost = leftmost;
        }

        /// <summary>
        /// Gets or sets the object of type T to store in the node
        /// </summary>
        internal T Element { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this is the leftmost branch
        /// </summary>
        internal bool LeftMost { get; set; }

        /// <summary>
        /// Gets or sets the parent node
        /// </summary>
        internal Node Parent { get; set; }

        /// <summary>
        /// Gets or sets the generation the node sits at
        /// </summary>
        internal int Generation { get; set; }
    }
}