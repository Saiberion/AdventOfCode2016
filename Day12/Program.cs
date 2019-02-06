using AocHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day12
{
    class Program
    {
        static int ExecuteInstructions(List<string> input, int initA, int initB, int initC, int initD)
        {
            Dictionary<char, int> registers = new Dictionary<char, int>
            {
                { 'a', initA },
                { 'b', initB },
                { 'c', initC },
                { 'd', initD }
            };

            for (int i = 0; i < input.Count;)
            {
                string[] splitted = input[i].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                switch (splitted[0])
                {
                    case "cpy":
                        if (int.TryParse(splitted[1], out int val))
                        {
                            registers[splitted[2][0]] = val;
                        }
                        else
                        {
                            registers[splitted[2][0]] = registers[splitted[1][0]];
                        }
                        i++;
                        break;
                    case "inc":
                        registers[splitted[1][0]]++;
                        i++;
                        break;
                    case "dec":
                        registers[splitted[1][0]]--;
                        i++;
                        break;
                    case "jnz":
                        if (int.TryParse(splitted[1], out int cond))
                        {
                            if (cond != 0)
                            {
                                i += int.Parse(splitted[2]);
                            }
                            else
                            {
                                i++;
                            }
                        }
                        else
                        {
                            if (registers[splitted[1][0]] != 0)
                            {
                                i += int.Parse(splitted[2]);
                            }
                            else
                            {
                                i++;
                            }
                        }
                        break;
                }
            }

            return registers['a'];
        }

        static void Main(string[] args)
        {
            List<string> input = InputLoader.LoadByLines("input.txt");
            Console.WriteLine("Value of Register a(0,0,0,0): {0}", ExecuteInstructions(input, 0, 0, 0, 0));
            Console.WriteLine("Value of Register a(0,0,1,0): {0}", ExecuteInstructions(input, 0, 0, 1, 0));
            Console.ReadLine();
        }
    }
}
