using AocHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Day14
{
    class Candidate
    {
        public StringBuilder Hash { get; set; }
        public int TripleIndex { get; set; }
        public char Value { get; set; }
    }

    class Program
    {
        static int GenerateOTPs(string salt, int count)
        {
            List<string> otps = new List<string>();
            //Dictionary<int, int> possibleOtps = new Dictionary<int, int>();
            List<Candidate> candidates = new List<Candidate>();
            MD5 md5 = MD5.Create();

            int index = 0;
            while (otps.Count < count)
            {
                string toHash;
                toHash = salt + index;

                byte[] hash = md5.ComputeHash(System.Text.Encoding.ASCII.GetBytes(toHash.ToString()));
                StringBuilder hashString = new StringBuilder();
                for (int i = 0; i < hash.Length; i++)
                {
                    hashString.Append(hash[i].ToString("x2"));
                }

                // Find triplets
                for(int i = 0; i < hashString.Length - 2; i++)
                {
                    if ((hashString[i] == hashString[i+1]) && (hashString[i] == hashString[i+2]))
                    {
                        // found triplet
                        // search upcoming hashes for matching quintuples
                        for (int j = 1; j <= 1000; j++)
                        {
                            toHash = salt + (index + j);
                            hash = md5.ComputeHash(System.Text.Encoding.ASCII.GetBytes(toHash.ToString()));
                            StringBuilder hashString2 = new StringBuilder();
                            for (int k = 0; k < hash.Length; k++)
                            {
                                hashString2.Append(hash[k].ToString("x2"));
                            }
                            if (!hashString2.ToString().Contains(new string(hashString[i], 5)))
                            {
                                continue;
                            }

                            otps.Add(hashString.ToString());
                            break;
                        }
                        break;
                    }
                }

                index++;
            }

            return index - 1;
        }

        static void Main(string[] args)
        {
            List<string> input = InputLoader.LoadByLines("input.txt");
            Console.WriteLine("Last index for OTP 64: {0}", GenerateOTPs(input[0], 64));
            Console.ReadLine();
        }
    }
}
