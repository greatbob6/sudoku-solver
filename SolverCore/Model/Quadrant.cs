using System;
using System.Collections.Generic;
using System.Text;

namespace SolverCore.Model
{
    public class Quadrant : Container
    {
        private IList<Row> _myRows;
        private IList<Column> _myColumns;

        public Quadrant(int num, IList<Cell> cells, IList<Row> rows, IList<Column> cols) : base(num, cells)
        {
            int firstrow = (num / 3) * 3;

            _myRows = new List<Row>(3)
        {
            rows[firstrow], rows[firstrow + 1], rows[firstrow + 2]
        };

            int firstcol = (num % 3) * 3;

            _myColumns = new List<Column>(3)
        {
            cols[firstcol], cols[firstcol + 1], cols[firstcol + 2]
        };
        }

        protected override List<Cell> _GetCells()
        {
            var startidx = 27 * (Number / 3) + 3 * (Number % 3);

            var cells = new List<Cell>(9)
        {
            _cells[startidx], _cells[startidx + 1], _cells[startidx + 2],
            _cells[startidx + 9], _cells[startidx + 10], _cells[startidx + 11],
            _cells[startidx + 18], _cells[startidx + 19], _cells[startidx + 20],
        };

            foreach (var cell in cells)
            {
                cell.Quadrant = this;
            }

            return cells;
        }
    }
}
