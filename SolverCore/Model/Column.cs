using System.Collections.Generic;

namespace SolverCore.Model
{
    public class Column : Container
    {
        public Column(int num, IList<Cell> cells) : base(num, cells)
        {
        }

        protected override List<Cell> _GetCells()
        {
            var cells = new List<Cell>(9)
        {
            _cells[Number],
            _cells[Number + (9 * 1)],
            _cells[Number + (9 * 2)],
            _cells[Number + (9 * 3)],
            _cells[Number + (9 * 4)],
            _cells[Number + (9 * 5)],
            _cells[Number + (9 * 6)],
            _cells[Number + (9 * 7)],
            _cells[Number + (9 * 8)]
        };

            foreach (var cell in cells)
            {
                cell.Column = this;
            }

            return cells;
        }
    }
}
