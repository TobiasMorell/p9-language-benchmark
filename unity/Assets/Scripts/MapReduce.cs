using System;
using System.Linq;
using System.Numerics;

namespace CSharp_Microbenches
{
    partial class Tests
    {
        private static string[] numbers = new[] {"13.37", "42.42", "741.897", "989.981", "168.186"};
        
        public static float MapReduceLinq(int dummy)
        {
            return numbers.Select(float.Parse).Sum();
        }
        public static float MapReduceForeach(int dummy)
        {
            var sum = 0.0f;
            foreach (var number in numbers)
            {
                sum += float.Parse(number);
            }
            return sum;
        }


        enum TempType
        {
            C, F, K
        }
        struct Temp
        {
            public TempType Type;
            public float Value;

            public Temp(float value, TempType type)
            {
                Value = value;
                Type = type;
            }
        }

        private static float ToKelvin(Temp temp)
        {
            switch (temp.Type)
            {
                case TempType.C: return temp.Value + 273.15f;
                case TempType.F: return ((temp.Value - 32.0f) / 1.8f) + 273.15f;
                case TempType.K: return temp.Value;
                default: throw new Exception("oh no :'(");
            }
        }

        private static readonly Temp[] _temps =
        {
            new Temp(12.5f, TempType.C), new Temp(65.4f, TempType.C),
            new Temp(123.32f, TempType.F), new Temp(37.5f, TempType.C),
            new Temp(100.0f, TempType.F), new Temp(98.7f, TempType.F), new Temp(1.0f, TempType.K)
        };
        public static float MapReduceStruct(int dummy)
        {
            var sum = 0.0f;
            foreach (var temperature in _temps)
            {
                sum += ToKelvin(temperature);
            }
            return sum;
        }
    }
}