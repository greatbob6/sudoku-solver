using System.Collections.Generic;

namespace SudokuSolver
{
    public static class PuzzleData
    {
        public static List<List<int?>> Puzzles = new List<List<int?>>
        {
            new List<int?>(81)
            {
                3, 9, 2, 5, null, null, null, 6, null,
                1, 8, 4, null, 3, null, null, 2, null,
                6, null, 5, 1, null, null, 8, null, null,
                8, null, null, 2, null, 7, null, 1, 4,
                4, 5, 3, null, null, null, 6, 7, 2,
                7, 2, null, 4, null, 3, null, null, 9,
                null, null, 6, null, null, 4, 7, null, 8,
                null, 3, null, null, 7, null, 4, 9, 1,
                null, 4, null, null, null, 9, 2, 3, 6
            },
            new List<int?>(81)
            {
                null, null, 2, null, null, null, 9, null, null,
                null, 9, null, 5, null, 4, null, 3, null,
                4, null, 5, 2, null, 9, 1, null, 8,
                null, 1, 7, null, 8, null, 3, 5, null,
                null, null, null, 4, null, 3, null, null, null,
                null, 4, 6, null, 1, null, 8, 9, null,
                5, null, 4, 9, null, 6, 7, null, 3,
                null, 7, null, 1, null, 8, null, 2, null,
                null, null, 9, null, null, null, 4, null, null
            },
            new List<int?>(81)
            {
                null, null, null, null, null, null, null, null, null,
                null, 6, null, 1, null, 3, null, 7, null,
                null, null, 2, 7, 9, 8, 1, null, null,
                null, 9, 8, null, 7, null, 6, 1, null,
                2, null, null, 9, null, 1, null, null, 3,
                null, 4, 3, null, 5, null, 2, 9, null,
                null, null, 1, 6, 3, 7, 5, null, null,
                null, 8, null, 5, null, 9, null, 2, null,
                null, null, null, null, null, null, null, null, null
            },
        };
    }
}
