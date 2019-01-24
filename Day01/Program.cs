using AocHelpers;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day01
{
    class Program
    {
        static Point[] FollowDirections(List<string> input)
        {
            HashSet<Point> visitedCoords = new HashSet<Point>();
            Point[] c = new Point[2];
            c[0] = new Point();
            c[1] = new Point();
            int facing = 0;
            bool c1Set = false;

            visitedCoords.Add(new Point(0, 0));

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

                while (steps-- > 0)
                {
                    switch (facing)
                    {
                        case 0:
                            c[0].Y++;
                            break;
                        case 1:
                            c[0].X++;
                            break;
                        case 2:
                            c[0].Y--;
                            break;
                        case 3:
                            c[0].X--;
                            break;
                    }
                    if (!c1Set)
                    {
                        if (!visitedCoords.Add(c[0]))
                        {
                            c[1].X = c[0].X;
                            c[1].Y = c[0].Y;
                            c1Set = true;
                        }
                    }
                }
            }

            return c;
        }

        /*static Coordinates FollowDirections2(string input)
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

                while (steps-- > 0)
                {
                    switch (facing)
                    {
                        case 0:
                            c.Y++;
                            break;
                        case 1:
                            c.X++;
                            if (grid.ContainsKey(c.X))
                            {
                                
                            }
                            else
                            {
                                grid.Add(c.X, new Dictionary<int, int>());
                                grid[c.X].Add(c.Y, 0);
                            }
                            break;
                        case 2:
                            c.Y--;
                            break;
                        case 3:
                            c.X--;
                            break;
                    }
                }
            }

            return c;
        }*/

        static void Main(string[] args)
        {
            List<string> input = InputLoader.LoadByLines("input.txt");
            Point[] c = FollowDirections(input);
            Console.WriteLine("Blocks until destination: {0}", Math.Abs(c[0].X) + Math.Abs(c[0].Y));
            Console.WriteLine("Blocks until real destination: {0}", Math.Abs(c[1].X) + Math.Abs(c[1].Y));
            Console.ReadLine();
        }
    }
}
