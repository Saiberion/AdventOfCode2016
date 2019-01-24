using AocHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Day05
{
    class Program
    {
        static string[] GeneratePassword(string input)
        {
            StringBuilder pwLeftRight = new StringBuilder();
            Dictionary<int, string> pwPosDetect = new Dictionary<int, string>();
            MD5 md5 = MD5.Create();

            int index = 0;
            while (pwPosDetect.Count < 8)
            {
                string toHash;
                toHash = input + index;
                byte[] hash = md5.ComputeHash(System.Text.Encoding.ASCII.GetBytes(toHash.ToString()));

                if (hash[0] == 0 && hash[1] == 0 && hash[2] <= 0x0F)
                {
                    int pos = hash[2] & 0x0f;
                    if (pwLeftRight.Length < 8)
                    {
                        pwLeftRight.Append(pos.ToString("X2")[1]);
                    }

                    if (pos < 8)
                    {
                        if (!pwPosDetect.ContainsKey(pos))
                        {
                            pwPosDetect.Add(pos, ((hash[3] & 0xf0) >> 4).ToString("X"));
                        }
                    }
                }
                index++;
            }

            string[] result = new string[2];
            result[0] = pwLeftRight.ToString();
            result[1] = pwPosDetect[0] + pwPosDetect[1] + pwPosDetect[2] + pwPosDetect[3] + pwPosDetect[4] + pwPosDetect[5] + pwPosDetect[6] + pwPosDetect[7];
            return result;
        }

        static void Main(string[] args)
        {
            List<string> input = InputLoader.LoadByLines("input.txt");
            string[] results = GeneratePassword(input[0]);
            Console.WriteLine("Door password simple: {0}", results[0]);
            Console.WriteLine("Door password enhanced: {0}", results[1]);
            Console.ReadLine();
        }
    }
}
