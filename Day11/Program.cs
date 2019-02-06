using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day11
{
    class Program
    {
        static void Main(string[] args)
        {
            int moveCount = 0;
            int[] floorTest = { 0, 4, 5, 1, 0 }; // replace 4 with 8 for second part
            int totalPieces = floorTest.Sum();
            int elevatorPieces = Math.Min(floorTest[1], 2);
            floorTest[1] -= elevatorPieces;
            int currentFloor = 1;
            while (floorTest[4] + 1 != totalPieces)
            {
                // go down
                while (elevatorPieces < 2 && currentFloor > 1)
                {
                    currentFloor--;
                    int piecesTaken = Math.Min(floorTest[currentFloor], 2 - elevatorPieces);
                    if (piecesTaken > 0)
                    {
                        elevatorPieces += piecesTaken;
                        floorTest[currentFloor] -= piecesTaken;
                    }
                    moveCount++;
                }
                // go up
                while (currentFloor < 4)
                {
                    currentFloor++;
                    int piecesTaken = Math.Min(floorTest[currentFloor], 2 - elevatorPieces);
                    if (piecesTaken > 0)
                    {
                        elevatorPieces += piecesTaken;
                        floorTest[currentFloor] -= piecesTaken;
                    }
                    moveCount++;
                }

                floorTest[4] += 1;
                elevatorPieces--;
            }

            Console.WriteLine($"Minimum number of moves is {moveCount}");
            Console.ReadLine();
        }
    }
}
