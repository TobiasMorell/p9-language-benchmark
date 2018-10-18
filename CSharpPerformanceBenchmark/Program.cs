using System;
using System.Collections.Generic;

namespace CSharpPerformanceBenchmark
{
    class Program
    {
        static void Main(string[] args)
        {
            //Benchmark.Mark8("Math test", DoMathStuff, 5, MsToNs(1000));
            Benchmark.Mark8("Prime", Primes, 5, MsToNs(1000));
        }

        static double MsToNs(long ms) => ms * 1000000D;

        static double DoMathStuff(int input)
        {
            var x = 1.1 * (input & 0xFF);
            return x * x * x * x * x * x * x * x * x * x * x * x * x * x * x * x * x * x * x * x;
        }
        
        public static double Primes(int number)
        {            
            var A = new bool[number + 1];
            for (int i = 2; i < number + 1; i++)
            {
                A[i] = true;
            }

            for (int i = 2; i < Math.Sqrt(number); i++)
            {
                if(A[i])
                {
                    var iPow = (int) Math.Pow(i, 2);
                    var num = 0;

                    for (int j = 0; j < number; j = iPow + num * i)
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

            return primes.Count;
        }
    }
}