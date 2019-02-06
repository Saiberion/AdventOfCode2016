using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day13
{
    class Program
    {
        static bool GetParity(int n)
        {
            bool parity = false;
            while (n != 0)
            {
                parity = !parity;
                n = n & (n - 1);
            }
            return parity;

        }

        static void Main(string[] args)
        {
            int input = 1352;
            bool[,] grid = new bool[50, 50];

            Console.SetWindowSize(grid.GetLength(0)+ 5, grid.GetLength(1) + 5);

            for (int y = 0; y < grid.GetLength(1); y++)
            {
                for(int x = 0; x < grid.GetLength(0); x++)
                {
                    grid[x, y] = GetParity(x * x + 3 * x + 2 * x * y + y + y * y + input);
                    if (((x == 1) && (y == 1)) || ((x == 31) && (y == 39)))
                    {
                        Console.Write("O");
                    }
                    else
                    {
                        Console.Write(grid[x, y] ? "#" : ".");
                    }
                }
                Console.WriteLine();
            }
            Console.ReadLine();
        }
    }
}
