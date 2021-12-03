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
            Day3();
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

        static void Day3()
        {
            input = GetInput(3);

            int stringLength = input[0].Length;

            string gamma = string.Empty;
            string epsilon = string.Empty;

            for (int i = 0; i < stringLength; i++)
            {
                int zeroes = 0;
                int ones = 0;

                for (int j = 0; j < input.Length; j++)
                {
                    int thisDigit = int.Parse(input[j][i].ToString());

                    switch (thisDigit)
                    {
                        case 0:
                            zeroes++;
                            break;
                        case 1:
                            ones++;
                            break;
                        default:
                            break;
                    }
                }

                Console.WriteLine($"Total zeroes in row {i}: {zeroes}. Total ones in row {i}: {ones}.");

                if (zeroes > ones)
                {
                    gamma += '0';
                    epsilon += '1';
                }
                else
                {
                    gamma += '1';
                    epsilon += '0';
                }
            }

            Console.WriteLine($"Binary gamma rate: {gamma}. Binary epsilon rate: {epsilon}.");

            int gammaInt = Convert.ToInt32(gamma, 2);
            int epsilonInt = Convert.ToInt32(epsilon, 2);
            int result = gammaInt * epsilonInt;

            Console.WriteLine($"Gamma rate: {gammaInt}. Epsilon rate: {epsilonInt}.\nThe answer to Part 1 is {result}");

            // Part 2

            List<string> listToPrune = new List<string>(input);

            for (int i = 0; i < stringLength; i++)
            {
                if (listToPrune.Count == 1) break;

                int zeroes = 0;
                int ones = 0;
                int thisDigit = 0;

                for (int j = 0; j < listToPrune.Count; j++)
                {
                    if (listToPrune[j][i] == '0') zeroes++;
                    else ones++;
                }

                if (ones >= zeroes) thisDigit = 1;

                List<string> predicateList = new List<string>(listToPrune.Where(x => char.GetNumericValue(x[i]) == thisDigit));

                listToPrune = new List<string>(predicateList);
            }

            string oxygen = listToPrune[0];
            Console.WriteLine($"Binary oxygen generator rating: {oxygen}.");

            listToPrune = new List<string>(input);

            for (int i = 0; i < stringLength; i++)
            {
                if (listToPrune.Count == 1) break;

                int zeroes = 0;
                int ones = 0;
                int thisDigit = 0;

                for (int j = 0; j < listToPrune.Count; j++)
                {
                    if (listToPrune[j][i] == '0') zeroes++;
                    else ones++;
                }

                Console.WriteLine($"{i}: Ones = {ones}, Zeroes = {zeroes}.");

                if (ones < zeroes) thisDigit = 1;

                List<string> predicateList = new List<string>(listToPrune.Where(x => char.GetNumericValue(x[i]) == thisDigit));

                listToPrune = new List<string>(predicateList);
            }

            string co2 = listToPrune[0];
            Console.WriteLine($"Binary co2 scrubber rating: {co2}.");

            int oxygenInt = Convert.ToInt32(oxygen, 2);
            int co2Int = Convert.ToInt32(co2, 2);
            result = oxygenInt * co2Int;

            Console.WriteLine($"Oxygen generator rating: {oxygenInt}. CO2 scrubber rating: {co2Int}.\nThe answer to Part 2 is {result}");
            Console.ReadKey();
        }

    }
}
