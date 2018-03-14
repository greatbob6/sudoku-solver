using System.Collections.Generic;

namespace SolverCore.Interfaces
{
    public interface IPuzzleRepository
    {
        IEnumerable<IPuzzle> GetPuzzles();
    }
}
