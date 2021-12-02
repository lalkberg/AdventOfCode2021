using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2021
{
    class Program
    {
        static string[] GetInput(int currentDay) => System.IO.File.ReadAllLines($@"C:\Users\Leo\source\repos\AdventOfCode2021\AdventOfCode2021\Data\day{currentDay}.txt");
        static string[] input;

        static void Main()
        {
            Day2();
        }

        static void Day1()
        {
            input = GetInput(1);

            int[] values = new int[input.Length];

            int comparison = int.MinValue;
            int increases = 0;

            for (int i = 0; i < input.Length; i++)
            {
                values[i] = int.Parse(input[i]);

                if (values[i] > comparison) increases++;

                comparison = values[i];
            }

            Console.WriteLine($"Number of increases: {increases}.");

            comparison = int.MinValue;
            increases = 0;

            for (int i = 0; i < values.Length - 2; i++)
            {
                int set = values[i] + values[i + 1] + values[i + 2];

                if (set > comparison) increases++;

                comparison = set;
            }

            Console.WriteLine($"Number of increases to number sets: {increases}.");
            Console.ReadKey();
        }

        static void Day2()
        {
            input = GetInput(2);

            int horizontal = 0;
            int depth = 0;

            for (int i = 0; i < input.Length; i++)
            {
                string[] splitString = input[i].Split(' ');

                int distance = int.Parse(splitString[1]);

                switch (splitString[0])
                {
                    case "forward":
                        horizontal += distance;
                        break;
                    case "down":
                        depth += distance;
                        break;
                    case "up":
                        depth -= distance;
                        break;
                    default:
                        break;
                }
            }

            int result = horizontal * depth;

            Console.WriteLine($"Result of part one: {result}.");

            horizontal = 0;
            depth = 0;

            int aim = 0;

            for (int i = 0; i < input.Length; i++)
            {
                string[] splitString = input[i].Split(' ');

                int distance = int.Parse(splitString[1]);

                switch (splitString[0])
                {
                    case "forward":
                        horizontal += distance;
                        if (aim != 0)
                        {
                            depth += aim * distance;
                        }
                        break;
                    case "down":
                        aim += distance;
                        break;
                    case "up":
                        aim -= distance;
                        break;
                    default:
                        break;
                }
            }

            result = horizontal * depth;

            Console.WriteLine($"Result of part two: {result}");
            Console.ReadKey();
        }

    }
}
