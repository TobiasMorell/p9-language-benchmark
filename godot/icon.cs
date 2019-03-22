using Godot;
using System;
using System.IO;
using System.Collections.Generic;

public class icon : Sprite
{
    // Member variables here, example:
    // private int a = 2;
    // private string b = "textvar";

    public override void _Ready()
    {
        // Called every time the node is added to the scene.
        // Initialization here
        
    }
    
    static double MsToNs(long ms) => ms * 1000000D;


    public override void _Process(float delta)
    {
        if (Input.IsKeyPressed((int) KeyList.Space))
        {
            Console.WriteLine("TEST STARTED");
            Benchmark.OpenLogFile("Godot C# (release).csv");
            
            Benchmark.Mark8("ScaleVector2D", Tests.ScaleVector2D, 5, MsToNs(250));
            Benchmark.Mark8("ScaleVector3D", Tests.ScaleVector3D, 5, MsToNs(250));
            Benchmark.Mark8("MultiplyVector2D", Tests.MultiplyVector2D, 5, MsToNs(250));
            Benchmark.Mark8("MultiplyVector3D", Tests.MultiplyVector3D, 5, MsToNs(250));
            Benchmark.Mark8("TranslateVector2D", Tests.TranslateVector2D, 5, MsToNs(250));
            Benchmark.Mark8("TranslateVector3D", Tests.TranslateVector3D, 5, MsToNs(250));
            Benchmark.Mark8("SubstractVector2D", Tests.SubstractVector2D, 5, MsToNs(250));
            Benchmark.Mark8("SubstractVector3D", Tests.SubstractVector3D, 5, MsToNs(250));
            Benchmark.Mark8("LengthVector2D", Tests.LengthVector2D, 5, MsToNs(250));
            Benchmark.Mark8("LengthVector3D", Tests.LengthVector3D, 5, MsToNs(250));
            Benchmark.Mark8("Dotproduct2D", Tests.Dotproduct2D, 5, MsToNs(250));
            Benchmark.Mark8("Dotproduct3D", Tests.Dotproduct3D, 5, MsToNs(250));
            Benchmark.Mark8("MemTest", Tests.MemTest, 5, MsToNs(250));
            Benchmark.Mark8("Prime", Tests.Primes, 5, MsToNs(250));
            Benchmark.Mark8("Sestoft", Tests.Sestoft, 5, MsToNs(250));
			
			Benchmark.CloseLogFile();
        }
        
    }
	
	public static class Benchmark
    {
		private static StreamWriter LogFile;
	
	    public static void OpenLogFile(string filename)
	    {
	
	        var curDir = System.IO.Directory.GetCurrentDirectory();
	        var fullPath = $"{curDir}/../../results/{filename}";
	
	        if(System.IO.File.Exists(fullPath))
	        {
	            System.IO.File.Delete(fullPath);
	        }
	
	        LogFile = new StreamWriter(fullPath);
	
	        LogFile.WriteLine("Test,Message,Mean,Deviation,Count");
	    }
	
	    public static void CloseLogFile()
	    {
	        LogFile.Flush();
	        LogFile.Close();
	    }
	
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
                    var started = DateTime.UtcNow;
                    for (int i = 0; i < count; i++)
                    {
                        dummy += fun(i);
                    }
                    runningTime = DateTime.UtcNow.Subtract(started).TotalMilliseconds * 1000000.0f;
                    double time = runningTime / count;
                    deltaTime += time;
                    deltaTimeSquared += time * time;
                    totalCount += count;
                }
            } while (runningTime < minTime && count < Int32.MaxValue / 2);

            double mean = deltaTime / iterations,
                standardDeviation = Math.Sqrt((deltaTimeSquared - mean * mean * iterations) / (iterations - 1));
            LogFile.WriteLine($"{msg},{mean},{standardDeviation},{count}");
			Console.WriteLine($"{msg} done!");
            return dummy / totalCount;
        }
    }
	
	public static class Tests
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
