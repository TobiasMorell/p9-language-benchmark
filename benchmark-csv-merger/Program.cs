using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;

namespace benchmark_csv_merger
{
    class Program
    {
        static void Main(string[] args)
        {
            const string resultDirectory = "../results";
            var files = Directory.EnumerateFiles(resultDirectory, "*.csv", SearchOption.AllDirectories);

            var scores = files.Select(ParseBenchmarkScore).OrderBy(t => t.Item1);
            
            string[] testNames = {
                "ScaleVector2D",
                "ScaleVector3D",
                "MultiplyVector2D",
                "MultiplyVector3D",
                "TranslateVector2D",
                "TranslateVector3D",
                "SubstractVector2D",
                "SubstractVector3D",
                "LengthVector2D",
                "LengthVector3D",
                "Dotproduct2D",
                "Dotproduct3D",
                "MemTest",
                "Prime",
                "Sestoft"
            };
            
            var numberOfTests = testNames.Length;
            var sb = new StringBuilder(",");
            sb.AppendLine(string.Join(", ", scores.Select(s => s.Item1)));

            for (var i = 0; i < numberOfTests; i++)
            {
                sb.Append(testNames[i]);
                sb.Append(", ");
                sb.Append(string.Join(", ", scores.Select(s => s.Item2[i])));
                sb.AppendLine();
            }
            
            File.WriteAllText(Path.Combine(resultDirectory, "..", "AggregatedResults.csv"), sb.ToString());
        }

        // CryEngine C# (Debug)
        // CryEngine C# (Release)
        // CryEngine C++ (Debug)
        
        static (string, List<string>) ParseBenchmarkScore(string csvFilePath)
        {
            var benchmarkEnvironment = Path.GetFileNameWithoutExtension(csvFilePath);
            var csvContent = File.ReadAllText(csvFilePath);

            var lines = csvContent.Split(new[] {'\n'}, StringSplitOptions.RemoveEmptyEntries);
            var labels = lines.FirstOrDefault().Split(new[] {',', '\r'}, StringSplitOptions.RemoveEmptyEntries);
            var results = new List<string>();
            foreach (var line in lines.Skip(1))
            {
                var values = line.Split(new[] {',', '\r'}, StringSplitOptions.RemoveEmptyEntries);
                var dict = Enumerable.Range(0, values.Length).ToDictionary(i => labels[i], i => values[i]);
                results.Add(dict["Mean"]);
            }

            return (benchmarkEnvironment, results);
        } 
    }
}