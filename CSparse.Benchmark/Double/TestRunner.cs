﻿
namespace CSparse.Double
{
    using System;

    public static class TestRunner
    {
        public static void Run()
        {
            Console.WriteLine("Running tests (Double) ...");

            var A = Generate.Random(1000, 1000, 0.05);
            var B = Generate.RandomSymmetric(1000, 0.05, true);

            new TestUmfpack().Run(A, B);
            new TestCholmod().Run(A, B);
            new TestSPQR().Run(A, B);
            new TestSuperLU().Run(A, B);
            new TestPardiso().Run(A, B);

            new TestFeast().Run();

            Console.WriteLine();
        }
    }
}
