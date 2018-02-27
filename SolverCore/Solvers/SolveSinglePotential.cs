using SolverCore.Interfaces;
using SolverCore.Model;
using System.Linq;

namespace SolverCore.Solvers
{
    public class SolveSinglePotential : ISolver
    {
        public void Solve(Puzzle puz)
        {
            foreach (var cell in puz.Cells.Where(x => x.Potentials.Count == 1))
            {
                cell.Value = cell.Potentials.First();
            }
        }
    }
}
