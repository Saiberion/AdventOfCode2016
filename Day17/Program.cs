using AocHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day17
{
    class Location
    {
        public int X;
        public int Y;
        public string Movement;
    }

    class Program
    {
        static List<Location> GetWalkableAdjacentSquares(int x, int y, string input, string movement)
        {
            MD5Managed md5 = new MD5Managed();
            byte[] hash = md5.ComputeHash(Encoding.ASCII.GetBytes(input + movement));

            List<Location> possibleLocations = new List<Location>();

            if ((((hash[0] >> 4) & 0xf) > 10) && (y > 0))
            {
                possibleLocations.Add(new Location { X = x, Y = y - 1, Movement = movement + "U" });
            }
            if (((hash[0] & 0xf) > 10) && (y < 3))
            {
                possibleLocations.Add(new Location { X = x, Y = y + 1, Movement = movement + "D" });
            }
            if ((((hash[1] >> 4) & 0xf) > 10) && (x > 0))
            {
                possibleLocations.Add(new Location { X = x - 1, Y = y, Movement = movement + "L" });
            }
            if (((hash[1] & 0xf) > 10) && (x < 3))
            {
                possibleLocations.Add(new Location { X = x + 1, Y = y, Movement = movement + "R" });
            }

            return possibleLocations;
        }

        static Tuple<string,int> MazeRunner(string passcode)
        {
            Location current = null;
            Location start = new Location { X = 0, Y = 0 };
            Location target = new Location { X = 3, Y = 3 };
            List<Location> openList = new List<Location>
            {
                // add the starting position to the open list
                start
            };
            List<Location> targetList = new List<Location>();

            while (openList.Count > 0)
            {
                // get the square with the lowest F score from openList
                current = openList[0];

                // remove it from the open list
                openList.Remove(current);

                if ((current.X == target.X) && (current.Y == target.Y))
                {
                    // store result
                    targetList.Add(current);
                    continue;
                }

                List<Location> adjacentSquares = GetWalkableAdjacentSquares(current.X, current.Y, passcode, current.Movement);

                foreach (Location adjacentSquare in adjacentSquares)
                {
                    openList.Add(adjacentSquare);
                }
            }

            string shortest = null;
            int mostSteps = int.MinValue;
            foreach (Location l in targetList)
            {
                if ((shortest == null) || (l.Movement.Length < shortest.Length))
                {
                    shortest = l.Movement;
                }
                if (l.Movement.Length > mostSteps)
                {
                    mostSteps = l.Movement.Length;
                }
            }

            return new Tuple<string, int>(shortest, mostSteps);
        }

        static void Main(string[] args)
        {
            List<string> input = InputLoader.LoadByLines("input.txt");
            Console.WriteLine("Shortest path: {0}", MazeRunner(input[0]));
            Console.ReadLine();
        }
    }
}
