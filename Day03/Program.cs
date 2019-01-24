using AocHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day03
{
    class Program
    {
        static int GetPossibleTrianglesByLine(List<string> input)
        {
            int possible = 0;

            foreach(string line in input)
            {
                string[] triangleSides = line.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                int a = int.Parse(triangleSides[0]);
                int b = int.Parse(triangleSides[1]);
                int c = int.Parse(triangleSides[2]);

                if ((a + b) > c)
                {
                    if ((a + c) > b)
                    {
                        if ((b + c) > a)
                        {
                            possible++;
                        }
                    }
                }
            }

            return possible;
        }

        static int GetPossibleTrianglesByColumn(List<string> input)
        {
            int possible = 0;
            List<int[]> triangleData = new List<int[]>();

            foreach (string line in input)
            {
                string[] triangleSides = line.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                int[] l = new int[3];
                l[0] = int.Parse(triangleSides[0]);
                l[1] = int.Parse(triangleSides[1]);
                l[2] = int.Parse(triangleSides[2]);
                triangleData.Add(l);
            }

            int z = 0;
            int[] triangle = new int[3];
            for (int x = 0; x < 3; x++)
            {
                for (int y = 0; y < triangleData.Count; y++)
                {
                    triangle[z++] = triangleData[y][x];
                    if (z == 3)
                    {
                        if ((triangle[0] + triangle[1]) > triangle[2])
                        {
                            if ((triangle[0] + triangle[2]) > triangle[1])
                            {
                                if ((triangle[1] + triangle[2]) > triangle[0])
                                {
                                    possible++;
                                }
                            }
                        }
                        z = 0;
                    }
                }
            }

            return possible;
        }

        static void Main(string[] args)
        {
            List<string> input = InputLoader.LoadByLines("input.txt");
            Console.WriteLine("Possible triangles: {0}", GetPossibleTrianglesByLine(input));
            Console.WriteLine("Possible triangles other order: {0}", GetPossibleTrianglesByColumn(input));
            Console.ReadLine();
        }
    }
}
