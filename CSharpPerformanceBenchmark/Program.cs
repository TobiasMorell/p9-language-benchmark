namespace CSharpPerformanceBenchmark
{
    class Program
    {
        static void Main(string[] args)
        {
            Benchmark.Mark8("Math test", DoMathStuff, 5, MsToNs(250));
        }

        static double MsToNs(long ms) => ms * 1000000D;

        static double DoMathStuff(int input)
        {
            var x = 1.1 * (input & 0xFF);
            return x * x * x * x * x * x * x * x * x * x * x * x * x * x * x * x * x * x * x * x;
        }
    }
}