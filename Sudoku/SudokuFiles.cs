using System;
using System.Linq;
using System.IO;

namespace Sudoku
{
    class SudokuFiles
    {
        public static void ReadPuzzle(int selectedPuzzle, SudokuBoard board)
        {
            string fileName = "";
            try
            {
                fileName = Directory.GetCurrentDirectory() + "\\Puzzles\\puzzle" + selectedPuzzle + ".txt";
                string[] lines = File.ReadAllLines(fileName);
                foreach(string line in lines)
                {
                    board.AddRow(line);
                }
            }
            catch(Exception e)
            {
                Console.Write("There was a problem reading the puzzle file.\n{0}", e.Message);
            }
        }

        public static void WriteSolution(int selectedPuzzle, SudokuBoard board)
        {
            string fileName = "";
            string sSolution = "";
            try
            {
                sSolution = "Original:" + Environment.NewLine + Environment.NewLine + board.Output() +
                    Environment.NewLine + Environment.NewLine + "Solution:" + Environment.NewLine + 
                    Environment.NewLine;
                fileName = Directory.GetCurrentDirectory() + "\\Puzzles\\puzzle" + selectedPuzzle + ".sln.txt";
                var solutions = board.Solve().ToList();
                Console.WriteLine("Solution(s) found: " + solutions.Count);
                var i = 1;
                foreach (var solution in solutions)
                {
                    Console.WriteLine("----------------");
                    Console.WriteLine("Solution " + i++.ToString() + " of " + solutions.Count + ":");
                    sSolution += solution.Output();
                    File.WriteAllText(fileName, sSolution);
                }
            }
            catch(Exception e)
            {
                Console.Write("There was a problem writing the solution file.\n{0}", e.Message);
            }
        }
    }
}
