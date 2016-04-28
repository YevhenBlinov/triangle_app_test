using System;
using System.Collections.Generic;
using System.IO;

namespace TriangleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please, enter path to the file");
            var path = Console.ReadLine();

            if (!File.Exists(path))
            {
                Console.WriteLine("File not found.");
                return;
            }

            var readText = File.ReadAllLines(path);

            if (readText.Length == 0)
            {
                Console.WriteLine("File is empty.");
                return;
            }

            var triangle = new List<List<int>>();
            var maxSum = 0;

            try
            {
                triangle = ReadTriangleFromFile(readText);
                var calculator = new MaximumSumCalculator(triangle);
                maxSum = calculator.Calculate();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                return;
            }

            Console.WriteLine("Maximum sum is {0}.", maxSum);
        }

        private static List<List<int>> ReadTriangleFromFile(string[] readText)
        {
            var triangle = new List<List<int>>();

            foreach (var line in readText)
            {
                var numbers = line.Split(' ');
                var tempList = new List<int>();

                foreach (var number in numbers)
                {
                    var temp = 0;

                    if (int.TryParse(number, out temp))
                    {
                        tempList.Add(temp);
                    }
                    else
                    {
                        throw new Exception("Data should contains only numbers.");
                    }
                }

                triangle.Add(tempList);
            }

            return triangle;
        }
    }
}
