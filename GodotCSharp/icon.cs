using Godot;
using System;
using CSharpPerformanceBenchmark;

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
            Console.WriteLine($"{"name".PadRight(30, ' ')}\tmean\t\tdeviation\tcount");
            
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
        }
        
    }
}
