using Core.Katas.SudokuSolver;
using NUnit.Framework;

namespace Tests.Katas
{
    internal class SudokuSolverTests
    {
        [Test]
        [Category("Playground")]
        [Category("Dummy")]
        [Category("Transversal")]
        public void SudokuSolver_solves_sudoku()
        {
            var solution = new SudokuGrid(new[,]
            {
                {4,1,5,6,3,8,9,7,2 },
                {3,6,2,4,7,9,1,8,5 },
                {7,8,9,2,1,5,3,6,4 },
                {9,2,6,3,4,1,7,5,8 },
                {1,3,8,7,5,6,4,2,9 },
                {5,7,4,9,8,2,6,3,1 },
                {2,5,7,1,6,4,8,9,3 },
                {8,4,3,5,9,7,2,1,6 },
                {6,9,1,8,2,3,5,4,7 }
            });

            var easy = new SudokuGrid(new[,]
            {
                {0,1,5,6,3,8,9,7,0 },
                {3,0,2,4,7,9,1,0,5 },
                {7,8,0,2,1,5,0,6,4 },
                {9,2,6,0,4,0,7,5,8 },
                {1,3,8,7,0,6,4,2,9 },
                {5,7,4,0,8,0,6,3,1 },
                {2,5,0,1,6,4,0,9,3 },
                {8,0,3,5,9,7,2,0,6 },
                {0,9,1,8,2,3,5,4,0 }
            });

            var grid = new SudokuGrid(new[,]
            {
                {0,1,5,6,3,8,9,7,2 },
                {3,6,2,4,7,9,1,8,5 },
                {7,8,9,2,1,5,3,6,4 },
                {9,2,6,3,4,1,7,5,8 },
                {1,3,8,7,5,6,4,2,9 },
                {5,7,4,9,8,2,6,3,1 },
                {2,5,7,1,6,4,8,9,3 },
                {8,4,3,5,9,7,2,1,6 },
                {6,9,1,8,2,3,5,4,7 }
            });

            grid.SolveCell(0, 0);

            Assert.That(grid.Equals(solution), Is.True);

            easy.Solve();

            Assert.That(easy.ToString(), Is.EqualTo(solution.ToString()));

            Assert.That(easy.Equals(solution), Is.True);
        }
    }
}