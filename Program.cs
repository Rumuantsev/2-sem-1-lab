using System;
using System.Collections.Generic;

namespace Lab7
{
    internal class Program
    {
        delegate List<int> InOrderTraversal(BinaryTree<int> Tree);
        delegate void AscendingBinaryTree(BinaryTree<int> Tree);
        delegate void DescendingBinaryTree(BinaryTree<int> Tree);
        static void Main(string[] args)
        {
            int NodesQuantity = 10; 
            int MaximumValue = 100; 
            Random Randomizer = new Random();

            BinaryTree<int> Tree = new BinaryTree<int>(Randomizer.Next(MaximumValue), null);
            for (int NodeIndex = 0; NodeIndex < NodesQuantity - 1; ++NodeIndex)
            {
                Tree.Add(Randomizer.Next(MaximumValue));
            }

            InOrderTraversal ListerLambda = (LambdaTree) =>
            {
                List<int> NodesList = new List<int>();
                foreach (int Node in LambdaTree)
                {
                    NodesList.Add(Node);
                }
                return NodesList;
            };

            AscendingBinaryTree AscendingOrder = (LambdaTree) =>
            {
                List<int> NodesList = ListerLambda(LambdaTree);
                NodesList.Sort();
                for (int NodeIndex = 0; NodeIndex <= NodesQuantity - 1; ++NodeIndex)
                {
                    Console.WriteLine(NodesList[NodeIndex]);
                }
            };

            DescendingBinaryTree DescendingOrder = (LambdaTree) =>
            {
                List<int> NodesList = ListerLambda(LambdaTree);
                NodesList.Sort();
                NodesList.Reverse();
                for (int NodeIndex = 0; NodeIndex <= NodesQuantity - 1; ++NodeIndex)
                {
                    Console.WriteLine(NodesList[NodeIndex]);
                }
            };

            Console.WriteLine("Вершины дерева в порядке убывания:");
            DescendingOrder(Tree);
            Console.WriteLine("Вершины дерева в порядке возрастания:");
            AscendingOrder(Tree);
            Console.WriteLine();
            Console.ReadKey();
        }
    }
}
