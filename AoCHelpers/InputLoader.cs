using System;
using System.Collections.Generic;
using System.IO;

namespace AoCHelpers
{
    public class InputLoader
    {
        public static List<string> LoadByLines(string filename)
        {
            FileStream file = new FileStream(filename, FileMode.Open);
            StreamReader stream = new StreamReader(file);
            string line;
            List<string> lines = new List<string>();

            while ((line = stream.ReadLine()) != null)
            {
                lines.Add(line);
            }

            stream.Dispose();
            file.Dispose();
            return lines;
        }
    }
}
