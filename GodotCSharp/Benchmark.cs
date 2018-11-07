using System;

namespace CSharpPerformanceBenchmark
{
    public static class Benchmark
    {
        public static double Mark8(string msg, Func<int, double> fun,
            int iterations, double minTime)
        {
            int count = 1, totalCount = 0;
            double dummy = 0.0, runningTime = 0.0, deltaTime = 0.0, deltaTimeSquared = 0.0;
            do
            {
                count *= 2;
                deltaTime = 0.0;
                deltaTimeSquared = 0.0;
                for (int j = 0; j < iterations; j++)
                {
                    Timer t = new Timer();
                    for (int i = 0; i < count; i++)
                    {
                        dummy += fun(i);
                    }
                    runningTime = t.Check();
                    double time = runningTime / count;
                    deltaTime += time;
                    deltaTimeSquared += time * time;
                    totalCount += count;
                }
            } while (runningTime < minTime && count < Int32.MaxValue / 2);

            double mean = deltaTime / iterations,
                standardDeviation = Math.Sqrt((deltaTimeSquared - mean * mean * iterations) / (iterations - 1));
            Console.WriteLine($"{msg.PadRight(30, ' ')}\t{mean:F3}ns\t{standardDeviation:F3}ns\t\t{count}");
            return dummy / totalCount;
        }
    }
}