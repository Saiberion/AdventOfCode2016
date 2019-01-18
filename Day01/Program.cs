using AocHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day01
{
    class Program
    {
        static Coordinates FollowDirections(List<string> input)
        {
            Coordinates c = new Coordinates();
            int facing = 0;

            string[] splitted = input[0].Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);

            foreach(string s in splitted)
            {
                switch(s[0])
                {
                    case 'R':
                        facing++;
                        break;
                    case 'L':
                        facing--;
                        break;
                }
                if (facing > 3)
                {
                    facing = 0;
                }
                if (facing < 0)
                {
                    facing = 3;
                }
                int steps = int.Parse(s.Remove(0, 1));

                switch(facing)
                {
                    case 0:
                        c.Y += steps;
                        break;
                    case 1:
                        c.X += steps;
                        break;
                    case 2:
                        c.Y -= steps;
                        break;
                    case 3:
                        c.X -= steps;
                        break;
                }
            }

            return c;
        }

        static Coordinates FollowDirections2(string input)
        {
            Coordinates c = new Coordinates();
            int facing = 0;

            string[] splitted = input.Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);

            Dictionary<int, Dictionary<int, int>> grid = new Dictionary<int, Dictionary<int, int>>();
            grid.Add(0, new Dictionary<int, int>());
            grid[0].Add(0, 0);

            foreach (string s in splitted)
            {
                switch (s[0])
                {
                    case 'R':
                        facing++;
                        break;
                    case 'L':
                        facing--;
                        break;
                }
                if (facing > 3)
                {
                    facing = 0;
                }
                if (facing < 0)
                {
                    facing = 3;
                }
                int steps = int.Parse(s.Remove(0, 1));

                switch (facing)
                {
                    case 0:
                        c.Y += steps;
                        break;
                    case 1:
                        c.X += steps;
                        break;
                    case 2:
                        c.Y -= steps;
                        break;
                    case 3:
                        c.X -= steps;
                        break;
                }
            }

            return c;
        }

        static void Main(string[] args)
        {
            List<string> input = InputLoader.LoadByLines("input.txt");
            Coordinates c = FollowDirections(input);
            Coordinates c2 = FollowDirections2(input[0]);
            Console.WriteLine("Blocks until destination: {0}", Math.Abs(c.X) + Math.Abs(c.Y));
            Console.WriteLine("Blocks until real destination: {0}", Math.Abs(c2.X) + Math.Abs(c2.Y));
            Console.ReadLine();
        }
    }
}
