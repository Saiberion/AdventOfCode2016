using AocHelpers;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day22
{
    class StorageNode
    {
        public int Size { get; set; }
        public int Used { get; set; }
        public int Avail { get; set; }
        public Point Coords { get; set; }
    }

    class Program
    {
        static List<StorageNode> BuildGrid(List<string> input)
        {
            List<StorageNode> grid = new List<StorageNode>();

            foreach (string line in input)
            {
                if (line.StartsWith("/"))
                {
                    string[] splitted = line.Split(new char[] { ' ', '-', 'x', 'y', '/', 'T' }, StringSplitOptions.RemoveEmptyEntries);
                    StorageNode node = new StorageNode
                    {
                        Coords = new Point(int.Parse(splitted[3]), int.Parse(splitted[4])),
                        Size = int.Parse(splitted[5]),
                        Used = int.Parse(splitted[6]),
                        Avail = int.Parse(splitted[7])
                    };
                    grid.Add(node);
                }
            }

            return grid;
        }

        static int CountViable(StorageNode a, StorageNode b)
        {
            int res = 0;

            if (a.Used > 0)
            {
                if (a.Used < b.Avail)
                {
                    res++;
                }
            }

            if (b.Used > 0)
            {
                if (b.Used < a.Avail)
                {
                    res++;
                }
            }

            return res;
        }

        static int ViablePairs(List<string> input)
        {
            int viable = 0;
            List<StorageNode> grid = BuildGrid(input);

            for(int i = 0; i < grid.Count - 1; i++)
            {
                for(int j = i + 1; j < grid.Count; j++)
                {
                    viable += CountViable(grid[i], grid[j]);
                }
            }

            return viable;
        }

        static int DataRetrieval(List<string> input)
        {
            List<StorageNode> grid = BuildGrid(input);
            int x_size = int.MinValue, y_size = int.MinValue;

            foreach (StorageNode n in grid)
            {
                if (n.Coords.X > x_size)
                {
                    x_size = n.Coords.X;
                }
                if (n.Coords.Y > y_size)
                {
                    y_size = n.Coords.Y;
                }

            }
            StorageNode[,] nodes = new StorageNode[x_size + 1, y_size + 1];
            foreach (StorageNode n in grid)
            {
                nodes[n.Coords.X, n.Coords.Y] = n;
            }

            StorageNode wStart = null, hole = null;

            for (int y = 0; y < nodes.GetLength(1); y++)
            {
                for (int x = 0; x < nodes.GetLength(0); x++)
                {
                    StorageNode n = nodes[x, y];
                    if (x == 0 && y == 0)
                    {
                        Console.Write("S");
                    }
                    else if (x == x_size && y == 0)
                    {
                        Console.Write("G");
                    }
                    else if (n.Used == 0)
                    {
                        hole = n;
                        Console.Write("_");
                    }
                    else if (n.Size > 250)
                    {
                        if (wStart == null)
                        {
                            wStart = nodes[x - 1, y];
                        }
                        Console.Write("#");
                    }
                    else
                    {
                        Console.Write(".");
                    }
                }
                Console.WriteLine();
            }

            int result = Math.Abs(hole.Coords.X - wStart.Coords.X) + Math.Abs(hole.Coords.Y - wStart.Coords.Y);
            result += Math.Abs(wStart.Coords.X - x_size) + wStart.Coords.Y;
            return result + 5 * (x_size - 1);
        }

        static void Main(string[] args)
        {
            List<string> input = InputLoader.LoadByLines("input.txt");
            Console.WriteLine("Viable pairs: {0}", ViablePairs(input));
            Console.WriteLine("Moves to get data: {0}", DataRetrieval(input));
            Console.ReadLine();
        }
    }
}
