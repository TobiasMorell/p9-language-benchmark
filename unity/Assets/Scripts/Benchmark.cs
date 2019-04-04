using System;
using System.Collections;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.Threading;
using CSharp_Microbenches;
using UnityEngine;
using UnityEngine.UI;

public class Benchmark : MonoBehaviour {
    private static StreamWriter LogFile;
    private static string mode;


    private static Tuple<string, double, double, int, double> Mark8(string msg, Func<int, float> fun,
        int iterations, double minTime)
    {
        int count = 1, totalCount = 0;
        double dummy = 0.0, runningTime = 0.0, deltaTime = 0.0, deltaTimeSquared = 0.0;
        do
        {
            count *= 2;
            deltaTime = 0.0;
            deltaTimeSquared = 0.0;
            for (var j = 0; j < iterations; j++)
            {
                var started = DateTime.UtcNow;
                for (var i = 0; i < count; i++)
                {
                    dummy += fun(i);
                }
                runningTime = DateTime.UtcNow.Subtract(started).TotalMilliseconds * 1000000.0f;
                var time = runningTime / count;
                deltaTime += time;
                deltaTimeSquared += time * time;
                totalCount += count;
            }
        } while (runningTime < minTime && count < int.MaxValue / 2);
    
        var mean = deltaTime / iterations;
        var standardDeviation = Math.Sqrt(Math.Abs(deltaTimeSquared - mean * mean * iterations) / (iterations - 1));
        Console.WriteLine($"{msg},{mean},{standardDeviation},{count}");
        return new Tuple<string, double, double, int, double>(msg, mean, standardDeviation, count, dummy);
    }


    bool testRun = false;
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && !testRun)
        {
            testRun = true;
            var iterations = 5;
            var minTime = 250 * 1000000.0;
            
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
            Thread.CurrentThread.CurrentUICulture = CultureInfo.InvariantCulture;
            
            var results = new List<Tuple<string, double, double, int, double>>
            {
                Benchmark.Mark8("Sestoft Multiply", Tests.Sestoft, iterations, minTime),
                Benchmark.Mark8("Primes", Tests.Primes, iterations, minTime),
                Benchmark.Mark8("RandomizeArray", Tests.RandomizeArray, iterations, minTime),
                Benchmark.Mark8("GameOfLife", Tests.IterateGameOfLifeTimes, iterations, minTime),
                Benchmark.Mark8("InvasionPercolation", Tests.RunInvasionPercolation, iterations, minTime),
                Benchmark.Mark8("FibonacciRecursive", Tests.FibonacciRecursive, iterations, minTime),
                Benchmark.Mark8("FibonacciIterative", Tests.FibonacciIterative, iterations, minTime),
                
                Benchmark.Mark8("ScaleVector2D", Tests.ScaleVector2D, iterations, minTime),
                Benchmark.Mark8("ScaleVector3D", Tests.ScaleVector3D, iterations, minTime),
                Benchmark.Mark8("MultiplyVector2D", Tests.MultiplyVector2D, iterations, minTime),
                Benchmark.Mark8("MultiplyVector3D", Tests.MultiplyVector3D, iterations, minTime),
                Benchmark.Mark8("TranslateVector2D", Tests.TranslateVector2D, iterations, minTime),
                Benchmark.Mark8("TranslateVector3D", Tests.TranslateVector3D, iterations, minTime),
                Benchmark.Mark8("SubtractVector2D", Tests.SubtractVector2D, iterations, minTime),
                Benchmark.Mark8("SubtractVector3D", Tests.SubtractVector3D, iterations, minTime),
                Benchmark.Mark8("LengthVector2D", Tests.LengthVector2D, iterations, minTime),
                Benchmark.Mark8("LengthVector3D", Tests.LengthVector3D, iterations, minTime),
                Benchmark.Mark8("DotProductVector2D", Tests.DotProduct2D, iterations, minTime),
                Benchmark.Mark8("DotProductVector3D", Tests.DotProduct3D, iterations, minTime)
            };



            File.WriteAllText("results.csv",
                $"Test,Mean,Deviation,Count\n{string.Join("\n", results.Select(t => $"{t.Item1},{t.Item2:F3},{t.Item3:F3},{t.Item4}"))}");
                
            Debug.Log(results.Count);
        }
    }

    static double MsToNs(long ms) => ms * 1000000D;
}
