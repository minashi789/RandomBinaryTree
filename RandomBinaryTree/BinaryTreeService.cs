using System;
using System.Collections.Generic;
using System.Linq;

namespace RandomBinaryTree
{
    public class BinaryTreeService : IBinaryTreeService
    {
        private Node _root;
        private readonly Random _random;

        public BinaryTreeService(int seed)
        {
            _random = new Random(seed);
        }

        public void Insert(int data)
        {
            _root = InsertRecursive(_root, data);
        }

        private Node InsertRecursive(Node node, int data)
        {
            if (node == null)
            {
                return new Node(data);
            }

            if (data < node.Data)
            {
                node.Left = InsertRecursive(node.Left, data);
            }
            else
            {
                node.Right = InsertRecursive(node.Right, data);
            }

            return node;
        }

        public bool Search(int data)
        {
            return SearchRecursive(_root, data);
        }

        private bool SearchRecursive(Node node, int data)
        {
            if (node == null)
            {
                return false;
            }

            if (node.Data == data)
            {
                return true;
            }

            return data < node.Data ? SearchRecursive(node.Left, data) : SearchRecursive(node.Right, data);
        }


        public void Print()
        {
            Console.WriteLine("Бинарное дерево:");
            PrintRecursive(_root);
            Console.WriteLine();
        }

        private void PrintRecursive(Node node, string indent = "", bool isLast = true)
        {
            if (node == null)
            {
                return;
            }

            Console.Write(indent);

            if (isLast)
            {
                Console.Write("└─");
                indent += "  "; // Два пробела для лучшей визуализации
            }
            else
            {
                Console.Write("├─");
                indent += "| "; // Вертикальная черта и пробел
            }

            Console.WriteLine(node.Data);

            PrintRecursive(node.Left, indent, false);
            PrintRecursive(node.Right, indent, true);
        }


        public static BinaryTreeService GenerateRandomTree(int seed, double mean, double stdDev, int count)
        {
            var tree = new BinaryTreeService(seed);
            var random = new Random(seed);

            var elements = Enumerable.Range(0, count)
                .Select(_ => (int)Math.Round(GenerateNormalDistribution(random, mean, stdDev)))
                .ToList();

            foreach (var element in elements)
            {
                tree.Insert(element);
            }

            return tree;
        }

        private static double GenerateNormalDistribution(Random random, double mean, double stdDev)
        {
            double u1 = 1.0 - random.NextDouble();
            double u2 = 1.0 - random.NextDouble();
            double randStdNormal = Math.Sqrt(-2.0 * Math.Log(u1)) * Math.Sin(2.0 * Math.PI * u2);
            return mean + stdDev * randStdNormal;
        }
    }
}