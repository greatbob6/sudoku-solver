using SolverCore.Interfaces;
using SolverCore.Solvers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SolverCore.Model
{
    public class Puzzle : IPuzzle
    {
        public static readonly List<int> Completed = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

        private List<Cell> _cells = new List<Cell>(81);
        private List<Quadrant> _quadrants = new List<Quadrant>(9);
        private List<Row> _rows = new List<Row>(9);
        private List<Column> _columns = new List<Column>(9);
        private List<ISolver> _solvers = new List<ISolver>();

        public IList<Cell> Cells { get => _cells; }
        public IList<Row> Rows { get => _rows; }
        public IList<Column> Columns { get => _columns; }
        public IList<Quadrant> Quadrants { get => _quadrants; }

        public Puzzle(IList<int?> startCells)
        {
            _SetupCells(startCells);
            _SetupContainers();
            _SetupSolvers();
        }

        private void _SetupCells(IList<int?> startCells)
        {
            for (int i = 0; i < 81; i++)
            {
                _cells.Add(new Cell(i, startCells[i], startCells[i].HasValue));
            }
        }

        private void _SetupContainers()
        {
            for (int i = 0; i < 9; i++)
            {
                _rows.Add(new Row(i, _cells));
                _columns.Add(new Column(i, _cells));
            }

            for (int i = 0; i < 9; i++)
            {
                _quadrants.Add(new Quadrant(i, _cells, _rows, _columns));
            }
        }

        private void _SetupSolvers()
        {
            _solvers.Add(new SolveOneEmpty());
            _solvers.Add(new SolveSinglePotential());
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat("Status: {0}", IsSolved() ? "Solved" : "Unsolved");
            sb.AppendLine();

            for (int y = 0; y < 9; y++)
            {
                sb.AppendLine("-".PadRight(36, '-'));

                for (int x = 0; x < 9; x++)
                {
                    sb.AppendFormat("| {0} ", _cells[y * 9 + x]);
                }

                sb.AppendLine("|");
            }

            sb.AppendLine("-".PadRight(36, '-'));

            return sb.ToString();
        }

        public bool IsSolved()
        {
            return _quadrants.All(x => x.IsCompleted()) && _rows.All(x => x.IsCompleted()) && _columns.All(x => x.IsCompleted());
        }

        public int NumberOfCellsUnsolved()
        {
            return _cells.Count(x => !x.Value.HasValue);
        }

        private void _UpdatePotentials()
        {
            foreach (var cell in _cells)
            {
                cell.CalculatePotentials();
            }
        }

        public void Solve()
        {
            var lastUnsolved = -1;
            var remaining = NumberOfCellsUnsolved();

            while (remaining != lastUnsolved && remaining != 0)
            {
                foreach (var solver in _solvers)
                {
                    _UpdatePotentials();

                    solver.Solve(this);
                }

                lastUnsolved = remaining;
                remaining = NumberOfCellsUnsolved();

                Console.WriteLine("Remaining: " + remaining);
            }
        }
    }
}
