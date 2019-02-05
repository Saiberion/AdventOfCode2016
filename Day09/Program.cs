using AocHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day09
{
    class Program
    {
        static Int64 DecompressV1(string input)
        {
            int decompressedLength = 0;
            StringBuilder marker = new StringBuilder();
            int scanMode = 0;
            int charsToRead = 1, repetitions = 0;

            for (int i = 0; i < input.Length; i++)
            {
                switch(scanMode)
                {
                    case 0: // Text
                        if (input[i] == '(')
                        {
                            scanMode = 1;
                            marker.Clear();
                        }
                        else
                        {
                            decompressedLength++;
                        }
                        break;
                    case 1: // Read marker number of characters
                        if (input[i] == 'x')
                        {
                            scanMode = 2;
                            charsToRead = int.Parse(marker.ToString());
                            marker.Clear();
                        }
                        else
                        {
                            marker.Append(input[i]);
                        }
                        break;
                    case 2: // Read marker number of repetitions
                        if (input[i] == ')')
                        {
                            scanMode = 3;
                            repetitions = int.Parse(marker.ToString());
                            marker.Clear();
                        }
                        else
                        {
                            marker.Append(input[i]);
                        }
                        break;
                    case 3: // read repetition characters
                        marker.Append(input[i]);
                        if (--charsToRead == 0)
                        {
                            for (int j = 0; j < repetitions; j++)
                            {
                                decompressedLength += marker.Length;
                                scanMode = 0;
                            }
                        }
                        break;
                }
            }

            return decompressedLength;
        }

        static Int64 DecompressV2(string input)
        {
            Int64 decompressedLength = 0;
            StringBuilder marker = new StringBuilder();
            int scanMode = 0;
            int charsToRead = 1, repetitions = 0;

            for (int i = 0; i < input.Length; i++)
            {
                switch (scanMode)
                {
                    case 0: // Text
                        if (input[i] == '(')
                        {
                            scanMode = 1;
                            marker.Clear();
                        }
                        else
                        {
                            decompressedLength++;
                        }
                        break;
                    case 1: // Read marker number of characters
                        if (input[i] == 'x')
                        {
                            scanMode = 2;
                            charsToRead = int.Parse(marker.ToString());
                            marker.Clear();
                        }
                        else
                        {
                            marker.Append(input[i]);
                        }
                        break;
                    case 2: // Read marker number of repetitions
                        if (input[i] == ')')
                        {
                            scanMode = 3;
                            repetitions = int.Parse(marker.ToString());
                            marker.Clear();
                        }
                        else
                        {
                            marker.Append(input[i]);
                        }
                        break;
                    case 3: // read repetition characters
                        marker.Append(input[i]);
                        if (--charsToRead == 0)
                        {
                            if (marker.ToString().Contains("("))
                            {
                                decompressedLength += repetitions * DecompressV2(marker.ToString());
                            }
                            else
                            {
                                decompressedLength += repetitions * marker.Length;
                            }
                            scanMode = 0;
                        }
                        break;
                }
            }

            return decompressedLength;
        }

        static void Main(string[] args)
        {
            List<string> input = InputLoader.LoadByLines("input.txt");
            Console.WriteLine("Decompressed Length V1: {0}", DecompressV1(input[0]));
            Console.WriteLine("Decompressed Length V2: {0}", DecompressV2(input[0]));
            Console.ReadLine();
        }
    }
}
