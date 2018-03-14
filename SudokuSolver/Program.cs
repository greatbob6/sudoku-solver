using Microsoft.Extensions.DependencyInjection;
using PuzzleRepository.Model;
using SolverCore.Interfaces;
using System;

namespace SudokuSolver
{
    class Program
    {
        static void Main(string[] args)
        {
            var serviceProvider = new ServiceCollection()
                .AddScoped<IPuzzleRepository, LocalPuzzleRepository>()
                .BuildServiceProvider();

            var puzzleRepo = serviceProvider.GetService<IPuzzleRepository>();

            var puzzles = puzzleRepo.GetPuzzles();

            foreach (var puz in puzzles)
            {
                puz.Solve();
                Console.WriteLine(puz.ToString());
            }
        }
    }
}
