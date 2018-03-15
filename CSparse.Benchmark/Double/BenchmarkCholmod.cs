﻿
namespace CSparse.Double
{
    using CSparse.Benchmark;
    using CSparse.Double.Factorization;
    using CSparse.Storage;
    using System;

    class BenchmarkCholmod : Benchmark<Cholmod, double>
    {
        public BenchmarkCholmod(MatrixFileCollection collection)
            :  base(collection)
        {
        }
        
        protected override Cholmod CreateSolver(CompressedColumnStorage<double> matrix, bool symmetric)
        {
            var solver = new Cholmod((SparseMatrix)matrix);

            if (!symmetric)
            {
                throw new Exception("CHOLMOD expects symmetric matrix.");
            }

            return solver;
        }

        protected override double[] CreateTestVector(int size)
        {
            return Vector.Create(size, 1.0);
        }

        protected override double ComputeError(double[] actual, double[] expected)
        {
            return Util.ComputeError(actual, expected);
        }

        private double ComputeResidual(CompressedColumnStorage<double> A, double[] x, double[] b)
        {
            return Util.ComputeResidual(A, x, b);
        }
    }
}
