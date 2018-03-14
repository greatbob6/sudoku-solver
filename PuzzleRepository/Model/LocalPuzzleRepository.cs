using PuzzleRepository.Resources;
using SolverCore.Interfaces;
using SolverCore.Model;
using System.Collections.Generic;
using System.Linq;

namespace PuzzleRepository.Model
{
    public class LocalPuzzleRepository : IPuzzleRepository
    {
        public IEnumerable<IPuzzle> GetPuzzles()
        {
            return PuzzleData.Puzzles.Select(data => new Puzzle(data));
        }
    }
}
