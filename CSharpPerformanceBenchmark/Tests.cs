using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace CSharpPerformanceBenchmark
{
    static class Tests
    {
        public static double ScaleVector2D(int scalar){
            var v = new Vector2(1);
            v *= scalar;
            return v.Length();
        }

        public static double ScaleVector3D(int scalar){
            var v = new Vector3(1);
            v *= scalar;
            return v.Length();
        }

        public static double MultiplyVector2D(int i){
            var v1 = new Vector2(1);
            var v2 = new Vector2(i);
            v1 *= v2;
            return v1.Length();
        }

        public static double MultiplyVector3D(int i){
            var v1 = new Vector3(1);
            var v2 = new Vector3(i);
            v1 *= v2;
            return v1.Length();
        }

        public static double TranslateVector2D(int i)
        {
            var v1 = new Vector2(1);
            var v2 = new Vector2(i);
            var v3 = v1 + v2;
            return v3.Length();
        }

        public static double TranslateVector3D(int i){
            var v1 = new Vector3(1);
            var v2 = new Vector3(i);
            var v3 = v1 + v2;
            return v3.Length();
        }

        public static double SubstractVector2D(int i){
            var v1 = new Vector2(i);
            var v2 = new Vector2(1);
            v1 -= v2;
            return v1.Length();
        }

        public static double SubstractVector3D(int i){
            var v1 = new Vector2(i);
            var v2 = new Vector2(1);
            v1 -= v2;
            return v1.Length();
        }

        public static double LengthVector2D(int i){
            var v1 = new Vector2(i);
            return v1.Length();
        }

        public static double LengthVector3D(int i){
            var v1 = new Vector3(i);
            return v1.Length();
        }

        public static double Dotproduct2D(int i){
            var v1 = new Vector2(1);
            var v2 = new Vector2(i);
            return Vector2.Dot(v1, v2);
        }

        public static double Dotproduct3D(int i){
            var v1 = new Vector3(1);
            var v2 = new Vector3(i);
            return Vector3.Dot(v1, v2);
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