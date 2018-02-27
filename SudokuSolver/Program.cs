using SolverCore.Model;
using System;
using System.Collections.Generic;

namespace SudokuSolver
{
    class Program
    {
        static void Main(string[] args)
        {
            foreach (var puz in PuzzleData.Puzzles)
            {
                var p = new Puzzle(puz);
                p.Solve();
                Console.WriteLine(p.ToString());
            }
        }
    }
}
