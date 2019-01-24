using AocHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day04
{
    class Program
    {
        static string GetRoomChecksum(List<string> roomName)
        {
            StringBuilder sb = new StringBuilder();

            SortedDictionary<char, int> letterOccurance = new SortedDictionary<char, int>();

            foreach(string namePart in roomName)
            {
                foreach (char c in namePart)
                {
                    if (letterOccurance.ContainsKey(c))
                    {
                        letterOccurance[c]++;
                    }
                    else
                    {
                        letterOccurance.Add(c, 1);
                    }
                }
            }

            for (int i = 0; i < 5; i++)
            {
                int maxVal = int.MinValue;
                char key = char.MinValue;
                foreach(KeyValuePair<char, int> kvp in letterOccurance)
                {
                    if (kvp.Value > maxVal)
                    {
                        maxVal = kvp.Value;
                        key = kvp.Key;
                    }
                }
                letterOccurance.Remove(key);
                sb.Append(key);
            }

            return sb.ToString();
        }

        static string DecryptRoomName(List<string> roomName, int sectorId)
        {
            StringBuilder sb = new StringBuilder();
            int shifts = sectorId % 26;
            string lookupAlphabet = "abcdefghijklmnopqrstuvwxyz";
            
            foreach(string namePart in roomName)
            {
                foreach(char c in namePart)
                {
                    int newIdx = c - 'a';
                    newIdx += shifts;
                    newIdx %= 26;
                    sb.Append(lookupAlphabet[newIdx]);
                }
                sb.Append(' ');
            }

            return sb.ToString().Trim();
        }

        static int[] SumIdRealRooms(List<string> input)
        {
            int[] results = new int[2];
            List<string> decryptedRoomNames = new List<string>();

            foreach (string line in input)
            {
                string[] roomCode = line.Split(new char[] { '-', '[', ']' }, StringSplitOptions.RemoveEmptyEntries);
                string checksumGiven = roomCode[roomCode.Length - 1];
                int sectorId = int.Parse(roomCode[roomCode.Length - 2]);
                List<string> roomName = new List<string>(roomCode);
                roomName.RemoveAt(roomName.Count - 1);
                roomName.RemoveAt(roomName.Count - 1);
                string checksumCalculated = GetRoomChecksum(roomName);

                if (checksumGiven.Equals(checksumCalculated))
                {
                    results[0] += sectorId;
                    decryptedRoomNames.Add(DecryptRoomName(roomName, sectorId));
                    if (DecryptRoomName(roomName, sectorId).Contains("north"))
                    {
                        int k = 0;
                        k++;
                        results[1] = sectorId;
                    }
                }
            }

            return results;
        }

        static void Main(string[] args)
        {
            List<string> input = InputLoader.LoadByLines("input.txt");
            int[] results = SumIdRealRooms(input);
            Console.WriteLine("Sum real room IDs: {0}", results[0]);
            Console.WriteLine("Sector ID where North Pole Items are stored: {0}", results[1]);
            Console.ReadLine();
        }
    }
}
