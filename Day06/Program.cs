using AocHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day06
{
    class Program
    {
        static string RepetitionCorrection(List<string> input)
        {
            StringBuilder sbP1 = new StringBuilder();
            StringBuilder sbP2 = new StringBuilder();

            Dictionary<char, int>[] charCountingByPosition = new Dictionary<char, int>[input[0].Length];

            for (int i = 0; i < input[0].Length; i++)
            {
                charCountingByPosition[i] = new Dictionary<char, int>();
            }

            foreach(string s in input)
            {
                for(int i = 0; i < s.Length; i++)
                {
                    if (charCountingByPosition[i].ContainsKey(s[i]))
                    {
                        charCountingByPosition[i][s[i]]++;
                    }
                    else
                    {
                        charCountingByPosition[i].Add(s[i], 1);
                    }
                }
            }

            for(int i = 0; i < charCountingByPosition.Length; i++)
            {
                int max = int.MinValue;
                int min = int.MaxValue;
                char c1 = char.MinValue;
                char c2 = char.MinValue;
                foreach (KeyValuePair<char, int> kvp in charCountingByPosition[i])
                {
                    if (kvp.Value > max)
                    {
                        c1 = kvp.Key;
                        max = kvp.Value;
                    }

                    if (kvp.Value < min)
                    {
                        c2 = kvp.Key;
                        min = kvp.Value;
                    }
                }
                sbP1.Append(c1);
                sbP2.Append(c2);
            }

            sbP1.Append(" - ");
            sbP1.Append(sbP2);
            return sbP1.ToString();
        }

        static void Main(string[] args)
        {
            List<string> input = InputLoader.LoadByLines("input.txt");
            Console.WriteLine("corrected message: {0}", RepetitionCorrection(input));
            Console.ReadLine();
        }
    }
}
