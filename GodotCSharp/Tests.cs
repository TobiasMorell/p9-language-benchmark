using System;
using System.Collections.Generic;
using Godot;

namespace CSharpPerformanceBenchmark
{
    static class Tests
    {
        public static double ScaleVector2D(int scalar){
            var v = new Vector2();
            v *= scalar;
            return v.Length();
        }

        public static double ScaleVector3D(int scalar){
            var v = new Vector3();
            v *= scalar;
            return v.Length();
        }

        public static double MultiplyVector2D(int i){
            var v1 = new Vector2();
            var v2 = new Vector2();
            v1 *= v2;
            return v1.Length();
        }

        public static double MultiplyVector3D(int i){
            var v1 = new Vector3();
            var v2 = new Vector3();
            v1 *= v2;
            return v1.Length();
        }

        public static double TranslateVector2D(int i){
            var v1 = new Vector2();
            v1[0] += i;
            return v1.Length();
        }

        public static double TranslateVector3D(int i){
            var v1 = new Vector3();
            v1[0] += i;
            return v1.Length();
        }

        public static double SubstractVector2D(int i){
            var v1 = new Vector2();
            var v2 = new Vector2();
            v1 -= v2;
            return v1.Length();
        }

        public static double SubstractVector3D(int i){
            var v1 = new Vector2();
            var v2 = new Vector2();
            v1 -= v2;
            return v1.Length();
        }

        public static double LengthVector2D(int i){
            var v1 = new Vector2();
            return v1.Length();
        }

        public static double LengthVector3D(int i){
            var v1 = new Vector3();
            return v1.Length();
        }

        public static double Dotproduct2D(int i){
            var v1 = new Vector2();
            var v2 = new Vector2();
            return v1.Dot(v2);
        }

        public static double Dotproduct3D(int i){
            var v1 = new Vector3();
            var v2 = new Vector3();
            return v1.Dot(v2);
        }
        
        public static double Primes(int number)
        {
            var realNumber = 100;
            
            var A = new bool[realNumber + 1];
            for (int i = 2; i < realNumber + 1; i++)
            {
                A[i] = true;
            }

            for (int i = 2; i < Math.Sqrt(realNumber); i++)
            {
                if(A[i])
                {
                    var iPow = (int) Math.Pow(i, 2);
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

            return primes.Count & number;
        }

        public static double MemTest(int i)
        {
            var array = new double[100000];
            return array.Length + i;
        }
        
        public static double Sestoft(int input)
        {
            var x = 1.1 * (input & 0xFF);
            return x * x * x * x * x * x * x * x * x * x * x * x * x * x * x * x * x * x * x * x;
        }
    }
}