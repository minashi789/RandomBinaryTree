using System;

namespace RandomBinaryTree
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("������� ��������� ���������� ��������� �����:");

            int seed = GetValidIntInput("Seed: ");
            double mean = GetValidDoubleInput("������� ��������: ");
            double stdDev = GetValidDoubleInput("����������� ����������: ");

            // ������� ������, ��������� seed � �����������
            IBinaryTreeService treeService = BinaryTreeService.GenerateRandomTree(seed, mean, stdDev, 12);

            treeService.Print(); // ���������� ������ ����������

            int searchElement = GetValidIntInput("������� ������� ��� ������: ");

            bool isFound = treeService.Search(searchElement); // ���������� ������ ����������

            Console.WriteLine(isFound
                ? $"������� {searchElement} ������ � ������."
                : $"������� {searchElement} �� ������ � ������.");

            Console.WriteLine("������� ����� ������� ��� ������...");
            Console.ReadKey();
        }

        // ������� ��� ��������� �����
        static int GetValidIntInput(string prompt)
        {
            while (true)
            {
                Console.Write(prompt);
                if (int.TryParse(Console.ReadLine(), out int value))
                {
                    return value;
                }

                Console.WriteLine("������������ ����. ���������� �����:");
            }
        }

        static double GetValidDoubleInput(string prompt)
        {
            while (true)
            {
                Console.Write(prompt);
                if (double.TryParse(Console.ReadLine(), out double value))
                {
                    return value;
                }

                Console.WriteLine("������������ ����. ���������� �����:");
            }
        }
    }
}