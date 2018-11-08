using System;
using CryEngine;

namespace CryEngine.Game
{
	[EntityComponent(Guid="36512014-a00a-f0f8-f64d-3106e35ed420")]
	public class Benchmark : EntityComponent
	{
        private class Timer
        {
            private DateTime _started;

            public Timer()
            {
                Play();
            }

            public double Check()
            {
                return DateTime.UtcNow.Subtract(_started).Ticks * 100D;
            }

            public void Play()
            {
                _started = DateTime.UtcNow;
            }
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
            CryEngine.Log.ToFile<Benchmark>($"{msg},{mean},{standardDeviation},{count}");
            return dummy / totalCount;
        }

        /// <summary>
        /// Called at the start of the game.
        /// </summary>
        protected override void OnGameplayStart()
		{
			
		}

        private bool IsTestsStarted = false;

#if DEBUG
        private string mode = "debug";
#else
        private string mode = "release";
#endif

        /// <summary>
        /// Called once every frame when the game is running.
        /// </summary>
        /// <param name="frameTime">The time difference between this and the previous frame.</param>
        protected override void OnUpdate(float frameTime)
		{
			if(Input.KeyDown(KeyId.Space) && !IsTestsStarted)
            {
                IsTestsStarted = true;
                CryEngine.Log.FileName = "Cry C# .csv";
                CryEngine.Log.ToFile<Benchmark>($"Test,Mean,Deviation,Count");

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

                CryEngine.Log.ToFile<Benchmark>("Done! Press 'Enter' to exit");
                Console.ReadLine();
            }
		}

        static double MsToNs(long ms) => ms * 1000000D;
    }
}