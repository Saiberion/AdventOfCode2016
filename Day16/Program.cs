using AocHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day16
{
    class Program
    {
        static string DragonChecksum(string input)
        {
            string[] splitted = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            int fillLength = int.Parse(splitted[0]);
            StringBuilder sb = new StringBuilder(splitted[1]);

            // Lengthen string
            while (sb.Length < fillLength)
            {
                string a = sb.ToString();
                sb.Append("0");
                for (int i = a.Length - 1; i >= 0; i--)
                {
                    if (a[i] == '0')
                    {
                        sb.Append("1");
                    }
                    else
                    {
                        sb.Append("0");
                    }
                }
            }

            // get checksum
            string chk = sb.ToString().Remove(fillLength);
            do
            {
                StringBuilder sbChk = new StringBuilder();
                for (int i = 0; i < chk.Length - 1; i += 2)
                {
                    if (chk[i] == chk[i + 1])
                    {
                        sbChk.Append("1");
                    }
                    else
                    {
                        sbChk.Append("0");
                    }
                }
                chk = sbChk.ToString();
            } while ((chk.Length % 2) == 0);

            return chk;
        }

        static void Main(string[] args)
        {
            List<string> input = InputLoader.LoadByLines("input.txt");
            Console.WriteLine("Dragon checksum disc 1: {0}", DragonChecksum(input[0]));
            Console.WriteLine("Dragon checksum disc 2: {0}", DragonChecksum(input[1]));
            Console.ReadLine();
        }
    }
}
