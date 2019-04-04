using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using CSharp_Microbenches;
using UnityEngine;
using Random = System.Random;

public class TestMath {
    public static double Sestoft(int i)
    {
        double d = 1.1 * (double)(i & 0xFF);
        return d * d * d * d * d * d * d * d * d * d * d * d * d * d * d * d * d * d * d * d;
    }

    public static double SestoftPow(int i)
    {
        double d = 1.1 * (double)(i & 0xFF);
        return Mathf.Pow((float) d, 20);
    }

    public static double Primes(int number)
    {
        var realNumber = 100;

        var A = new bool[realNumber + 1];
        for (int i = 2; i < realNumber + 1; i++)
        {
            A[i] = true;
        }

        for (int i = 2; i < Mathf.Sqrt(realNumber); i++)
        {
            if (A[i])
            {
                var iPow = (int)Mathf.Pow(i, 2);
                var num = 0;

                for (int j = 0; j < realNumber; j = iPow + num * i)
                {
                    A[i] = false;
                    num++;
                }
            }
        }

        var primes = new List<int>();
        for (int i = 2; i < A.Length; i++)
        {
            if (A[i])
                primes.Add(i);
        }

        return primes[primes.Count - 1] & number;
    }

    public static double MemTest(int i)
    {
        var array = new double[100000];
        return array.Length & i;
    }
    
    public static float RunInvasionPercolation(int dummy)
        {
            var res = InvasionPercolation.InvasionPercolationPriorityQueue(5, 10, dummy);
            return res.Length;
        }
        
        public static float RandomizeArray(int dummy)
        {
            const int n = 4, m = 4;
            var random = new Random();
            int[,] array = new int[n, m];
            
            for (var i=0;i<n;++i)
            for (var j=0;j<m;++j)
                array[i, j] = random.Next();

            return array[n - 1, m - 1];
        }

        public static float FibonacciRecursive(int dummy) => FibonacciRecursive(0, 1, 150);
        private static float FibonacciRecursive(int current, int next, int no)
        {
            if (no == 0) return current + next;
            return FibonacciRecursive(next, current + next, no - 1);
        }

        public static float FibonacciIterative(int dummy)
        {
            const int n = 150;
            int a = 0, b = 1, c = 0;

            for (var i = 2; i < n; i++)
            {
                c = a + b;
                a = b;
                b = a;
            }

            return c;
        }
        
        private const string DefaultGameOfLifeGrid = @"
10000
00110
00101
";
        public static float IterateGameOfLifeTimes(int dummy)
        {
            var grid = DefaultGameOfLifeGrid;
            for (int i = 0; i <= 4; i++)
            {
                grid = IterateGrid(grid);
            }

            return 0;
        }
        
        static string IterateGrid(string grid)
        {
            var lines = grid.Split(new []{'\r', '\n'}, StringSplitOptions.RemoveEmptyEntries);
            var width = lines.FirstOrDefault().Length;
            var height = lines.Count();

            int ComputeNeighbours(int x, int y)
            {
                var arr = new[]
                {
                    (-1, -1), (0, -1), (1, -1),
                    (-1, 0),           (1,  0),
                    (-1, 1),  (0,  1), (1,  1)
                };

                return arr.Select(t =>
                {
                    var (dx, dy) = t;
                    int nx = x + dx, ny = y + dy;
                    if (nx >= 0 && nx < width && ny >= 0 && ny < height &&
                        lines[ny][nx] == '1')
                    {
                        return 1;
                    }
                    else
                    {
                        return 0;
                    }
                }).Sum();
            }

            char Life(int x, int y, char c)
            {
                switch ((c, ComputeNeighbours(x, y)))
                {
                    case var tuple when tuple == ('1', 2):
                        return c;
                    case var tuple when tuple.Item2 == (3):
                        return '1';
                    default:
                        return '0';
                }
            }

            var newLines = lines.Select((line, y) =>
            {
                var chars = line.ToCharArray();
                var values = chars.Select((c, x) => Life(x, y, c)).ToArray();
                return new string(values);
            });
            
            return string.Join("\r\n", newLines);
        }
    
}
