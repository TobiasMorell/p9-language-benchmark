using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace CSharp_Microbenches
{
    static class Tests
    {
        
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

    
        public static float ScaleVector2D(int scalar){
            var v = new Vector2(1);
            v *= scalar;
            return v.Length();
        }

        public static float ScaleVector3D(int scalar){
            var v = new Vector3(1);
            v *= scalar;
            return v.Length();
        }

        public static float MultiplyVector2D(int i){
            var v1 = new Vector2(1);
            var v2 = new Vector2(i);
            v1 *= v2;
            return v1.Length();
        }

        public static float MultiplyVector3D(int i){
            var v1 = new Vector3(1);
            var v2 = new Vector3(i);
            v1 *= v2;
            return v1.Length();
        }

        public static float TranslateVector2D(int i)
        {
            var v1 = new Vector2(1);
            var v2 = new Vector2(i);
            var v3 = v1 + v2;
            return v3.Length();
        }

        public static float TranslateVector3D(int i){
            var v1 = new Vector3(1);
            var v2 = new Vector3(i);
            var v3 = v1 + v2;
            return v3.Length();
        }

        public static float SubtractVector2D(int i){
            var v1 = new Vector2(i);
            var v2 = new Vector2(1);
            v1 -= v2;
            return v1.Length();
        }

        public static float SubtractVector3D(int i){
            var v1 = new Vector2(i);
            var v2 = new Vector2(1);
            v1 -= v2;
            return v1.Length();
        }

        public static float LengthVector2D(int i){
            var v1 = new Vector2(i);
            return v1.Length();
        }

        public static float LengthVector3D(int i){
            var v1 = new Vector3(i);
            return v1.Length();
        }

        public static float DotProduct2D(int i){
            var v1 = new Vector2(1);
            var v2 = new Vector2(i);
            return Vector2.Dot(v1, v2);
        }

        public static float DotProduct3D(int i){
            var v1 = new Vector3(1);
            var v2 = new Vector3(i);
            return Vector3.Dot(v1, v2);
        }
        
        
        public static float Primes(int number)
        {
            var max = 100;
            
            var a = new BitArray(max + 1, true);
            var lastp = (int) Math.Sqrt(max);
            
            
            for (var p = 2; p < lastp + 1; p++)
            {
                if (!a[p]) continue;
                for (var pm = p * 2; pm < max - 1; pm += p)
                {
                    a[pm] = false;
                }
            }

            var primes = new List<int>();
            for (var i = 2; i < max - 1; i++)
            {
                if (a[i])
                    primes.Add(i);
            }

            return primes.Last();
        }

        
        public static float Sestoft(int input)
        {
            var x = 1.1f * (input & 0xFF);
            return x * x * x * x * x * x * x * x * x * x * x * x * x * x * x * x * x * x * x * x;
        }
    }
}