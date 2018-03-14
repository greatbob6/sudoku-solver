namespace SolverCore.Interfaces
{
    public interface IPuzzle
    {
        bool IsSolved();

        int NumberOfCellsUnsolved();

        void Solve();
    }
}
