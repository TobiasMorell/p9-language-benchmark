using System;
using System.IO;

namespace CSharpPerformanceBenchmark
{
    public static class Benchmark
    {
		private static StreamWriter LogFile;
	
	    public static void OpenLogFile(string filename)
	    {
	
	        var curDir = Directory.GetCurrentDirectory();
	        var fullPath = $"{curDir}/../../results/{filename}";
	
	        if(File.Exists(fullPath))
	        {
	            File.Delete(fullPath);
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
            LogFile.WriteLine($"{msg},{mean},{standardDeviation},{count}");
			Console.WriteLine($"{msg} done!");
            return dummy / totalCount;
        }
    }
}