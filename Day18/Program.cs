using AocHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day18
{
    class Program
    {
        static int TrapRoom(List<string> input, int rows)
        {
            int safeTiles = 0;

            foreach (char c in input[input.Count - 1])
            {
                if (c == '.')
                {
                    safeTiles++;
                }
            }
            while (input.Count < rows)
            {
                StringBuilder sb = new StringBuilder();

                for (int i = 0; i < input[input.Count - 1].Length; i++)
                {
                    bool left, center, right;
                    if (i == 0)
                    {
                        left = false;
                    }
                    else
                    {
                        left = input[input.Count - 1][i - 1] == '^';
                    }
                    center = input[input.Count - 1][i] == '^';
                    if (i == (input[input.Count - 1].Length - 1))
                    {
                        right = false;
                    }
                    else
                    {
                        right = input[input.Count - 1][i + 1] == '^';
                    }

                    if ((!left && !center && right)
                        || (!left && center && right)
                        || (left && !center && !right)
                        || (left && center && !right))
                    {
                        sb.Append("^");
                    }
                    else
                    {
                        sb.Append(".");
                        safeTiles++;
                    }
                }
                input.Add(sb.ToString());
            }

            return safeTiles;
        }

        static void Main(string[] args)
        {
            List<string> input = InputLoader.LoadByLines("input.txt");
            Console.WriteLine("Safe tiles: {0}", TrapRoom(input, 40));
            input = InputLoader.LoadByLines("input.txt");
            Console.WriteLine("Safe tiles: {0}", TrapRoom(input, 400000));
            Console.ReadLine();
        }
    }
}
