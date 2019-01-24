using AocHelpers;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day02
{
    class Program
    {
        static string KeypadNormal(List<string> input)
        {
            StringBuilder sb = new StringBuilder();
            Point p = new Point(1, 1);
            foreach (string line in input)
            {
                foreach(char c in line)
                {
                    switch(c)
                    {
                        case 'U':
                            if (p.Y > 0)
                            {
                                p.Y--;
                            }
                            break;
                        case 'D':
                            if (p.Y < 2)
                            {
                                p.Y++;
                            }
                            break;
                        case 'L':
                            if (p.X > 0)
                            {
                                p.X--;
                            }
                            break;
                        case 'R':
                            if (p.X < 2)
                            {
                                p.X++;
                            }
                            break;
                    }
                }
                int key = p.X + 1 + p.Y * 3;
                sb.Append(key);
            }
            return sb.ToString();
        }

        static string KeypadSpecial(List<string> input)
        {
            Dictionary<Point, char> keypad = new Dictionary<Point, char>();

            keypad.Add(new Point(0, 0), 'X');
            keypad.Add(new Point(1, 0), 'X');
            keypad.Add(new Point(2, 0), '1');
            keypad.Add(new Point(3, 0), 'X');
            keypad.Add(new Point(4, 0), 'X');

            keypad.Add(new Point(0, 1), 'X');
            keypad.Add(new Point(1, 1), '2');
            keypad.Add(new Point(2, 1), '3');
            keypad.Add(new Point(3, 1), '4');
            keypad.Add(new Point(4, 1), 'X');

            keypad.Add(new Point(0, 2), '5');
            keypad.Add(new Point(1, 2), '6');
            keypad.Add(new Point(2, 2), '7');
            keypad.Add(new Point(3, 2), '8');
            keypad.Add(new Point(4, 2), '9');

            keypad.Add(new Point(0, 3), 'X');
            keypad.Add(new Point(1, 3), 'A');
            keypad.Add(new Point(2, 3), 'B');
            keypad.Add(new Point(3, 3), 'C');
            keypad.Add(new Point(4, 3), 'X');

            keypad.Add(new Point(0, 4), 'X');
            keypad.Add(new Point(1, 4), 'X');
            keypad.Add(new Point(2, 4), 'D');
            keypad.Add(new Point(3, 4), 'X');
            keypad.Add(new Point(4, 4), 'X');

            Point p = new Point(0, 2);

            StringBuilder sb = new StringBuilder();
            
            foreach (string line in input)
            {
                foreach (char c in line)
                {
                    switch (c)
                    {
                        case 'U':
                            if (p.Y > 0)
                            {
                                p.Y--;
                                if (keypad[p] == 'X')
                                {
                                    p.Y++;
                                }
                            }
                            break;
                        case 'D':
                            if (p.Y < 4)
                            {
                                p.Y++;
                                if (keypad[p] == 'X')
                                {
                                    p.Y--;
                                }
                            }
                            break;
                        case 'L':
                            if (p.X > 0)
                            {
                                p.X--;
                                if (keypad[p] == 'X')
                                {
                                    p.X++;
                                }
                            }
                            break;
                        case 'R':
                            if (p.X < 4)
                            {
                                p.X++;
                                if (keypad[p] == 'X')
                                {
                                    p.X--;
                                }
                            }
                            break;
                    }
                }
                
                sb.Append(keypad[p]);
            }
            return sb.ToString();
        }

        static void Main(string[] args)
        {
            List<string> input = InputLoader.LoadByLines("input.txt");
            Console.WriteLine("Bathroom Code on normal keypad: {0}", KeypadNormal(input));
            Console.WriteLine("Bathroom Code on special keypad: {0}", KeypadSpecial(input));
            Console.ReadLine();
        }
    }
}
