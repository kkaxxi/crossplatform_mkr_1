using System;
using System.Collections.Generic;
using Xunit;
using Mkr_1.Mkr_1; 

namespace Mkr_1.Mkr_1.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void Test_LosingPairsForK0()
        {
            var result = Program.GenerateLosingPairs(0);
            Assert.Equal((0, 0), result[0]);
            Console.WriteLine($"Test_LosingPairsForK0: Expected (0, 0), got {result[0]}");
        }

        [Fact]
        public void Test_LosingPairsForK1()
        {
            var result = Program.GenerateLosingPairs(1);
            Assert.Equal((1, 2), result[1]);
            Console.WriteLine($"Test_LosingPairsForK1: Expected (1, 2), got {result[1]}");
        }

        [Fact]
        public void Test_LosingPairsForKRandom()
        {
            int randomK = new Random().Next(5, 15);
            var result = Program.GenerateLosingPairs(randomK);
            double phi = (1 + Math.Sqrt(5)) / 2;
            int expectedA = (int)(randomK * phi);
            int expectedB = expectedA + randomK;

            Assert.Equal((expectedA, expectedB), result[randomK]);
            Console.WriteLine($"Test_LosingPairsForKRandom: For k={randomK}, expected ({expectedA}, {expectedB}), got {result[randomK]}");
        }

        [Fact]
        public void Test_LosingPairsForBoundaryValues()
        {
            int maxK = 1000;
            var result = Program.GenerateLosingPairs(maxK);
            Assert.Equal(1001, result.Count);
            Console.WriteLine($"Test_LosingPairsForBoundaryValues: Total pairs generated for maxK={maxK} is {result.Count}");

            // Проверка первого и последнего значения
            Assert.Equal((0, 0), result[0]);
            Console.WriteLine($"Boundary check - First pair: Expected (0, 0), got {result[0]}");

            double phi = (1 + Math.Sqrt(5)) / 2;
            int expectedA = (int)(maxK * phi);
            int expectedB = expectedA + maxK;
            Assert.Equal((expectedA, expectedB), result[maxK]);
            Console.WriteLine($"Boundary check - Last pair: Expected ({expectedA}, {expectedB}), got {result[maxK]}");
        }

        [Fact]
        public void Test_LosingPairsForLargeK()
        {
            int maxK = 10000;
            var result = Program.GenerateLosingPairs(maxK);
            
            // Переконуємося, що було згенеровано рівно maxK + 1 пар
            Assert.Equal(maxK + 1, result.Count);
            
            // Перевірка останньої пари
            double phi = (1 + Math.Sqrt(5)) / 2;
            int expectedA = (int)(maxK * phi);
            int expectedB = expectedA + maxK;
            Assert.Equal((expectedA, expectedB), result[maxK]);

            Console.WriteLine($"Test_LosingPairsForLargeK: For maxK={maxK}, expected last pair ({expectedA}, {expectedB}), got {result[maxK]}");
        }


        [Fact]
        public void Test_LosingPairsConsistency()
        {
            int maxK = 20;
            var result = Program.GenerateLosingPairs(maxK);
            double phi = (1 + Math.Sqrt(5)) / 2;

            for (int k = 0; k <= maxK; k++)
            {
                int expectedA = (int)(k * phi);
                int expectedB = expectedA + k;
                var actualPair = result[k];
                Assert.Equal((expectedA, expectedB), actualPair);
                Console.WriteLine($"Test_LosingPairsConsistency: For k={k}, expected ({expectedA}, {expectedB}), got {actualPair}");
            }
        }
    }
}
