using SolverCore.Interfaces;
using SolverCore.Model;
using System.Collections.Generic;
using System.Linq;

namespace SolverCore.Solvers
{
    public class SolveOneEmpty : ISolver
    {
        public void Solve(Puzzle puz)
        {
            List<Container> containers = new List<Container>();
            containers.AddRange(puz.Quadrants);
            containers.AddRange(puz.Rows);
            containers.AddRange(puz.Columns);

            foreach (var con in containers)
            {
                var unfilled = con.MyCells.Where(x => x.Value == null);

                if (unfilled.Count() == 1)
                {
                    unfilled.First().Value = Puzzle.Completed.Except(con.MyCells.Where(x => x.Value.HasValue).Select(x => x.Value.Value)).First();
                }
            }
        }
    }
}
