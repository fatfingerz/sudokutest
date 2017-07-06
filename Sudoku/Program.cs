using System;
using System.Linq;

namespace Sudoku
{
    class Program
    {
        static void Main(string[] args)
        {
            int selPuzzle = 0;
            Console.WriteLine("Enter a digit from 1 to 5 to choose a Sudoku puzzle:");
            while (true)
            {
                ConsoleKeyInfo input = Console.ReadKey();
                if (input.KeyChar == '1' || input.KeyChar == '2' || input.KeyChar == '3' ||
                   input.KeyChar == '4' || input.KeyChar == '5')
                {
                    selPuzzle = Convert.ToInt32(input.KeyChar.ToString());
                    break;
                }
                else
                    Console.WriteLine("\nPlease try again.");
            }
                        
            SolvePuzzle(selPuzzle);

            Console.WriteLine("Press any key to exit");
            Console.ReadKey();
        }

        private static void SolvePuzzle(int nPuzzle)
        {
            var board = SudokuBoard.ClassicWith3x3Boxes();
            SudokuFiles.ReadPuzzle(nPuzzle, board);
            CompleteSolve(nPuzzle, board);
        }

        private static void CompleteSolve(int selectedPuzzle, SudokuBoard board)
        {
            Console.WriteLine("\nOriginal Board:");
            board.Output();
            SudokuFiles.WriteSolution(selectedPuzzle, board);
        }
    }
}