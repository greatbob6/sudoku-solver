using System.Collections.Generic;
using System.Linq;

namespace SolverCore.Model
{
    public abstract class Container
    {
        protected IList<Cell> _cells;

        public int Number { get; private set; }
        public IList<Cell> MyCells { get; private set; }

        public Container(int num, IList<Cell> cells)
        {
            Number = num;
            _cells = cells;

            MyCells = _GetCells();
        }

        protected abstract List<Cell> _GetCells();

        public bool ContainsNumber(int num)
        {
            return MyCells.Any(x => x.Value == num);
        }

        public bool IsCompleted()
        {
            return MyCells
                .Where(c => c.Value.HasValue)
                .Select(c => (int)c.Value)
                .OrderBy(c => c)
                .SequenceEqual(Puzzle.Completed);
        }
    }
}
