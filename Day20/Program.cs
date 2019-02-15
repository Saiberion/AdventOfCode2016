using AocHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day20
{
    class Program
    {
        static Tuple<long,long> MinimumFreeIP(List<string> input)
        {
            long validIPs = 0;
            long minResult = -1;
            List<long[]> ranges = new List<long[]>();
            foreach(string s in input)
            {
                string[] splitted = s.Split(new char[] { '-' }, StringSplitOptions.RemoveEmptyEntries);
                ranges.Add(new long[] { long.Parse(splitted[0]), long.Parse(splitted[1]) });
            }

            long minAllowed = uint.MaxValue;

            long minimumBlocked = uint.MaxValue;
            long[] minRange = null;
            foreach (long[] arr in ranges)
            {
                if (minimumBlocked > arr[0])
                {
                    minimumBlocked = arr[0];
                    minRange = arr;
                }
            }

            if (minRange[0] > 0)
            {
                return new Tuple<long, long>(0, 0);
            }
            else
            {
                minAllowed = minRange[1] + 1;
                ranges.Remove(minRange);
            }

            do
            {
                minimumBlocked = uint.MaxValue;
                foreach (long[] arr in ranges)
                {
                    if (minimumBlocked > arr[0])
                    {
                        minimumBlocked = arr[0];
                        minRange = arr;
                    }
                }
                if ((minRange[0] < minAllowed) && (minRange[1] < minAllowed))
                {
                    // ignore, this range is already dead
                    ranges.Remove(minRange);
                }
                else if ((minRange[0] > minAllowed) && (minRange[1] > minAllowed))
                {
                    // no range is starting earlier, result found
                    // could get used for Part 2 counting
                    validIPs += minRange[0] - minAllowed;
                    if (minResult == -1)
                    {
                        minResult = minAllowed;
                    }
                    minAllowed = minRange[1] + 1;
                    ranges.Remove(minRange);
                }
                else
                {
                    // overlapping region
                    minAllowed = minRange[1] + 1;
                    ranges.Remove(minRange);
                }
            } while (ranges.Count > 0);

            return new Tuple<long, long>(minResult, validIPs);
        }

        static void Main(string[] args)
        {
            List<string> input = InputLoader.LoadByLines("input.txt");
            Console.WriteLine("Dragon checksum disc 1: {0}", MinimumFreeIP(input));
            Console.ReadLine();
        }
    }
}
