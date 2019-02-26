using AocHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day21
{
    class Program
    {
        static string Scramble(string pw, List<string> input)
        {
            StringBuilder result = new StringBuilder(pw);
            foreach(string instr in input)
            {
                string[] splitted = instr.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                switch(splitted[0])
                {
                    case "swap":
                        switch(splitted[1])
                        {
                            case "position":
                                char c = result[int.Parse(splitted[2])];
                                result[int.Parse(splitted[2])] = result[int.Parse(splitted[5])];
                                result[int.Parse(splitted[5])] = c;
                                break;
                            case "letter":
                                for (int i = 0; i < result.Length; i++)
                                {
                                    if (result[i] == splitted[2][0])
                                    {
                                        result[i] = splitted[5][0];
                                    }
                                    else if (result[i] == splitted[5][0])
                                    {
                                        result[i] = splitted[2][0];
                                    }
                                }
                                break;
                        }
                        break;
                    case "rotate":
                        switch(splitted[1])
                        {
                            case "left":
                                result = new StringBuilder(
                                    result.ToString().Substring(int.Parse(splitted[2])) +
                                    result.ToString().Substring(0, int.Parse(splitted[2]))
                                );
                                break;
                            case "right":
                                result = new StringBuilder(
                                    result.ToString().Substring(result.Length - int.Parse(splitted[2])) +
                                    result.ToString().Substring(0, result.Length - int.Parse(splitted[2]))
                                );
                                break;
                            case "based":
                                int steps = result.ToString().IndexOf(splitted[6][0]);
                                steps = steps + 1 + (steps >= 4 ? 1 : 0);
                                steps %= result.Length;
                                result = new StringBuilder(
                                    result.ToString().Substring(result.Length - steps) +
                                    result.ToString().Substring(0, result.Length - steps)
                                );
                                break;
                        }
                        break;
                    case "reverse":
                        StringBuilder tmp = new StringBuilder();
                        tmp.Append(result.ToString().Substring(0, int.Parse(splitted[2])));
                        char[] arr = result.ToString().Substring(int.Parse(splitted[2]), int.Parse(splitted[4]) - int.Parse(splitted[2]) + 1).ToCharArray();
                        Array.Reverse(arr);
                        tmp.Append(arr);
                        tmp.Append(result.ToString().Substring(int.Parse(splitted[4]) + 1));
                        result = tmp;
                        break;
                    case "move":
                        char c2 = result[int.Parse(splitted[2])];
                        result = result.Remove(int.Parse(splitted[2]), 1).Insert(int.Parse(splitted[5]), c2);
                        break;
                }
            }


            return result.ToString();
        }

        static string Unscramble(string pw, List<string> input)
        {
            StringBuilder result = new StringBuilder(pw);
            for (int i = input.Count - 1; i >= 0; i--)
            {
                string[] splitted = input[i].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                switch (splitted[0])
                {
                    case "swap":
                        switch (splitted[1])
                        {
                            case "position":
                                char c = result[int.Parse(splitted[2])];
                                result[int.Parse(splitted[2])] = result[int.Parse(splitted[5])];
                                result[int.Parse(splitted[5])] = c;
                                break;
                            case "letter":
                                for (int j = 0; j < result.Length; j++)
                                {
                                    if (result[j] == splitted[2][0])
                                    {
                                        result[j] = splitted[5][0];
                                    }
                                    else if (result[j] == splitted[5][0])
                                    {
                                        result[j] = splitted[2][0];
                                    }
                                }
                                break;
                        }
                        break;
                    case "rotate":
                        switch (splitted[1])
                        {
                            case "left":
                                result = new StringBuilder(
                                    result.ToString().Substring(result.Length - int.Parse(splitted[2])) +
                                    result.ToString().Substring(0, result.Length - int.Parse(splitted[2]))
                                );
                                break;
                            case "right":
                                result = new StringBuilder(
                                    result.ToString().Substring(int.Parse(splitted[2])) +
                                    result.ToString().Substring(0, int.Parse(splitted[2]))
                                );
                                break;
                            case "based":
                                // start index | shifts | end index
                                // ------------+--------+----------
                                //      0      |    1   |     1
                                //      1      |    2   |     3
                                //      2      |    3   |     5
                                //      3      |    4   |     7
                                //      4      |    6   |     2
                                //      5      |    7   |     4
                                //      6      |    8   |     6
                                //      7      |    9   |     0
                                int endindex = result.ToString().IndexOf(splitted[6][0]);
                                int shifts = 0;
                                switch (endindex)
                                {
                                    case 0:
                                        shifts = 1; // 9 % 8;
                                        break;
                                    case 1:
                                        shifts = 1;
                                        break;
                                    case 2:
                                        shifts = 6;
                                        break;
                                    case 3:
                                        shifts = 2;
                                        break;
                                    case 4:
                                        shifts = 7;
                                        break;
                                    case 5:
                                        shifts = 3;
                                        break;
                                    case 6:
                                        shifts = 0; // 8 % 8;
                                        break;
                                    case 7:
                                        shifts = 4;
                                        break;
                                }
                                result = new StringBuilder(
                                    result.ToString().Substring(shifts) +
                                    result.ToString().Substring(0, shifts)
                                );
                                break;
                        }
                        break;
                    case "reverse":
                        StringBuilder tmp = new StringBuilder();
                        tmp.Append(result.ToString().Substring(0, int.Parse(splitted[2])));
                        char[] arr = result.ToString().Substring(int.Parse(splitted[2]), int.Parse(splitted[4]) - int.Parse(splitted[2]) + 1).ToCharArray();
                        Array.Reverse(arr);
                        tmp.Append(arr);
                        tmp.Append(result.ToString().Substring(int.Parse(splitted[4]) + 1));
                        result = tmp;
                        break;
                    case "move":
                        char c2 = result[int.Parse(splitted[5])];
                        result = result.Remove(int.Parse(splitted[5]), 1).Insert(int.Parse(splitted[2]), c2);
                        break;
                }
            }

            return result.ToString();
        }

        static void Main(string[] args)
        {
            List<string> input = InputLoader.LoadByLines("input.txt");
            Console.WriteLine("Scrambled password: {0}", Scramble("abcdefgh", input));
            Console.WriteLine("Scrambled password: {0}", Unscramble("fbgdceah", input));
            Console.ReadLine();
        }
    }
}
