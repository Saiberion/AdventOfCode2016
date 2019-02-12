using AocHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day15
{
    class Disc
    {
        public int Positions { get; internal set; }
        public int CurrentPosition { get; internal set; }

        public Disc(int positions, int startingPosition)
        {
            this.Positions = positions;
            this.CurrentPosition = startingPosition;
        }

        public int GetPositionAt(int time)
        {
            return (time + this.CurrentPosition) % this.Positions;
        }
    }

    class Program
    {
        static int DiscMazePassThrough(List<string> input, bool second)
        {
            List<Disc> discs = new List<Disc>();
            foreach (string line in input)
            {
                string[] splitted = line.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                discs.Add(new Disc(int.Parse(splitted[3]), int.Parse(splitted[11].Remove(1))));
            }
            if (second)
            {
                discs.Add(new Disc(11, 0));
            }

            int time = 0;
            while (true)
            {
                bool allDiscsAtPos0 = true;
                for(int i = 0; i < discs.Count; i++)
                {
                    if (discs[i].GetPositionAt(time + i + 1) != 0)
                    {
                        allDiscsAtPos0 = false;
                        break;
                    }
                }
                if (allDiscsAtPos0)
                {
                    break;
                }
                time++;
            }

            return time;
        }

        static void Main(string[] args)
        {
            List<string> input = InputLoader.LoadByLines("input.txt");
            Console.WriteLine("Get capsule at time: {0}", DiscMazePassThrough(input, false));
            Console.WriteLine("2nd try: Get capsule at time: {0}", DiscMazePassThrough(input, true));
            Console.ReadLine();
        }
    }
}
