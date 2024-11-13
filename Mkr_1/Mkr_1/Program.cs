using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace Mkr_1.Mkr_1
{
    public class Program
    {
        static void Main()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            // Задання шляху до файлів
            string inputFilePath = Path.Combine("Mkr_1", "Mkr_1", "INPUT.TXT");
            string outputFilePath = Path.Combine("Mkr_1", "Mkr_1", "OUTPUT.TXT");

            // Перевірка, чи існує вхідний файл
            if (!File.Exists(inputFilePath))
            {
                Console.WriteLine($"Помилка: Файл не знайдено за шляхом {inputFilePath}");
                return;
            }

            // Зчитування даних з файлу INPUT.TXT
            string[] inputLines;
            try
            {
                inputLines = File.ReadAllLines(inputFilePath);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Помилка при читанні файлу: {ex.Message}");
                return;
            }

            // Парсинг кількості тестів
            int n;
            if (!int.TryParse(inputLines[0], out n) || n < 1)
            {
                Console.WriteLine("Помилка: Некоректне значення кількості тестів у першому рядку.");
                return;
            }

            // Парсинг запитів
            List<int> queries = new List<int>();
            for (int i = 1; i <= n; i++)
            {
                if (int.TryParse(inputLines[i], out int query) && query >= 0)
                {
                    queries.Add(query);
                }
                else
                {
                    Console.WriteLine($"Помилка: Некоректне значення в рядку {i + 1} файлу INPUT.TXT.");
                    return;
                }
            }

            // Генерація програшних позицій
            List<(int, int)> losingPairs = GenerateLosingPairs(queries.Max());

            // Запис результату у OUTPUT.TXT
            try
            {
                using (StreamWriter writer = new StreamWriter(outputFilePath))
                {
                    foreach (int k in queries)
                    {
                        (int a, int b) = losingPairs[k];
                        writer.WriteLine($"{a} {b}");
                    }
                }
                Console.WriteLine($"Результати успішно записані у {outputFilePath}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Помилка при записі у файл OUTPUT.TXT: {ex.Message}");
            }
        }

        public static List<(int, int)> GenerateLosingPairs(int maxK)
        {
            if (maxK < 0)
                throw new ArgumentOutOfRangeException(nameof(maxK), "Значення не може бути від'ємним");

            List<(int, int)> losingPairs = new List<(int, int)>();
            double phi = (1 + Math.Sqrt(5)) / 2;

            for (int k = 0; k <= maxK; k++)
            {
                int a = (int)(k * phi);
                int b = a + k;
                losingPairs.Add((a, b));
            }

            return losingPairs;
        }
    }
}
