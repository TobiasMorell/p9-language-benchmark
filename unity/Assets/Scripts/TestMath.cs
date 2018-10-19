using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestMath : MonoBehaviour {
    public double Sestoft(int i)
    {
        double d = 1.1 * (double)(i & 0xFF);
        return d * d * d * d * d * d * d * d * d * d * d * d * d * d * d * d * d * d * d * d;
    }

    public double SestoftPow(int i)
    {
        double d = 1.1 * (double)(i & 0xFF);
        return Mathf.Pow((float) d, 20);
    }

    public List<int> Primes(int number)
    {
        //Create an array of all true
        var A = new bool[number + 1];
        A.SetValue(true, 2, number + 1);

        for (int i = 2; i < Mathf.Sqrt(number); i++)
        {
            if(A[i])
            {
                var iPow = (int) Mathf.Pow(i, 2);
                var num = 0;

                for (int j = 0; j < number; j = iPow + num * i)
                {
                    A[i] = false;
                    num++;
                }
            }
        }

        var primes = new List<int>();
        for (int i = 0; i < A.Length; i++)
        {
            if (A[i])
                primes.Add(i);
        }

        return primes;
    }
}
