using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day19
{
    class Program
    {
        class Elf
        {
            public int Seat { get; set; }
            public int Presents { get; set; }
        }

        static int StealingPart1(int maxElves)
        {
            List<Elf> elves = new List<Elf>();
            int lastElf = 0;
            bool allPresentsGathered = false;
            bool couldSteal;

            for (int i = 0; i < maxElves; i++)
            {
                elves.Add(new Elf { Seat = i + 1, Presents = 1 });
            }

            while (!allPresentsGathered)
            {
                for (int i = 0; i < maxElves; i++)
                {
                    if (elves[i].Presents > 0)
                    {
                        couldSteal = false;
                        for (int j = i + 1; j < maxElves; j++)
                        {
                            if (elves[j].Presents > 0)
                            {
                                elves[i].Presents += elves[j].Presents;
                                elves[j].Presents = 0;
                                couldSteal = true;
                                break;
                            }
                        }
                        if (!couldSteal)
                        {
                            for (int j = 0; j < i; j++)
                            {
                                if (elves[j].Presents > 0)
                                {
                                    elves[i].Presents += elves[j].Presents;
                                    elves[j].Presents = 0;
                                    couldSteal = true;
                                    break;
                                }
                            }
                        }

                        if (elves[i].Presents == maxElves)
                        {
                            allPresentsGathered = true;
                            lastElf = elves[i].Seat;
                            break;
                        }
                    }
                }
            }
            return lastElf;
        }

        static int StealingPart2(int maxElves)
        {
            List<Elf> elves = new List<Elf>();
            int lastElf = 0;
            bool allPresentsGathered = false;

            for (int i = 0; i < maxElves; i++)
            {
                elves.Add(new Elf { Seat = i + 1, Presents = 1 });
            }

            while (!allPresentsGathered)
            {
                for (int i = 0; i < elves.Count; i++)
                {
                    Elf e = elves[i];
                    int skip = elves.Count / 2;
                    int index = (i + skip) % elves.Count;
                    e.Presents += elves[index].Presents;
                    elves.RemoveAt(index);

                    if (e.Presents == maxElves)
                    {
                        allPresentsGathered = true;
                        lastElf = elves[i].Seat;
                        break;
                    }
                }
            }
            return lastElf;
        }

        static void Main(string[] args)
        {
            int nrElves = 3018458;
            Console.WriteLine("Elf with all presents: {0}", StealingPart1(nrElves));
            Console.WriteLine("Elf with all presents: {0}", StealingPart2(nrElves));
            Console.ReadLine();
        }
    }
}
