using System;

namespace RandomBinaryTree
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите параметры генератора случайных чисел:");

            int seed = GetValidIntInput("Seed: ");
            double mean = GetValidDoubleInput("Среднее значение: ");
            double stdDev = GetValidDoubleInput("Стандартное отклонение: ");

            // Создаем сервис, передавая seed в конструктор
            IBinaryTreeService treeService = BinaryTreeService.GenerateRandomTree(seed, mean, stdDev, 12);

            treeService.Print(); // Используем методы интерфейса

            int searchElement = GetValidIntInput("Введите элемент для поиска: ");

            bool isFound = treeService.Search(searchElement); // Используем методы интерфейса

            Console.WriteLine(isFound
                ? $"Элемент {searchElement} найден в дереве."
                : $"Элемент {searchElement} не найден в дереве.");

            Console.WriteLine("Нажмите любую клавишу для выхода...");
            Console.ReadKey();
        }

        // Функции для валидации ввода
        static int GetValidIntInput(string prompt)
        {
            while (true)
            {
                Console.Write(prompt);
                if (int.TryParse(Console.ReadLine(), out int value))
                {
                    return value;
                }

                Console.WriteLine("Некорректный ввод. Попробуйте снова:");
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

                Console.WriteLine("Некорректный ввод. Попробуйте снова:");
            }
        }
    }
}