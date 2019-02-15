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
            public Elf Next { get; set; }
            public Elf Prev { get; set; }
        }

        static int StealingPart1(int maxElves)
        {
            Elf root = new Elf { Seat = 1, Presents = 1 };
            Elf elf = root;
            Elf target = null;

            for (int i = 1; i < maxElves; i++)
            {
                if (i == maxElves)
                {
                    elf.Next = root;
                }
                else
                {
                    elf.Next = new Elf { Seat = i + 1, Presents = 1, Prev = elf };
                }
                elf = elf.Next;
                if (i == 1)
                {
                    target = elf;
                }
            }
            elf.Next = root;
            root.Prev = elf;
            elf = root;

            while(elf.Next != elf)
            {
                elf.Presents += target.Presents;

                target.Prev.Next = target.Next;
                target.Next.Prev = target.Prev;
                target = target.Next.Next;

                elf = elf.Next;
            }
            
            return elf.Seat;
        }

        static int StealingPart2(int maxElves)
        {
            Elf root = new Elf { Seat = 1, Presents = 1 };
            Elf elf = root;
            Elf target = null;
            int remaining = maxElves;

            for (int i = 1; i < maxElves; i++)
            {
                if (i == maxElves)
                {
                    elf.Next = root;
                }
                else
                {
                    elf.Next = new Elf { Seat = i + 1, Presents = 1, Prev = elf };
                }
                elf = elf.Next;
                if (i == maxElves / 2)
                {
                    target = elf;
                }
            }
            elf.Next = root;
            root.Prev = elf;
            elf = root;

            while (elf.Next != elf)
            {
                elf.Presents += target.Presents;

                target.Prev.Next = target.Next;
                target.Next.Prev = target.Prev;
                if ((remaining % 2) == 1)
                {
                    target = target.Next.Next;
                }
                else
                {
                    target = target.Next;
                }
                remaining--;

                elf = elf.Next;
            }

            return elf.Seat;
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
