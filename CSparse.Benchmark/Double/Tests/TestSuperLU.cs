﻿
namespace CSparse.Double.Tests
{
    using CSparse.Double.Factorization;
    using CSparse.Factorization;
    using CSparse.Interop.SuperLU;

    class TestSuperLU : Test
    {
        public TestSuperLU()
            : base("SuperLU")
        {
        }

        protected override IDisposableSolver<double> CreateSolver(SparseMatrix matrix, bool symmetric)
        {
            var solver = new SuperLU(matrix);

            if (symmetric)
            {
                var options = solver.Options;

                options.SymmetricMode = true;
                options.ColumnOrderingMethod = OrderingMethod.MinimumDegreeAtPlusA;
                options.DiagonalPivotThreshold = 0.001;
            }

            return solver;
        }
    }
}
