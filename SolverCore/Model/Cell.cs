using System.Collections.Generic;

namespace SolverCore.Model
{
    public class Cell
    {
        private int? _value;

        public int? Value
        {
            get => _value;
            set
            {
                if (!_value.HasValue)
                {
                    _value = value;
                }
            }
        }

        public bool Original { get; set; }
        public int Number { get; set; }

        public Row Row { get; set; }
        public Column Column { get; set; }
        public Quadrant Quadrant { get; set; }

        public List<int> Potentials { get; set; }

        public Cell(int number, int? value, bool original)
        {
            _value = value;

            Number = number;
            Original = original;

            Potentials = new List<int>();
        }

        public override string ToString()
        {
            return Value.HasValue ? Value.Value.ToString("0") : "?";
        }

        public void CalculatePotentials()
        {
            if (!_value.HasValue)
            {
                Potentials.Clear();

                var pots = new List<int>(Puzzle.Completed);
                pots.RemoveAll(x => Row.ContainsNumber(x) || Column.ContainsNumber(x) || Quadrant.ContainsNumber(x));

                Potentials.AddRange(pots);
            }
            else
            {
                Potentials.Clear();
            }
        }
    }
}
